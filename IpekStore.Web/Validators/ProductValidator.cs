using FluentValidation;
using IpekStore.Web.Models.VM.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Validators
{
    public class ProductValidator:AbstractValidator<EditProductVM>
    {
        public ProductValidator()
        {

        }
    }
}
