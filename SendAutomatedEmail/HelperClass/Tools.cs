using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendAutomatedEmail.HelperClass
{
    public class Tools
    {
        public string GetDescription()
        {
            var sb = new StringBuilder("<h1><center><span style='color: #6866dc;'>Meeting Agenda</span></center></h1>");

            sb.AppendLine("<hr />");
                sb.AppendLine("<div padding='1.2rem'>");
                    sb.AppendLine($"<center><b>Date</b>: <span style='color: #7a7a7a'>{DateTime.Now.ToString("dddd, dd MMMM yyyy")}</span>&nbsp;&nbsp; <b>Time</b>: <span style='color: #7a7a7a'>{DateTime.Now.ToString("hh:mm tt")}</span>&nbsp;&nbsp; <b>Location</b>: <span style='color: #7a7a7a;'>To Be Determine</span>&nbsp;&nbsp; </center>");
                sb.AppendLine("</div>");
            sb.AppendLine("<hr />");         

            sb.AppendLine("<h2>Meeting Objective</h2>");
            sb.AppendLine("<ul>");
                sb.AppendLine("<li>Write the meeting purpose here. Keep it in one to three sentences</li>");
            sb.AppendLine("</ul>");
            
            sb.AppendLine("<h2>Agenda</h2>");
            sb.AppendLine("<ul>");
                sb.AppendLine("<li>Software Development Feature update one</li>");
                sb.AppendLine("<li>Software Development Feature update two</li>");
                sb.AppendLine("<li>Software Development Feature update three</li>");
            sb.AppendLine("</ul>");

            
            sb.AppendLine("<h2>Next Steps</h2>");
            sb.AppendLine("<ul>");
            sb.AppendLine("<li>Design By Salweyar Patel</li>");          
            sb.AppendLine("</ul>");


            return sb.ToString();
        }
    }
}
