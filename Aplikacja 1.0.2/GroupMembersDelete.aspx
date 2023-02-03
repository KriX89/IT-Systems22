﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupMembersDelete.aspx.cs" Inherits="Aplikacja_1._0._2.GroupMembersEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>

    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
  <ContentTemplate>    
  <div id="KomunikatModal" class="modal fade bd-example-modal-sm" role="dialog">
  <<div class="modal-dialog modal-sm">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-body">

          <div class="row" style="height: 80px">
            <div class="col-md-4" style="text-align:center"><asp:Image ID="Image1" runat="server" Height="60px" Width="60px" BackColor="#ebebeb" ImageAlign="AbsMiddle" ImageUrl="../image/info_icon.png" /> </div>
            <div class="col-md-8" style="text-align:left"><asp:Label ID="Label29" runat="server" Font-Size="Larger" Text="Komunikat" /></div>
        </div>

         <center> <input id="Button27" type="button" value="OK" style="width:80px" onclick="closeKomunikatModal()" /></center>
    </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
      <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


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
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label21" runat="server" Text="Status: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" Width="100%" ForeColor="Black" /></div>
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




  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
  <ContentTemplate>    
  <div id="deleteModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label20" runat="server" Text="Delete group member" />
        </div>
      <div class="modal-body">   
          <asp:HiddenField ID="HiddenEmail" runat="server" />
          <asp:HiddenField ID="HiddenTextBox" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="System: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox8" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="First Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox9" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>

        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label12" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox10" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>         
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="Login: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox11" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>  

        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label14" runat="server" Text="Department: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox12" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>     
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label15" runat="server" Text="Plant: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox13" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>  
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label16" runat="server" Text="BWI Empl No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox14" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>  
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label17" runat="server" Text="Plant ID No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox15" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>  

       <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label18" runat="server" Text="Ticket No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox16" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label22" runat="server" Text="Status: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox17" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label23" runat="server" Text="New Ticket No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox18" runat="server" Width="100%" ForeColor="Black" /></div>
        </div> 
        </div>
    </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button3" runat="server" Text="Delete" ForeColor="Black" OnClientClick="closeDeleteModal()" OnClick="Button3_Click" />
          <asp:Button ID="Button9" runat="server" Text="To be deleted" ForeColor="Black" OnClientClick="closeDeleteModal()" OnClick="Button9_Click" />
          <input id="Button7" type="button" value="Cancel" style="color:black" onclick="closeDeleteModal()" />
      </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="margin-left:auto; margin-right:auto; width:90%;">
    <asp:Button ID="Button8" class="naglowektab" runat="server" Text="GROUP MEMBERS" OnClientClick="return false;" Style="cursor:default"/>
    <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat "  class="button_2" runat="server" Text="Filter" OnClick="Button5_Click" />
    <asp:Button ID="Button4" Style="background-image: url(../image/delete.png); background-repeat: no-repeat "  class="button_2" runat="server" Text="Delete" OnClick="Button4_Click" />
            <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
            <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
            </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

  


 


    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= DropDownList1.ClientID %>');
            var FirstName = document.getElementById('<%= TextBox1.ClientID %>');
            var LastName = document.getElementById('<%= TextBox2.ClientID %>');
            var Login = document.getElementById('<%= TextBox3.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList4.ClientID %>');
            var BWIEmplNo = document.getElementById('<%= TextBox4.ClientID %>');
            var PlantIDNo = document.getElementById('<%= TextBox5.ClientID %>');
            var TicketNo = document.getElementById('<%= TextBox6.ClientID %>');
            var Status = document.getElementById('<%= DropDownList2.ClientID %>');
            System.value = "";
            FirstName.value = "";
            LastName.value = "";
            Login.value = "";
            Plant.value = "";
            BWIEmplNo.value = "";
            PlantIDNo.value = "";
            TicketNo.value = "";
            Status.value = "";
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

        function openKomunikatModal() {
            $('#KomunikatModal').modal('show');
        }
        function closeKomunikatModal() {
            $("#KomunikatModal").modal('hide');
        }


    </script> 


</asp:Content>
