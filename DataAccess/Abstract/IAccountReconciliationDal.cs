using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IAccountReconciliationDal:IEntityRepository<AccountReconciliation>
{
    public List<AccountReconciliation> GetAccountReconciliationByCompanyId(int companyId);
}