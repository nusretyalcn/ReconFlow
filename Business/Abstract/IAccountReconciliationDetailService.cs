using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IAccountReconciliationDetailService
{
    IResult Add(AccountReconciliationDetail accountReconciliationDetail);
    IResult Delete(AccountReconciliationDetail accountReconciliationDetail);
    IResult Update(AccountReconciliationDetail accountReconciliationDetail);
    IDataResult<List<AccountReconciliationDetail>> GetAll();
    IDataResult<AccountReconciliationDetail> GetById(int id);
    IDataResult<List<AccountReconciliationDetail>> GetByAccountReconciliationId(int accountReconciliationId);

}