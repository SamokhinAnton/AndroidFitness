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

        public bool isBanned { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool isActive { get; set; }

        public RoleEntity Role { get; set; }


        public List<ProgramEntity> MyPrograms { get; set; }

        public List<ProgramEntity> CreatedPrograms { get; set; }


    }
}
