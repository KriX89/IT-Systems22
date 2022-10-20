using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using CheckBox = System.Web.UI.WebControls.CheckBox;

namespace Aplikacja_1._0._2
{
    public partial class SystemUsersEdit : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
            }
        }

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT UserID, AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, Active FROM SystemUsers_v1 WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, TextBox4.Text, TextBox5.Text) + " order by UserID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns();
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


            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT UserID, AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, Active FROM SystemUsers_v1 order by UserID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                hiddencolumns();
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
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                //   e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView2.SelectedIndex;
            if (HiddenEmpID.Value != GridView2.Rows[i].Cells[0].Text)
            {
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenEmpID.Value = GridView2.Rows[i].Cells[0].Text;
                TextBox6.Text = GridView2.Rows[i].Cells[2].Text.Replace("&#243;", "ó");
                TextBox7.Text = GridView2.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                TextBox8.Text = GridView2.Rows[i].Cells[4].Text.Replace("&#243;", "ó");
                CheckBox chk = GridView2.Rows[i].Cells[9].Controls[0] as CheckBox;
                CheckBox1.Checked = chk.Checked;  
            }
            else
            {
                HiddenEmpID.Value = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                CheckBox1.Checked = true;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT UserID, AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, Active FROM SystemUsers_v1 WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, TextBox4.Text, TextBox5.Text) + " order by UserID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns();
        }

        protected void clearAll()
        {
            HiddenEmpID.Value = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            CheckBox1.Checked = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE SystemUsers_v1 SET Login = '" + TextBox8.Text + "', Active = '" + CheckBox1.Checked + "' WHERE UserID = " + HiddenEmpID.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();


                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT UserID, AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, Active FROM SystemUsers_v1 order by UserID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                hiddencolumns();
                dt.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('User updated.');", true);
                clearAll();
            }
            catch
            {
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }


        protected void Button8_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }


    }
}