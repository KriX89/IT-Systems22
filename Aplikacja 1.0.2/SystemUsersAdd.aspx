<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemUsersAdd.aspx.cs" Inherits="Aplikacja_1._0._2.SystemUsersAdd" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>

<asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>   
  <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

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

    <div style="margin-left:auto; margin-right:auto; width:95%; height:45%">
        <div class="row">
            <div class="col-md-4" style="text-align:center">
            <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">
            <table style="width: 100%; text-align:center">
            <tr style="padding: 20px 20px 20px 20px;">
                <td><asp:Label ID="Label1" runat="server" Text="Authentication Group: " /></td>
                <td><asp:Label ID="Label2" runat="server" Text="Plant: " /></td>
                <td><asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                <td>
                <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" /></td>
            </tr>
            </table>
        </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>   
                                <asp:GridView runat="server" ID="GridView2" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
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
                <div class="col-md-8" style="text-align:center" > 
                    <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">
                    <table style="width: 100%; text-align:center">
                    <tr style="padding: 20px 20px 20px 20px;">
                        <td><asp:Label ID="Label3" runat="server" Text="First Name: "/></td>
                        <td><asp:Label ID="Label4" runat="server" Text="Last Name: " /></td>
                        <td><asp:Label ID="Label5" runat="server" Text="Department: " /></td>
                        <td><asp:Label ID="Label6" runat="server" Text="Plant: " /></td>
                        <td><asp:Label ID="Label7" runat="server" Text="BWI Empl No: " /></td>
                        <td><asp:Label ID="Label8" runat="server" Text="Plant ID No: " /></td>
                        <td><asp:Button ID="Button3" runat="server" Text="Search" ForeColor="Black" OnClick="Button3_Click" /></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></td>
                        <td><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></td>
                        <td><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></td>
                        <td><asp:DropDownList ID="DropDownList3" runat="server" ForeColor="Black" /></td>
                        <td><asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></td>
                        <td><asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" /></td>
                    <td>
                    <input id="Button4" type="button" value="Clear" style="color:black" onclick="btClear2()" /></td>
                    </tr>
                    </table>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    <asp:HiddenField ID="HiddenTextBox" runat="server" />
                    <asp:HiddenField ID="HiddenTextBox2" runat="server" />
                    <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_OnPageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
                </div>
        </div>
   </div>
    <div style="margin-left:auto; margin-right:auto; width:95%; height:45%">
         <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    <table style="width: 100%; text-align:center">
                    <tr style="padding: 20px 20px 20px 20px;">
                        <td><asp:Label ID="Label9" runat="server" Text="Authentication Group:"/></td>
                        <td><asp:Label ID="Label10" runat="server" Text="First Name:" /></td>
                        <td><asp:Label ID="Label11" runat="server" Text="Last Name " /></td>
                        <td><asp:Label ID="Label12" runat="server" Text="Plant:" /></td>
                        <td><asp:Label ID="Label13" runat="server" Text="BWI Empl No:" /></td>
                        <td><asp:Label ID="Label14" runat="server" Text="Plant ID No:" /></td>
                        <td><asp:Label ID="Label15" runat="server" Text="Active:" /></td>
                        <td><asp:Label ID="Label16" runat="server" Text="Login:" /></td>
                        
                    </tr>
                    <tr>

                        <td><asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox7" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox8" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox9" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox10" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox11" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:CheckBox ID="CheckBox1" runat="server" Checked="true" /></td>
                        <td><asp:TextBox ID="TextBox12" runat="server" ForeColor="Black" /></td>
                        <td><asp:Button ID="Button5" runat="server" Text="Add" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to add?')" OnClick="Button5_Click" /></td>

                    </tr>
                    </table>
                    </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" /> 
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />

                        </Triggers>
                    </asp:UpdatePanel>
              </div>
                
             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
             <ContentTemplate>
                 <div style="margin-left:auto; margin-right:auto; width:80%;">
                 <asp:GridView runat="server" ID="GridView3" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridView3_OnPageIndexChanging" >
                 <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                 </asp:GridView>
                 </div>
             </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="GridView3" EventName="PageIndexChanged" />
             </Triggers>
             </asp:UpdatePanel>
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
