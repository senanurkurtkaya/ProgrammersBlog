using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
    }
}
