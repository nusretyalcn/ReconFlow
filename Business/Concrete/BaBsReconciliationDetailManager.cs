using Business.Abstract;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BaBsReconciliationDetailManager:IBaBsReconciliationDetailService
{
    private readonly IBaBsReconciliationDetailDal _baBsReconciliationDal;

    public BaBsReconciliationDetailManager(IBaBsReconciliationDetailDal baBsReconciliationDal)
    {
        _baBsReconciliationDal = baBsReconciliationDal;
    }

    [TransactionScopeAspect]
    [CacheRemoveAspect("IBaBsReconciliationService.Get")]
    [SecuredOperation("Admin")]
    public IResult Add(BaBsReconciliationDetail bsReconciliationDetail)
    {
        _baBsReconciliationDal.Add(bsReconciliationDetail);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    [CacheRemoveAspect("IBaBsReconciliationService.Get")]
    [SecuredOperation("Admin")]
    public IResult Delete(BaBsReconciliationDetail bsReconciliationDetail)
    {
        _baBsReconciliationDal.Delete(bsReconciliationDetail);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    [CacheRemoveAspect("IBaBsReconciliationService.Get")]
    [SecuredOperation("Admin")]
    public IResult Update(BaBsReconciliationDetail bsReconciliationDetail)
    {
        _baBsReconciliationDal.Update(bsReconciliationDetail);
        return new SuccessResult();
    }

    [CacheAspect]
    [SecuredOperation("Get")]
    public IDataResult<List<BaBsReconciliationDetail>> GetAll()
    {
        return new SuccessDataResult<List<BaBsReconciliationDetail>>(_baBsReconciliationDal.GetAll());
    }

    [CacheAspect]
    [SecuredOperation("Get")]
    public IDataResult<BaBsReconciliationDetail> GetById(int id)
    {
        return new SuccessDataResult<BaBsReconciliationDetail>(_baBsReconciliationDal.Get(bs => bs.Id == id));
    }

    [CacheAspect]
    [SecuredOperation("Get")]
    public IDataResult<List<BaBsReconciliationDetail>> GetByBaBsReconciliationId(int bsReconciliationId)
    {
        return new SuccessDataResult<List<BaBsReconciliationDetail>>(_baBsReconciliationDal.GetAll(p=>p.BaBsReconciliationId == bsReconciliationId));
    }
}