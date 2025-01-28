using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface IBaBsReconciliationDal:IEntityRepository<BaBsReconciliation>
{
    public List<BaBsReconciliation> GetBaBsReconciliationByCompanyId(int companyId);
    public List<BaBsReconciliationDto> GetBaBsReconciliationDetail(int id);
}