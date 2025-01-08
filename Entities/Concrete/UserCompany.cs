using Core.Entities;

namespace Entities.Concrete;

public class UserCompany: IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CompanyId { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
}