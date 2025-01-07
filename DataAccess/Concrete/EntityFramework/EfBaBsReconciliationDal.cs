using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Context;

public class EfBaBsReconciliationDal:EfEntityRepositoryBase<BaBsReconciliation,EfDbContext>,IBaBsReconciliationDal
{
    
}