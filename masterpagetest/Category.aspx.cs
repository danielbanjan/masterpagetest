using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Category : System.Web.UI.Page
{
    SqlDataAdapter sda_f;
    DataTable dt_f;
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Visible = false;
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        //CheckBoxList1.Items.Add(new ListItem("Argentina", "Argentina"));
        //CheckBoxList1.Items.Add(new ListItem("Australia", "Australia"));
        //CheckBoxList1.Items.Add(new ListItem("Items 3", "Items 3"));
    }

    protected void Countries_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label mylabel = new Label();

        div1.Controls.Add(mylabel);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Countries.SelectedItem.Text].ConnectionString);
        string st = "select id,domain,categorykey,filter,status,boost,start_time,cpc from Config_Customerv2_Campaign";
        SqlCommand sqlcom = new SqlCommand(st, conn);
        conn.Open();
        var a = sqlcom.ExecuteScalar();
        conn.Close();
        if (a != null)
        {
            mylabel.Visible = false;
            try
            {
                conn.Open();
                sda_f = new SqlDataAdapter(sqlcom);
                dt_f = new DataTable();
                sda_f.Fill(dt_f);
                GridView1.DataSource = dt_f;
                GridView1.DataBind();
                GridView1.Visible = true;
                conn.Close();
            }
            catch (SqlException ex)
            {
            }
        }
        else
        {
            mylabel.Visible = true;
            mylabel.Text = "No Featured Campaigns";
            mylabel.ForeColor = System.Drawing.Color.Red;
        }

    }

}