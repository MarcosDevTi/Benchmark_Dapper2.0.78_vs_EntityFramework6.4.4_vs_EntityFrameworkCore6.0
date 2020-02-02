using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace EfVsDapper.Mvc.TagHelpers
{
    [HtmlTargetElement("cell-result")]
    public class CellResultTagHelper : TagHelper
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public ResultView ResultView { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var sb = new StringBuilder()
              .AppendLine(" <td>")
              .AppendLine("     <div>")
              .AppendLine("         <div>")
              .AppendLine("             <i class=\"far fa-clock\"></i>")
              .AppendLine($"             Min: {ResultView.Dapper.Display.TempoMin}")
              .AppendLine("         </div>")
              .AppendLine("         <div>")
              .AppendLine("             <i class=\"far fa-clock\"></i>")
              .AppendLine($"             Max: {ResultView.Dapper.Display.TempoMax}")
              .AppendLine("         </div>")
              .AppendLine("     </div>")
              .AppendLine("     <div>")
              .AppendLine("         <i class=\"fas fa-memory\"></i>")
              .AppendLine($"         {ResultView.Dapper.Display.Ram}")
              .AppendLine($"         <a href=\"/{ControllerName}/{ActionName}?interactions={ResultView.Dapper.Interactions}\" class=\"badge badge-primary\">")
              .AppendLine("             <i class=\"fas fa-sync-alt\">   Reflesh</i>")
              .AppendLine("         </a>")
              .AppendLine("     </div>")
              .AppendLine(" </td>")
              .ToString();

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
