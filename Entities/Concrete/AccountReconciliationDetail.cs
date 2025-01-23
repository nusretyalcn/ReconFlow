using Core.Entities;

namespace Entities.Concrete;

public class AccountReconciliationDetail:IEntity
{
    public int Id { get; set; }
    public int AccountReconciliationId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    
}