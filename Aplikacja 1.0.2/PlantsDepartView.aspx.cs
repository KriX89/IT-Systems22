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
    public partial class PlantsDepartView : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";

        private void LoadGridData()
        {
            DataTable dt2 = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT Plant, Department, Active FROM Departments_v1", conn);
            dt2.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt2;
            GridView1.DataBind();
            dt2.Clear();
        }



        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridData();
        }


        public static string buduj_warunek(string Plant, string Department, bool Active)
        {
            string warunek = "";
            // bool pierwszy = true;

            if (Plant != "")
                warunek += "Plant  LIKE '%" + Plant + "%'";
            else
                warunek += " Plant LIKE '%'";

            if (Department != "")
                warunek += "AND Department LIKE '%" + Department + "%'";
            else
                warunek += "AND Department LIKE '%'";

            if (Active)
                warunek += "AND Active = 1";
            else
                warunek += "AND Active = 0";



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
            SqlCommand command = new SqlCommand("SELECT PlantID, Plant, Active FROM Plants", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();

            DataTable dt2 = new DataTable();
            conn.Open();
            command = new SqlCommand("SELECT Plant, Department, Active FROM Departments_v1", conn);
            dt2.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt2;
            GridView1.DataBind();
            dt2.Clear();


            if (DropDownList1.Items.Count < 1)
            {
                conn.Open();
                command = new SqlCommand("SELECT DepartmentID, Department FROM Departments", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Department";
                DropDownList1.DataValueField = "DepartmentID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                dt.Clear();
            }


            if (DropDownList2.Items.Count < 1)
            {
                conn.Open();
                command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "Plant";
                DropDownList2.DataValueField = "PlantID";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT Plant, Department, Active FROM Departments_v1 WHERE "+buduj_warunek(DropDownList2.SelectedItem.Text, DropDownList1.SelectedItem.Text, CheckBox1.Checked), conn);
            dt2.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt2;
            GridView1.DataBind();
            dt2.Clear();
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }
    }
}