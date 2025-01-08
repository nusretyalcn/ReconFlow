using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<List<OperationClaim>> GetClaims(User user,int companyId);
    IResult Add(User user);
    IDataResult<User> GetByEmail(string email);
    IDataResult<List<User>> GetAll();
}