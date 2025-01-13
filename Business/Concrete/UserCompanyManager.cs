using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserCompanyManager:IUserCompanyService
{
    private readonly IUserCompanyDal _userCompanyDal;

    public UserCompanyManager(IUserCompanyDal userCompanyDal)
    {
        _userCompanyDal = userCompanyDal;
    }

    public IDataResult<List<UserCompany>> GetAll()
    {
        return new SuccessDataResult<List<UserCompany>>(_userCompanyDal.GetAll(p=>p.IsActive == true));
    }

    public IResult Add(UserCompany userCompany)
    {
        _userCompanyDal.Add(userCompany);
        return new SuccessResult();
    }

    public IResult Delete(UserCompany userCompany)
    {
        _userCompanyDal.Delete(userCompany);
        return new SuccessResult();
    }

    public IResult Update(UserCompany userCompany)
    {
        _userCompanyDal.Update(userCompany);
        return new SuccessResult();
    }

    public IDataResult<UserCompany> GetById(int companyId)
    {
        return new SuccessDataResult<UserCompany>(_userCompanyDal.Get(u => u.Id == companyId));
    }

    public IResult UpdateRange(List<UserCompany> userCompaniesToUpdate)
    {
        _userCompanyDal.UpdateRange(userCompaniesToUpdate);
        return new SuccessResult();
    }
}