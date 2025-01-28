namespace Entities.Dtos;

public class BaBsReconciliationDto
{
    public int Id { get; set; }
    public int CurrentAccountId { get; set; }
    public string Type { get; set; }
    public int Mounth { get; set; }
    public int Year { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }  
    public bool? IsSendEmail { get; set; }
    public DateTime? SendEmailDate { get; set; }
    public bool? IsResultSucceed { get; set; }
    public DateTime? ResultDate { get; set; }
    public string? ResultNote { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}