using Core.Entities;

namespace Entities.Dtos;

public class UserDto:IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime AddedDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsEmailConfirm { get; set; }
    public string? MailConfirmValue { get; set; }
    public DateTime MailConfirmDate { get; set; }
}