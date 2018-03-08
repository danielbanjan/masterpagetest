using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

public partial class aboutus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        string emailTo = email_txtbox.Text;
        string subject = "Test Emails " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        string body = "<div style = 'width: 50%'>";
        body += "<img src=http://i.imgur.com/jFekwMW.png>";
        body += "<br />";
        //for (int j = 0; j < links.Length; j++)
        //{
        //    body += "<p><a rel='nofollow'; target='_blank'; href='" + links[j] + "'><b>Email Link nr" + j + "</b></a></p>";
        //}
        body += "Thanks,";
        body += "<br />";
        body += "<b>dBTechnologies</b>";
        body += "</div>";
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress("danitestrubrikk@gmail.com", "dBTechnologies");
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential("danitestrubrikk@gmail.com", "Daniel.91");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                smtp.Timeout = 10000;
            }
        }
    }
}