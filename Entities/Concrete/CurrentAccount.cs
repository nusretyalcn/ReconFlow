using Core.Entities;

namespace Entities.Concrete;

public class CurrentAccount:IEntity
{
    public int Id { get; set; } 
    public int CurrentId { get; set; }
    public string Code { get; set; }
    public decimal CurrentDebit { get; set; }  
    public decimal CurrentCredit { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }

}