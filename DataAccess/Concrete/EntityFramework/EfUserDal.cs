using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, EfDbContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new EfDbContext())
        {
            var result = from operationClaim in context.OperationClaims
                join userOperationClaim in context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id,
                    Name = operationClaim.Name,
                };
            return result.ToList();
        }
    }

    public List<Company> GetUserCompanies(int userId)
    {
        using (var context = new EfDbContext())
        {
            var result = from company in context.Companies
                join userCompany in context.UserCompanies
                    on company.Id equals userCompany.CompanyId
                where userCompany.UserId == userId
                      && userCompany.IsActive == true
                      && company.IsActive == true
                select new Company()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Address = company.Address,
                    TaxDepartment = company.TaxDepartment,
                    TaxNumber = company.TaxNumber,
                    IdentityNumber = company.IdentityNumber
                };
            return result.ToList();
        }
    }

    public List<UserDto> GetAllUsers()
    {
        using (EfDbContext context = new EfDbContext())
        {
            var result = from user in context.Users
                select new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    AddedDate = user.AddedDate,
                    IsActive = user.IsActive,
                    IsEmailConfirm = user.IsEmailConfirm,
                    MailConfirmDate = user.MailConfirmDate,
                    MailConfirmValue = user.MailConfirmValue
                };
            return result.ToList();
        }
    }
}