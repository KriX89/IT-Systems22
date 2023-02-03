<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupMembersAdd.aspx.cs" Inherits="Aplikacja_1._0._2.GroupMembersAdd" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>

  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>   


  <div id="myModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Add User to Group Members" />
        </div>
      <div class="modal-body">   
        <asp:HiddenField ID="HiddenEmail" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="System: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox9" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label12" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox10" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="System Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox11" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label14" runat="server" Text="First Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox12" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label15" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox13" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label16" runat="server" Text="Plant: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox14" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label17" runat="server" Text="BWI Empl. No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox15" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label18" runat="server" Text="Plant ID No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox16" runat="server" Width="100%" ForeColor="Black" Enabled="false"/></div>
        </div>
            
            
            
            
            
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label21" runat="server" Text="Valid From: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="txtDate" runat="server" Width="100%" TextMode="Date" ClientIDMode="Static" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label22" runat="server" Text="Valid To: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox18" runat="server" Width="100%" TextMode="Date" ClientIDMode="Static" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label23" runat="server" Text="Indefinitely: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label20" runat="server" Text="TicketNo: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox19" Width="100%" runat="server" /></div>
        </div>


                
                </div>
            </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button6" runat="server" Text="Save" OnClientClick="closeModal()" OnClick="Button6_Click"  />
          <asp:Button ID="Button7" runat="server" Text="Cancel" OnClientClick="closeModal()"  />
      </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


  <asp:UpdatePanel ID="UpdatePanel6" runat="server">
  <ContentTemplate>  
  <div id="filtrModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label24" runat="server" Text="Systems filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="System: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList3" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Authentication Group: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox3" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="System Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label5" runat="server" Text="Plant: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
       
        </div>
        </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClientClick="closeFiltrModal()" OnClick="Button1_Click" />
          <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" />
          <input id="Button12" type="button" value="Cancel" style="color:black" onclick="closeFiltrModal()" />
      </div>
    </div>
  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


  <asp:UpdatePanel ID="UpdatePanel7" runat="server">
  <ContentTemplate>  
  <div id="filtrModal2" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label25" runat="server" Text="System users filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="First Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label8" runat="server" Text="Plant: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="BWI Empl No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label10" runat="server" Text="Plant ID No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox8" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
       
        </div>
        </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button3" runat="server" Text="Search" ForeColor="Black" OnClientClick="closeFiltrModal2()" OnClick="Button3_Click" />
          <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear2()" />
          <input id="Button12" type="button" value="Cancel" style="color:black" onclick="closeFiltrModal2()" />
      </div>
    </div>
  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>



    <div style="margin-left:auto; margin-right:auto; width:90%; height:45%">
        <div class="row">
            <div class="col-md-6" >
            <asp:Button ID="Button8" class="naglowektab" runat="server" Width="300px" Text="SYSTEMS" OnClientClick="return false;" Style="cursor:default"/>
            <asp:Button ID="Button9" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button9_Click" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:GridView runat="server" ID="GridView1" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_OnPageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>

            <div class="col-md-6">
                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:Button ID="Button4" class="naglowektab" runat="server" Width="300px" Text="SYSTEM USERS" OnClientClick="return false;" Style="cursor:default"/>
                <asp:Button ID="Button10" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button10_Click" />
                <asp:Button ID="Button5" Style="background-image: url(../image/plus.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Add new" OnClick="Button5_Click" />
                <asp:HiddenField ID="HiddenTextBox" runat="server" />
                <asp:HiddenField ID="HiddenTextBox2" runat="server" />
                <asp:HiddenField ID="HiddenTextBox3" runat="server" />
                <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                </asp:GridView>
                </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </div>


    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= DropDownList3.ClientID %>');
            var AuthecticationGrName = document.getElementById('<%= TextBox2.ClientID %>');
            var GroupName = document.getElementById('<%= TextBox3.ClientID %>');
            var SystemGroupName = document.getElementById('<%= TextBox4.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList1.ClientID %>');
            System.value = "";
            AuthecticationGrName.value = "";
            Plant.value = "";
            GroupName.value = "";
            SystemGroupName.value = "";
        }


        function btClear2() {
            var FirstName = document.getElementById('<%= TextBox5.ClientID %>');
            var LastName = document.getElementById('<%= TextBox6.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList2.ClientID %>');
            var BWIEmplNo = document.getElementById('<%= TextBox7.ClientID %>');
            var PlantIDNo = document.getElementById('<%= TextBox8.ClientID %>');
            FirstName.value = "";
            LastName.value = "";
            Plant.value = "";
            BWIEmplNo.value = "";
            PlantIDNo.value = "";
        }


        function showAlert(text) {
            alert(text);
        }

        function openModal() {
            $('#myModal').modal('show');
        }
        function closeModal() {
            $("#myModal").modal('hide');
        }

        function openFiltrModal() {
            $('#filtrModal').modal('show');
        }
        function closeFiltrModal() {
            $("#filtrModal").modal('hide');
        }

        function openFiltrModal2() {
            $('#filtrModal2').modal('show');
        }
        function closeFiltrModal2() {
            $("#filtrModal2").modal('hide');
        }


        function openAddModal() {
            $('#AddModal').modal('show');
        }
        function closeAddModal() {
            $("#AddModal").modal('hide');
        }


    </script> 


</asp:Content>
