using IpekStore.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Core.Domain.Entities
{
    public class Product:BaseEntity,IPermanent,ITrackable
    {
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public bool IsActive { get; set; }


        public Product()
        {
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
        }
    }
}
