using System;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models.Layout
{
    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            //< log >
            //< date > 3 / 31 / 2015 5:33:07 PM </ date >
            //< level > ERROR </ level >
            //< message > Error parsing request</ message >
            //</ log >

                      StringBuilder result = new StringBuilder();
            result.AppendLine("<log>")
                  .AppendLine("\t<date>{0}</date>")
                  .AppendLine("\t<level>{1}</level>")
                  .AppendLine("\t<message>{2}</message>")
                  .AppendLine("</log>");

            return result.ToString().TrimEnd();
        }
    }
}
