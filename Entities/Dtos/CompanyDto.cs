using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Entities.Dtos;

public class CompanyDto:IDto
{
    public int UserId { get; set; }
    public Company Company { get; set; }
}