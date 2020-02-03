using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
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
            .AppendLine($"                        <h5>{LastResult?.TypeTransaction}</h5>")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-3\">")
            .AppendLine($"                        Tempo: {DisplayTime(LastResult.TempoResult)}")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-2\">")
            .AppendLine($"                        Ram: {LastResult?.Ram}")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-2\">")
            .AppendLine($"                        Amount: {LastResult?.Amount}")
            .AppendLine("                    </div>")
            .AppendLine("                    <div class=\"col-3\">")
            .AppendLine($"                        Total Ram: {LastResult?.TotalRam}")
            .AppendLine("                    </div>")
            .AppendLine("                </div>")
            .AppendLine("            </div>")
            .ToString();

                output.Content.SetHtmlContent(sb.ToString());
            }
        }

        public string DisplayTime(TimeSpan? tempo)
        {
            var result = string.Empty;
            var min = tempo?.Minutes;
            var sec = tempo?.Seconds;
            var millisec = tempo?.Milliseconds;
            if (millisec > 0)
            {
                result += millisec + " milisec";
            }
            if (sec > 0)
            {
                result = sec + " sec, " + result;
            }
            if (min > 0)
            {
                result = min + " minutes, " + result;
            }
            return result;
        }

    }
}
