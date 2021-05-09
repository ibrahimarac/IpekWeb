using IpekStore.Web.Constants;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IpekStore.Web.CustomMvcHelpers
{
    public static class BoolToTextHelper
    {
        public static IHtmlContent BoolToTextFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            var model = htmlHelper.ViewData.Model;
            var status= expression.Compile().Invoke(model);
            if (status)
                return new HtmlString(ViewConstants.STATUS_ACTIVE_TEXT);
            else
                return new HtmlString(ViewConstants.STATUS_PASSIVE_TEXT);
        }
        
    }
}
