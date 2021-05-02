using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.Entities
{
    public abstract class AuditableEntity:BaseEntity
    {
        public string CreateUser { get; set; }
        public string LastupUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }
}
