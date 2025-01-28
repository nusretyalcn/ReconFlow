using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
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
        
        builder.RegisterType<CurrentManager>().As<ICurrentService>();
        builder.RegisterType<EfCurrentDal>().As<ICurrentDal>();
        
        builder.RegisterType<CurrentAccountManager>().As<ICurrentAccountService>();
        builder.RegisterType<EfCurrentAccountDal>().As<ICurrentAccountDal>();
        

        builder.RegisterType<AuthManager>().As<IAuthService>();
        
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();
        
        builder.RegisterType<UserCompanyManager>().As<IUserCompanyService>();
        builder.RegisterType<EfUserCompanyDal>().As<IUserCompanyDal>();

        
        
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();


    }
}