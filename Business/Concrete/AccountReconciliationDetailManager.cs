using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
    [CacheRemoveAspect("IAccountReconciliationDetailService.Get")]
    [SecuredOperation("Admin")]
    public IResult Add(AccountReconciliationDetail accountReconciliationDetail)
    {
        _accountReconciliationDetailDal.Add(accountReconciliationDetail);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationDetailValidator))]
    [CacheRemoveAspect("IAccountReconciliationDetailService.Get")]
    [SecuredOperation("Admin")]
    public IResult Delete(AccountReconciliationDetail accountReconciliationDetail)
    {
        _accountReconciliationDetailDal.Delete(accountReconciliationDetail);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(AccountReconciliationDetailValidator))]
    [CacheRemoveAspect("IAccountReconciliationDetailService.Get")]
    [SecuredOperation("Admin")]
    public IResult Update(AccountReconciliationDetail accountReconciliationDetail)
    {
        _accountReconciliationDetailDal.Update(accountReconciliationDetail);
        return new SuccessResult();
    }

    [CacheAspect]
    [SecuredOperation("Get")]
    public IDataResult<List<AccountReconciliationDetail>> GetAll()
    {
        return new SuccessDataResult<List<AccountReconciliationDetail>>(_accountReconciliationDetailDal.GetAll());
    }

    [CacheAspect]
    [SecuredOperation("Get")]
    public IDataResult<AccountReconciliationDetail> GetById(int id)
    {
        return new SuccessDataResult<AccountReconciliationDetail>(_accountReconciliationDetailDal.Get(c => c.Id == id));
    }

    [CacheAspect]
    [SecuredOperation("Get")]
    public IDataResult<List<AccountReconciliationDetail>> GetByAccountReconciliationId(int accountReconciliationId)
    {
        return new SuccessDataResult<List<AccountReconciliationDetail>>(_accountReconciliationDetailDal.GetAll(c => c.AccountReconciliationId == accountReconciliationId));
    }
}