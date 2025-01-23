using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
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

    [TransactionScopeAspect]
    public IResult Add(CurrentAccount currentAccount)
    {
        _currentAccountDal.Add(currentAccount);
        return new SuccessResult(Messages.CurrencyAccountAdded);
    }

    [TransactionScopeAspect]
    public IResult Delete(CurrentAccount currentAccount)
    {
        _currentAccountDal.Delete(currentAccount);
        return new SuccessResult(Messages.CurrentAccountDeleted);
    }

    [TransactionScopeAspect]
    public IResult DeleteRange(List<CurrentAccount> currentAccounts)
    {
        _currentAccountDal.DeleteRange(currentAccounts);
        return new SuccessResult(Messages.CurrentAccountDeleted);
    }

    [TransactionScopeAspect]
    public IResult Update(CurrentAccount currentAccount)
    {
        _currentAccountDal.Update(currentAccount);
        return new SuccessResult(Messages.CurrentAccountUpdated);
    }

    public IDataResult<List<CurrentAccount>> GetAll()
    {
        return new SuccessDataResult<List<CurrentAccount>>(_currentAccountDal.GetAll());
    }

    public IDataResult<CurrentAccount> GetById(int id)
    {
        return new SuccessDataResult<CurrentAccount>(_currentAccountDal.Get(c => c.Id == id));
    }

    public IDataResult<List<CurrentAccount>> GetByCurrentId(int currentId)
    {
        return new SuccessDataResult<List<CurrentAccount>>(_currentAccountDal.GetAll(c => c.CurrentId == currentId));
    }
}