using System;
using System.Web.UI.WebControls;
using System.Data;
using System.DirectoryServices;
using System.Collections.Specialized;
using System.Collections;



namespace Aplikacja_1._0._2
{
    public partial class Lokalizacja : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }



        DataTable GetDataTable(GridView dtg)
        {
            DataTable dt = new DataTable();

            if (Session["Uprawnienia"]!=null)
            {
                if (dtg.HeaderRow != null)
                {


                    for (int i = 2; i < dtg.HeaderRow.Cells.Count; i++)
                    {

                        dt.Columns.Add(dtg.Columns[i].HeaderText);
                    }
                }


                foreach (GridViewRow row in dtg.Rows)
                {
                        DataRow dr;
                        dr = dt.NewRow();

                        for (int i = 2; i < row.Cells.Count; i++)
                        {
                            dr[i - 2] = row.Cells[i].Text.Replace(" ", "");
                            dr[i - 2] = row.Cells[i].Text.Replace("&nbsp;", "");
                        }
                        dt.Rows.Add(dr);

                }
            }
                else
            {
                if (dtg.HeaderRow != null)
                {


                    for (int i = 2; i < dtg.HeaderRow.Cells.Count; i++)
                    {

                        dt.Columns.Add(dtg.Columns[i].HeaderText);
                    }
                }


                foreach (GridViewRow row in dtg.Rows)
                {
                    DataRow dr;
                    dr = dt.NewRow();

                    for (int i = 2; i < row.Cells.Count; i++)
                    {
                        dr[i - 2] = row.Cells[i].Text.Replace(" ", "");
                        dr[i - 2] = row.Cells[i].Text.Replace("&nbsp;", "");

                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }



        protected void Button4_Click(object sender, EventArgs e)
        {
 
        } 


        protected void Button6_Click(object sender, EventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {

        }

        bool grupa = false;
        bool grupaRW = false;
        bool grupaRO = false;
        protected void Button1_Click1(object sender, EventArgs e)
        {
            bool IsAuthenticated(string srvr, string usr, string pwd)
            {
                bool authenticated = false;
                 

                try
                {
                    DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd);
                    object nativeObject = entry.NativeObject;
                    authenticated = true;
                }
                catch (DirectoryServicesCOMException cex)
                {

                }
                catch (Exception ex)
                {

                }

                return authenticated;
            }



            if (IsAuthenticated("LDAP://plkro-dcx02.BWIGROUP.pri", uname1.Value, psw1.Value))
            {


                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://plkro-dcx02.BWIGROUP.pri");
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry)
                {
                    PageSize = int.MaxValue,
                    Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=" + uname1.Value + "))"
                };



                searcher.PropertiesToLoad.Add("cn");

                var result = searcher.FindOne();


                StringCollection groups = new StringCollection();

                SearchResult res = searcher.FindOne();
                if (null != res)
                {
                    DirectoryEntry obUser = new DirectoryEntry(res.Path);
                    // Invoke Groups method.
                    object obGroups = obUser.Invoke("Groups");
                    foreach (object ob in (IEnumerable)obGroups)
                    {
                        // Create object for each group.
                        DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                        groups.Add(obGpEntry.Name);
                    }
                }


                //wyswietlanie listy grup

                for (int i = 0; i < groups.Count; i++)
                {
                    if (groups[i].ToString() == "CN=KRO-APP-IT_MGMT-RW" || groups[i].ToString() == "CN=KRO-APP-IT_MGMT-RO")
                    {
                        if(groups[i].ToString() == "CN=KRO-APP-IT_MGMT-RW")
                            grupaRW = true;
                        if (groups[i].ToString() == "CN=KRO-APP-IT_MGMT-RO")
                            grupaRO = true;
                        grupa = true;
                    }
                }




                if (result.Properties.Contains("cn"))
                {
                    if (grupa)
                    {
                        Session["Login"] = uname1.Value;
                        
                        if (grupaRW)
                        {
                            Session["Uprawnienia"] = "RW";
                        }


                        if (grupaRO)
                        {
                            Session["Uprawnienia"] = "RO";

                        }

                        


                        Response.Redirect("Menu.aspx"); 
                    }
                    else
                    {
                        Label3.Text = "No permissions.";
                    }


                }

            }
            else
            {
                if (uname1.Value == "" || psw1.Value == "")
                {
                    if (uname1.Value == "" && psw1.Value == "")
                    {
                        Label3.Text = "User name or password is invalid.";
                    }
                    else
                    {
                        if (uname1.Value == "")
                        {
                            Label3.Text = "Enter login.";
                        }

                        if (psw1.Value == "")
                        {
                            Label3.Text = "Enter password.";
                        }
                    }
                }
                else
                    Label3.Text = "User name or password is invalid.";



            }
        }








    }
}