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
        //[Column(TypeName = "varchar(150)")]
        [MaxLength(150, ErrorMessage = "Ürün adı en fazla 150 karakter olabilir.")]
        [MinLength(5, ErrorMessage = "Ürün adı en az 5 karakter olabilir.")]
        [Required(ErrorMessage = "Ürün adı gereklidir.")]
        public string Name { get; set; }
        
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Product()
        {
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
        }
    }
}
