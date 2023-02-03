using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacja_1._0._2
{
    public partial class SystemsEdit : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";



        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[8].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[9].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[10].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[11].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[14].Attributes.Add("style", "display:none");
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[8].Attributes.Add("style", "display:none");
                gvr.Cells[9].Attributes.Add("style", "display:none");
                gvr.Cells[10].Attributes.Add("style", "display:none");
                gvr.Cells[11].Attributes.Add("style", "display:none");
                gvr.Cells[14].Attributes.Add("style", "display:none");
            }
        }


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.*, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID  WHERE " + buduj_warunek(TextBox1.Text, DropDownList8.SelectedItem.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text) + " order by A.System_ID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

                GridView2.DataSource = dt;
                GridView2.DataBind();
                
            if (dt.Rows.Count != 0)
            {
                hiddencolumns();
            }
            dt.Clear();
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Support Group: "+(e.Row.DataItem as DataRowView)[14].ToString().Replace("&#243;", "ó");
                e.Row.Attributes["style"] = "cursor:pointer";
                //     e.Row.ToolTip = GridView2.Rows[e.Row.RowIndex].Cells[14].Text.Replace("&#243;", "ó");
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView2.SelectedIndex;
            if (HiddenTextBox.Value != GridView2.Rows[i].Cells[0].Text)
            {
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox.Value = GridView2.Rows[i].Cells[0].Text;
                TextBox2.Text = GridView2.Rows[i].Cells[1].Text;
                DropDownList4.SelectedValue = GridView2.Rows[i].Cells[8].Text;
                DropDownList5.SelectedValue = GridView2.Rows[i].Cells[9].Text;
                DropDownList6.SelectedValue = GridView2.Rows[i].Cells[10].Text;
                TextBox3.Text = GridView2.Rows[i].Cells[5].Text.Replace("&#243;", "ó");
                TextBox4.Text = GridView2.Rows[i].Cells[6].Text.Replace("&#243;", "ó");
                DropDownList7.SelectedValue = GridView2.Rows[i].Cells[11].Text;
                CheckBox chk = GridView2.Rows[i].Cells[12].Controls[0] as CheckBox;
                CheckBox1.Checked = chk.Checked;
                TextBox5.Text = GridView2.Rows[i].Cells[13].Text.Replace("&#243;", "ó");
                TextBox6.Text = GridView2.Rows[i].Cells[14].Text.Replace("&#243;", "ó");
            }
            else
            {
                HiddenTextBox.Value = "";
                TextBox2.Text = "";
                DropDownList4.SelectedValue = String.Empty;
                DropDownList5.SelectedValue = String.Empty;
                DropDownList6.SelectedValue = String.Empty;
                TextBox3.Text = "";
                TextBox4.Text = "";
                DropDownList7.SelectedValue = String.Empty;
                CheckBox1.Checked = true;
                TextBox5.Text = "";
                TextBox6.Text = "";
            }
        }



        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        public static string buduj_warunek(string System, string AuthecticationGrName, string LocationType, string SystemType, string Plant)
        {
            string warunek = "";
            // bool pierwszy = true;

            if (System != "")
                warunek += " A.System LIKE '%" + System + "%'";
            else
                warunek += " A.System LIKE '%'";
            if (AuthecticationGrName != "")
                warunek += "AND  A.AuthecticationGrName LIKE '%" + AuthecticationGrName + "%'";
            else
                warunek += "AND A.AuthecticationGrName LIKE '%'";

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
                SqlCommand command = new SqlCommand("SELECT A.*, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID order by A.System_ID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();         
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt.Clear();

                DataTable dt2 = new DataTable();

                if (DropDownList8.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT AGroupID, AuthecticationGrName FROM AuthecticationGroups", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList8.DataSource = dt2;
                    DropDownList8.DataTextField = "AuthecticationGrName";
                    DropDownList8.DataValueField = "AGroupID";
                    DropDownList8.DataBind();
                    DropDownList8.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();

                    conn.Open();
                    command = new SqlCommand("SELECT AGroupID, AuthecticationGrName FROM AuthecticationGroups WHERE Active = 'true'", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList4.DataSource = dt2;
                    DropDownList4.DataTextField = "AuthecticationGrName";
                    DropDownList4.DataValueField = "AGroupID";
                    DropDownList4.DataBind();
                    DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    dt2.Clear();
                }


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

                    conn.Open();
                    command = new SqlCommand("SELECT LocTypeID, LocationType FROM LocationTypes WHERE Active = 'true'", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList5.DataSource = dt2;
                    DropDownList5.DataTextField = "LocationType";
                    DropDownList5.DataValueField = "LocTypeID";
                    DropDownList5.DataBind();
                    DropDownList5.Items.Insert(0, new ListItem(String.Empty, String.Empty));
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

                    conn.Open();
                    command = new SqlCommand("SELECT SystemTypeID, SystemType FROM SystemTypes WHERE Active = 'true'", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList6.DataSource = dt2;
                    DropDownList6.DataTextField = "SystemType";
                    DropDownList6.DataValueField = "SystemTypeID";
                    DropDownList6.DataBind();
                    DropDownList6.Items.Insert(0, new ListItem(String.Empty, String.Empty));
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

                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants  WHERE Active = 'true'", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList7.DataSource = dt2;
                    DropDownList7.DataTextField = "Plant";
                    DropDownList7.DataValueField = "PlantID";
                    DropDownList7.DataBind();
                    DropDownList7.Items.Insert(0, new ListItem(String.Empty, String.Empty));
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
            SqlCommand command = new SqlCommand("SELECT A.*, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID  WHERE " + buduj_warunek(TextBox1.Text, DropDownList8.SelectedItem.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text) + " order by A.System_ID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

                GridView2.DataSource = dt;
                GridView2.DataBind();
            if (dt.Rows.Count != 0)
            {
                hiddencolumns();
            }
            else
            {
                Label29.Text = "Nothing found.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openKomunikatModal();", true);
            }
          //  TextBox7.Text = "SELECT A.*, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID  WHERE " + buduj_warunek(TextBox1.Text, DropDownList8.SelectedItem.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text) + " order by A.System_ID desc";
        }

        protected void clearAll()
        {
            HiddenTextBox.Value = "";
            DropDownList4.SelectedValue = String.Empty;
            DropDownList5.SelectedValue = String.Empty;
            DropDownList6.SelectedValue = String.Empty;
            DropDownList7.SelectedValue = String.Empty;
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            CheckBox1.Checked = true;
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Systems VALUES('" + TextBox2.Text + "', '" + DropDownList4.SelectedItem.Value + "', '" + DropDownList5.SelectedItem.Value + "', '" + DropDownList6.SelectedItem.Value + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "',  '" + DropDownList7.SelectedItem.Value + "', '" + CheckBox1.Checked + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();


                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT A.*, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID order by A.System_ID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row added.');", true);
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
                SqlCommand command = new SqlCommand("UPDATE Systems SET System = '" + TextBox2.Text + "', ATypeID = '" + DropDownList4.SelectedItem.Value + "', SystemLocationID = '" + DropDownList5.SelectedItem.Value + "', SystemTypeID = '" + DropDownList6.SelectedItem.Value + "', Vendor = '" + TextBox3.Text + "', PhysicalLocation = '" + TextBox4.Text + "', PlantID = '" + DropDownList7.SelectedItem.Value + "', Active = '" + CheckBox1.Checked + "', SupportEmail = '" + TextBox5.Text + "' , SupportGroup = '" + TextBox6.Text + "' WHERE System_ID = " + HiddenTextBox.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();

                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT A.*, B.SupportEmail, B.SupportGroup FROM Systems_v1 as A join Systems as B on A.System_ID = B.System_ID order by A.System_ID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Row updated.');", true);
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
            Label16.Text = "Add new system";
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
                Button3.Visible = false;
                Button4.Visible = true;
                Label16.Text = "Change selected system";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
            }
        }
    }
}