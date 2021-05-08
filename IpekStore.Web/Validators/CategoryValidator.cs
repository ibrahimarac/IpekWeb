using FluentValidation;
using IpekStore.Web.Models.VM.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Validators
{
    public class CategoryValidator:AbstractValidator<EditCategoryVM>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olabilir.")
                .MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olabilir.");
        }
    }
}
