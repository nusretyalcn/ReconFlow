using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCutingConserns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class CompanyManager:ICompanyService
{
    private readonly ICompanyDal _companyDal;
    private readonly IUserCompanyService _userCompanyService;
    public CompanyManager(ICompanyDal companyDal, IUserCompanyService userCompanService)
    {
        _companyDal = companyDal;
        _userCompanyService = userCompanService;
    }

    [CacheAspect]
    public IDataResult<List<Company>> GetAll()
    {
        return new SuccessDataResult<List<Company>>(_companyDal.GetAll(p=>p.IsActive==true), Messages.CompaniesListed);
    }

    [ValidationAspect(typeof(CompanyDtoValidator))]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ICompanyService.Get")]
    public IResult Add(CompanyDto companyDto)
    {
        IResult result = BusinessRules.Run(IsCompanyExists(companyDto.Companies));
        if (result != null)
        {
            return result;
        }
        foreach (var company in companyDto.Companies)
        {
            _companyDal.Add(company);
            UserCompany userCompany = new UserCompany()
            {
                UserId = companyDto.UserId,
                CompanyId = company.Id,
                AddedDate = DateTime.Now,
                IsActive = true
            };
            _userCompanyService.Add(userCompany);
        }

        return new SuccessResult(Messages.CompanyAdded);
    }

    [TransactionScopeAspect]
    [CacheRemoveAspect("ICompanyService.Get")]
    public IResult Delete(CompanyDto companyDto)
    {
        var companyIds = companyDto.Companies.Select(c => c.Id).ToList();
        var userCompaniesToUpdate = _userCompanyService.GetAll().Data.Where(p => companyIds.Contains(p.Id)).ToList();
        var companiesToUpdate = _companyDal.GetAll(p=>companyIds.Contains(p.Id) && p.IsActive == true);

        foreach (var company in companiesToUpdate)
        {
            company.IsActive = false;
        }

        foreach (var userCompany in userCompaniesToUpdate)
        {
            userCompany.IsActive = false;
        }
        
        _userCompanyService.UpdateRange(userCompaniesToUpdate);
        _companyDal.UpdateRange(companiesToUpdate);
        
        return new SuccessResult(Messages.CompanyDeleted);
    }

    [ValidationAspect(typeof(CompanyValidator))]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ICompanyService.Get")]
    public IResult Update(Company company)
    {
        _companyDal.Update(company);
        return new SuccessResult(Messages.CompanyUpdated);
    }

    [CacheAspect]
    public IDataResult<Company> GetById(int companyId)
    {
        return new SuccessDataResult<Company>(_companyDal.Get(c => c.Id == companyId));
    }
    
    private IResult IsCompanyExists(List<Company> companies)
    {
        foreach (var company in companies)
        {
            var result = _companyDal.GetAll(p => p.IsActive == true &&
                                                 p.Name == company.Name
                                                 && p.TaxNumber == company.TaxNumber).Any();

            if (result)
            {
                return new ErrorResult("Company already exists");   
            }
        }
        return new SuccessResult();

    }
}