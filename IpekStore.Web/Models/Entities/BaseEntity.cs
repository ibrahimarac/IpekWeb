using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.Entities
{
    public abstract class BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public BaseEntity()
        {
            IsActive = true;
        }
    }
}
