using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Web.UI;

namespace Aplikacja_1._0._2
{
    public partial class SystemUsersView : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 order by UserID desc", conn);
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

        public static string buduj_warunek(string AuthecticationGrName, string FirstName, string LastName, string Login, string Department, string Plant, string BWIEmplNo, string PlantIDNo)
        {
            string warunek = "";
            // bool pierwszy = true;

            if (AuthecticationGrName != "")
                warunek += " AuthecticationGrName LIKE '%" + AuthecticationGrName + "%'";
            else
                warunek += " AuthecticationGrName LIKE '%'";

            if (FirstName != "")
                warunek += "AND  FirstName LIKE '" + FirstName + "%'";
            else
                warunek += "AND FirstName LIKE '%'";

            if (LastName != "")
                warunek += "AND LastName LIKE '" + LastName + "%'";
            else
                warunek += "AND LastName LIKE '%'";

            if (Login != "")
                warunek += "AND Login LIKE '%" + Login + "%'";
            else
                warunek += "AND Login LIKE '%'";

            if (Department != "")
                warunek += "AND Department LIKE '%" + Department + "%'";
            else
                warunek += "AND Department LIKE '%'";

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
            SqlCommand command = new SqlCommand("SELECT AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 order by UserID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();

            DataTable dt2 = new DataTable();

            if (DropDownList1.Items.Count < 1)
            {
                conn.Open();
                command = new SqlCommand("SELECT AGroupID, AuthecticationGrName FROM AuthecticationGroups", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();
                DropDownList1.DataSource = dt2;
                DropDownList1.DataTextField = "AuthecticationGrName";
                DropDownList1.DataValueField = "AGroupID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                dt2.Clear();
            }

            if (DropDownList2.Items.Count < 1)
            {
                conn.Open();
                command = new SqlCommand("SELECT DepartmentID, Department FROM Departments", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();
                DropDownList2.DataSource = dt2;
                DropDownList2.DataTextField = "Department";
                DropDownList2.DataValueField = "DepartmentID";
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
            SqlCommand command = new SqlCommand("SELECT AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, TextBox4.Text, TextBox5.Text) + " order by UserID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind(); 
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }
    }
}