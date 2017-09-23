using Example.Domain.Validation;
using FluentValidation.Results;
using System;

namespace Example.Domain.Model
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        
    }
}
