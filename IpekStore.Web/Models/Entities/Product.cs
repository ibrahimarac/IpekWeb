using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.Entities
{
    [Table("Products")]
    public class Product:AuditableEntity
    {
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Product()
        {
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
        }
    }
}
