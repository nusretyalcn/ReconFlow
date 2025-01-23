using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework;

public class EfCurrentDal:EfEntityRepositoryBase<Current,EfDbContext>,ICurrentDal
{
    
    public List<CurrentDetailDto> GetCurrentDetails()
    {
        using (var context = new EfDbContext())
        {
            var result = from current in context.Currents
                join currentAccount in context.CurrentAccounts 
                    on current.Id equals currentAccount.CurrentId
                join company in context.Companies 
                    on current.CompanyId equals  company.Id
                where current.IsActive == true
                      && company.IsActive == true && currentAccount.IsActive == true
                select new CurrentDetailDto()
                {
                    CompanyName = company.Name,
                    CurrentName = current.Name,
                    CurrentType = current.CurrentType,
                    CurrentCode = current.Code,
                    CurrentAccountCode = currentAccount.Code,
                    CurrentAccountCredit = currentAccount.CurrentCredit,
                    CurrentAccountDebit = currentAccount.CurrentDebit,
                    AccountAddedDate = currentAccount.AddedDate,
                    CurrentAddress = current.Address,
                    CurrentTaxNumber = current.TaxNumber,
                    CurrentAuthorized = current.Authorized,
                };
            return result.ToList();
        }
    }
}