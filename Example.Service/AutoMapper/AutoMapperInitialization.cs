using AutoMapper;
using Example.Application.ViewModel;
using Example.Domain.Model;
using Example.Domain.Response;

namespace Example.Application.AutoMapper
{
    public class AutoMapperInitialization
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<Response<User>, Response<UserViewModel>>();
                cfg.CreateMap<Response<UserViewModel>, Response<User>>();
            });
        }
    }
}
