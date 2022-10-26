using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System;
using System.Web.UI;

namespace Aplikacja_1._0._2
{
    public partial class Menu : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";

        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[9].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[9].Attributes.Add("style", "display:none");
            }
        }

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, A.TicketNo,  CONVERT(char(10), ValidFrom,126) as ValidFrom,  CONVERT(char(10), ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 AND A.Status = 'To be deleted' ", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();
        }



        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {


            int i = GridView2.SelectedIndex;
            if (HiddenTextBox.Value != GridView2.Rows[i].Cells[0].Text)
            {
                TextBox7.Text = GridView2.Rows[i].Cells[0].Text.Replace("&#243;", "ó");
                TextBox8.Text = GridView2.Rows[i].Cells[1].Text.Replace("&#243;", "ó");
                TextBox9.Text = GridView2.Rows[i].Cells[2].Text.Replace("&#243;", "ó");
                TextBox10.Text = GridView2.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                TextBox11.Text = GridView2.Rows[i].Cells[4].Text.Replace("&#243;", "ó");
                TextBox12.Text = GridView2.Rows[i].Cells[5].Text.Replace("&#243;", "ó").Replace("&nbsp;", "");
                TextBox13.Text = GridView2.Rows[i].Cells[8].Text.Replace("&#243;", "ó");
                HiddenTextBox.Value = GridView2.Rows[i].Cells[9].Text.Replace("&#243;", "ó");



            }
            else
            {

                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";

                HiddenTextBox.Value = "";

            } 

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Logowanie.aspx");
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, A.TicketNo, CONVERT(char(10), ValidFrom,126) as ValidFrom,  CONVERT(char(10), ValidTo,126) as ValidTo, A.Status, A.RecID FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 AND A.Status = 'To be deleted' ", conn);

                //      SqlCommand command = new SqlCommand("SELECT TOP 10 System, GroupName, FirstName, LastName, Login, A.TicketNo, C.ValidFrom, C.ValidTo FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join GroupMembers as C on A.RecID = C.RecID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID > 0 AND C.ValidTo is not null order by C.ValidTo ", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE GroupMembers SET Status_ID = 3 WHERE RecID = " + HiddenTextBox.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();

                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";


                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, A.TicketNo, CONVERT(char(10), ValidFrom,126) as ValidFrom,  CONVERT(char(10), ValidTo,126) as ValidTo, A.Status, A.RecID FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 AND A.Status = 'To be deleted' ", conn);

                //      SqlCommand command = new SqlCommand("SELECT TOP 10 System, GroupName, FirstName, LastName, Login, A.TicketNo, C.ValidFrom, C.ValidTo FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join GroupMembers as C on A.RecID = C.RecID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID > 0 AND C.ValidTo is not null order by C.ValidTo ", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Status changed to - deleted');", true);
            }
            catch
            {
                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }
        }




    }
}