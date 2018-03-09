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
using System.Text;
using System.Data;

public partial class aboutus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=db-de.hugintechnologies.com;Initial Catalog=Germany;Persist Security Info=True;User ID=rubrikkadmin@mpl8x702z9;Password=q4hi0Awi");
        con.Open();
        SqlCommand cmd = new SqlCommand("select id,domain,categorykey,filter,status,boost,start_time,cpc from Config_Customerv2_Campaign where domain='jobninja.com'", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string body = this.CreateEmailBody(GetGridviewData(GridView1));
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        string emailTo = email_txtbox.Text;
        string subject = "Test Emails " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
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
    public string GetGridviewData(GridView gv)
    {
        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);
        gv.RenderControl(htw);
        return strBuilder.ToString();
    }

    private string CreateEmailBody(string gridview)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.html")))
        {   body = reader.ReadToEnd();  }
        body = body.Replace("{gridview}", gridview);
        return body;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* For not inside runat-server issue when reading gridview for html email body */
    }



}