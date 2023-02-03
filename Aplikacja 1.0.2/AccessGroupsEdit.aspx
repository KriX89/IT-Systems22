<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessGroupsEdit.aspx.cs" Inherits="Aplikacja_1._0._2.AccessGroupsEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>

  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
  <ContentTemplate>    
  <div id="CheckModal" class="modal fade bd-example-modal-lg" role="dialog">    
  <<div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-body">

          <div class="row">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="Users in AD"/></div>
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label14" runat="server" Text="Users in IAM"/></div>
        </div> 
          <div style='overflow-y: auto; overflow-x: hidden; max-height:500px; width:auto'>
          <div class="row">
            <div class="col-md-6" style="text-align:center"><asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" BackColor="White" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NetID" HeaderText="NetID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />


                <asp:TemplateField HeaderText="IAM">
                <ItemTemplate>
                <asp:Button ID="btnAddRecord"  
                            CommandArgument="<%#((GridViewRow)Container).Cells[0].Text+'%'+((GridViewRow)Container).Cells[1].Text %>"  
                            CommandName="AddRecord" runat="server" onclientclick="closeCheckModal()" Text="Add in IAM" />
                </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
            </asp:GridView> </div>
            <div class="col-md-6" style="text-align:center"><asp:GridView ID="GridView3" OnRowCommand="GridView3_RowCommand" runat="server" BackColor="White" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NetID" HeaderText="NetID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />


                <asp:TemplateField HeaderText="IAM">
                <ItemTemplate>
                <asp:Button ID="btnDelRecord"  
                            CommandArgument="<%#((GridViewRow)Container).Cells[0].Text %>" 
                            CommandName="DelRecord" runat="server" onclientclick="closeCheckModal()" Text="Delete in IAM" />
                </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
            </asp:GridView></div>
        </div> 
              </div>

    </div>
        <div class="modal-footer" style="text-align:center">
            <input id="Button30" type="button" value="OK" style="width:80px" onclick="closeCheckModal()" />
      </div>


    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
      <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
  <ContentTemplate>    
  <div id="KomunikatModal" class="modal fade bd-example-modal-sm" role="dialog">
  <div class="modal-dialog modal-sm">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-body">

          <div class="row" style="height: 80px">
            <div class="col-md-4" style="text-align:center"><asp:Image ID="Image2" runat="server" Height="60px" Width="60px" BackColor="#ebebeb" ImageAlign="AbsMiddle" ImageUrl="../image/info_icon.png" /> </div>
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



  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>    
  <div id="filtrModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Systems access groups filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="System: "/></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Authentication Group Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Descriotion: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></div>
        </div>

        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label5" runat="server" Text="System Group Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></div>
        </div>    
            
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Plant: " /></div>
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
  <div id="AddModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label17" runat="server" Text="Add new system acces group" />
        </div>
      <div class="modal-body">   
        <asp:HiddenField ID="HiddenGroupID" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="System: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList4" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label8" runat="server" Text="Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="Descriotion: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"></td><td><asp:Label ID="Label10" runat="server" Text="System Group Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="Active: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" Width="100%" Checked="True" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-12" style="text-align:center"><asp:Label ID="Label12" runat="server" ForeColor="Red" Style="display:none" Text="* required fields" /></div>
        </div>
        </div>
       </div>

      <div class="modal-footer" style="text-align:center">
         
                    <asp:Button ID="Button3" runat="server" Text="Add access group" ForeColor="Black" OnClientClick="return closeAddModalValid()" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="return closeAddModalValid()" OnClick="Button4_Click" />
                    <input id="Button10" type="button" value="Cancel" style="color:black" onclick="closeAddModal()" />
      </div>
    </div>

  </div>
  </div>
        </ContentTemplate>
  <Triggers>
      <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="Button4" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>




    <div style="margin-left:auto; margin-right:auto; width:90%;">
        <div class="row">
                    <asp:Button ID="Button7" class="naglowektab" runat="server" Text="ACCESS GROUPS" OnClientClick="return false;" Style="cursor:default"/>
                    <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button5_Click" />
                    <asp:Button ID="Button8" Style="background-image: url(../image/plus.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Add new" OnClick="Button7_Click" />
                    <asp:Button ID="Button9" Style="background-image: url(../image/edit.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Change selected" OnClick="Button8_Click" />
                    <asp:Button ID="Button11" Style="background-image: url(../image/training.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Check" OnClick="Button11_Click" />

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
            var System = document.getElementById('<%= DropDownList1.ClientID %>');
            var AuthecticationGrName = document.getElementById('<%= DropDownList2.ClientID %>');
            var GroupName = document.getElementById('<%= TextBox1.ClientID %>');
            var Description = document.getElementById('<%= TextBox2.ClientID %>');
            var SystemGroupName = document.getElementById('<%= TextBox3.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList3.ClientID %>');
            System.value = "";
            AuthecticationGrName.value = "";
            Plant.value = "";
            GroupName.value = "";
            Description.value = "";
            SystemGroupName.value = "";
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

        function closeAddModalValid() {


            var ddl4 = document.getElementById('<%= DropDownList4.ClientID %>');
            var tb4 = document.getElementById('<%= TextBox4.ClientID %>');
            var tb5 = document.getElementById('<%= TextBox5.ClientID %>');
            var tb6 = document.getElementById('<%= TextBox6.ClientID %>');
            var lInfo = document.getElementById('<%= Label12.ClientID %>');


            var label7 = document.getElementById('<%= Label7.ClientID %>');
            var label8 = document.getElementById('<%= Label8.ClientID %>');
            var label9 = document.getElementById('<%= Label9.ClientID %>');
            var label10 = document.getElementById('<%= Label10.ClientID %>');


            if (ddl4.value == "" || tb4.value == "" || tb5.value == "" || tb6.value == "") {
                lInfo.style.display = "block";
                label7.style.color = "red";
                label8.style.color = "red";
                label9.style.color = "red";
                label10.style.color = "red";
                return false;



            }
            else {
                $("#AddModal").modal('hide');
                return true;

            }


        }

        function openKomunikatModal() {
            $('#KomunikatModal').modal('show');
        }
        function closeKomunikatModal() {
            $("#KomunikatModal").modal('hide');
        }

        function openCheckModal() {
            $('#CheckModal').modal('show');
        }
        function closeCheckModal() {
            $("#CheckModal").modal('hide');
        }


    </script> 


</asp:Content>
