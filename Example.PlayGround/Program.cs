using Example.Application;
using Example.Application.Interface;
using Example.Application.ViewModel;
using Example.Domain.Repository.Interface;
using Example.Domain.Service;
using Example.Domain.Service.Interface;
using Example.Domain.Validation;
using Example.Domain.Validation.Interface;
using Example.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Example.PlayGround
{
    class Program
    {
        private static readonly IServiceProvider _serviceProvider;

        static Program()
        {
            // Configure the container

            _serviceProvider = new ServiceCollection()
                .AddScoped<IUserApplication, UserApplication>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserAddValidation, UserAddValidation>()
                .AddScoped<IUserUpdateValidation, UserUpdateValidation>()
                .BuildServiceProvider();

            Application.AutoMapper.AutoMapperInitialization.RegisterMapping();
        }

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var _userApp = _serviceProvider.GetService<IUserApplication>();

            var user = new UserViewModel() { Email = Guid.NewGuid() + "@gmail.com", Name = "Antônio Filho", Password = "123456" };

            var resultAdd = await _userApp.Add(user);

            //if (!resultAdd.isValid)
            //    resultAdd.messages.ForEach(x => Console.WriteLine(x.message));
            //else
            //{
            //    Console.WriteLine("Registred user Id: {0}", resultAdd.Id.Value);

            //    user = await _userApp.Get(resultAdd.Id.Value);

            //    user.Email = "";

            //    var resultUpdate = await _userApp.Update(user);

            //    if (!resultUpdate.isValid)
            //        resultAdd.messages.ForEach(x => Console.WriteLine(x.message));
            //    else
            //    {
            //        Console.WriteLine("E-mail updated");

            //        user = await _userApp.Get(resultAdd.Id.Value);
            //        await _userApp.Delete(resultAdd.Id.Value);

            //        Console.WriteLine("User deleted");
            //    }
            //}

            Console.ReadKey();
        }

    }
}