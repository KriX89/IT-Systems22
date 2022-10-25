using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System;



namespace Aplikacja_1._0._2
{
    public partial class Menu : System.Web.UI.Page
    {

        string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";



        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, A.TicketNo,  CONVERT(char(10), ValidFrom,126) as ValidFrom,  CONVERT(char(10), ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 AND A.Status = 'To be deleted' ", conn);
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




        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Logowanie.aspx");
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT System, GroupName, FirstName, LastName, Login, A.TicketNo, CONVERT(char(10), ValidFrom,126) as ValidFrom,  CONVERT(char(10), ValidTo,126) as ValidTo, A.Status FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID = 2 AND A.Status = 'To be deleted' ", conn);

                //      SqlCommand command = new SqlCommand("SELECT TOP 10 System, GroupName, FirstName, LastName, Login, A.TicketNo, C.ValidFrom, C.ValidTo FROM GroupMembers_v1 as A  join SystemAccessLevels as B on A.System_ID = B.SystemID join GroupMembers as C on A.RecID = C.RecID WHERE B.NetID = '" + Session["Login"] + "' AND AccessLevelID > 0 AND C.ValidTo is not null order by C.ValidTo ", conn);
                dt.Load(command.ExecuteReader());
                conn.Close();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dt.Clear();
            }

        }

        


    }
}