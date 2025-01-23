using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface ICurrentDal: IEntityRepository<Current>
{
    public List<CurrentDetailDto> GetCurrentDetails();
}