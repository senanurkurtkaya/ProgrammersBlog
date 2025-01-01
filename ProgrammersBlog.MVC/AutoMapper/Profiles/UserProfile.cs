using AutoMapper;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.MVC.Helpers.Abstract;

namespace ProgrammersBlog.MVC.AutoMapper.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile(IImageHelper imageHelper)
        {
            CreateMap<UserAddDto, User>().ForMember(dest => dest.Picture, opt => opt.MapFrom(x => imageHelper.Upload(x.UserName, x.PictureFile, PictureType.User, null)));
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
