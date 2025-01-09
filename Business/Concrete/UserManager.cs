using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCutingConserns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation;

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
        ValidationTool.Validate(new UserValidator(), user);
        BusinessRules.Run(IsUserExist(user));
        _userDal.Add(user);
        return new SuccessResult();
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult();
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
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