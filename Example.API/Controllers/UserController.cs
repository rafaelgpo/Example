using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.Application.Interface;
using Example.Application.ViewModel;
using Example.Domain.Messaging;

namespace Example.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApp;

        public UserController(IUserApplication userApp)
        {
            _userApp = userApp;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            return await _userApp.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserViewModel> Get(int id)
        {
            return await _userApp.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task<AddResponse> Post(UserViewModel user)
        {
            return await _userApp.Add(user);
        }

        // PUT: api/User
        [HttpPut]
        public async Task<UpdateResponse> Put(UserViewModel user)
        {
            return await _userApp.Update(user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userApp.Delete(id);
        }
    }
}
