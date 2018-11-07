using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Soil { get; set; }

        public DateTime BirthDate { get; set; }

        public RoleEntity Role { get; set; }


    }
}
