<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Aplikacja_1._0._2.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css">
        


    <br>
    <br>
    <div style="text-align:center">
    <asp:Label ID="Label1" runat="server" ForeColor="White" Font-Size="Larger" Text="The 10 most recent permissions that will expire" />
        </div>
    <br>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left:auto; margin-right:auto; width:90%;">
            <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" >
            <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
            </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>






    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.js">
                  $(".navbar-toggler").click(function () {
              $(".menu").toggle();
          });


          $(document).ready(function () {
              $('#dtBasicExample').DataTable();
              $('.dataTables_length').addClass('bs-select');
          });




    </script>



</asp:Content>
