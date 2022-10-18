using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;

namespace Aplikacja_1._0._2
{
    public partial class SiteMaster : MasterPage
    {

      /*  protected void Page_UnLoad(object sender, EventArgs e)
        {
            string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";

            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Semaphores SET ActiveUser = 2 WHERE TableID = 2", conn);
            command.ExecuteNonQuery();
            conn.Close();

        } */
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertRO", "alertRO()", true);

            if (Session["Uprawnienia"] != null)
            {
                if (Session["Uprawnienia"] == "RO")
                {
                    HiddenField1.Value = "RO";
                }

                if (Session["Uprawnienia"] == "RW")
                {
                    HiddenField1.Value = "RW";
                }


            } 
        }


        protected void logout(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("Logowanie.aspx");

        }

        protected void groupmembersview(object sender, EventArgs e)
        {
            Response.Redirect("GroupMembersView.aspx");
        }

        protected void groupmembersadd(object sender, EventArgs e)
        {
            Response.Redirect("GroupMembersAdd.aspx");
        }

        protected void groupmembersdelete(object sender, EventArgs e)
        {
            Response.Redirect("GroupMembersDelete.aspx");
        }

        protected void systemsview(object sender, EventArgs e)
        {
            Response.Redirect("SystemsView.aspx");
        }


        protected void systemedit(object sender, EventArgs e)
        {
            Response.Redirect("SystemsEdit.aspx");
        }

        protected void systypeedit(object sender, EventArgs e)
        {
            Response.Redirect("SysTypeEdit.aspx");
        }

        protected void syslocationedit(object sender, EventArgs e)
        {
            Response.Redirect("SysLocationEdit.aspx");
        }



        protected void accessgroupview(object sender, EventArgs e)
        {
            Response.Redirect("AccessGroupsView.aspx");
        }


        protected void accessgroupedit(object sender, EventArgs e)
        {
            Response.Redirect("AccessGroupsEdit.aspx");
        }

        

        protected void authgroupsedit(object sender, EventArgs e)
        {
            Response.Redirect("AuthGroupEdit.aspx");
        }

        protected void systemusersview(object sender, EventArgs e)
        {
            Response.Redirect("SystemUsersView.aspx");

        }

        protected void systemusersadd(object sender, EventArgs e)
        {
            Response.Redirect("SystemUsersAdd.aspx");

        }

        protected void systemusersedit(object sender, EventArgs e)
        {
            Response.Redirect("SystemUsersEdit.aspx");

        }



        protected void emplview(object sender, EventArgs e)
        {
            Response.Redirect("EmplView.aspx");

        }

        protected void empledit(object sender, EventArgs e)
        {

            Response.Redirect("EmplEdit.aspx");

        }

        protected void plantsdepartview(object sender, EventArgs e)
        {

            Response.Redirect("PlantsDepartView.aspx");

        }

        protected void plantsedit(object sender, EventArgs e)
        {

            Response.Redirect("PlantsEdit.aspx");

        }

        protected void departmentsedit(object sender, EventArgs e)
        {

            Response.Redirect("DepartmentsEdit.aspx");

        }

        protected void usersystems(object sender, EventArgs e)
        {
            Response.Redirect("UserSystems.aspx");
        }


        protected void usersinsystem(object sender, EventArgs e)
        {
            Response.Redirect("UsersInSystem.aspx");
        }

        protected void accesssystems(object sender, EventArgs e)
        {
            Response.Redirect("AccessSystems.aspx");
        }

        protected void accessplants(object sender, EventArgs e)
        {
            Response.Redirect("AccessPlants.aspx");
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

        }



        protected void empladd(object sender, EventArgs e)
        {

            string constr = "Data Source=PLKRO-SQL02;Initial Catalog=IT;User ID=webkrosno;Password=!kR0sno2022#";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Employees VALUES('10101', 1, '1', 'bbb', 1, 1, 1)", conn);
            command.ExecuteNonQuery();
            conn.Close();
            empledit(null, null);
        }

                

    }
}