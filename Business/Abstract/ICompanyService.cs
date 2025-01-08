using Entities.Concrete;

namespace Business.Abstract;

public interface ICompanyService
{
    List<Company> GetAll();
}