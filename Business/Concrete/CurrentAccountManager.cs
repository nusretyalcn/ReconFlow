using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CurrentAccountManager:ICurrentAccountService
{
    private readonly ICurrentAccountDal _currentAccountDal;

    public CurrentAccountManager(ICurrentAccountDal currentAccountDal)
    {
        _currentAccountDal = currentAccountDal;
    }

    public IResult Add(CurrentAccount currentAccount)
    {
        _currentAccountDal.Add(currentAccount);
        return new SuccessResult(Messages.CurrencyAccountAdded);
    }

    public IResult Delete(CurrentAccount currentAccount)
    {
        _currentAccountDal.Delete(currentAccount);
        return new SuccessResult(Messages.CurrencyAccountDeleted);
    }

    public IResult Update(CurrentAccount currentAccount)
    {
        _currentAccountDal.Update(currentAccount);
        return new SuccessResult(Messages.CurrencyAccountUpdated);
    }

    public IDataResult<List<CurrentAccount>> GetAll()
    {
        return new SuccessDataResult<List<CurrentAccount>>(_currentAccountDal.GetAll());
    }

    public IDataResult<CurrentAccount> GetById(int id)
    {
        return new SuccessDataResult<CurrentAccount>(_currentAccountDal.Get(c => c.Id == id));
    }
}