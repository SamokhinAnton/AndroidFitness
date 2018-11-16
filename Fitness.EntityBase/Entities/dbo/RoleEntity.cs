using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class RoleEntity
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public virtual List<UserEntity> Users { get; set; }
    }
}
