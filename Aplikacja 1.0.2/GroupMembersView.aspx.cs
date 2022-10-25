using System.Data;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Data.SqlClient;
using System;
using System.Web.UI;

namespace Aplikacja_1._0._2
{
    public partial class GroupMembersView : System.Web.UI.Page
    {
        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";


        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, TicketNo, CONVERT(char(10), ValidTo,126) as ValidTo,  Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, DropDownList4.SelectedItem.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, Session["Login"].ToString(), DropDownList5.SelectedItem.Text) + " order by RecID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dt.Clear();
        }



        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        public static string buduj_warunek(string System, string GroupName, string FirstName, string LastName, string Login, string Department, string Plant, string BWIEmplNo, string PlantIDNo, string TicketNo, string NetID, string Status)
        {
            string warunek = "NetID = '" + NetID + "' AND AccessLevelID > 0 ";

         //   warunek += "NetID = '" + NetID + "' AND AccessLevelID > 0 ";
            // bool pierwszy = true;

            if (System != "")
                warunek += "AND System LIKE '%" + System + "%'";
            else
                warunek += "AND System LIKE '%'";

            if (GroupName != "")
                warunek += "AND  GroupName LIKE '%" + GroupName + "%'";
            else
                warunek += "AND GroupName LIKE '%'";

            if (FirstName != "")
                warunek += "AND  FirstName LIKE '" + FirstName + "%'";
            else
                warunek += "AND FirstName LIKE '%'";

            if (LastName != "")
                warunek += "AND LastName LIKE '" + LastName + "%'";
            else
                warunek += "AND LastName LIKE '%'";

            if (Login != "")
                warunek += "AND Login LIKE '%" + Login + "%'";
            else
                warunek += "AND Login LIKE '%'";

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

            if (TicketNo != "")
                warunek += "AND TicketNo LIKE '%" + TicketNo + "%'";
            else
                warunek += "AND TicketNo LIKE '%'";

            if (Status != "")
                warunek += "AND Status = '" + Status + "'";
            else
                warunek += "AND TicketNo LIKE '%'";




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
                SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, TicketNo,  CONVERT(char(10), ValidTo,126) as ValidTo , Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID > 0 order by RecID desc", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();

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


                if (DropDownList2.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT GroupID, GroupName FROM SystemAccessGroups", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList2.DataSource = dt2;
                    DropDownList2.DataTextField = "GroupName";
                    DropDownList2.DataValueField = "GroupID";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    dt2.Clear();
                }



                if (DropDownList3.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT DepartmentID, Department FROM Departments", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList3.DataSource = dt2;
                    DropDownList3.DataTextField = "Department";
                    DropDownList3.DataValueField = "DepartmentID";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
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

                if (DropDownList5.Items.Count < 1)
                {
                    conn.Open();
                    command = new SqlCommand("SELECT Status_ID, Status FROM GroupMembersStatuses", conn);
                    dt2.Load(command.ExecuteReader());
                    conn.Close();
                    DropDownList5.DataSource = dt2;
                    DropDownList5.DataTextField = "Status";
                    DropDownList5.DataValueField = "Status_ID";
                    DropDownList5.DataBind();
                    DropDownList5.Items.Insert(0, new ListItem(String.Empty, String.Empty));
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
            SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, Department, Plant, BWIEmplNo, PlantIDNo, TicketNo, CONVERT(char(10), ValidTo,126) as ValidTo, Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE " + buduj_warunek(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList3.SelectedItem.Text, DropDownList4.SelectedItem.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, Session["Login"].ToString(), DropDownList5.SelectedItem.Text) + " order by RecID desc", conn);
            dt.Load(command.ExecuteReader());
            conn.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFiltrModal();", true);
        }


    }
}