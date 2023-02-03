<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersInSystem.aspx.cs" Inherits="Aplikacja_1._0._2.UsersInSystem" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>



      <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>    
  <div id="filtrModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Systems filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="System: "/></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Location type: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></div>
        </div>


        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="System type: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></div>
        </div>         
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Plant: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList3" runat="server" ForeColor="Black" /></div>
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
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="System: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" Width="100%" ForeColor="Black" Enabled="false" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="Group Name: " /></div>
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
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label24" runat="server" Text="Execution date: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox19" runat="server" type="Date" Width="100%" ForeColor="Black" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label25" runat="server" Text="Info: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox20" runat="server" Width="100%" ForeColor="Black" /></div>
        </div> 



        </div>
    </div>

      <div class="modal-footer" style="text-align:center">

          <asp:Button ID="Button9" runat="server" Text="To be deleted" ForeColor="Black" OnClientClick="closeDeleteModal()" OnClick="Button9_Click" />
          <input id="Button10" type="button" value="Cancel" style="color:black" onclick="closeDeleteModal()" />
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


        <div style="margin-left:auto; margin-right:auto; width:95%;">
        <div class="row">
            <div class="col-md-6">
                        <asp:Button ID="Button4" class="naglowektab" runat="server" Text="SYSTEMS" OnClientClick="return false;" Style="cursor:default"/>
            <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button5_Click" />

            
        
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>   
                                <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridView1_OnPageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>

                </div>
                <div class="col-md-6" > 
                    <asp:Button ID="Button3" class="naglowektab" runat="server" Text="GROUPS" OnClientClick="return false;" Style="cursor:default"/>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>   
                        <asp:HiddenField ID="HiddenEmpID" runat="server" />
                        <asp:HiddenField ID="HiddenTextBox2" runat="server" />
                                <asp:GridView runat="server" ID="GridView2" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="9" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
                </div>
        </div>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
             <ContentTemplate>
                 <div style="margin-left:auto; margin-right:auto; width:90%;">
                 <asp:Button ID="Button7" class="naglowektab" runat="server" Text="MEMBERS" OnClientClick="return false;" Style="cursor:default"/>
                 <asp:GridView runat="server" ID="GridView3" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView3_OnPageIndexChanging" OnRowDataBound="GridView3_RowDataBound" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" >
                 <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                 </asp:GridView>
                 </div>
             </ContentTemplate>
             <Triggers>
             <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
             <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
             </Triggers>
             </asp:UpdatePanel>

   </div>

    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= TextBox1.ClientID %>');
            var LocationType = document.getElementById('<%= DropDownList1.ClientID %>');
            var SystemType = document.getElementById('<%= DropDownList2.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList3.ClientID %>');


            System.value = "";
            LocationType.value = "";
            SystemType.value = "";
            Plant.value = "";

        }

        function showAlert(text) {
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
