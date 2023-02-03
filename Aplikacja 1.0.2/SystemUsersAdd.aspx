<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemUsersAdd.aspx.cs" Inherits="Aplikacja_1._0._2.SystemUsersAdd" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
      <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


    <br>
    <br>

<asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>   
  <div id="myModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-body">          
          <asp:HiddenField ID="HiddenField1" runat="server" />
          <asp:GridView ID="GridView4" runat="server" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView4_OnPageIndexChanging" OnRowDataBound="GridView4_RowDataBound">
              <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
          </asp:GridView>
          <asp:Label ID="Label17" runat="server" Text="Selected: "></asp:Label>
          <label id="Label19" for="html"></label><br>
      </div>
      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button6" runat="server" Text="Select" OnClientClick="closeModal()"   OnClick="Button2_Click"/>
          <asp:Button ID="Button7" runat="server" Text="Cancel" OnClientClick="closeModal()"  />
      </div>
    </div>

  </div>
</div>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>



  <asp:UpdatePanel ID="UpdatePanel6" runat="server">
  <ContentTemplate>  
  <div id="filtrModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label18" runat="server" Text="Authentication group filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="Authentication Group: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Plant: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></div>
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
            <asp:Label ID="Label20" runat="server" Text="Emploees filter" />
        </div>
      <div class="modal-body">   
      <asp:HiddenField ID="HiddenTextBox" runat="server" />
      <asp:HiddenField ID="HiddenTextBox2" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="First Name: "/></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label5" runat="server" Text="Department: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Plant: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList3" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="BWI Empl No: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label8" runat="server" Text="Plant ID No: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" /></div>
        </div>
       
        </div>
        </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button3" runat="server" Text="Search" ForeColor="Black" OnClientClick="closeFiltrModal2()" OnClick="Button3_Click" />
          <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear2()" />
          <input id="Button6" type="button" value="Cancel" style="color:black" onclick="closeFiltrModal2()" />
      </div>
    </div>
  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


  <asp:UpdatePanel ID="UpdatePanel8" runat="server">
  <ContentTemplate>    
  <div id="AddModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label21" runat="server" Text="Add new system user" />
        </div>
      <div class="modal-body">   
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="Authentication Group:"/></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label10" runat="server" Text="First Name:" /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" ForeColor="Black" Enabled="false"/></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="Last Name " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox8" runat="server" ForeColor="Black" Enabled="false"/></div>
        </div>   
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label12" runat="server" Text="Plant:" /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox9" runat="server" ForeColor="Black" Enabled="false"/></div>
        </div>  
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="BWI Empl No:" /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox10" runat="server" ForeColor="Black" Enabled="false"/></div>
        </div>  
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label14" runat="server" Text="Plant ID No:" /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox11" runat="server" ForeColor="Black" Enabled="false"/></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label15" runat="server" Text="Active:" /></div>
            <div class ="col-md-6" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" Checked="true" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label16" runat="server" Text="Login:" /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox12" runat="server" ForeColor="Black" /></div>
        </div> 
        </div>
       </div>

      <div class="modal-footer" style="text-align:center">
         
                    <asp:Button ID="Button5" runat="server" Text="Add new user" ForeColor="Black" OnClientClick="closeAddModal()" OnClick="Button5_Click" />
                    <input id="Button13" type="button" value="Cancel" style="color:black" onclick="closeAddModal()" />
      </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


    <div style="margin-left:auto; margin-right:auto; width:90%; height:100%">
        <div class="row">
            <div class="col-md-4">
            <asp:Button ID="Button8" class="naglowektab" runat="server" Width="300px" Text="AUTHENTICATION GROUPS" OnClientClick="return false;" Style="cursor:default"/>
            <asp:Button ID="Button9" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button9_Click" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>   
                                <asp:GridView runat="server" ID="GridView2" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
                </div>


            <div class="col-md-8" > 
            
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>   
            <div runat="server" id="tabela2" style="display:none">
            <asp:Button ID="Button4" class="naglowektab" runat="server" Width="300px" Text="EMPLOYEES" OnClientClick="return false;" Style="cursor:default"/>
            <asp:Button ID="Button10" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button10_Click" />
            <asp:Button ID="Button11" Style="background-image: url(../image/plus.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Add new" OnClick="Button11_Click" />
            <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_OnPageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
            </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
             </Triggers>
             </asp:UpdatePanel>

            </div>
            </div>
   </div>



    <script type="text/javascript">
        function btClear() {
            var AuthecticationGrName = document.getElementById('<%= TextBox1.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList1.ClientID %>');
            AuthecticationGrName.value = "";
            Plant.value = "";
        }


        function btClear2() {
            var FirstName = document.getElementById('<%= TextBox2.ClientID %>');
            var LastName = document.getElementById('<%= TextBox3.ClientID %>');
            var Department = document.getElementById('<%= DropDownList2.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList3.ClientID %>');
            var BWIEmplNo = document.getElementById('<%= TextBox4.ClientID %>');
            var PlantIDNo = document.getElementById('<%= TextBox5.ClientID %>');
            FirstName.value = "";
            LastName.value = "";
            Department.value = "";
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

        function openKomunikatModal() {
            $('#KomunikatModal').modal('show');
        }
        function closeKomunikatModal() {
            $("#KomunikatModal").modal('hide');
        }

        function SelectRow(row) {

            var netID2 = document.getElementById('<%= HiddenField1.ClientID %>');
            var netID = document.getElementById('Label19');
            // get all data rows - siblings to current
            var _rows = row.parentNode.childNodes;

            var _selectedRowFirstCell = row.getElementsByTagName("td")[2];
            netID.innerHTML = _selectedRowFirstCell.innerHTML;
            netID2.value = _selectedRowFirstCell.innerHTML;

        }


    </script> 

</asp:Content>
