using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Data.SqlClient;
using System;
using CheckBox = System.Web.UI.WebControls.CheckBox;

namespace Aplikacja_1._0._2
{
    public partial class GroupMembersEdit : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.RecID, A.System, A.GroupName, A.FirstName, A.LastName, A.Login, A.Department, A.Plant, A.BWIEmplNo, A.PlantIDNo, A.TicketNo, C.SupportEmail, C.SupportGroup, CONVERT(char(10), A.ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList4.SelectedItem.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, Session["Login"].ToString(), DropDownList2.SelectedItem.Text) + " order by A.RecID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();
            hiddencolumns();
        }


        public void hiddencolumns()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[11].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[12].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[11].Attributes.Add("style", "display:none");
                gvr.Cells[12].Attributes.Add("style", "display:none");
            }
        }



        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        public static string buduj_warunek(string System, string FirstName, string LastName, string Login, string Plant, string BWIEmplNo, string PlantIDNo, string TicketNo, string NetID, string Status)
        {
            string warunek = "B.NetID = '" + NetID + "' AND B.AccessLevelID = 2 ";
            // bool pierwszy = true;

            if (System != "")
                warunek += "AND A.System LIKE '%" + System + "%'";
            else
                warunek += "AND A.System LIKE '%'";

            if (FirstName != "")
                warunek += "AND  A.FirstName LIKE '" + FirstName + "%'";
            else
                warunek += "AND A.FirstName LIKE '%'";

            if (LastName != "")
                warunek += "AND A.LastName LIKE '" + LastName + "%'";
            else
                warunek += "AND A.LastName LIKE '%'";

            if (Login != "")
                warunek += "AND A.Login LIKE '%" + Login + "%'";
            else
                warunek += "AND A.Login LIKE '%'";

            if (Plant != "")
                warunek += "AND A.Plant LIKE '%" + Plant + "%'";
            else
                warunek += "AND A.Plant LIKE '%'";

            if (BWIEmplNo != "")
                warunek += "AND A.BWIEmplNo LIKE '%" + BWIEmplNo + "%'";
            else
                warunek += "AND A.BWIEmplNo LIKE '%'";

            if (PlantIDNo != "")
                warunek += "AND A.PlantIDNo LIKE '%" + PlantIDNo + "%'";
            else
                warunek += "AND A.PlantIDNo LIKE '%'";

            if (TicketNo != "")
                warunek += "AND A.TicketNo LIKE '%" + TicketNo + "%'";
            else
                warunek += "AND A.TicketNo LIKE '%'";

            if (Status != "")
                warunek += "AND A.Status = '" + Status + "'";
            else
                warunek += "AND A.Status LIKE '%'";


            return warunek;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Support Email: " + (e.Row.DataItem as DataRowView)[11].ToString().Replace("&#243;", "ó");
                e.Row.ToolTip += "\nSupport Group: " + (e.Row.DataItem as DataRowView)[12].ToString().Replace("&#243;", "ó");
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");

            int i = GridView2.SelectedIndex;
            if (HiddenTextBox.Value != GridView2.Rows[i].Cells[0].Text)
            {
                HiddenTextBox.Value = GridView2.Rows[i].Cells[0].Text;
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                TextBox7.Text = GridView2.Rows[i].Cells[1].Text.Replace("&#243;", "ó");
                TextBox8.Text = GridView2.Rows[i].Cells[2].Text.Replace("&#243;", "ó");
                TextBox9.Text = GridView2.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                TextBox10.Text = GridView2.Rows[i].Cells[4].Text.Replace("&#243;", "ó");
                TextBox11.Text = GridView2.Rows[i].Cells[5].Text.Replace("&#243;", "ó");
                TextBox12.Text = GridView2.Rows[i].Cells[6].Text.Replace("&#243;", "ó");
                TextBox13.Text = GridView2.Rows[i].Cells[7].Text.Replace("&#243;", "ó");
                TextBox14.Text = GridView2.Rows[i].Cells[8].Text.Replace("&#243;", "ó");
                TextBox15.Text = GridView2.Rows[i].Cells[9].Text.Replace("&#243;", "ó");
                TextBox16.Text = GridView2.Rows[i].Cells[10].Text.Replace("&nbsp;", "");
                HiddenEmail.Value = GridView2.Rows[i].Cells[11].Text.Replace("&#243;", "ó");
                TextBox17.Text = GridView2.Rows[i].Cells[14].Text;

            }
            else
            {
                HiddenEmail.Value = "";
                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                TextBox17.Text = "";
            }
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
                SqlCommand command = new SqlCommand("SELECT A.RecID, A.System, A.GroupName, A.FirstName, A.LastName, A.Login, A.Department, A.Plant, A.BWIEmplNo, A.PlantIDNo, A.TicketNo, C.SupportEmail, C.SupportGroup, CONVERT(char(10), A.ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '" + Session["Login"] + "' AND B.AccessLevelID = 2 order by A.RecID desc", conn);
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



                if (DropDownList4.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList4.DataSource = dt2;
                    DropDownList4.DataTextField = "Plant";
                    DropDownList4.DataValueField = "PlantID";
                    DropDownList4.DataBind();
                    DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }

                if (DropDownList2.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT Status_ID, Status FROM GroupMembersStatuses", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList2.DataSource = dt2;
                    DropDownList2.DataTextField = "Status";
                    DropDownList2.DataValueField = "Status_ID";
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
            SqlCommand command = new SqlCommand("SELECT A.RecID, A.System, A.GroupName, A.FirstName, A.LastName, A.Login, A.Department, A.Plant, A.BWIEmplNo, A.PlantIDNo, A.TicketNo, C.SupportEmail, C.SupportGroup, CONVERT(char(10), A.ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList4.SelectedItem.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, Session["Login"].ToString(), DropDownList2.SelectedItem.Text) + " order by A.RecID desc", conn);
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
                SqlCommand command = new SqlCommand("UPDATE GroupMembers SET Status_ID = 3 WHERE RecID = " + HiddenTextBox.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();

                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                TextBox17.Text = "";

                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT A.RecID, A.System, A.GroupName, A.FirstName, A.LastName, A.Login, A.Department, A.Plant, A.BWIEmplNo, A.PlantIDNo, A.TicketNo, C.SupportEmail, C.SupportGroup,  CONVERT(char(10), A.ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '" + Session["Login"] + "' AND B.AccessLevelID = 2 order by A.RecID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                hiddencolumns();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Status changed to - deleted');", true);
            }
            catch
            {
                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                TextBox17.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox17.Text == "Active")
            {
                Button3.Visible = false;
                Button9.Visible = true;
            }

            if (TextBox17.Text == "To be deleted")
            {
                Button3.Visible = true;
                Button9.Visible = false;
            }

            if (TextBox17.Text == "Deleted")
            {
                Button3.Visible = false;
                Button9.Visible = false;
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE GroupMembers SET Status_ID = 2 WHERE RecID = " + HiddenTextBox.Value, conn);
                command.ExecuteNonQuery();
                conn.Close();

                conn.Open();

                command = new SqlCommand("INSERT INTO Mail_To (Mail_From, Mail_To, Subject, body, Date1, Status) VALUES('ITSystemsBWI@bwigroup.com', '" + HiddenEmail.Value + "', 'Delete user on system: " + TextBox7.Text + "' , ' body ' , getdate(), ' 0 ')", conn);


                command.ExecuteNonQuery();
                conn.Close();

                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                TextBox17.Text = "";

                DataTable dt = new DataTable();
                dt.Clear();
                conn.Open();
                command = new SqlCommand("SELECT A.RecID, A.System, A.GroupName, A.FirstName, A.LastName, A.Login, A.Department, A.Plant, A.BWIEmplNo, A.PlantIDNo, A.TicketNo, C.SupportEmail, C.SupportGroup,  CONVERT(char(10), A.ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '" + Session["Login"] + "' AND B.AccessLevelID = 2 order by A.RecID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                hiddencolumns();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Status changed to - to be deleted and an e-mail was sent to the owner of the system');", true);
            }
            catch
            {
                HiddenTextBox.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                TextBox17.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }
        }

    }
}