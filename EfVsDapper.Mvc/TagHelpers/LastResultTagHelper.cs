using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace EfVsDapper.Mvc.TagHelpers
{
    [HtmlTargetElement("last-result")]
    public class LastResultTagHelper : TagHelper
    {
        public LastResult LastResult { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (LastResult != null)
            {
                var sb = new StringBuilder()
            .AppendLine("<div class=\"alert alert-info\" role=\"alert\">")
            .AppendLine("                <div class=\"row\">")
            .AppendLine("                    <div class=\"col-2\">")
            .AppendLine($"                        <h4>{LastResult.TypeTransaction}</h4>")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-3\">")
            .AppendLine($"                        Tempo: Sec: {LastResult.TempoResult.Seconds}, Millisec: {LastResult.TempoResult.Milliseconds}")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-2\">")
            .AppendLine($"                        Ram: {LastResult.Ram}")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-2\">")
            .AppendLine($"                        Amount: {LastResult.Amount}")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-3\">")
            .AppendLine($"                        Total Ram: {LastResult.TotalRam}")
            .AppendLine("                    </div>")
            .AppendLine("                </div>")
            .AppendLine("            </div>")
            .ToString();

                output.Content.SetHtmlContent(sb.ToString());
            }
        }

    }
}
