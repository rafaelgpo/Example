using Example.Application;
using Example.Application.Interface;
using Example.Application.ViewModel;
using Example.Domain.Repository.Interface;
using Example.Domain.Service;
using Example.Domain.Service.Interface;
using Example.Domain.Validation;
using Example.Domain.Validation.Interface;
using Example.Repository;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Threading.Tasks;

namespace Example.PlayGround
{
    class Program
    {

        static readonly Container container;

        static Program()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            // 2. Configure the container (register)
            container.Register<IUserApplication, UserApplication>();
            container.Register<IUserService, UserService>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserAddValidation, UserAddValidation>();
            container.Register<IUserUpdateValidation, UserUpdateValidation>();

            // 3. Verify your configuration
            container.Verify();

            Application.AutoMapper.AutoMapperInitialization.RegisterMapping();
        }

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                var _userApp = container.GetInstance<UserApplication>();

                var user = new UserViewModel() { Email = Guid.NewGuid() + "@gmail.com", Name = "Antônio Filho", Password = "123456" };

                var resultAdd = await _userApp.Add(user);

                if (!resultAdd.isValid)
                    resultAdd.messages.ForEach(x => Console.WriteLine(x.message));
                else
                {
                    Console.WriteLine("Registred user Id: {0}", resultAdd.Id.Value);

                    user = await _userApp.Get(resultAdd.Id.Value);

                    user.Email = "";

                    var resultUpdate = await _userApp.Update(user);

                    if (!resultUpdate.isValid)
                        resultAdd.messages.ForEach(x => Console.WriteLine(x.message));
                    else
                    {
                        Console.WriteLine("E-mail updated");

                        user = await _userApp.Get(resultAdd.Id.Value);
                        await _userApp.Delete(user);

                        Console.WriteLine("User deleted");
                    }
                }
            }

            
            Console.ReadKey();
        }

    }
}