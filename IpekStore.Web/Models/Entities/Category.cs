using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.Entities
{
    [Table("Categories")]
    public class Category:AuditableEntity
    {
        [MaxLength(30,ErrorMessage ="Kategori adı en fazla 30 karakter olabilir.")]
        [MinLength(5,ErrorMessage ="Kategori adı en az 5 karakter olabilir.")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
        }
    }
}
