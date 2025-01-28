using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class AccountReconciliationManager : IAccountReconciliationService
{
    private readonly IAccountReconciliationDal _accountReconciliationDal;

    public AccountReconciliationManager(IAccountReconciliationDal accountReconciliationDal)
    {
        _accountReconciliationDal = accountReconciliationDal;
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationValidator))]
    public IResult Add(AccountReconciliation accountReconciliation)
    {
        _accountReconciliationDal.Add(accountReconciliation);
        return new SuccessResult(Messages.AccountReconciliationAdded);
    }

    [TransactionScopeAspect]
    public IResult Delete(AccountReconciliation accountReconciliation)
    {
        _accountReconciliationDal.Delete(accountReconciliation);
        return new SuccessResult(Messages.AccountReconciliationDeleted);
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationValidator))]
    public IResult Update(AccountReconciliation accountReconciliation)
    {
        _accountReconciliationDal.Update(accountReconciliation);
        return new SuccessResult(Messages.AccountReconciliationUpdated);
    }

    public IDataResult<List<AccountReconciliation>> GetAll()
    {
        return new SuccessDataResult<List<AccountReconciliation>>(_accountReconciliationDal.GetAll());
    }

    public IDataResult<AccountReconciliation> GetById(int id)
    {
        return new SuccessDataResult<AccountReconciliation>(_accountReconciliationDal.Get(b => b.Id == id));
    }

    public IDataResult<List<AccountReconciliation>> GetByCurrentAccountId(int currentAccountId)
    {
        return new SuccessDataResult<List<AccountReconciliation>>(_accountReconciliationDal.GetAll(b => b.CurrentAccountId == currentAccountId));
    }

    public IDataResult<List<AccountReconciliation>> GetAccountReconciliationByCompanyId(int companyId)
    {
        return new SuccessDataResult<List<AccountReconciliation>>(_accountReconciliationDal.GetAccountReconciliationByCompanyId(companyId));
    }

    public IDataResult<List<AccountReconciliationDto>> GetAccountReconciliationDetail(int id)
    {
        return new SuccessDataResult<List<AccountReconciliationDto>>(_accountReconciliationDal.GetAccountReconciliationDetail(id));
    }
}