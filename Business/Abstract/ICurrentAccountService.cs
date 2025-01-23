using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICurrentAccountService
{
    IResult Add(CurrentAccount currentAccount);
    IResult Delete(CurrentAccount currentAccount);
    IResult Update(CurrentAccount currentAccount);
    IDataResult<List<CurrentAccount>> GetAll();
    IDataResult<CurrentAccount> GetById(int id);
}