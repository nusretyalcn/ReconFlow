using Core.Entities;

namespace Entities.Concrete;

public class MailParameter:IEntity
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Email { get; set; }
    public string Passsword { get; set; }
    public string SMTP { get; set; }
    public int Port { get; set; }
    public bool SSL { get; set; }
}