using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICurrentAccountService
{
    IResult Add(CurrentAccount currentAccount);
    IResult Delete(CurrentAccount currentAccount);
    IResult DeleteRange(List<CurrentAccount> currentAccounts);
    IResult Update(CurrentAccount currentAccount);
    IDataResult<List<CurrentAccount>> GetAll();
    IDataResult<CurrentAccount> GetById(int id);
    IDataResult<List<CurrentAccount>> GetByCurrentId(int currentId);
}