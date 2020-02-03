using EntityFrameworkVsCoreDapperNetFramework.Results;
using System.Text;
using System.Web.Mvc;

namespace EfVsDapper.Mvc5.TagHelpers
{
    public static class CellResultTagHelper
    {
        public static MvcHtmlString GetCellResultTag(this HtmlHelper html, ItemResultView ItemResultView, string ControllerName, string ActionName)
        {
            var sb = new StringBuilder()
              .AppendLine(" <td>")
              .AppendLine("     <div>")
              .AppendLine("         <div>")
              .AppendLine("             <i class=\"far fa-clock\"></i>")
              .AppendLine($"             Min: {ItemResultView.Display.TempoMin}")
              .AppendLine("         </div>")
              .AppendLine("         <div>")
              .AppendLine("             <i class=\"far fa-clock\"></i>")
              .AppendLine($"             Max: {ItemResultView.Display.TempoMax}")
              .AppendLine("         </div>")
              .AppendLine("     </div>")
              .AppendLine("     <div>")
               .AppendLine($"         <a href=\"/{ControllerName}/Clear?idResult={ItemResultView.Display.IdResult}\" class=\"badge badge-danger\">")
              .AppendLine("             <i class=\"far fa-trash-alt\"></i>")
              .AppendLine("         </a>")
              .AppendLine($"         <a href=\"/{ControllerName}/{ActionName}?interactions={ItemResultView.Interactions}\" class=\"badge badge-primary\">")
              .AppendLine("             <i class=\"fas fa-sync-alt\"></i>")
              .AppendLine("         </a>")
              .AppendLine("         <i class=\"fas fa-memory ml-2\"></i>")
              .AppendLine($"         {ItemResultView.Display.Ram?.ToString("0.##")} MB")
              .AppendLine("     </div>")
              .AppendLine(" </td>")
              .ToString();

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
