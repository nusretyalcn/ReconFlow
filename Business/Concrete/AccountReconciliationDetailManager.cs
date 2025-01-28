using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class AccountReconciliationDetailManager: IAccountReconciliationDetailService
{
    private readonly IAccountReconciliationDetailDal _accountReconciliationDetailDal;

    public AccountReconciliationDetailManager(IAccountReconciliationDetailDal accountReconciliationDetailDal)
    {
        _accountReconciliationDetailDal = accountReconciliationDetailDal;
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationDetailValidator))]
    public IResult Add(AccountReconciliationDetail accountReconciliationDetail)
    {
        _accountReconciliationDetailDal.Add(accountReconciliationDetail);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationDetailValidator))]
    public IResult Delete(AccountReconciliationDetail accountReconciliationDetail)
    {
        _accountReconciliationDetailDal.Delete(accountReconciliationDetail);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationDetailValidator))]
    public IResult Update(AccountReconciliationDetail accountReconciliationDetail)
    {
        _accountReconciliationDetailDal.Update(accountReconciliationDetail);
        return new SuccessResult();
    }

    public IDataResult<List<AccountReconciliationDetail>> GetAll()
    {
        return new SuccessDataResult<List<AccountReconciliationDetail>>(_accountReconciliationDetailDal.GetAll());
    }

    public IDataResult<AccountReconciliationDetail> GetById(int id)
    {
        return new SuccessDataResult<AccountReconciliationDetail>(_accountReconciliationDetailDal.Get(c => c.Id == id));
    }

    public IDataResult<List<AccountReconciliationDetail>> GetByAccountReconciliationId(int accountReconciliationId)
    {
        return new SuccessDataResult<List<AccountReconciliationDetail>>(_accountReconciliationDetailDal.GetAll(c => c.AccountReconciliationId == accountReconciliationId));
    }
}