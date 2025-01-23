using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICurrentService
{
    IResult Add(Current current);
    IResult Delete(Current current);
    IResult Update(Current current);
    IDataResult<List<Current>> GetAll();
    IDataResult<Current> GetById(int id);
    IDataResult<List<Current>> GetCurrentByCompanyId(int companyId);
    IDataResult<List<CurrentDetailDto>> GetCurrentDetails();
    
}