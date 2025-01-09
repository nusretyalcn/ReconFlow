using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete;

public class CurrentAccountManager:ICurrentAccountService
{
    private readonly ICurrencyAccountDal _currencyAccountDal;

    public CurrentAccountManager(ICurrencyAccountDal currencyAccountDal)
    {
        _currencyAccountDal = currencyAccountDal;
    }
}