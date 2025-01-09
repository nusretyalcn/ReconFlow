using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface IUserDal: IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
    public List<Company> GetUserCompanies(int userId);
    public List<UserDto> GetAllUsers();
}