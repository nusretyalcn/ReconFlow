using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework.Context;

public class EfBaBsReconciliationDal : EfEntityRepositoryBase<BaBsReconciliation, EfDbContext>, IBaBsReconciliationDal
{
    public List<BaBsReconciliation> GetBaBsReconciliationByCompanyId(int companyId)
    {
        using (var context = new EfDbContext())
        {
            var result = from bsReconciliation in context.BaBsReconciliations
                join currentAccount in context.CurrentAccounts
                    on bsReconciliation.CurrentAccountId equals currentAccount.Id
                join current in context.Currents on currentAccount.CurrentId equals current.Id
                where current.CompanyId == companyId
                      && current.IsActive == true
                      && currentAccount.IsActive == true
                      && bsReconciliation.IsActive == true
                select new BaBsReconciliation
                {
                    Id = bsReconciliation.Id,
                    CurrentAccountId = bsReconciliation.CurrentAccountId,
                    Type = bsReconciliation.Type,
                    Mounth = bsReconciliation.Mounth,
                    Year = bsReconciliation.Year,
                    Quantity = bsReconciliation.Quantity,
                    Total = bsReconciliation.Total,
                    IsSendEmail = bsReconciliation.IsSendEmail,
                    SendEmailDate = bsReconciliation.SendEmailDate,
                    IsResultSucceed = bsReconciliation.IsResultSucceed,
                    ResultDate = bsReconciliation.ResultDate,
                    AddedDate = bsReconciliation.AddedDate,
                    IsActive = bsReconciliation.IsActive,
                };
            return result.ToList();
        }
    }

    public List<BaBsReconciliationDto> GetBaBsReconciliationDetail(int id)
    {
        using (var context = new EfDbContext())
        {
            var result = from bsReconciliation in context.BaBsReconciliations
                join bsReconciliationDetail in context.BaBsReconciliationDetails
                    on bsReconciliation.Id equals bsReconciliationDetail.BaBsReconciliationId
                where bsReconciliationDetail.BaBsReconciliationId == id
                      && bsReconciliation.IsActive == true
                select new BaBsReconciliationDto
                {
                    Id = bsReconciliation.Id,
                    CurrentAccountId = bsReconciliation.CurrentAccountId,
                    Type = bsReconciliation.Type,
                    Mounth = bsReconciliation.Mounth,
                    Year = bsReconciliation.Year,
                    Quantity = bsReconciliation.Quantity,
                    Total = bsReconciliation.Total,
                    IsSendEmail = bsReconciliation.IsSendEmail,
                    SendEmailDate = bsReconciliation.SendEmailDate,
                    IsResultSucceed = bsReconciliation.IsResultSucceed,
                    ResultDate = bsReconciliation.ResultDate,
                    AddedDate = bsReconciliation.AddedDate,
                    IsActive = bsReconciliation.IsActive,
                    Amount = bsReconciliationDetail.Amount,
                    Description = bsReconciliationDetail.Description,
                };
            return result.ToList();
        }
    }
}