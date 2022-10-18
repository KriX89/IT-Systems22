<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupMembersAdd.aspx.cs" Inherits="Aplikacja_1._0._2.GroupMembersAdd" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>

  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>   
  <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Add User to Access Group" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label21" runat="server" Text="Valid From: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="txtDate" runat="server" TextMode="Date" ClientIDMode="Static" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label22" runat="server" Text="Valid To: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox18" runat="server" TextMode="Date" ClientIDMode="Static" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label23" runat="server" Text="Indefinitely: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label20" runat="server" Text="TicketNo: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox19" runat="server" /></div>
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

    <div style="margin-left:auto; margin-right:auto; width:100%; height:45%">
        <div class="row">
            <div class="col-md-6" style="text-align:center">
                <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd" >
                    <table style="width: 100%; text-align: center">
                        <tr style="padding: 20px 20px 20px 20px;">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="System: " /></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Authentication Group: " /></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Group Name: " /></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="System Group Name: " /></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Plant: " /></td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                            <td>
                                <input id="Button2" type="button" value="Clear" style="color: black" onclick="btClear()" /></td>
                        </tr>
                    </table>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:GridView runat="server" ID="GridView1" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridView1_OnPageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            <div class="col-md-6" style="text-align:center">
                <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd" >
                    <table style="width: 100%; text-align: center">
                        <tr style="padding: 20px 20px 20px 20px;">
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="First Name: " /></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Last Name: " /></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Plant: " /></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="BWI Empl No: " /></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Plant ID No: " /></td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Search" ForeColor="Black" OnClick="Button3_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" ForeColor="Black" /></td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server" ForeColor="Black" /></td>
                            
                            <td>
                                <input id="Button4" type="button" value="Clear" style="color: black" onclick="btClear2()" /></td>
                        </tr>
                    </table>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:HiddenField ID="HiddenTextBox" runat="server" />
                <asp:HiddenField ID="HiddenTextBox2" runat="server" />
                <asp:HiddenField ID="HiddenTextBox3" runat="server" />
                <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
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
    <div style="margin-left:auto; margin-right:auto; width:100%; height:45%">
         <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="HiddenEmail" runat="server" />
                    <table style="width: 100%; text-align:center">
                    <tr style="padding: 20px 20px 20px 20px;">
                        <td><asp:Label ID="Label11" runat="server" Text="System"/></td>
                        <td><asp:Label ID="Label12" runat="server" Text="Group Name" /></td>
                        <td><asp:Label ID="Label13" runat="server" Text="System Group Name" /></td>
                        <td><asp:Label ID="Label14" runat="server" Text="First Name" /></td>
                        <td><asp:Label ID="Label15" runat="server" Text="Last Name" /></td>
                        <td><asp:Label ID="Label16" runat="server" Text="Plant" /></td>
                        <td><asp:Label ID="Label17" runat="server" Text="BWI Empl No:" /></td>
                        <td><asp:Label ID="Label18" runat="server" Text="Plant ID No:" /></td>
                        
                    </tr>
                    <tr>

                        <td><asp:TextBox ID="TextBox9" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox10" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox11" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox12" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox13" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox14" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox15" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:TextBox ID="TextBox16" runat="server" ForeColor="Black" Enabled="false"/></td>
                        <td><asp:Button ID="Button5" runat="server" Text="Add" ForeColor="Black" OnClick="Button5_Click" /></td>

                    </tr>
                    </table>
                    </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
              </div>
                
             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
             <ContentTemplate>
                 <div style="margin-left:auto; margin-right:auto; width:90%;">
                 <asp:GridView runat="server" ID="GridView3" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView3_OnPageIndexChanging" >
                 <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                 </asp:GridView>
                 </div>
             </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                 <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
             </Triggers>
             </asp:UpdatePanel>


    </div>

    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= TextBox1.ClientID %>');
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


    </script> 


</asp:Content>
