using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    private readonly IUserCompanyDal _userCompanyDal;
    public CompanyManager(ICompanyDal companyDal, IUserCompanyDal userCompanyDal)
    {
        _companyDal = companyDal;
        _userCompanyDal = userCompanyDal;
    }

    public IDataResult<List<Company>> GetAll()
    {
        return new SuccessDataResult<List<Company>>(_companyDal.GetAll(p=>p.IsActive==true), Messages.CompaniesListed);
    }

    [ValidationAspect(typeof(CompanyValidator))]
    [TransactionScopeAspect]
    public IResult Add(CompanyDto companyDto)
    {
        BusinessRules.Run(IsCompanyExists(companyDto.Company));

        _companyDal.Add(companyDto.Company);
        UserCompany userCompany = new UserCompany()
        {
            UserId = companyDto.UserId,
            CompanyId = companyDto.Company.Id,
            AddedDate = DateTime.Now,
            IsActive = true
        };
        _userCompanyDal.Add(userCompany);
        return new SuccessResult(Messages.CompanyAdded);
    }

    [TransactionScopeAspect]
    public IResult Delete(Company company)
    {
        _companyDal.Delete(company);
        return new SuccessResult(Messages.CompanyDeleted);
    }

    [ValidationAspect(typeof(CompanyValidator))]
    [TransactionScopeAspect]
    public IResult Update(Company company)
    {
        _companyDal.Update(company);
        return new SuccessResult(Messages.CompanyUpdated);
    }

    public IDataResult<Company> GetById(int companyId)
    {
        return new SuccessDataResult<Company>(_companyDal.Get(c => c.Id == companyId));
    }
    
    private IResult IsCompanyExists(Company company)
    {
        var result = _companyDal.GetAll(p => p.IsActive == true 
                             && p.TaxDepartment == company.TaxDepartment 
                             && p.TaxNumber == company.TaxNumber ).Any();
        
        if (result)
        {
            return new ErrorResult("Company already exists");
        }

        return new SuccessResult();
    }
}