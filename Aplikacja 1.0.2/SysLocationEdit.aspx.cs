using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_1._0._2
{
    public partial class SysLocationEdit : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Logowanie.aspx");
            }

            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM LocationTypes", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dt.Clear();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = GridView1.SelectedIndex;
            if (HiddenTextBox.Value != GridView1.Rows[i].Cells[0].Text)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox.Value = GridView1.Rows[i].Cells[0].Text;
                TextBox1.Text = GridView1.Rows[i].Cells[1].Text.Replace("&#243;", "ó");
                CheckBox chk = GridView1.Rows[i].Cells[2].Controls[0] as CheckBox;
                CheckBox1.Checked = chk.Checked;
            }
            else
            {
                HiddenTextBox.Value = "";
                TextBox1.Text = "";
                CheckBox1.Checked = true;
            }
        }

        protected void clearAll()
        {
            HiddenTextBox.Value = "";
            TextBox1.Text = "";
            CheckBox1.Checked = true;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO LocationTypes VALUES('" + TextBox1.Text + "', '" + CheckBox1.Checked + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();

                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT * FROM LocationTypes", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dt.Clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row added.');", true);
                clearAll();
            }
            catch
            {
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE LocationTypes SET LocationType = '" + TextBox1.Text + "', Active = '" + CheckBox1.Checked + "' WHERE LocTypeID = " + HiddenTextBox.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();



                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT * FROM LocationTypes", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dt.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row updated.');", true);
                clearAll();
            }
            catch
            {
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            clearAll();
            Button1.Visible = true;
            Button2.Visible = false;
            Label16.Text = "Add new location";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Button2.Visible = true;
            Label16.Text = "Change selected location";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }

    }
}