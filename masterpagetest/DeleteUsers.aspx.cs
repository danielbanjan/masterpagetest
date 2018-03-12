using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class DeleteUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int n = 0;
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if(item.Selected == true)n++;
        }
        var flag = 0;
        String st = "";
        String dss = "";
        if (n == 0 || string.IsNullOrWhiteSpace(TextBox1.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please input an email!')", true);
        }
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected == true)
            { 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[item.Text].ConnectionString);
            string[] lines = TextBox1.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int j = 0; j < lines.Length; j++)
            {
                st = "DELETE FROM Users WHERE username = '" + lines[j] + "'";
                dss = "DELETE FROM SavedSearch WHERE contactemail = '" + lines[j] + "'";
                SqlCommand sqlcom = new SqlCommand(st, conn);
                SqlCommand sqlcom2 = new SqlCommand(dss, conn);
                SqlCommand sqlcheck = new SqlCommand("select userid from users where username = '" + lines[j] + "'", conn);
                conn.Open();
                var a = sqlcheck.ExecuteScalar();
                conn.Close();
                if (a != null)
                {
                    conn.Close();
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.ToString() + "');", true);
                        }
                    try
                    {
                        String res = Convert.ToString(sqlcheck.ExecuteScalar());
                        String dm = "Delete from memberships where userid ='" + res + "'";
                        SqlCommand sqlcom3 = new SqlCommand(dm, conn);
                        sqlcom3.ExecuteNonQuery();
                        sqlcom.ExecuteNonQuery();
                        sqlcom2.ExecuteNonQuery();
                        conn.Close();
                        flag = 1;
                    }
                    catch (SqlException ex)
                    {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.ToString() + "');", true);
                    }
                }
                else
                {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No users with that email on " + item.Text + " portal.')", true);
                }
            }
        }
        if (flag == 1)
        {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted users from all selected portals.')", true);
        }
    }
}

    protected void Check_Clicked(object sender, EventArgs e)
    {
        if (checkbox1.Checked == true)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = true;
            }
            checkbox1.Text = "Deselect All";
        }
        else {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = false;
                checkbox1.Text = "Select All";
            }
        }
    }
}