using System;
using System.Collections.Generic;

namespace HerokuTest.Models
{
    public partial class Users
    {
        public Users()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Secret { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
