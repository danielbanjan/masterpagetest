using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class FeaturedAndDeboost : System.Web.UI.Page
{
    SqlDataAdapter sda_f;
    DataTable dt_f;
    SqlDataAdapter sda_d;
    DataTable dt_d;
    protected void Page_Load(object sender, EventArgs e)
    {
        gv_featured_id.Visible = false;
        gv_deboost_id.Visible = false;
        gv_deboost_title_id.Visible = false;
        gv_featured_title_id.Visible = false;
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void Countries_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label labelfeatured = new Label();

        div1.Controls.Add(labelfeatured);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Countries.SelectedItem.Text].ConnectionString);
        string st_f = "select id,domain,categorykey,filter,status,boost,start_time,cpc from Config_Customerv2_Campaign";
        SqlCommand sqlcom_f = new SqlCommand(st_f, conn);
        conn.Open();
        var a_f = sqlcom_f.ExecuteScalar();
        conn.Close();
        if (a_f != null)
        {
            labelfeatured.Visible = false;
            try
            {
                conn.Open();
                sda_f = new SqlDataAdapter(sqlcom_f);
                dt_f = new DataTable();
                sda_f.Fill(dt_f);
                featured_gv.DataSource = dt_f;
                featured_gv.DataBind();
                gv_featured_id.Visible = true;
                gv_featured_title_id.Visible = true;
                conn.Close();
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.ToString() + "');", true);
            }
        }
        else
        {
            labelfeatured.Visible = true;
            labelfeatured.Text = "No Featured Campaigns";
            labelfeatured.ForeColor = System.Drawing.Color.Red;
        }

        Label labeldeboost = new Label();

        div2.Controls.Add(labeldeboost);
        string st_d = "select id,categorykey,domain,filter,status,start_time from Config_Customerv2_Deboosting";
        SqlCommand sqlcom_d = new SqlCommand(st_d, conn);
        conn.Open();
        var a_d = sqlcom_d.ExecuteScalar();
        conn.Close();
        if (a_d != null)
        {
            labeldeboost.Visible = false;
            try
            {
                conn.Open();
                sda_d = new SqlDataAdapter(sqlcom_d);
                dt_d = new DataTable();
                sda_d.Fill(dt_d);
                deboost_gv.DataSource = dt_d;
                deboost_gv.DataBind();
                gv_deboost_id.Visible = true;
                gv_deboost_title_id.Visible = true;
                conn.Close();
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.ToString() + "');", true);
            }
        }
        else
        {
            labeldeboost.Visible = true;
            labeldeboost.Text = "No Deboost Campaigns";
            labeldeboost.ForeColor = System.Drawing.Color.Red;
        }



    }

}