using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.VM.Category
{
    public class CategoryVM
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name="Kategori adı")]
        public string Name { get; set; }

        [Display(Name="Durumu")]
        public bool Status { get; set; }
    }
}
