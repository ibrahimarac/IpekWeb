using FluentValidation;
using IpekStore.Web.Models.VM.Category;
using IpekStore.Web.Models.VM.Product;
using IpekStore.Web.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DependencyExtensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            return  services
                .AddTransient<IValidator<EditCategoryVM>, CategoryValidator>()
                .AddTransient<IValidator<EditProductVM>, ProductValidator>();
        } 
    }
}
