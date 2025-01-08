using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete;

public class BaBsReconciliationManager:IBaBsReconciliationService
{
    private IBaBsReconciliationDal _baBsReconciliationDal;

    public BaBsReconciliationManager(IBaBsReconciliationDal bsReconciliationDal)
    {
        _baBsReconciliationDal = bsReconciliationDal;
    }
}