<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersInSystem.aspx.cs" Inherits="Aplikacja_1._0._2.UsersInSystem" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
        <div style="margin-left:auto; margin-right:auto; width:95%; height:45%">
        <div class="row">
            <div class="col-md-6" style="text-align:center">
            <div style="margin-left:auto; margin-right:auto; width:100%;  background-color:#373636cd; text-align:center">
            <table style="width: 100%; text-align:center; color:white">
            <tr style="padding: 20px 20px 20px 20px;">
                <td><asp:Label ID="Label1" runat="server" Text="System: " /></td>
                <td><asp:Label ID="Label2" runat="server" Text="Location type: " /></td>
                <td><asp:Label ID="Label3" runat="server" Text="System type: " /></td>
                <td><asp:Label ID="Label4" runat="server" Text="Plant: " /></td>
                <td><asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" ForeColor="Black" /></td>
                <td><input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" /></td>
            </tr>
            </table>
            
        
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
                </div>
                <div class="col-md-6" style="text-align:center" > 
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
                 <asp:GridView runat="server" ID="GridView3" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView3_OnPageIndexChanging" >
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

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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

    </script> 
</asp:Content>
