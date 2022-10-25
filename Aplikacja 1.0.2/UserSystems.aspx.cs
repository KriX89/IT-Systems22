using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Aplikacja_1._0._2
{
    public partial class UserSystems : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT EmpID, FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedItem.Text, TextBox3.Text, TextBox4.Text) + " order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            hiddencolumns();
            dt.Clear();
        }


        private void LoadGridData2()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("Select sysuser.UserID, syst.System, syst.AuthecticationGrName, sysuser.Login from SystemUsers_v1 as sysuser INNER JOIN Systems_v1 as syst on sysuser.AutenticationGroup = syst.ATypeID join SystemAccessLevels as A on syst.System_ID = A.SystemID  WHERE sysuser.EmpID = " + HiddenEmpID.Value + " AND A.NetID = '" + Session["Login"] + "' AND A.AccessLevel > 0", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns2();
            dt.Clear();
        }


        private void LoadGridData3()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT GroupName, TicketNo, DT, Author FROM GroupMembers_v1 where UserID = " + HiddenTextBox2.Value + " AND Status_ID = 1", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView3.DataSource = dt;
            GridView3.DataBind();
            dt.Clear();
        }



        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridData();
        }


        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData2();
        }

        protected void GridView3_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            LoadGridData3();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                //   e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                //   e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
            for (int j = 0; j < GridView1.Rows.Count; j++)
                GridView1.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView1.SelectedIndex;
            if (HiddenEmpID.Value != GridView1.Rows[i].Cells[0].Text)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenEmpID.Value = GridView1.Rows[i].Cells[0].Text;

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();


                    SqlCommand command = new SqlCommand("Select sysuser.UserID, syst.System, syst.AuthecticationGrName, sysuser.Login from SystemUsers_v1 as sysuser INNER JOIN Systems_v1 as syst on sysuser.AutenticationGroup = syst.ATypeID join SystemAccessLevels as A on syst.System_ID = A.SystemID  WHERE sysuser.EmpID = "+ HiddenEmpID.Value + " AND A.NetID = '" + Session["Login"] + "' AND A.AccessLevel > 0", conn);
                    dt.Load(command.ExecuteReader());
                    conn.Close();
                    if (dt.Rows.Count == 0)
                    ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    hiddencolumns2();
                    dt.Clear();
                }
                catch { ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true); }


            }
            else
            {
                HiddenEmpID.Value = "";

            } 
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView2.SelectedIndex;
            if (HiddenTextBox2.Value != GridView2.Rows[i].Cells[0].Text)
            {
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox2.Value = GridView2.Rows[i].Cells[0].Text;

                try
                {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT GroupName, TicketNo, DT, Author FROM GroupMembers_v1 where UserID = " + HiddenTextBox2.Value + "AND System = '" + GridView2.Rows[i].Cells[1].Text + "' AND Status_ID = 1", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                if(dt.Rows.Count == 0)
                        ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);
                GridView3.DataSource = dt;
                GridView3.DataBind();
                dt.Clear();
                }
                catch { ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true); }

            }
            else
            {
                HiddenTextBox2.Value = "";

            }
        }


        public void hiddencolumns()
        {
            GridView1.HeaderRow.Cells[0].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView1.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
            }
        }


        public void hiddencolumns2()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
            }
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
                SqlCommand command = new SqlCommand("SELECT EmpID, FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1 order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                hiddencolumns();
                dt.Clear();

                DataTable dt2 = new DataTable();
                if (DropDownList1.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "Plant";
                    DropDownList1.DataValueField = "PlantID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }
            }

        }


        public static string buduj_warunek(string FirstName, string LastName, string Plant, string BWIEmplNo, string PlantIDNo)
        {
            string warunek = "";
            // bool pierwszy = true;

            if (FirstName != "")
                warunek += " FirstName LIKE '" + FirstName + "%'";
            else
                warunek += " FirstName LIKE '%'";

            if (LastName != "")
                warunek += "AND  LastName LIKE '" + LastName + "%'";
            else
                warunek += "AND LastName LIKE '%'";

            if (Plant != "")
                warunek += "AND Plant LIKE '%" + Plant + "%'";
            else
                warunek += "AND Plant LIKE '%'";

            if (BWIEmplNo != "")
                warunek += "AND BWIEmplNo LIKE '%" + BWIEmplNo + "%'";
            else
                warunek += "AND BWIEmplNo LIKE '%'";

            if (PlantIDNo != "")
                warunek += "AND PlantIDNo LIKE '%" + PlantIDNo + "%'";
            else
                warunek += "AND PlantIDNo LIKE '%'";

            return warunek;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT EmpID, FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedItem.Text, TextBox3.Text, TextBox4.Text) + " order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                hiddencolumns();

                HiddenEmpID.Value = "";
                HiddenTextBox2.Value = "";
                GridView2.DataSource = null;
                GridView2.DataBind();
                GridView3.DataSource = null;
                GridView3.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }

    }
}