using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CompanyManager:ICompanyService
{
    private readonly ICompanyDal _companyDal;
    public CompanyManager(ICompanyDal companyDal)
    {
        _companyDal = companyDal;
    }

    public IDataResult<List<Company>> GetAll()
    {
        return new SuccessDataResult<List<Company>>(_companyDal.GetAll(p=>p.IsActive==true), Messages.CompaniesListed);
    }

    public IResult Add(Company company)
    {
        company.AddedDate = DateTime.Now;
        company.IsActive = true;
        _companyDal.Add(company);
        return new SuccessResult(Messages.CompanyAdded);
    }

    public IResult Delete(Company company)
    {
        _companyDal.Delete(company);
        return new SuccessResult(Messages.CompanyDeleted);
    }

    public IResult Update(Company company)
    {
        _companyDal.Update(company);
        return new SuccessResult(Messages.CompanyUpdated);
    }

    public IDataResult<Company> GetById(int companyId)
    {
        return new SuccessDataResult<Company>(_companyDal.Get(c => c.Id == companyId));
    }

    public IResult CompanyExists(Company company)
    {
        var result = _companyDal.Get(p => p.IsActive == true 
                             && p.TaxDepartment == company.TaxDepartment 
                             && p.TaxNumber == company.TaxNumber );
        
        if (result != null)
        {
            return new ErrorResult("Company already exists");
        }

        return new SuccessResult();
    }
}