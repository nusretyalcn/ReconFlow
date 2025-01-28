using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class BaBsReconciliationManager:IBaBsReconciliationService
{
    private IBaBsReconciliationDal _baBsReconciliationDal;

    public BaBsReconciliationManager(IBaBsReconciliationDal bsReconciliationDal)
    {
        _baBsReconciliationDal = bsReconciliationDal;
    }

    [TransactionScopeAspect]
    public IResult Add(BaBsReconciliation bsReconciliation)
    {
        _baBsReconciliationDal.Add(bsReconciliation);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    public IResult Delete(BaBsReconciliation bsReconciliation)
    {
        _baBsReconciliationDal.Delete(bsReconciliation);
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    public IResult Update(BaBsReconciliation bsReconciliation)
    {
        _baBsReconciliationDal.Update(bsReconciliation);
        return new SuccessResult();
    }

    public IDataResult<List<BaBsReconciliation>> GetAll()
    {
        return new SuccessDataResult<List<BaBsReconciliation>>(_baBsReconciliationDal.GetAll());
    }

    public IDataResult<BaBsReconciliation> GetById(int id)
    {
        return new SuccessDataResult<BaBsReconciliation>(_baBsReconciliationDal.Get(b => b.Id == id));
    }

    public IDataResult<List<BaBsReconciliation>> GetByCurrentAccountId(int currentAccountId)
    {
        return new SuccessDataResult<List<BaBsReconciliation>>(_baBsReconciliationDal.GetAll(b => b.CurrentAccountId == currentAccountId));
    }

    public IDataResult<List<BaBsReconciliation>> GetBaBsReconciliationByCompanyId(int companyId)
    {
        return new SuccessDataResult<List<BaBsReconciliation>>(_baBsReconciliationDal.GetBaBsReconciliationByCompanyId(companyId));
    }

    public IDataResult<List<BaBsReconciliationDto>> GetBaBsReconciliationDetail(int id)
    {
        return new SuccessDataResult<List<BaBsReconciliationDto>>(_baBsReconciliationDal.GetBaBsReconciliationDetail(id));
    }
}