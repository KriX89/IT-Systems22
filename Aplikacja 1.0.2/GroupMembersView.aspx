<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupMembersView.aspx.cs" Inherits="Aplikacja_1._0._2.GroupMembersView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>


  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>    
  <div id="filtrModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Group members filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="System: "/></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="First Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>

        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label5" runat="server" Text="Login: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox3" runat="server" Width="100%" ForeColor="Black" /></div>
        </div> 
            
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Department: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList3" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>            
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="Plant: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList4" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>  

        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label8" runat="server" Text="BWI Empl No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>     
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="Plant ID No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>  
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label10" runat="server" Text="TicketNo: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>  
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="Status: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList5" runat="server" Width="100%" ForeColor="Black" /></div>
        </div> 


        </div>
    </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClientClick="closeFiltrModal()" OnClick="Button1_Click" />
          <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" />
          <input id="Button6" type="button" value="Cancel" style="color:black" onclick="closeFiltrModal()" />
      </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>



    <div style="margin-left:auto; margin-right:auto; width:100%;">
        <asp:Button ID="Button4" class="naglowektab" runat="server" Text="GROUP MEMBERS" OnClientClick="return false;" Style="cursor:default"/>
        <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button5_Click" />

    </div>

   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left:auto; margin-right:auto; width:100%;">
            <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" >
            <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
            </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>


    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= DropDownList1.ClientID %>');
            var GroupName = document.getElementById('<%= DropDownList2.ClientID %>');
            var FirstName = document.getElementById('<%= TextBox1.ClientID %>');
            var LastName = document.getElementById('<%= TextBox2.ClientID %>');
            var Login = document.getElementById('<%= TextBox3.ClientID %>');
            var Department = document.getElementById('<%= DropDownList3.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList4.ClientID %>');
            var BWIEmplNo = document.getElementById('<%= TextBox4.ClientID %>');
            var PlantIDNo = document.getElementById('<%= TextBox5.ClientID %>');
            var TicketNo = document.getElementById('<%= TextBox6.ClientID %>');
            var Status = document.getElementById('<%= DropDownList5.ClientID %>');
            System.value = "";
            GroupName.value = "";
            FirstName.value = "";
            LastName.value = "";
            Login.value = "";
            Department.value = "";
            Plant.value = "";
            BWIEmplNo.value = "";
            PlantIDNo.value = "";
            TicketNo.value = "";
            Status.value = "";
        }


        function openFiltrModal() {
            $('#filtrModal').modal('show');
        }
        function closeFiltrModal() {
            $("#filtrModal").modal('hide');
        }


    </script> 
</asp:Content>
