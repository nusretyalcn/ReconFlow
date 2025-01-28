using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface IBaBsReconciliationService
{
    IResult Add(BaBsReconciliation bsReconciliation);
    IResult Delete(BaBsReconciliation bsReconciliation);
    IResult Update(BaBsReconciliation bsReconciliation);
    IDataResult<List<BaBsReconciliation>> GetAll();
    IDataResult<BaBsReconciliation> GetById(int id);
    IDataResult<List<BaBsReconciliation>> GetByCurrentAccountId(int currentAccountId);
    IDataResult<List<BaBsReconciliation>> GetBaBsReconciliationByCompanyId(int companyId);
    IDataResult<List<BaBsReconciliationDto>> GetBaBsReconciliationDetail(int id);
}