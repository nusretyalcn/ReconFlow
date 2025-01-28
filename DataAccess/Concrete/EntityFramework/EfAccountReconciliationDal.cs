using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework;

public class EfAccountReconciliationDal : EfEntityRepositoryBase<AccountReconciliation, EfDbContext>,
    IAccountReconciliationDal
{
    public List<AccountReconciliation> GetAccountReconciliationByCompanyId(int companyId)
    {
        using (var context = new EfDbContext())
        {
            var result = from accountReconciliation in context.AccountReconciliations
                join currentAccount in context.CurrentAccounts
                    on accountReconciliation.CurrentAccountId equals currentAccount.Id
                join current in context.Currents on currentAccount.CurrentId equals current.Id
                where current.CompanyId == companyId
                      && current.IsActive == true
                      && currentAccount.IsActive == true
                      && accountReconciliation.IsActive == true
                select new AccountReconciliation
                {
                    Id = accountReconciliation.Id,
                    CurrentAccountId = accountReconciliation.CurrentAccountId,
                    ReconciliationNo = accountReconciliation.ReconciliationNo,
                    TotalDebit = accountReconciliation.TotalDebit,
                    TotalCredit = accountReconciliation.TotalCredit,
                    Balance = accountReconciliation.Balance,
                    StartingDate = accountReconciliation.StartingDate,
                    EndingDate = accountReconciliation.EndingDate,
                    IsActive = accountReconciliation.IsActive,
                    IsSendEmail = accountReconciliation.IsSendEmail,
                    SendEmailDate = accountReconciliation.SendEmailDate,
                    IsResultSucceed = accountReconciliation.IsResultSucceed,
                    ResultDate = accountReconciliation.ResultDate,
                    ResultNote = accountReconciliation.ResultNote,
                    AddedDate = accountReconciliation.AddedDate,
                };
            return result.ToList();
        }
    }

    public List<AccountReconciliationDto> GetAccountReconciliationDetail(int id)
    {
        using (var context = new EfDbContext())
        {
            var result = from accountReconciliation in context.AccountReconciliations
                join accountReconciliationDetail in context.AccountReconciliationDetails
                    on accountReconciliation.Id equals accountReconciliationDetail.AccountReconciliationId
                where accountReconciliationDetail.AccountReconciliationId == id
                    && accountReconciliation.IsActive == true
                select new AccountReconciliationDto()
                {
                    Id = accountReconciliation.Id,
                    CurrentAccountId = accountReconciliation.CurrentAccountId,
                    ReconciliationNo = accountReconciliation.ReconciliationNo,
                    TotalDebit = accountReconciliation.TotalDebit,
                    TotalCredit = accountReconciliation.TotalCredit,
                    Balance = accountReconciliation.Balance,
                    StartingDate = accountReconciliation.StartingDate,
                    EndingDate = accountReconciliation.EndingDate,
                    IsActive = accountReconciliation.IsActive,
                    IsSendEmail = accountReconciliation.IsSendEmail,
                    SendEmailDate = accountReconciliation.SendEmailDate,
                    IsResultSucceed = accountReconciliation.IsResultSucceed,
                    ResultDate = accountReconciliation.ResultDate,
                    ResultNote = accountReconciliation.ResultNote,
                    AddedDate = accountReconciliation.AddedDate,
                    Description = accountReconciliationDetail.Description,
                    Date = accountReconciliationDetail.Date,
                };
            return result.ToList();
        }
    }
}