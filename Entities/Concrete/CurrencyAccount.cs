using Core.Entities;

namespace Entities.Concrete;

public class CurrencyAccount:IEntity
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string TaxDepartment { get; set; }
    public string? TaxNumber { get; set; }
    public string? IdentityNumber { get; set; }
    public string Authorized { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
}