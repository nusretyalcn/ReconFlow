namespace Entities.Dtos;

public class AccountReconciliationDto
{
    public int Id { get; set; }
    public int CurrentAccountId { get; set; }
    public string ReconciliationNo { get; set; }
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal Balance { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public bool? IsSendEmail { get; set; }
    public DateTime? SendEmailDate { get; set; }
    public bool? IsResultSucceed { get; set; }
    public DateTime? ResultDate { get; set; }
    public string? ResultNote { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}