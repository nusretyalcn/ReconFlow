using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBaBsReconciliationDetailService
{
    IResult Add(BaBsReconciliationDetail bsReconciliationDetail);
    IResult Delete(BaBsReconciliationDetail bsReconciliationDetail);
    IResult Update(BaBsReconciliationDetail bsReconciliationDetail);
    IDataResult<List<BaBsReconciliationDetail>> GetAll();
    IDataResult<BaBsReconciliationDetail> GetById(int id);
    IDataResult<List<BaBsReconciliationDetail>> GetByBaBsReconciliationId(int bsReconciliationId);
}