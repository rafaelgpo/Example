using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Application.Interface;
using Example.Application.ViewModel;
using Example.API.Models;
using Example.Domain.Validation;
using Example.Domain.Events.Interface;
using Example.Domain.Events;
using System;

namespace Example.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : BaseController
    {

        private readonly IUserApplication _userApp;

        public UserController(IUserApplication userApp, IDomainNotificationHandler<ValidationMessage> notifications) : base(notifications)
        {
            _userApp = userApp;
        }


        // GET: api/User
        [HttpGet]
        public async Task<MessageHttpResponse> Get()
        {
            return HttpResponse(await _userApp.GetAll());
        }

        //GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<MessageHttpResponse> Get(int id)
        {
            return HttpResponse(await _userApp.Get(id));
        }

        // POST: api/User
        [HttpPost]
        public async Task<MessageHttpResponse> Post([FromBody] UserViewModel user)
        {
            return HttpResponse(await _userApp.Add(user));
        }

        // PUT: api/User
        [HttpPut]
        public async Task<MessageHttpResponse> Put([FromBody] UserViewModel user)
        {
            await _userApp.Update(user);

            return HttpResponse();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<MessageHttpResponse> Delete(int id)
        {
            await _userApp.Delete(id);

            return HttpResponse();
        }
    }
}
