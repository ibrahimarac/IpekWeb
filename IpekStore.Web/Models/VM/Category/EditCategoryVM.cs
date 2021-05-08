using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.VM.Category
{
    public class EditCategoryVM
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name="Kategori adı")]
        [Required(ErrorMessage ="Kategori adı girilmelidir.")]
        [MinLength(3,ErrorMessage ="Kategori adı en az 3 karakter olmalıdır.")]
        [MaxLength(30,ErrorMessage ="Kategori adı en fazla 30 karakter olabilir.")]
        public string Name { get; set; }

        [Display(Name="Aktif kategori")]
        public bool IsActive { get; set; }
    }
}
