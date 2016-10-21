using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Monk.Utils
{
    public static class RazorExtention
    {
        public static MvcHtmlString Description(this HtmlHelper htmlHelper, string name)
        {
            ModelMetadata _modelMetadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewData);
            return MvcHtmlString.Create(_modelMetadata.Description);
        }

        public static MvcHtmlString DescriptionFor<TModel, TResult>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
        {
            ModelMetadata _modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return MvcHtmlString.Create(_modelMetadata.Description);
        }
    }
}