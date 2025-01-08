using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICompanyService
{
    IDataResult<List<Company>> GetAll();
    IResult Add(Company company);
    IResult Delete(Company company);
    IResult Update(Company company);
    IDataResult<Company> GetById(int companyId);
    IResult CompanyExists(Company company);
}