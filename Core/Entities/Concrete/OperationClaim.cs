namespace Core.Entities.Concrete;

public class OperationClaim:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
}