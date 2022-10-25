using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Aplikacja_1._0._2
{
    public partial class GroupMembersAdd : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";

        public static string buduj_warunek(string System, string AuthecticationGrName, string GroupName, string SystemGroupName, string Plant, string NetID)
        {
            string warunek = " A.Active = 'true'";
            // bool pierwszy = true;

            if (System != "")
                warunek += "AND A.System LIKE '%" + System + "%'";
            else
                warunek += "AND A.System LIKE '%'";

            if (AuthecticationGrName != "")
                warunek += "AND A.AuthecticationGrName LIKE '%" + AuthecticationGrName + "%'";
            else
                warunek += "AND A.AuthecticationGrName LIKE '%'";

            if (GroupName != "")
                warunek += "AND  A.GroupName LIKE '%" + GroupName + "%'";
            else
                warunek += "AND A.GroupName LIKE '%'";

            if (SystemGroupName != "")
                warunek += "AND  A.SystemGroupName LIKE '%" + SystemGroupName + "%'";
            else
                warunek += "AND A.SystemGroupName LIKE '%'";

            if (Plant != "")
                warunek += "AND  A.Plant LIKE '%" + Plant + "%'";
            else
                warunek += "AND A.Plant LIKE '%'";



                warunek += "AND  NetID = '" + NetID + "' AND AccessLevel = 2 ";


            return warunek;
        }



        public static string buduj_warunek2(string FirstName, string LastName, string Plant, string BWIEmplNo, string PlantIDNo)
        {
            string warunek = "AND Active = 'true'";
            // bool pierwszy = true;

            if (FirstName != "")
                warunek += "AND FirstName LIKE '" + FirstName + "%'";
            else
                warunek += "AND FirstName LIKE '%'";

            if (LastName != "")
                warunek += "AND LastName LIKE '" + LastName + "%'";
            else
                warunek += "AND LastName LIKE '%'";

            if (Plant != "")
                warunek += "AND  Plant LIKE '%" + Plant + "%'";
            else
                warunek += "AND Plant LIKE '%'";

            if (BWIEmplNo != "")
                warunek += "AND  BWIEmplNo LIKE '%" + BWIEmplNo + "%'";
            else
                warunek += "AND BWIEmplNo LIKE '%'";

            if (PlantIDNo != "")
                warunek += "AND  PlantIDNo LIKE '%" + PlantIDNo + "%'";
            else
                warunek += "AND PlantIDNo LIKE '%'";

            return warunek;
        }



        public void hiddencolumns()
        {
            try
            {
                GridView1.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[4].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[7].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[8].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[9].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[10].Attributes.Add("style", "display:none");

                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    gvr.Cells[0].Attributes.Add("style", "display:none");
                    gvr.Cells[4].Attributes.Add("style", "display:none");
                    gvr.Cells[7].Attributes.Add("style", "display:none");
                    gvr.Cells[8].Attributes.Add("style", "display:none");
                    gvr.Cells[9].Attributes.Add("style", "display:none");
                    gvr.Cells[10].Attributes.Add("style", "display:none");

                }
            }
            catch { }
        }

        public void hiddencolumns2()
        {
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[1].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[5].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[6].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[10].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[11].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[12].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[1].Attributes.Add("style", "display:none");
                gvr.Cells[5].Attributes.Add("style", "display:none");
                gvr.Cells[6].Attributes.Add("style", "display:none");
                gvr.Cells[10].Attributes.Add("style", "display:none");
                gvr.Cells[11].Attributes.Add("style", "display:none");
                gvr.Cells[12].Attributes.Add("style", "display:none");

            }
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);

                e.Row.ToolTip = "Support Email: " + (e.Row.DataItem as DataRowView)[9].ToString().Replace("&#243;", "ó");
                e.Row.ToolTip += "\nSupport Group: " + (e.Row.DataItem as DataRowView)[10].ToString().Replace("&#243;", "ó");
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView1.Rows.Count; j++)
                GridView1.Rows[j].BackColor = System.Drawing.Color.FromName("0");

            int i = GridView1.SelectedIndex;



            if (HiddenTextBox.Value != GridView1.Rows[i].Cells[0].Text)
            {

                GridView1.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox.Value = GridView1.Rows[i].Cells[0].Text;
                HiddenTextBox3.Value = GridView1.Rows[i].Cells[2].Text;

                TextBox9.Text = GridView1.Rows[i].Cells[1].Text.Replace("&#243;", "ó");
                TextBox10.Text = GridView1.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                TextBox11.Text = GridView1.Rows[i].Cells[5].Text.Replace("&#243;", "ó");

                HiddenEmail.Value = GridView1.Rows[i].Cells[9].Text.Replace("&#243;", "ó");


                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM SystemUsers_v1 WHERE Active = 'true' AND AuthecticationGrName = '" + HiddenTextBox3.Value + "'  order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
                hiddencolumns2();

            }
            else
            {
                HiddenTextBox.Value = "";
              //  TextBox6.Text = "";
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


                TextBox12.Text = GridView2.Rows[i].Cells[2].Text.Replace("&#243;", "ó");
                TextBox13.Text = GridView2.Rows[i].Cells[3].Text.Replace("&#243;", "ó");
                TextBox14.Text = GridView2.Rows[i].Cells[7].Text.Replace("&#243;", "ó");
                TextBox15.Text = GridView2.Rows[i].Cells[8].Text.Replace("&#243;", "ó");
                TextBox16.Text = GridView2.Rows[i].Cells[9].Text.Replace("&#243;", "ó");



            }
            else
            {
                HiddenTextBox2.Value = "";
                //  TextBox6.Text = "";
            }

        }



        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.*, C.SupportEmail, C.SupportGroup FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, DropDownList1.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            hiddencolumns();
            dt.Clear();
        }

        private void LoadGridData2()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM SystemUsers_v1 WHERE Active = 'true' AND AuthecticationGrName = '" + HiddenTextBox3.Value + "'  order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns2();
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

                SqlCommand command = new SqlCommand("SELECT A.*, C.SupportEmail, C.SupportGroup FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '"+ Session["Login"] + "' AND A.Active = 'true' AND AccessLevel = 2 order by GroupID desc", conn);

              //  SqlCommand command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '"+ Session["Login"] + "' AND Active = 'true' AND AccessLevel = 2 order by GroupID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                hiddencolumns();
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

            //      WHERE B.NetID = '"+ Session["Login"] + "' AND Active = 'true' order by GroupID desc


       //     SqlCommand command = new SqlCommand("SELECT A.*, C.SupportEmail, C.SupportGroup FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '" + Session["Login"] + "' AND A.Active = 'true' AND AccessLevel = 2 order by GroupID desc", conn);


            SqlCommand command = new SqlCommand("SELECT A.*, C.SupportEmail, C.SupportGroup FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, DropDownList1.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
        //    SqlCommand command = new SqlCommand("SELECT * FROM SystemAccessGroups_v1  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, DropDownList1.SelectedItem.Text) + " order by GroupID desc", conn);

        //    SqlCommand command = new SqlCommand("SELECT * FROM SystemAccessGroups_v1  WHERE " + buduj_warunek(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, DropDownList1.SelectedItem.Text) + " order by GroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            hiddencolumns();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM SystemUsers_v1  WHERE AuthecticationGrName='"+ HiddenTextBox3.Value + "' " + buduj_warunek2(TextBox5.Text, TextBox6.Text, DropDownList2.SelectedItem.Text, TextBox7.Text, TextBox8.Text) + " order by UserID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns2(); 
        }

        protected void clearAll()
        {
            HiddenTextBox.Value = "";
            HiddenTextBox2.Value = "";
            HiddenEmail.Value = "";
         //   TextBox17.Text = "";
        }
        protected void Button5_Click(object sender, EventArgs e)
        {



            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CheckBox1.Checked = false;
            TextBox18.Text = null;
            TextBox19.Text = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }


        protected void Button6_Click(object sender, EventArgs e)
        {


                try
                {
                    SqlConnection conn = new SqlConnection(constr);
                    DataTable dtAccessGroups = new DataTable();
                    dtAccessGroups.Clear();
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT System, AuthecticationGrName, GroupName, Description, SystemGroupName FROM SystemAccessGroups_v1 WHERE GroupID = " + HiddenTextBox.Value, conn);
                    dtAccessGroups.Load(command.ExecuteReader());
                    conn.Close();

                    DataTable dtSystemUser = new DataTable();
                    dtSystemUser.Clear();
                    conn.Open();
                    command = new SqlCommand("SELECT FirstName, LastName, Login, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 WHERE UserID = " + HiddenTextBox2.Value, conn);
                    dtSystemUser.Load(command.ExecuteReader());
                    conn.Close();

                  //  conn.Open();

                  //  if (CheckBox1.Checked)
                 //    command = new SqlCommand("INSERT INTO Mail_To (Mail_From, Mail_To, Subject, body, Date1, Status) VALUES('ITSystemsBWI@bwigroup.com', '" + HiddenEmail.Value + "', 'Add new user on system: " + dtAccessGroups.Rows[0][0] + "' , ' body ' , getdate(), ' 0 ')", conn); 
                 //   else
                  //  { command = new SqlCommand("INSERT INTO GroupMembers (GroupID, UserID, TicketNo, ValidFrom, ValidTo, DT, Author) VALUES('" + HiddenTextBox.Value + "', '" + HiddenTextBox2.Value + "', '" + TextBox19.Text + "' , '" + txtDate.Text + "' , '" + TextBox18.Text + "' , getdate(), '" + Session["Login"] + "')", conn); }

                 //   command.ExecuteNonQuery();
                 //   conn.Close();

           //     TextBox11.Text = "INSERT INTO Mail_To (Mail_From, Mail_To, Subject, body, Date1, Status) VALUES('ITSystemsBWI@bwigroup.com', '" + HiddenEmail.Value + "', 'Add new user on system: " + dtAccessGroups.Rows[0][0] + "' , '" + txtDate.Text + "' , getdate(), ' 0 ')";



                conn.Open();

                    if (CheckBox1.Checked)
                    {  command = new SqlCommand("INSERT INTO GroupMembers (GroupID, UserID, TicketNo, ValidFrom, DT, Author, Status_ID) VALUES('" + HiddenTextBox.Value + "', '" + HiddenTextBox2.Value + "', '" + TextBox19.Text + "' , '" + txtDate.Text + "' , getdate(), '" + Session["Login"] + "', 1)", conn); }
                    else
                    { command = new SqlCommand("INSERT INTO GroupMembers (GroupID, UserID, TicketNo, ValidFrom, ValidTo, DT, Author, Status_ID) VALUES('" + HiddenTextBox.Value + "', '" + HiddenTextBox2.Value + "', '" + TextBox19.Text + "' , '" + txtDate.Text + "' , '" + TextBox18.Text + "' , getdate(), '" + Session["Login"] + "', 1)", conn); }
                    
                    command.ExecuteNonQuery();
                    conn.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('User added.');", true);


                }
                catch
                {
                    clearAll();
                    ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Something went wrong.');", true);
                } 
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal2();", true);
        }


    }
}