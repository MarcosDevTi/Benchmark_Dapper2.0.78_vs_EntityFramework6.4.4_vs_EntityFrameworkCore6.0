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
        public string ActionRetour { get; set; }

        public ItemResultView ItemResultView { get; set; }
        public int InteractionElement { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var interac = $"{InteractionElement}_{ActionName}";
            var sb = new StringBuilder()
              .AppendLine(" <td>")
              .AppendLine($"     <div id=\"{interac}\">")
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
               .AppendLine($"         <a href=\"/{ControllerName}/Clear?idResult={ItemResultView.Display.IdResult}&actionRetour={ActionRetour}\" class=\"badge badge-danger\">")
              .AppendLine("             <i class=\"far fa-trash-alt\"></i>")
              .AppendLine("         </a>")
              .AppendLine($"         <a onclick='startChrono(\"{interac}\")' href=\"/{ControllerName}/{ActionName}?interactions={ItemResultView.Interactions}\" class=\"badge badge-primary\">")
              .AppendLine("             <i class=\"fas fa-sync-alt\"></i>")
              .AppendLine("         </a>")
              .AppendLine("         <i class=\"fas fa-memory ml-2\"></i>")
              .AppendLine($"         {ItemResultView.Display.Ram?.ToString("0.##")} MB")
              .AppendLine("     </div>")
              .AppendLine(" </td>")
              .ToString();

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
