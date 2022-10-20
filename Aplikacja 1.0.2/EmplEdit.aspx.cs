using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using DocumentFormat.OpenXml.Spreadsheet;
using CheckBox = System.Web.UI.WebControls.CheckBox;

namespace Aplikacja_1._0._2
{
    public partial class EmplEdit : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


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

        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[8].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[9].Attributes.Add("style", "display:none");
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[8].Attributes.Add("style", "display:none");
                gvr.Cells[9].Attributes.Add("style", "display:none");
            }
        }

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employees_v1 WHERE "+ buduj_warunek(TextBox5.Text, TextBox6.Text, DropDownList3.SelectedItem.Text, DropDownList4.SelectedItem.Text, TextBox7.Text, TextBox8.Text) + " order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();
            hiddencolumns();
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

                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT DepartmentID, Department FROM Departments", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();
                DropDownList1.DataSource = dt2;
                DropDownList1.DataTextField = "Department";
                DropDownList1.DataValueField = "DepartmentID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                dt2.Clear();


                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenEmpID.Value = GridView2.Rows[i].Cells[0].Text;
                TextBox1.Text = GridView2.Rows[i].Cells[1].Text.Replace("&#243;", "ó");
                TextBox2.Text = GridView2.Rows[i].Cells[2].Text.Replace("&#243;", "ó");
                DropDownList1.SelectedValue = GridView2.Rows[i].Cells[8].Text;
                DropDownList2.SelectedValue = GridView2.Rows[i].Cells[9].Text;
                TextBox3.Text = GridView2.Rows[i].Cells[5].Text.Replace("&#243;", "ó");
                TextBox4.Text = GridView2.Rows[i].Cells[6].Text.Replace("&#243;", "ó");
                CheckBox chk = GridView2.Rows[i].Cells[7].Controls[0] as CheckBox;
                CheckBox1.Checked = chk.Checked;
            }
            else
            {
                HiddenEmpID.Value = "";
                TextBox1.Text = "";
                TextBox2.Text = "";

                DropDownList1.SelectedValue = String.Empty;
                DropDownList2.SelectedValue = String.Empty;

                TextBox3.Text = "";
                TextBox4.Text = "";
                CheckBox1.Checked = true;
            }
        }



        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
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
                SqlCommand command = new SqlCommand("SELECT * FROM Employees_v1 order by EmpID desc", conn);
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
                    command = new SqlCommand("SELECT DepartmentID, Department FROM Departments", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "Department";
                    DropDownList1.DataValueField = "DepartmentID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    DropDownList3.DataSource = dt2;
                    DropDownList3.DataTextField = "Department";
                    DropDownList3.DataValueField = "DepartmentID";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));

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

                    DropDownList4.DataSource = dt2;
                    DropDownList4.DataTextField = "Plant";
                    DropDownList4.DataValueField = "PlantID";
                    DropDownList4.DataBind();
                    DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    dt2.Clear();
                }
            }


        }

        protected void clearAll()
        {
            HiddenEmpID.Value = "";
            DropDownList1.SelectedValue = String.Empty;
            DropDownList2.SelectedValue = String.Empty;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            CheckBox1.Checked = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Employees VALUES('" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', " + DropDownList1.SelectedItem.Value + ",  '" + CheckBox1.Checked + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();

                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT * FROM Employees_v1 order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns();
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
            try { 
                 SqlConnection conn = new SqlConnection(constr);
                 conn.Open();
                 SqlCommand command = new SqlCommand("UPDATE Employees SET BWIEmplNo = '" + TextBox3.Text + "', PlantIDNo = '" + TextBox4.Text + "', FirstName = '" + TextBox1.Text + "', LastName = '" + TextBox2.Text + "', DepartmentID = '" + DropDownList1.SelectedValue + "', Active = '" + CheckBox1.Checked + "' WHERE EmpID = " + HiddenEmpID.Value, conn);
                 command.ExecuteNonQuery();
                 conn.Close();
                 DataTable dt = new DataTable();
                 dt.Clear();
                 conn.Open();
                 command = new SqlCommand("SELECT * FROM Employees_v1 order by EmpID desc", conn);
                 dt.Load(command.ExecuteReader());
                 conn.Close();
                 GridView2.DataSource = dt;
                 GridView2.DataBind();
                 dt.Clear();
                 hiddencolumns();
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

            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employees_v1  WHERE " + buduj_warunek(TextBox5.Text, TextBox6.Text, DropDownList3.SelectedItem.Text, DropDownList4.SelectedItem.Text, TextBox7.Text, TextBox8.Text) + " order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns();

        }



        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

        /*    DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT DepartmentID, Department FROM Departments WHERE Plant_ID = " + DropDownList2.SelectedValue, conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();
                DropDownList1.DataSource = dt2;
                DropDownList1.DataTextField = "Department";
                DropDownList1.DataValueField = "DepartmentID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                dt2.Clear(); */

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }


        protected void Button7_Click(object sender, EventArgs e)
        {
            clearAll();
            Button1.Visible = true;
            Button2.Visible = false;
            Label16.Text = "Add new employee";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Button2.Visible = true;
            Label16.Text = "Change selected emploee";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }



    }
}