using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using ListItem = System.Web.UI.WebControls.ListItem;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using System.Reflection.Emit;

namespace Aplikacja_1._0._2
{
    public partial class AccessGroupsEdit : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[8].Attributes.Add("style", "display:none");
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[8].Attributes.Add("style", "display:none");
            }
        }

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
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
            if (HiddenGroupID.Value != GridView2.Rows[i].Cells[0].Text)
            {
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenGroupID.Value = GridView2.Rows[i].Cells[0].Text;
                DropDownList4.SelectedValue = GridView2.Rows[i].Cells[8].Text;
                TextBox4.Text = GridView2.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                TextBox5.Text = GridView2.Rows[i].Cells[4].Text.Replace("&#243;", "ó");
                TextBox6.Text = GridView2.Rows[i].Cells[5].Text.Replace("&#243;", "ó");

                CheckBox chk = GridView2.Rows[i].Cells[7].Controls[0] as CheckBox;
                CheckBox1.Checked = chk.Checked;
            }
            else
            {
                HiddenGroupID.Value = "";
                DropDownList4.SelectedValue = String.Empty;
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                CheckBox1.Checked = true;
            }
        }



        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        public static string buduj_warunek(string System, string AuthecticationGrName, string GroupName, string Description, string SystemGroupName, string Plant, string NetID)
        {
            string warunek = "NetID = '" + NetID + "' AND AccessLevelID = 2 ";
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
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 order by GroupID desc", conn);
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
                    command = new SqlCommand("SELECT System_ID, System FROM Systems as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] +"' AND AccessLevelID = 2", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "System";
                    DropDownList1.DataValueField = "System_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    DropDownList4.DataSource = dt2;
                    DropDownList4.DataTextField = "System";
                    DropDownList4.DataValueField = "System_ID";
                    DropDownList4.DataBind();
                    DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));

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




        }

        protected void clearAll()
        {
            HiddenGroupID.Value = "";
            DropDownList4.SelectedValue = String.Empty;
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            CheckBox1.Checked = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO SystemAccessGroups VALUES('" + DropDownList4.SelectedItem.Value + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + CheckBox1.Checked + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();




                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 order by GroupID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns();



                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row Added.');", true);
                clearAll();
            }
            catch
            {
                clearAll();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }

        }



        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE SystemAccessGroups SET SystemID = '" + DropDownList4.SelectedItem.Value + "', GroupName = '" + TextBox4.Text + "', Description = '" + TextBox5.Text + "', SystemGroupName = '" + TextBox6.Text + "', Active = '" + CheckBox1.Checked + "' WHERE GroupID = " + HiddenGroupID.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 order by GroupID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns();

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row Updated.');", true);
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

        protected void Button7_Click(object sender, EventArgs e)
        {
            clearAll();
            Button3.Visible = true;
            Button4.Visible = false;
            Label17.Text = "Add new system access group";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Button3.Visible = false;
            Button4.Visible = true;
            Label17.Text = "Change selected system access group";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
        }


    }
}