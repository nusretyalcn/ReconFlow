using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CompanyManager>().As<ICompanyService>();
        builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();
        
        builder.RegisterType<AccountReconciliationManager>().As<IAccountReconciliationService>();
        builder.RegisterType<EfAccountReconciliationDal>().As<IAccountReconciliationDal>();
        
        builder.RegisterType<AccountReconciliationDetailManager>().As<IAccountReconciliationDetailService>();
        builder.RegisterType<EfAccountReconciliationDetailDal>().As<IAccountReconciliationDetailDal>();
        
        builder.RegisterType<BaBsReconciliationManager>().As<IBaBsReconciliationService>();
        builder.RegisterType<EfBaBsReconciliationDal>().As<IBaBsReconciliationDal>();
        
        builder.RegisterType<BaBsReconciliationDetailManager>().As<IBaBsReconciliationDetailService>();
        builder.RegisterType<EfBaBsReconciliationDetailDal>().As<IBaBsReconciliationDetailDal>();
        
        builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
        builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>();
        
        builder.RegisterType<CurrencyAccountManager>().As<ICurrencyAccountService>();
        builder.RegisterType<EfCurrencyAccountDal>().As<ICurrencyAccountDal>();
        
        builder.RegisterType<MailParameterManager>().As<IMailParameterService>();
        builder.RegisterType<EfMailParameter>().As<IMailParameterDal>();

        builder.RegisterType<AuthManager>().As<IAuthService>();
        
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        
        
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


    }
}