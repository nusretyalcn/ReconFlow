using Core.Entities;

namespace Entities.Concrete;

public class AccountReconciliation:IEntity
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CurrentAccountId { get; set; }
    public int CurrentId { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public bool? IsSendEmail { get; set; }
    public DateTime? SendEmailDate { get; set; }
    public bool? IsResultSucceed { get; set; }
    public DateTime? ResultDate { get; set; }
    public string? ResultNote { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
    
}