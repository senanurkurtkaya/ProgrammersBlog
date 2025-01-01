using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;


namespace ProgrammersBlog.MVC.Helpers.Abstract
{
    public interface IImageHelper
    {
        string Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}

