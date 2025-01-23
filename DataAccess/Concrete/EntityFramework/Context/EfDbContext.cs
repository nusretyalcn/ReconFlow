using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;

public class EfDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;
                                          Database=eReconciliationDb;
                                          User Id= SA;
                                          Password=1245a22521A;
                                          TrustServerCertificate=True;
                                          Encrypt=false");
    }

    public DbSet<AccountReconciliation> AccountReconciliations { get; set; }
    public DbSet<AccountReconciliationDetail> AccountReconciliationDetails { get; set; }
    public DbSet<BaBsReconciliation> BaBsReconciliations { get; set; }
    public DbSet<BaBsReconciliationDetail> BaBsReconciliationDetails { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Current> Currents { get; set; }
    public DbSet<CurrentAccount> CurrentAccounts { get; set; }
    public DbSet<MailParameter> MailParameters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCompany> UserCompanies { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    
}