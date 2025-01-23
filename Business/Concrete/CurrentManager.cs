using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class CurrentManager:ICurrentService
{
    private readonly ICurrentDal _currentDal;

    public CurrentManager(ICurrentDal currentDal)
    {
        _currentDal = currentDal;
    }

    public IResult Add(Current current)
    {
        _currentDal.Add(current);
        return new SuccessResult(Messages.CurrentAdded);
    }

    public IResult Delete(Current current)
    {
        _currentDal.Delete(current);
        return new SuccessResult(Messages.CurrentDeleted);
    }

    public IResult Update(Current current)
    {
        _currentDal.Update(current);
        return new SuccessResult(Messages.CurrentUpdated);
    }

    public IDataResult<List<Current>> GetAll()
    {
        return new SuccessDataResult<List<Current>>(_currentDal.GetAll());
    }

    public IDataResult<Current> GetById(int id)
    {
        return new SuccessDataResult<Current>(_currentDal.Get(u => u.Id == id));
    }

    public IDataResult<List<Current>> GetCurrentByCompanyId(int companyId)
    {
        return new SuccessDataResult<List<Current>>(_currentDal.GetAll(u => u.CompanyId == companyId));
    }

    public IDataResult<List<CurrentDetailDto>> GetCurrentDetails()
    {
        return new SuccessDataResult<List<CurrentDetailDto>>(_currentDal.GetCurrentDetails());
    }
}