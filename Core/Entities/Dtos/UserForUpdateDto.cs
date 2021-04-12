using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Core.Entities.Dtos
{
    public class UserForUpdateDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordToCheck { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
