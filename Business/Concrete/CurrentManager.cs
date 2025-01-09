using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete;

public class CurrentManager:ICurrentService
{
    private ICurrencyDal _currencyDal;

    public CurrentManager(ICurrencyDal currencyDal)
    {
        _currencyDal = currencyDal;
    }
}