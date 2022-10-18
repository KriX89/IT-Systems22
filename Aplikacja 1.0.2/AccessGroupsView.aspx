<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessGroupsView.aspx.cs" Inherits="Aplikacja_1._0._2.AccessGroupsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:80%; color:white; background-color:#373636cd">
        <table style="width: 100%; text-align:center">
            <tr style="padding: 20px 20px 20px 20px;">
                <td><asp:Label ID="Label1" runat="server" Text="System: "/></td>
                <td><asp:Label ID="Label2" runat="server" Text="Authentication Group Name: " /></td>
                <td><asp:Label ID="Label3" runat="server" Text="Group Name: " /></td>
                <td><asp:Label ID="Label4" runat="server" Text="Descriotion: " /></td>
                <td><asp:Label ID="Label5" runat="server" Text="System Group Name: " /></td>
                <td><asp:Label ID="Label6" runat="server" Text="Plant: " /></td>
                <td><asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" ForeColor="Black" /></td>
                <td>
                <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" /></td>
            </tr>
        </table>
    </div>

    <br>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left:auto; margin-right:auto; width:80%;">
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


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
    </script> 


</asp:Content>
