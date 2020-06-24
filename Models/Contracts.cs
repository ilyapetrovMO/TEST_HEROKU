using System;
using System.Collections.Generic;

namespace HerokuTest.Models
{
    public partial class Contracts
    {
        public int ContractId { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Secret { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
