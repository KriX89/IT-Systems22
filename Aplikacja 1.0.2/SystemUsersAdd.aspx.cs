using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using DocumentFormat.OpenXml.Spreadsheet;
using System.DirectoryServices;


namespace Aplikacja_1._0._2
{
    public partial class SystemUsersAdd : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        public static string buduj_warunek(string AuthecticationGrName, string ModeName)
        {
            string warunek = " Active = 'true'";
            // bool pierwszy = true;

            if (AuthecticationGrName != "")
                warunek += "AND AuthecticationGrName LIKE '%" + AuthecticationGrName + "%'";
            else
                warunek += "AND AuthecticationGrName LIKE '%'";

            if (ModeName != "")
                warunek += "AND  ModeName LIKE '%" + ModeName + "%'";
            else
                warunek += "AND ModeName LIKE '%'";

            return warunek;
        }

        public static string buduj_warunek2(string FirstName, string LastName, string Department, string Plant, string BWIEmplNo, string PlantIDNo)
        {
            string warunek = " Active = 'true'";
            // bool pierwszy = true;

            if (FirstName != "")
                warunek += "AND FirstName LIKE '" + FirstName + "%'";
            else
                warunek += "AND FirstName LIKE '%'";

            if (LastName != "")
                warunek += "AND  LastName LIKE '" + LastName + "%'";
            else
                warunek += "AND LastName LIKE '%'";

            if (Department != "")
                warunek += "AND  Department LIKE '%" + Department + "%'";
            else
                warunek += "AND Department LIKE '%'";

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
            GridView2.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[3].Attributes.Add("style", "display:none");
            GridView2.HeaderRow.Cells[4].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[3].Attributes.Add("style", "display:none");
                gvr.Cells[4].Attributes.Add("style", "display:none");
            }
        }

        public void hiddencolumns2()
        {
                GridView1.HeaderRow.Cells[0].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[7].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[8].Attributes.Add("style", "display:none");
                GridView1.HeaderRow.Cells[9].Attributes.Add("style", "display:none");

                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    gvr.Cells[0].Attributes.Add("style", "display:none");
                    gvr.Cells[7].Attributes.Add("style", "display:none");
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
            SqlCommand command = new SqlCommand("SELECT * FROM AuthenticationGroups_v1 WHERE Active = 'true' order by AGroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();
            hiddencolumns();
        }

        private void LoadGridData2()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employees_v1  WHERE " + buduj_warunek2(TextBox2.Text, TextBox3.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, TextBox4.Text, TextBox5.Text) + " order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dt.Clear();
            hiddencolumns2();
        }

        private void LoadGridData3()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 order by UserID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView3.DataSource = dt;
            GridView3.DataBind();
            dt.Clear();
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
                GridView2.Rows[j].BackColor = System.Drawing.Color.FromName("0");

            int i = GridView2.SelectedIndex;

            HiddenTextBox2.Value = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";

            if (HiddenTextBox.Value != GridView2.Rows[i].Cells[0].Text)
            {

                GridView2.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox.Value = GridView2.Rows[i].Cells[0].Text;
                TextBox6.Text = GridView2.Rows[i].Cells[1].Text.Replace("&#243;", "ó");

                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Employees_v1 WHERE Active = 'true' order by EmpID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dt.Clear();
                hiddencolumns2();

            }
            else
            {
                HiddenTextBox.Value = "";
                TextBox6.Text = "";
            }

        }

   //     int RowCount = 0;
   /*     protected void GridView4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // get the row index, add onclick attribute for javascript:__doPostBack('GridView1','Select$0')
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "javascript:__doPostBack('" + ((GridView)sender).ID + "','Select$" + (RowCount - 1).ToString() + "')");
                e.Row.Attributes.Add("onmouseover", "JavaScript:this.style.cursor='hand';");

            }
            RowCount++;
        }  */


        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onClick", "javascript:void SelectRow(this);");
             //   e.Row.Attributes.Add("onmousehover", "JavaScript:this.style.cursor='hand';");
                //   e.Row.Attributes.Add("onclick", "javascript:__doPostBack('" + ((GridView)sender).ID + "','Select$" + (RowCount - 1).ToString() + "')");
                //   e.Row.Attributes.Add("onmouseover", "JavaScript:this.style.cursor='hand';");

                //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView4, "Select$" + e.Row.RowIndex);
            }
        }


 /*       protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView4.Rows.Count; j++)
                GridView4.Rows[j].BackColor = System.Drawing.Color.FromName("0");

            int i = GridView4.SelectedIndex;


            if (HiddenField1.Value != GridView4.Rows[i].Cells[2].Text)
            {

                GridView4.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenField1.Value = GridView4.Rows[i].Cells[2].Text;
                TextBox12.Text = GridView4.Rows[i].Cells[2].Text;


            }
            else
            {
                HiddenField1.Value = "";
            }

        } */






        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox12.Text = "";
            for (int j = 0; j < GridView1.Rows.Count; j++)
                GridView1.Rows[j].BackColor = System.Drawing.Color.FromName("0");

            int i = GridView1.SelectedIndex;

            if (HiddenTextBox2.Value != GridView1.Rows[i].Cells[0].Text)
            {

                GridView1.Rows[i].BackColor = System.Drawing.Color.White;
                HiddenTextBox2.Value = GridView1.Rows[i].Cells[0].Text;
                TextBox7.Text = GridView1.Rows[i].Cells[1].Text.Replace("&#243;","ó");
                TextBox8.Text = GridView1.Rows[i].Cells[2].Text.Replace("&#243;", "ó");
                TextBox9.Text = GridView1.Rows[i].Cells[4].Text.Replace("&#243;", "ó");
                TextBox10.Text = GridView1.Rows[i].Cells[5].Text.Replace("&#243;", "ó");
                TextBox11.Text = GridView1.Rows[i].Cells[6].Text.Replace("&#243;", "ó");
                if (TextBox6.Text == "Active Directory")
                {
                    DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://plkro-dcx02.BWIGROUP.pri");
                    DirectorySearcher searcher = new DirectorySearcher(directoryEntry)
                    {
                        PageSize = int.MaxValue,
                        Filter = "(&(objectCategory=person)(objectClass=user)(cn=" + TextBox7.Text.Replace(" ","") + " " + TextBox8.Text.Replace(" ","") + "))"
                      //  Filter = "(&(objectCategory=person)(objectClass=user)(cn=Witold Czekański))"
                    };


                    searcher.PropertiesToLoad.Add("sAMAccountName");

                    var result = searcher.FindOne();

                    if (result == null)
                    {
                      //  TextBox12.Text = "(&(objectCategory=person)(objectClass=user)(cn=" + TextBox7.Text + " " + TextBox8.Text + "))";
                        //   MessageBox.Show("Brak uzytkownika w domenie");
                        return; // Or whatever you need to do in this case
                    }

                    string netID;

                  //  string surname;


                    if (result.Properties.Contains("sAMAccountName"))
                    {

                        


                        DataTable dt = new DataTable();
                        dt.Columns.Add("First Name", typeof(String));
                        dt.Columns.Add("Last Name", typeof(String));
                        dt.Columns.Add("NetID", typeof(String));

                        DataRow workRow;

                        for (int j = 0; j < result.Properties["sAMAccountName"].Count; j++)
                        {
                            workRow = dt.NewRow();
                            workRow[0] = TextBox7.Text;
                            workRow[1] = TextBox8.Text;
                            workRow[2] = result.Properties["sAMAccountName"][j].ToString();
                            dt.Rows.Add(workRow);
                       }

                        GridView4.DataSource = dt;
                        GridView4.DataBind();

                           //   netID = result.Properties["sAMAccountName"][0].ToString();
                            //  TextBox12.Text = netID;


                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);


                    }

                }


            }
            else
            {
                HiddenTextBox2.Value = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
            }

        }


        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridData2();
        }

        protected void GridView3_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            LoadGridData3();
        }

        protected void GridView4_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
         //   LoadGridData4();
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
                SqlCommand command = new SqlCommand("SELECT * FROM AuthenticationGroups_v1 WHERE Active = 'true' order by AGroupID desc", conn);
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
                    command = new SqlCommand("SELECT ModeID, ModeName FROM Modes", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "ModeName";
                    DropDownList1.DataValueField = "ModeID";
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


                DataTable dt3 = new DataTable();
                dt3.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 order by UserID desc", conn);
                dt3.Load(command.ExecuteReader());
                conn.Close();
                GridView3.DataSource = dt3;
                GridView3.DataBind();
                dt3.Clear();

            }






        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM AuthenticationGroups_v1  WHERE " + buduj_warunek(TextBox1.Text, DropDownList1.SelectedItem.Text) + " order by AGroupID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            hiddencolumns();

        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employees_v1  WHERE " + buduj_warunek2(TextBox2.Text, TextBox3.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, TextBox4.Text, TextBox5.Text) + " order by EmpID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            hiddencolumns2();
        }

        protected void clearAll()
        {
            HiddenTextBox2.Value = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO SystemUsers VALUES('" + HiddenTextBox2.Value + "', '" + HiddenTextBox.Value + "', '" + TextBox12.Text + "', '" + CheckBox1.Checked + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();


                DataTable dt3 = new DataTable();
                dt3.Clear();
                conn = new SqlConnection(constr);
                conn.Open();
                command = new SqlCommand("SELECT AuthecticationGrName, FirstName , LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo FROM SystemUsers_v1 order by UserID desc", conn);
                dt3.Load(command.ExecuteReader());
                conn.Close();
                GridView3.DataSource = dt3;
                GridView3.DataBind();
                dt3.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('User added.');", true);
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
               TextBox12.Text = HiddenField1.Value;

        }


    }
}