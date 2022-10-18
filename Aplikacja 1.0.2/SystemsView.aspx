<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemsView.aspx.cs" Inherits="Aplikacja_1._0._2.SystemsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:80%; color:white; background-color:#373636cd">
        <table style="width: 100%; text-align:center">
            <tr style="padding: 20px 20px 20px 20px;">
                <td><asp:Label ID="Label1" runat="server" Text="System: "/></td>
                <td><asp:Label ID="Label2" runat="server" Text="Location Type: " /></td>
                <td><asp:Label ID="Label3" runat="server" Text="System Type: " /></td>
                <td><asp:Label ID="Label4" runat="server" Text="Plant: " /></td>
                <td><asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></td>
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
            <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" >
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
            var System = document.getElementById('<%= TextBox1.ClientID %>');
            var LocationType = document.getElementById('<%= DropDownList1.ClientID %>');
            var SystemType = document.getElementById('<%= DropDownList2.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList3.ClientID %>');
            System.value = "";
            LocationType.value = "";
            SystemType.value = "";
            Plant.value = "";
            }
    </script> 


</asp:Content>
