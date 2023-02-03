using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;

namespace Aplikacja_1._0._2
{
    public partial class UserSystems : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT EmpID, FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedItem.Text, TextBox3.Text, TextBox4.Text) + " order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

                GridView1.DataSource = dt;
                GridView1.DataBind();
            if (dt.Rows.Count != 0)
            {
                hiddencolumns();
            }
            dt.Clear();
        }


        private void LoadGridData2()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //  SqlCommand command = new SqlCommand("Select sysuser.UserID, syst.System, syst.AuthecticationGrName, sysuser.Login from SystemUsers_v1 as sysuser INNER JOIN Systems_v1 as syst on sysuser.AutenticationGroup = syst.ATypeID join SystemAccessLevels as A on syst.System_ID = A.SystemID join WHERE sysuser.EmpID = " + HiddenEmpID.Value + " AND A.NetID = '" + Session["Login"] + "' AND A.AccessLevelID > 0 AND B.GroupName is not null", conn);
            //  SqlCommand command = new SqlCommand("Select sysuser.UserID, syst.System, syst.AuthecticationGrName, sysuser.Login from SystemUsers_v1 as sysuser INNER JOIN Systems_v1 as syst on sysuser.AutenticationGroup = syst.ATypeID join SystemAccessLevels as A on syst.System_ID = A.SystemID  WHERE sysuser.EmpID = " + HiddenEmpID.Value + " AND A.NetID = '" + Session["Login"] + "' AND A.AccessLevelID > 0", conn);

            SqlCommand command = new SqlCommand("Select b.UserID, a.System, b.AuthecticationGrName, a.Login from (GroupMembers_v1 as A join SystemUsers_v1 as B on a.UserID = b.UserID)  join SystemAccessLevels as D on A.System_ID = D.SystemID WHERE b.EmpID = " + HiddenEmpID.Value + " AND d.NetID = '" + Session["Login"] + "' AND d.AccessLevelID > 0", conn);

            dt.Load(command.ExecuteReader());
            conn.Close();

                GridView2.DataSource = dt;
                GridView2.DataBind();
            if (dt.Rows.Count != 0)
            {
                hiddencolumns2();
            }
            dt.Clear();
        }


        private void LoadGridData3()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT GroupName, TicketNo, DT, Author FROM GroupMembers_v1 where UserID = " + HiddenTextBox2.Value + " AND Status_ID = 1", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            if (dt.Rows.Count != 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            dt.Clear();
        }



        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridData();
        }


        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData2();
        }

        protected void GridView3_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            LoadGridData3();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                //   e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                //   e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView3, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                //   e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
            for (int j = 0; j < GridView1.Rows.Count; j++)
                GridView1.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView1.SelectedIndex;
            if (HiddenEmpID.Value != GridView1.Rows[i].Cells[0].Text)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenEmpID.Value = GridView1.Rows[i].Cells[0].Text;

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();

                    //  SqlCommand command = new SqlCommand("Select sysuser.UserID, syst.System, syst.AuthecticationGrName, sysuser.Login , b.login from SystemUsers_v1 as sysuser INNER JOIN Systems_v1 as syst on sysuser.AutenticationGroup = syst.ATypeID join SystemAccessLevels as A on syst.System_ID = A.SystemID join GroupMembers_v1 as B on sysuser.UserID = B.UserID WHERE sysuser.EmpID = " + HiddenEmpID.Value + " AND A.NetID = '" + Session["Login"] + "' AND A.AccessLevelID > 0 AND B.GroupName is not null", conn);
                    //  SqlCommand command = new SqlCommand("Select sysuser.UserID, syst.System, syst.AuthecticationGrName, sysuser.Login from SystemUsers_v1 as sysuser INNER JOIN Systems_v1 as syst on sysuser.AutenticationGroup = syst.ATypeID join SystemAccessLevels as A on syst.System_ID = A.SystemID  WHERE sysuser.EmpID = "+ HiddenEmpID.Value + " AND A.NetID = '" + Session["Login"] + "' AND A.AccessLevelID > 0", conn);


                    SqlCommand command = new SqlCommand("Select b.UserID, a.System, b.AuthecticationGrName, a.Login from (GroupMembers_v1 as A join SystemUsers_v1 as B on a.UserID = b.UserID)  join SystemAccessLevels as D on A.System_ID = D.SystemID WHERE b.EmpID = " + HiddenEmpID.Value + " AND d.NetID = '" + Session["Login"] + "' AND d.AccessLevelID > 0", conn);

                    dt.Load(command.ExecuteReader());
                    conn.Close();
                    if (dt.Rows.Count == 0)
                    ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);

                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                    if (dt.Rows.Count != 0)
                    {
                        hiddencolumns2();
                    }
                        dt.Clear();
                    
                }
                catch { ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true); }


            }
            else
            {
                HiddenEmpID.Value = "";

            } 
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");


            int i = GridView2.SelectedIndex;
            if (HiddenTextBox2.Value != GridView2.Rows[i].Cells[0].Text)
            {
                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox2.Value = GridView2.Rows[i].Cells[0].Text;
                HiddenTextBox3.Value = GridView2.Rows[i].Cells[1].Text;

                try
                {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT RecID, GroupName, TicketNo, DT, Author FROM GroupMembers_v1 where UserID = " + HiddenTextBox2.Value + "AND System = '" + GridView2.Rows[i].Cells[1].Text + "' AND Status_ID = 1", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                if(dt.Rows.Count == 0)
                        ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);
                GridView3.DataSource = dt;
                GridView3.DataBind();
                dt.Clear();
                }
                catch { ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true); }

            }
            else
            {
                HiddenTextBox2.Value = "";

            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = GridView3.SelectedIndex;

            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT RecID, System, GroupName, FirstName, LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, TicketNo, Status FROM GroupMembers_v1 where RecID = '" + GridView3.Rows[i].Cells[0].Text +"'" , conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

            HiddenTextBox.Value = dt.Rows[0][0].ToString();
            TextBox7.Text = dt.Rows[0][1].ToString();
            TextBox8.Text = dt.Rows[0][2].ToString();
            TextBox9.Text = dt.Rows[0][3].ToString();
            TextBox10.Text = dt.Rows[0][4].ToString();
            TextBox11.Text = dt.Rows[0][5].ToString();
            TextBox12.Text = dt.Rows[0][6].ToString();
            TextBox13.Text = dt.Rows[0][7].ToString();
            TextBox14.Text = dt.Rows[0][8].ToString();
            TextBox15.Text = dt.Rows[0][9].ToString();
            TextBox16.Text = dt.Rows[0][10].ToString();
            TextBox17.Text = dt.Rows[0][11].ToString();


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


                command = new SqlCommand("INSERT INTO Mail_To (Mail_From, Mail_To, Subject, body, Date1, Status) VALUES('ITSystemsBWI@bwigroup.com', 'jacek.maj@bwigroup.com ; krzysztof.czekanski@bwigroup.com', 'Delete user on system: " + TextBox7.Text + "' , ' This is a test email generated by IAM' , getdate(), ' 0 ')", conn);
                //      command = new SqlCommand("INSERT INTO Mail_To (Mail_From, Mail_To, Subject, body, Date1, Status) VALUES('ITSystemsBWI@bwigroup.com', '" + HiddenEmail.Value + "', 'Delete user on system: " + TextBox7.Text + "' , ' This is a test email generated by IAM' , getdate(), ' 0 ')", conn);


                command.ExecuteNonQuery();
                conn.Close();



                DataTable dt = new DataTable();
                dt.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT RecID, GroupName, TicketNo, DT, Author FROM GroupMembers_v1 where UserID = " + HiddenTextBox2.Value + "AND System = '" + HiddenTextBox3.Value + "' AND Status_ID = 1", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                if (dt.Rows.Count == 0)
                    ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);
                GridView3.DataSource = dt;
                GridView3.DataBind();
                dt.Clear();





                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Status changed to - to be deleted and an e-mail was sent to the owner of the system');", true);
            }
            catch
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
            }


        }


            public void hiddencolumns()
        {
            GridView1.HeaderRow.Cells[0].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView1.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
            }
        }


        public void hiddencolumns2()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
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
                SqlCommand command = new SqlCommand("SELECT EmpID, FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1 order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();   
                }
                dt.Clear();

                DataTable dt2 = new DataTable();
                if (DropDownList1.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT PlantID, Plant FROM Plants", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "Plant";
                    DropDownList1.DataValueField = "PlantID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }
            }

        }


        public static string buduj_warunek(string FirstName, string LastName, string Plant, string BWIEmplNo, string PlantIDNo)
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

        protected void Button1_Click(object sender, EventArgs e)
        {

                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT EmpID, FirstName, LastName, Department, Plant, BWIEmplNo, PlantIDNo FROM Employees_v1  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedItem.Text, TextBox3.Text, TextBox4.Text) + " order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();

                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (dt.Rows.Count != 0)
                {
                hiddencolumns();
                }

                HiddenEmpID.Value = "";
                HiddenTextBox2.Value = "";
                GridView2.DataSource = null;
                GridView2.DataBind();
                GridView3.DataSource = null;
                GridView3.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }

    }
}