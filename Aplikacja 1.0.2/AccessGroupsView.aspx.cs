using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Web.UI;

namespace Aplikacja_1._0._2
{
    public partial class AccessGroupsView : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT System, AuthecticationGrName , GroupName, Description, SystemGroupName, Plant FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
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

        public static string buduj_warunek(string System, string AuthecticationGrName, string GroupName, string Description, string SystemGroupName, string Plant, string NetID)
        {
            string warunek = "NetID = '" + NetID + "' AND AccessLevel > 0 ";
            // bool pierwszy = true;

            if (System != "")
                warunek += "AND System LIKE '%" + System + "%'";
            else
                warunek += "AND System LIKE '%'";

            if (AuthecticationGrName != "")
                warunek += "AND  AuthecticationGrName LIKE '%" + AuthecticationGrName + "%'";
            else
                warunek += "AND AuthecticationGrName LIKE '%'";

            if (GroupName != "")
                warunek += "AND GroupName LIKE '%" + GroupName + "%'";
            else
                warunek += "AND GroupName LIKE '%'";

            if (Description != "")
                warunek += "AND Description LIKE '%" + Description + "%'";
            else
                warunek += "AND Description LIKE '%'";

            if (SystemGroupName != "")
                warunek += "AND SystemGroupName LIKE '%" + SystemGroupName + "%'";
            else
                warunek += "AND SystemGroupName LIKE '%'";

            if (Plant != "")
                warunek += "AND Plant LIKE '%" + Plant + "%'";
            else
                warunek += "AND Plant LIKE '%'";


            return warunek;
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
            SqlCommand command = new SqlCommand("SELECT System, AuthecticationGrName , GroupName, Description, SystemGroupName, Plant FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND Active = 'true' AND AccessLevel > 0 order by GroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
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


            if (DropDownList2.Items.Count < 1)
            {
                conn.Open();
                command = new SqlCommand("SELECT AGroupID, AuthecticationGrName FROM AuthecticationGroups", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();
                DropDownList2.DataSource = dt2;
                DropDownList2.DataTextField = "AuthecticationGrName";
                DropDownList2.DataValueField = "AGroupID";
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
            SqlCommand command = new SqlCommand("SELECT System, AuthecticationGrName , GroupName, Description, SystemGroupName, Plant FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }
    }
}