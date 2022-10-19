using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Web.UI;

namespace Aplikacja_1._0._2
{
    public partial class SystemsView : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.System, A.AuthecticationGrName , A.LocationType, A.SystemType, A.Vendor, A.PhysicalLocation, A.Plant, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID WHERE " + buduj_warunek(TextBox1.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text) + " order by A.System_ID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();
            hiddencolumns();
        }


        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[7].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[8].Attributes.Add("style", "display:none");
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[7].Attributes.Add("style", "display:none");
                gvr.Cells[8].Attributes.Add("style", "display:none");
            }
        }

        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        public static string buduj_warunek(string System, string LocationType, string SystemType, string Plant)
        {
            string warunek = "";
            // bool pierwszy = true;

            if (System != "")
                warunek += " A.System LIKE '%" + System + "%'";
            else
                warunek += " A.System LIKE '%'";

            if (LocationType != "")
                warunek += "AND  A.LocationType LIKE '%" + LocationType + "%'";
            else
                warunek += "AND A.LocationType LIKE '%'";

            if (SystemType != "")
                warunek += "AND A.SystemType LIKE '%" + SystemType + "%'";
            else
                warunek += "AND A.SystemType LIKE '%'";

            if (Plant != "")
                warunek += "AND A.Plant LIKE '%" + Plant + "%'";
            else
                warunek += "AND A.Plant LIKE '%'";


            return warunek;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Support Email: " + (e.Row.DataItem as DataRowView)[7].ToString().Replace("&#243;", "ó");
                e.Row.ToolTip += "\nSupport Group: " + (e.Row.DataItem as DataRowView)[8].ToString().Replace("&#243;", "ó");
            }
        }

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

            SqlCommand command = new SqlCommand("SELECT A.System, A.AuthecticationGrName , A.LocationType, A.SystemType, A.Vendor, A.PhysicalLocation, A.Plant, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID order by A.System_ID desc", conn);
          //  SqlCommand command = new SqlCommand("SELECT System, AuthecticationGrName , LocationType, SystemType, Vendor, PhysicalLocation, Plant FROM Systems_v1 order by System_ID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns();

                DataTable dt2 = new DataTable();
                if (DropDownList1.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT LocTypeID, LocationType FROM LocationTypes", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "LocationType";
                    DropDownList1.DataValueField = "LocTypeID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }


                if (DropDownList2.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT SystemTypeID, SystemType FROM SystemTypes", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList2.DataSource = dt2;
                    DropDownList2.DataTextField = "SystemType";
                    DropDownList2.DataValueField = "SystemTypeID";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }


                if (DropDownList3.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList3.DataSource = dt2;
                    DropDownList3.DataTextField = "Plant";
                    DropDownList3.DataValueField = "PlantID";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.System, A.AuthecticationGrName , A.LocationType, A.SystemType, A.Vendor, A.PhysicalLocation, A.Plant, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID WHERE " + buduj_warunek(TextBox1.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text) + " order by A.System_ID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }
    }
}