using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Application.Interface;
using Example.Application.ViewModel;
using Example.API.Models;
using Example.Domain.Validation;
using System;

namespace Example.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController
    {

        private readonly IUserApplication _userApp;

        public UserController(IUserApplication userApp)
        {
            _userApp = userApp;
        }


        // GET: api/User
        [HttpGet]
        public async Task<MessageHttpResponse> Get()
        {
            throw new NotImplementedException();
        }

        //GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<MessageHttpResponse> Get(int id)
        {
            return MessageHttpResponse.Response<UserViewModel>(await _userApp.GetGeneric(id));
        }

        // POST: api/User
        [HttpPost]
        public async Task<MessageHttpResponse> Post([FromBody] UserViewModel user)
        {
            return MessageHttpResponse.Response<int?>(await _userApp.Add(user));
        }

        // PUT: api/User
        [HttpPut]
        public async Task<MessageHttpResponse> Put([FromBody] UserViewModel user)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<MessageHttpResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
