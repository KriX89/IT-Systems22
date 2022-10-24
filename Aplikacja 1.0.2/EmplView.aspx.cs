using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Web.UI;

namespace Aplikacja_1._0._2
{
    public partial class EmplView : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1 WHERE "+ buduj_warunek(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox3.Text, TextBox4.Text) + " order by EmpID desc", conn);
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

        public static string buduj_warunek(string FirstName, string LastName, string Department, string Plant, string BWIEmplNo, string PlantIDNo)
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

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1 order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();

                DataTable dt2 = new DataTable();
                if (DropDownList1.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT DepartmentID, Department FROM Departments", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "Department";
                    DropDownList1.DataValueField = "DepartmentID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }


                if (DropDownList2.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList2.DataSource = dt2;
                    DropDownList2.DataTextField = "Plant";
                    DropDownList2.DataValueField = "PlantID";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1  WHERE "+buduj_warunek(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox3.Text, TextBox4.Text)+ " order by EmpID desc", conn);
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