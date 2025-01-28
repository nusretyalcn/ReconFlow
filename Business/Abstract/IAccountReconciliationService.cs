using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface IAccountReconciliationService
{
    IResult Add(AccountReconciliation accountReconciliation);
    IResult Delete(AccountReconciliation accountReconciliation);
    IResult Update(AccountReconciliation accountReconciliation);
    IDataResult<List<AccountReconciliation>> GetAll();
    IDataResult<AccountReconciliation> GetById(int id);
    IDataResult<List<AccountReconciliation>> GetByCurrentAccountId(int currentAccountId);
    IDataResult<List<AccountReconciliation>> GetAccountReconciliationByCompanyId(int companyId);
    IDataResult<List<AccountReconciliationDto>> GetAccountReconciliationDetail(int id);
}