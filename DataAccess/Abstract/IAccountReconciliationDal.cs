using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface IAccountReconciliationDal:IEntityRepository<AccountReconciliation>
{
    public List<AccountReconciliation> GetAccountReconciliationByCompanyId(int companyId);
    public List<AccountReconciliationDto> GetAccountReconciliationDetail(int id);
}