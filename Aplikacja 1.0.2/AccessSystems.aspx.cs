using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Aplikacja_1._0._2
{
    public partial class AccessSystems : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";


        public void hiddencolumns()
        {
            try
            {
                GridView2.HeaderRow.Cells[2].Attributes.Add("style", "display:none");
                GridView2.HeaderRow.Cells[3].Attributes.Add("style", "display:none");

                foreach (GridViewRow gvr in GridView2.Rows)
                {
                    gvr.Cells[2].Attributes.Add("style", "display:none");
                    gvr.Cells[3].Attributes.Add("style", "display:none");
                }
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Logowanie.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT NetID, System, A.AccessLevelID, SystemID, AccessLevel FROM SystemAccessLevels as A join Systems as B on A.SystemID = B.System_ID join AccessLevels as C on A.AccessLevelID = C.AccessLevelID", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    if (dt.Rows.Count != 0)
                    {
                    hiddencolumns();
                    }
                    dt.Clear();
                


                DataTable dt2 = new DataTable();

                if (DropDownList1.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT System_ID, System FROM Systems", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "System";
                    DropDownList1.DataValueField = "System_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }

                DropDownList2.Items.Insert(0, new ListItem("None", "0"));
                DropDownList2.Items.Insert(1, new ListItem("View only", "1"));
                DropDownList2.Items.Insert(2, new ListItem("View/Edit", "2"));
            }
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView2.SelectedIndex;
            if (HiddenTextBox.Value != GridView2.Rows[i].Cells[0].Text)
            {
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox.Value = GridView2.Rows[i].Cells[0].Text;
                TextBox1.Text = GridView2.Rows[i].Cells[0].Text.Replace("&#243;", "ó");
                DropDownList1.SelectedValue = GridView2.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                DropDownList2.SelectedValue = GridView2.Rows[i].Cells[2].Text.Replace("&#243;", "ó");

            }
            else
            {
                HiddenTextBox.Value = "";
                TextBox1.Text = "";

            }
        }

        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT NetID, System, A.AccessLevelID, SystemID, AccessLevel FROM SystemAccessLevels as A join Systems as B on A.SystemID = B.System_ID join AccessLevels as C on A.AccessLevelID = C.AccessLevelID", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

            GridView2.DataSource = dt;
            GridView2.DataBind();
            if (dt.Rows.Count != 0)
            {
                hiddencolumns();
            }
            dt.Clear();


        }


        protected void clearAll()
        {
            HiddenTextBox.Value = "";
            TextBox1.Text = "";

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO SystemAccessLevels VALUES('" + TextBox1.Text + "', '" + DropDownList1.SelectedValue + "', '" + DropDownList2.SelectedValue + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();

                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT NetID, System, A.AccessLevelID, SystemID, AccessLevel FROM SystemAccessLevels as A join Systems as B on A.SystemID = B.System_ID join AccessLevels as C on A.AccessLevelID = C.AccessLevelID", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                if (dt.Rows.Count != 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    dt.Clear();
                    hiddencolumns();
                }

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
                SqlCommand command = new SqlCommand("UPDATE SystemAccessLevels SET AccessLevelID = '" + DropDownList2.SelectedValue + "' WHERE NetID = '" + TextBox1.Text + "' AND SystemID = '" + DropDownList1.SelectedValue + "'", conn);
                command.ExecuteNonQuery();
                conn.Close();



                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT NetID, System, A.AccessLevelID, SystemID, AccessLevel FROM SystemAccessLevels as A join Systems as B on A.SystemID = B.System_ID join AccessLevels as C on A.AccessLevelID = C.AccessLevelID", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                if (dt.Rows.Count != 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    dt.Clear();
                    hiddencolumns();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row updated.');", true);
                clearAll();


            }
            catch
            {
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            clearAll();
            Button1.Visible = true;
            Button2.Visible = false;
            Label16.Text = "Add new access to system";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (HiddenTextBox.Value == "")
            {
                Label29.Text = "First you need to select row.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openKomunikatModal();", true);
            }
            else
            {
                Button1.Visible = false;
                Button2.Visible = true;
                Label16.Text = "Change selected access";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
            }
        }


    }
}