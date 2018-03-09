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
    SqlDataAdapter sda_m;
    DataTable dt_m;
    //SqlCommandBuilder scb_f;
    //SqlCommandBuilder scb_d;
    //SqlCommandBuilder scb_m;
    protected void Page_Load(object sender, EventArgs e)
    {
        gv_featured_id.Visible = false;
        gv_deboost_id.Visible = false;
        gv_deboost_title_id.Visible = false;
        gv_featured_title_id.Visible = false;
        gv_maxnum_id.Visible = false;
        gv_maxnum_title_id.Visible = false;
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void Countries_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Countries.SelectedItem.Text].ConnectionString);
        foreach (ListItem item in fdm_cbx.Items)
        {
            if(item.Text== "Featured Campaigns"&& item.Selected == true)
            { 
                Label labelfeatured = new Label();
                gv_featured_title_id.Controls.Add(labelfeatured);
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
                    gv_featured_title_id.Visible = true;
                    labelfeatured.Visible = true;
                    labelfeatured.Text = "- No Featured Campaigns";
                    labelfeatured.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (item.Text == "Deboost Campaigns" && item.Selected == true)
            { 
                Label labeldeboost = new Label();
                gv_deboost_title_id.Controls.Add(labeldeboost);
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
                    gv_deboost_title_id.Visible = true;
                    labeldeboost.Visible = true;
                    labeldeboost.Text = "- No Deboost Campaigns";
                    labeldeboost.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (item.Text == "MaxNum Settings" && item.Selected == true)
            { 
                Label labelmaxnum = new Label();
                gv_maxnum_title_id.Controls.Add(labelmaxnum);
                string st_m = "select * from Config_CategoryTree_MaxNum";
                SqlCommand sqlcom_m = new SqlCommand(st_m, conn);
                conn.Open();
                var a_m = sqlcom_m.ExecuteScalar();
                conn.Close();
                if (a_m != null)
                {
                    labelmaxnum.Visible = false;
                    try
                    {
                        conn.Open();
                        sda_m = new SqlDataAdapter(sqlcom_m);
                        dt_m = new DataTable();
                        sda_m.Fill(dt_m);
                        gv_maxnum.DataSource = dt_m;
                        gv_maxnum.DataBind();
                        gv_maxnum_id.Visible = true;
                        gv_maxnum_title_id.Visible = true;
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.ToString() + "');", true);
                    }
                }
                else
                {
                    gv_maxnum_title_id.Visible = true;
                    labelmaxnum.Visible = true;
                    labelmaxnum.Text = "-No MaxNum Settings";
                    labelmaxnum.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }


    protected void SA_cbx_fdm_CheckedChanged(object sender, EventArgs e)
    {
        if (SA_cbx_fdm.Checked == true)
        {
            foreach (ListItem item in fdm_cbx.Items)
            {
                item.Selected = true;
            }
            SA_cbx_fdm.Text = "Deselect All";
            Countries_SelectedIndexChanged(this, EventArgs.Empty);
        }
        else
        {
            foreach (ListItem item in fdm_cbx.Items)
            {
                item.Selected = false;
                SA_cbx_fdm.Text = "Select All";
            }
            Countries_SelectedIndexChanged(this, EventArgs.Empty);
        }
    }

    protected void fdm_cbx_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void featured_gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        featured_gv.EditIndex = e.NewEditIndex;
    }
}