using AutoMapper;
using Example.Application.ViewModel;
using Example.Domain.Model;

namespace Example.Application.AutoMapper
{
    public class AutoMapperInitialization
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });
        }
    }
}
