<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Aplikacja_1._0._2.Menu" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css">
        


    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
  <ContentTemplate>    
  <div id="deleteModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label20" runat="server" Text="Delete group member" />
        </div>
      <div class="modal-body">   
          <asp:HiddenField ID="HiddenTextBox" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="System: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox8" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="First Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox9" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div>

        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label12" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox10" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div>         
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="Login: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox11" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div>  

       <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label18" runat="server" Text="Ticket No: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox12" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label22" runat="server" Text="Status: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox13" runat="server" ForeColor="Black" Enabled="false" /></div>
        </div> 


        </div>
    </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button3" runat="server" Text="Delete" ForeColor="Black" OnClientClick="closeDeleteModal()" OnClick="Button3_Click" />
          <input id="Button7" type="button" value="Cancel" style="color:black" onclick="closeDeleteModal()" />
      </div>
    </div>
        </div>
  </div>
  </ContentTemplate>
  <Triggers>

  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />

  </Triggers>
  </asp:UpdatePanel>

    <br>
    <br>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left:auto; margin-right:auto; width:90%;">
            <asp:Button ID="Button8" class="naglowektab" runat="server" Text="TO BE DELETED" OnClientClick="return false;" Style="cursor:default"/>
            <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
            <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
            </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>





    <script type="text/javascript">
    
                  $(".navbar-toggler").click(function () {
              $(".menu").toggle();
          });


          $(document).ready(function () {
              $('#dtBasicExample').DataTable();
              $('.dataTables_length').addClass('bs-select');
          });



        function btClear() {

        }


        function showAlert( text ) {
            alert(text);
        }

        function openFiltrModal() {
            $('#filtrModal').modal('show');
        }
        function closeFiltrModal() {
            $("#filtrModal").modal('hide');
        }

        function openDeleteModal() {
            $('#deleteModal').modal('show');
        }
        function closeDeleteModal() {
            $("#deleteModal").modal('hide');
        }




    </script>



</asp:Content>
