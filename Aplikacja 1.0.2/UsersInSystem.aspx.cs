﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Aplikacja_1._0._2
{
    public partial class UsersInSystem : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRA-SQL01;Initial Catalog=IAM;User ID=IAM_RW;Password=#iTiAM2022!";

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

        //    SqlCommand command = new SqlCommand("SELECT A.System_ID, A.System, A.AuthecticationGrName, A.LocationType, A.SystemType, A.Plant, C.SupportEmail, C.SupportGroup FROM Systems_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '" + Session["Login"] + "' and B.AccessLevelID>0 order by A.System_ID desc", conn);

            SqlCommand command = new SqlCommand("SELECT A.System_ID, A.System, A.AuthecticationGrName, A.LocationType, A.SystemType, A.Plant, C.SupportEmail, C.SupportGroup FROM Systems_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE " + buduj_warunek(TextBox1.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by A.System_ID desc", conn);
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
            SqlCommand command = new SqlCommand("Select GroupID, GroupName, Description, SystemGroupName FROM SystemAccessGroups_v1 WHERE System_ID = " + HiddenEmpID.Value, conn);
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
            SqlCommand command = new SqlCommand("SELECT RecID, FirstName, LastName, Login, BWIEmplNo, PlantIDNo, TicketNo, DT, Author FROM GroupMembers_v1 where GroupID = " + HiddenTextBox2.Value + " AND Status_ID = 1", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView3.DataSource = dt;
            GridView3.DataBind();
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

                e.Row.ToolTip = "Support email: "+(e.Row.DataItem as DataRowView)[6].ToString();
                e.Row.ToolTip += "\nSupport group: " + (e.Row.DataItem as DataRowView)[7].ToString();
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

            }
            //   e.Row.ToolTip = "Click to select this row.";
        
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView3, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
            //   e.Row.ToolTip = "Click to select this row.";

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    SqlCommand command = new SqlCommand("Select GroupID, GroupName, Description, SystemGroupName FROM SystemAccessGroups_v1 WHERE System_ID = " + HiddenEmpID.Value, conn);
                    dt.Load(command.ExecuteReader());
                    conn.Close();

                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                    if (dt.Rows.Count != 0)
                    {
                        hiddencolumns2();
                    }
                    if (dt.Rows.Count == 0)
                        ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);
                    dt.Clear();
                }
                catch { ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true); }

                GridView3.DataSource = null;
                GridView3.DataBind();

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

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT RecID, FirstName, LastName, Login, BWIEmplNo, PlantIDNo, TicketNo, DT, Author FROM GroupMembers_v1 where GroupID = " + HiddenTextBox2.Value + " AND Status_ID = 1", conn);
                    dt.Load(command.ExecuteReader());
                    conn.Close();
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    if (dt.Rows.Count == 0)
                        ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true);
                    dt.Clear();
                } catch { ScriptManager.RegisterStartupScript(this, GetType(), "AnyValue", "showAlert('Nothing found.');", true); }

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
            SqlCommand command = new SqlCommand("SELECT RecID, System, GroupName, FirstName, LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, TicketNo, Status FROM GroupMembers_v1 where RecID = '" + GridView3.Rows[i].Cells[0].Text + "'", conn);
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
                command = new SqlCommand("SELECT RecID, FirstName, LastName, Login, BWIEmplNo, PlantIDNo, TicketNo, DT, Author FROM GroupMembers_v1 where GroupID = " + HiddenTextBox2.Value + " AND Status_ID = 1", conn);
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
            GridView1.HeaderRow.Cells[6].Attributes.Add("style", "display:none");
            GridView1.HeaderRow.Cells[7].Attributes.Add("style", "display:none");

            foreach (GridViewRow gvr in GridView1.Rows)
            {
                gvr.Cells[0].Attributes.Add("style", "display:none");
                gvr.Cells[6].Attributes.Add("style", "display:none");
                gvr.Cells[7].Attributes.Add("style", "display:none");
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

                SqlCommand command = new SqlCommand("SELECT A.System_ID, A.System, A.AuthecticationGrName, A.LocationType, A.SystemType, A.Plant, C.SupportEmail, C.SupportGroup FROM Systems_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID WHERE B.NetID = '" + Session["Login"] +"' and B.AccessLevelID>0 order by A.System_ID desc", conn);
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
                    command = new SqlCommand("SELECT LocTypeID, LocationType FROM LocationTypes", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList1.DataSource = dt2;
                    DropDownList1.DataTextField = "LocationType";
                    DropDownList1.DataValueField = "LocTypeID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
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


        public static string buduj_warunek(string System, string LocationType, string SystemType, string Plant, string NetID)
        {
            string warunek = "B.NetID = '" + NetID + "' AND B.AccessLevelID > 0 ";
            // bool pierwszy = true;

            if (System != "")
                warunek += "AND A.System LIKE '%" + System + "%'";
            else
                warunek += "AND A.System LIKE '%'";

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

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT A.System_ID, A.System, A.AuthecticationGrName, A.LocationType, A.SystemType, A.Plant, C.SupportEmail, C.SupportGroup  FROM Systems_v1 as A join SystemAccessLevels as B on A.System_ID = B.SystemID join Systems as C on A.System_ID = C.System_ID  WHERE " + buduj_warunek(TextBox1.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, Session["Login"].ToString()) + " order by A.System_ID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();

                GridView1.DataSource = dt;
                GridView1.DataBind();
            if (dt.Rows.Count != 0)
            {
                hiddencolumns();
            }

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