using Example.Domain.Validation;
using FluentValidation.Results;
using System;

namespace Example.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistredIn { get; set; }
        public Boolean Active { get; set; }

        public User()
        {
            this.RegistredIn = DateTime.UtcNow;
            this.Active = true;
        }
    }
}
