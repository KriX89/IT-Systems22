using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using DocumentFormat.OpenXml.Spreadsheet;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using System.DirectoryServices;
using System.Collections;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Aplikacja_1._0._2
{
    public partial class AccessGroupsEdit : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";


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
            SqlCommand command = new SqlCommand("SELECT A.* FROM SystemAccessGroups_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by GroupID desc", conn);
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
                e.Row.ToolTip = "Click to select this row.";
                e.Row.Attributes["style"] = "cursor:pointer";
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
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt.Clear();

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
            if (dt.Rows.Count != 0)
            {
                hiddencolumns();
            }
            else
            {
                Label29.Text = "Nothing found.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openKomunikatModal();", true);
            }
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
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt.Clear();




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
                if (dt.Rows.Count != 0)
                {
                    hiddencolumns();
                }
                dt.Clear();

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
            if (HiddenGroupID.Value == "")
            {
                Label29.Text = "First you need to select row.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openKomunikatModal();", true);
            }
            else
            {
                Button3.Visible = false;
                Button4.Visible = true;
                Label17.Text = "Change selected system access group";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddModal();", true);
            }
        }

        public DataTable datausers(string grupa)
        {
            DataTable dt = new DataTable();

            dt.Clear();
            dt.Columns.Add("NetID");
            dt.Columns.Add("Name");


            SearchResult result;
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(cn={0})", grupa);
            search.PropertiesToLoad.Add("member");
            result = search.FindOne();
            ArrayList userNames = new ArrayList();
            if (result != null)
            {
                for (int counter = 0; counter < result.Properties["member"].Count; counter++)
                {
                    string st = (string)result.Properties["member"][counter];
                    if (st.Contains("OU=User Accounts"))
                    {
                        DirectoryEntry gpMemberEntry = new DirectoryEntry(("LDAP://" + st));
                        if (!(gpMemberEntry == null))
                        {
                            System.DirectoryServices.PropertyCollection userProps = gpMemberEntry.Properties;
                            object objUser = userProps["sAMAccountname"].Value;
                            object objUser2 = userProps["cn"].Value;

                            DataRow ravi = dt.NewRow();
                            ravi["NetID"] = objUser.ToString();
                            ravi["Name"] = objUser2.ToString();
                            dt.Rows.Add(ravi);

                        }
                    }

                    if (st.Contains("OU=Groups"))
                    {
                        DirectoryEntry gpMemberEntry = new DirectoryEntry(("LDAP://" + st));
                        if (!(gpMemberEntry == null))
                        {
                            System.DirectoryServices.PropertyCollection userProps = gpMemberEntry.Properties;

                            dt.Merge(datausers(userProps["cn"].Value.ToString()));
                            //   this.dataGridView1.Rows.Add(userProps["cn"].Value, userProps["sAMAccountname"].Value);

                        }
                    }





                }
            }
            


            return dt;
        }


        public void Button11_Click(object sender, EventArgs e)
        {
            string groupName = TextBox6.Text.Replace(@"BWIGROUP\", "");


        /*    DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("NetID");
            dt.Columns.Add("Name");


            SearchResult result;
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(cn={0})", groupName);
            search.PropertiesToLoad.Add("member");
            result = search.FindOne();
            ArrayList userNames = new ArrayList();
            if (result != null)
            {
                for (int counter = 0; counter < result.Properties["member"].Count; counter++)
                {
                    string st = (string)result.Properties["member"][counter];
                    if (st.Contains("OU=User Accounts"))
                    {
                        DirectoryEntry gpMemberEntry = new DirectoryEntry(("LDAP://" + st));
                        if (!(gpMemberEntry == null))
                        {
                            System.DirectoryServices.PropertyCollection userProps = gpMemberEntry.Properties;
                            object objUser = userProps["sAMAccountname"].Value;
                            object objUser2 = userProps["cn"].Value;

                            DataRow ravi = dt.NewRow();
                            ravi["NetID"] = objUser.ToString();
                            ravi["Name"] = objUser2.ToString();
                            dt.Rows.Add(ravi);

                        }
                    }





                }
            } */

            GridView1.DataSource = datausers(groupName);
            GridView1.DataBind();

               DataTable dt2 = new DataTable();
               dt2.Clear();
               SqlConnection conn = new SqlConnection(constr);
               conn.Open();
               SqlCommand command = new SqlCommand("SELECT Login as NetID, FirstName+' '+LastName as Name FROM GroupMembers_v1 where GroupID = '"+HiddenGroupID.Value+"'", conn);
               dt2.Load(command.ExecuteReader());
               conn.Close();
               GridView3.DataSource = dt2;
               GridView3.DataBind();
               dt2.Clear();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                bool find = false;
                for (int j = 0; j < GridView3.Rows.Count; j++)
                {
                    if (GridView1.Rows[i].Cells[0].Text == GridView3.Rows[j].Cells[0].Text)
                        find = true;
                }
                if (find)
                {
                    GridView1.Rows[i].Cells[2].Attributes.Add("style", "display:none");
                    GridView1.Rows[i].BackColor = System.Drawing.Color.LightGreen; 
                }
                else
                {
                    GridView1.Rows[i].BackColor = System.Drawing.Color.Yellow; }
                }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                bool find = false;
                for (int j = 0; j < GridView1.Rows.Count; j++)
                {
                    if (GridView3.Rows[i].Cells[0].Text == GridView1.Rows[j].Cells[0].Text)
                        find = true;
                }
                if (find)
                {
                    GridView3.Rows[i].Cells[2].Attributes.Add("style", "display:none");
                    GridView3.Rows[i].BackColor = System.Drawing.Color.LightGreen; 
                }
                else
                { GridView3.Rows[i].BackColor = System.Drawing.Color.Yellow; }
            } 


            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCheckModal();", true);
        }

        public string change_signs(string name)
        {
            name = name.ToLower();
            name = name.Replace("a", "[a|ą]");
            name = name.Replace("c", "[c|ć]");
            name = name.Replace("e", "[e|ę]");
            name = name.Replace("l", "[l|ł]");
            name = name.Replace("n", "[n|ń]");
            name = name.Replace("o", "[o|ó]");
            name = name.Replace("s", "[s|ś]");
            name = name.Replace("z", "[z|ż|ź]");
            return name;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string netID = e.CommandArgument.ToString().Split('%')[0];
            string first_name = change_signs(e.CommandArgument.ToString().Split('%')[1].Split(' ')[0]);
            string last_name = change_signs(e.CommandArgument.ToString().Split('%')[1].Split(' ')[1]);


            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT UserID FROM SystemUsers_v1 where Login = '" + netID + "'", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

            if (dt.Rows.Count != 0)
            {
                string userID = dt.Rows[0][0].ToString();

                conn.Open();

                command = new SqlCommand("INSERT INTO GroupMembers (GroupID, UserID, ValidFrom, DT, Author, Status_ID) VALUES('" + HiddenGroupID.Value + "', '" + userID + "', getdate() , getdate(), '" + Session["Login"] + "', 1)", conn); 
                command.ExecuteNonQuery();
                conn.Close();

                Button11_Click(null, null);

            }
            else 
            {
                DataTable dt2 = new DataTable();
                dt2.Clear();
                conn.Open();
                command = new SqlCommand("SELECT EmpID FROM Employees_v1 where FirstName like '" + first_name + "' and LastName like '"+last_name+"'", conn);
                dt2.Load(command.ExecuteReader());
                conn.Close();
                if (dt2.Rows.Count == 1)
                {

                    DataTable dt3 = new DataTable();
                    dt3.Clear();
                    conn.Open();
                    command = new SqlCommand("INSERT INTO SystemUsers (EmpID, AutenticationGroup, login, Active) OUTPUT Inserted.UserID VALUES('" + dt2.Rows[0][0].ToString() + "','1', '" + netID + "', 'true')", conn);
                    dt3.Load(command.ExecuteReader());

                    command = new SqlCommand("INSERT INTO GroupMembers (GroupID, UserID, ValidFrom, DT, Author, Status_ID) VALUES('" + HiddenGroupID.Value + "', '" + dt3.Rows[0][0].ToString() + "', getdate() , getdate(), '" + Session["Login"] + "', 1)", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    Button11_Click(null, null);

                }

                else
                {
                    Label29.Text = "Employee not found in the database.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openKomunikatModal();", true);
                }

            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string netID = e.CommandArgument.ToString();

            SqlConnection conn = new SqlConnection(constr);
            DataTable dt = new DataTable();
            dt.Clear();
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT UserID FROM SystemUsers_v1 where login = '"+netID+"' and AutenticationGroup = 1", conn);
            dt.Load(command.ExecuteReader());


            command = new SqlCommand("DELETE FROM GroupMembers  where UserID="+ dt.Rows[0][0].ToString() + " and GroupID = "+ HiddenGroupID.Value, conn);
            command.ExecuteNonQuery();
            conn.Close();

            Button11_Click(null, null);

        }

    }
}