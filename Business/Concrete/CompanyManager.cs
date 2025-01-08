using Business.Abstract;
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
    public List<Company> GetAll()
    {
        return _companyDal.GetAll();
    }
}