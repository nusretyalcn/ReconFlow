using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class CurrentManager:ICurrentService
{
    private readonly ICurrentDal _currentDal;
    private readonly ICurrentAccountService _currentAccountService;

    public CurrentManager(ICurrentDal currentDal, ICurrentAccountService currentAccountService)
    {
        _currentDal = currentDal;
        _currentAccountService = currentAccountService;
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(CurrentValidator))]
    [CacheRemoveAspect("ICurrentService.Get")]
    public IResult Add(Current current)
    {
        _currentDal.Add(current);
        return new SuccessResult(Messages.CurrentAdded);
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(CurrentValidator))]
    [CacheRemoveAspect("ICurrentService.Get")]
    public IResult Delete(Current current)
    {
        var currentAccounts= _currentAccountService.GetByCurrentId(current.Id).Data;
        _currentAccountService.DeleteRange(currentAccounts);
        _currentDal.Delete(current);
        return new SuccessResult(Messages.CurrentDeleted);
    }

    [TransactionScopeAspect]
    [ValidationAspect(typeof(CurrentValidator))]
    [CacheRemoveAspect("ICurrentService.Get")]
    public IResult Update(Current current)
    {
        _currentDal.Update(current);
        return new SuccessResult(Messages.CurrentUpdated);
    }

    [CacheAspect]
    public IDataResult<List<Current>> GetAll()
    {
        return new SuccessDataResult<List<Current>>(_currentDal.GetAll());
    }

    [CacheAspect]
    public IDataResult<Current> GetById(int id)
    {
        return new SuccessDataResult<Current>(_currentDal.Get(u => u.Id == id));
    }

    [CacheAspect]
    public IDataResult<List<Current>> GetCurrentByCompanyId(int companyId)
    {
        return new SuccessDataResult<List<Current>>(_currentDal.GetAll(u => u.CompanyId == companyId));
    }

    [CacheAspect]
    public IDataResult<List<CurrentDetailDto>> GetCurrentDetails()
    {
        return new SuccessDataResult<List<CurrentDetailDto>>(_currentDal.GetCurrentDetails());
    }
}