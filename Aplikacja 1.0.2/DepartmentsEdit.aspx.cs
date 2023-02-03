﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_1._0._2
{
    public partial class DepartmentsEdit : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";


        public void hiddencolumns()
        {
            GridView1.HeaderRow.Cells[2].Attributes.Add("style", "display:none");
            GridView1.HeaderRow.Cells[4].Attributes.Add("style", "display:none");
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                gvr.Cells[2].Attributes.Add("style", "display:none");
                gvr.Cells[4].Attributes.Add("style", "display:none");
            }
        }


        private void LoadGridData()
        {
            DataTable dt2 = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Departments_v1", conn);
            dt2.Load(command.ExecuteReader());
            conn.Close();

                GridView1.DataSource = dt2;
                GridView1.DataBind();
                
            if (dt2.Rows.Count != 0)
            {
                hiddencolumns();
            }
            dt2.Clear();
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                   e.Row.ToolTip = "Click to select this row.";
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView1.Rows.Count; j++)
                GridView1.Rows[j].BackColor = System.Drawing.Color.FromName("0");

            int i = GridView1.SelectedIndex;
            if (HiddenTextBox.Value != GridView1.Rows[i].Cells[4].Text)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox.Value = GridView1.Rows[i].Cells[4].Text;
                DropDownList1.SelectedValue = GridView1.Rows[i].Cells[2].Text;
                TextBox1.Text = GridView1.Rows[i].Cells[1].Text.Replace("&#243;", "ó");
                CheckBox chk = GridView1.Rows[i].Cells[3].Controls[0] as CheckBox;
                CheckBox1.Checked = chk.Checked;
            }
            else
            {
                HiddenTextBox.Value = "";
                DropDownList1.SelectedValue = String.Empty;
                TextBox1.Text = "";
                CheckBox1.Checked = true;
            }
        }



        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
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
                DataTable dt2 = new DataTable();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Departments_v1", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();

                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    
                if (dt2.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt2.Clear();


                if (DropDownList1.Items.Count < 1)
                {
                    DataTable dt = new DataTable();
                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                    dt.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "Plant";
                    DropDownList1.DataValueField = "PlantID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }
            }
        }

        protected void clearAll()
        {
            HiddenTextBox.Value = "";
            DropDownList1.SelectedValue = String.Empty;
            TextBox1.Text = "";
            CheckBox1.Checked = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Departments VALUES('" + DropDownList1.SelectedItem.Value + "', '" + TextBox1.Text + "', '" + CheckBox1.Checked + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();

                DataTable dt2 = new DataTable();
                conn.Open();
                command = new SqlCommand("SELECT * FROM Departments_v1", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();

                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    dt2.Clear();
                if (dt2.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row added.');", true);
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
                SqlCommand command = new SqlCommand("UPDATE Departments SET Plant_ID = '" + DropDownList1.SelectedValue + "', Department = '" + TextBox1.Text + "', Active = '" + CheckBox1.Checked + "' WHERE DepartmentID = " + HiddenTextBox.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();

                DataTable dt2 = new DataTable();
                conn.Open();
                command = new SqlCommand("SELECT * FROM Departments_v1", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();

                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    
                if (dt2.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt2.Clear();
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row updated.');", true);
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
            Label17.Text = "Add new department";
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
                Label17.Text = "Change selected department";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);

                

            }
        }



    }
}