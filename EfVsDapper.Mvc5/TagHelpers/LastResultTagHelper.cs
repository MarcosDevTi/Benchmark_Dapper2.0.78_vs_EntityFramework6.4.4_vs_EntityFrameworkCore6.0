using EntityFrameworkVsCoreDapperNetFramework.Results;
using System;
using System.Text;
using System.Web.Mvc;

namespace EfVsDapper.Mvc5.TagHelpers
{
    public static class LastResultTagHelper
    {
        public static MvcHtmlString GetLastResult(this HtmlHelper html, LastResult lastResult)
        {
            var sb = new StringBuilder();
            if (lastResult != null)
            {
                sb.AppendLine("<div class=\"alert alert-info\" role=\"alert\">");
                sb.AppendLine("                <div class=\"row\">");
                sb.AppendLine("                    <div class=\"col-2\">");
                sb.AppendLine($"                        <h5>{lastResult?.TypeTransaction}</h5>");
                sb.AppendLine("                    </div>");
                sb.AppendLine("                    <div class=\"col-3\">");
                sb.AppendLine($"                        Tempo: {DisplayTime(lastResult.TempoResult)}");
                sb.AppendLine("                    </div>");
                sb.AppendLine("                    <div class=\"col-2\">");
                sb.AppendLine($"                        Ram: {lastResult?.Ram}");
                sb.AppendLine("                    </div>");
                sb.AppendLine("                    <div class=\"col-2\">");
                sb.AppendLine($"                        Amount: {lastResult?.Amount}");
                sb.AppendLine("                    </div>");
                sb.AppendLine("                    <div class=\"col-3\">");
                sb.AppendLine($"                        Total Ram: {lastResult?.TotalRam}");
                sb.AppendLine("                    </div>");
                sb.AppendLine("                </div>");
                sb.AppendLine("            </div>");
                sb.ToString();
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        public static string DisplayTime(TimeSpan? tempo)
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
