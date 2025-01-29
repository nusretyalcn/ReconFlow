namespace Core.Entities.Concrete;

public class UserOperationClaim:IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
    
}