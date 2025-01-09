using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager:IUserService
{
    private readonly IUserDal _userDal;
    
    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    public IDataResult<List<OperationClaim>> GetClaims(User user)
    {
        return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
    }

    public IResult Add(User user)
    {
        BusinessRules.Run(IsUserExist(user));
        user.AddedDate = DateTime.Now;
        user.IsActive = true;
        _userDal.Add(user);
        return new SuccessResult();
    }

    public IDataResult<User> GetByEmail(string email)
    {
        return new SuccessDataResult<User>(_userDal.Get(p => p.Email == email));
    }
    
    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public IResult IsUserExist(User user)
    {
        var result = _userDal.GetAll(p => p.Email == user.Email).Any();
        if (result) return new ErrorResult(Messages.UserExist);
        return new SuccessResult();
    }
}