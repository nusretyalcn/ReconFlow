using Core.Entities;

namespace Entities.Dtos;

public class CurrentDetailDto:IDto
{
    public string CompanyName { get; set; }
    public string CurrentCode { get; set; }
    public string CurrentName { get; set; }
    public int CurrentType { get; set; }
    public string CurrentAccountCode { get; set; }
    public decimal CurrentAccountDebit { get; set; }  
    public decimal CurrentAccountCredit { get; set; }
    public DateTime AccountAddedDate { get; set; }
    public string CurrentAddress { get; set; }
    public string? CurrentTaxNumber { get; set; }
    public string CurrentAuthorized { get; set; }
}