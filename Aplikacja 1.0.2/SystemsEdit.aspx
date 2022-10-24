<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemsEdit.aspx.cs" Inherits="Aplikacja_1._0._2.SystemsEdit" EnableEventValidation="false" %>
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
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label8" runat="server" Text="System: "/></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="Authentication Group: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList8" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="Location Type: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label10" runat="server" Text="System Type: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></div>
        </div>

                    <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="Plant: " /></div>
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
  <div id="AddModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label16" runat="server" Text="Add new system" />
        </div>
      <div class="modal-body">   
                              <asp:HiddenField id="HiddenTextBox" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="System Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Authentication Group Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList4" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Location Type: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList5" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="System Type: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList6" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label5" runat="server" Text="Vendor: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></div>
        </div>           
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Physical Location: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="Plant: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList7" runat="server" ForeColor="Black" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label12" runat="server" Text="Active: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label14" runat="server" Text="Support Email: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" /></div>
        </div> 

                    <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label15" runat="server" Text="Support Group: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" /></div>
        </div> 



                </div>
            </div>

      <div class="modal-footer" style="text-align:center">
         
                    <asp:Button ID="Button3" runat="server" Text="Add System" ForeColor="Black" OnClientClick="closeAddModal()" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="closeAddModal()" OnClick="Button4_Click" />
                    <input id="Button10" type="button" value="Cancel" style="color:black" onclick="closeAddModal()" />
      </div>
    </div>

  </div>
  </div>
        </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click" />
  <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>



    <div style="margin-left:auto; margin-right:auto; width:90%;">
        <div class="row">
                    <asp:Button ID="Button9" class="naglowektab" runat="server" Text="SYSTEMS" OnClientClick="return false;" Style="cursor:default"/>
                    <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button5_Click" />
                    <asp:Button ID="Button7" Style="background-image: url(../image/plus.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Add new" OnClick="Button7_Click" />
                    <asp:Button ID="Button8" Style="background-image: url(../image/edit.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Change selected" OnClick="Button8_Click" />

                    <br>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="margin-left:auto; margin-right:auto; width:100%;">
                        <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                        <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                        </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
                        <asp:AsyncPostBackTrigger ControlID="Button4" EventName ="click" />
                    </Triggers>
                    </asp:UpdatePanel>
        </div>
   </div>



    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= TextBox1.ClientID %>');
            var AuthecticationGrName = document.getElementById('<%= DropDownList8.ClientID %>');
            var LocationType = document.getElementById('<%= DropDownList1.ClientID %>');
            var SystemType = document.getElementById('<%= DropDownList2.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList3.ClientID %>');
            System.value = "";
            AuthecticationGrName.value = "";
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

        function openAddModal() {
            $('#AddModal').modal('show');
        }
        function closeAddModal() {
            $("#AddModal").modal('hide');
        }

    </script> 


</asp:Content>
