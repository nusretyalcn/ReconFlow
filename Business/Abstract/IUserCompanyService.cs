using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface IUserCompanyService
{
    IDataResult<List<UserCompany>> GetAll();
    IResult Add(UserCompany userCompany);
    IResult Delete(UserCompany userCompany);
    IResult Update(UserCompany userCompany);
    IDataResult<UserCompany> GetById(int companyId);
    IResult UpdateRange(List<UserCompany> userCompaniesToUpdate);
}