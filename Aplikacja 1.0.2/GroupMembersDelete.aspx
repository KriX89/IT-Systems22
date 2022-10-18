<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupMembersDelete.aspx.cs" Inherits="Aplikacja_1._0._2.GroupMembersEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <div class="row">
            <div class="col-md-9" style="text-align:center">
    <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">
        <table style="width: 100%; text-align:center">
            <tr style="padding: 20px 20px 20px 20px;">
                <td><asp:Label ID="Label1" runat="server" Text="System: "/></td>
                <td><asp:Label ID="Label3" runat="server" Text="First Name: " /></td>
                <td><asp:Label ID="Label4" runat="server" Text="Last Name: " /></td>
                <td><asp:Label ID="Label5" runat="server" Text="Login: " /></td>
                <td><asp:Label ID="Label7" runat="server" Text="Plant: " /></td>
                <td><asp:Label ID="Label8" runat="server" Text="BWI Empl No: " /></td>
                <td><asp:Label ID="Label9" runat="server" Text="Plant ID No: " /></td>
                <td><asp:Label ID="Label10" runat="server" Text="TicketNo: " /></td>
                <td><asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></td>
                <td><asp:DropDownList ID="DropDownList4" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" /></td>
                <td><asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" /></td>

                <td>
                <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" /></td>
            </tr>
        </table>
    </div>

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
            <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
                </div>
        <div class="col-md-3" style="text-align:center">
            <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd" >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>   
                    <table style="width: 100%;">
                        <asp:HiddenField ID="HiddenEmail" runat="server" />
                        <asp:HiddenField ID="HiddenTextBox" runat="server" />
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="System: " /></td><td><asp:TextBox ID="TextBox7" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Group Name: " /></td><td><asp:TextBox ID="TextBox8" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label11" runat="server" Text="First Name: " /></td><td><asp:TextBox ID="TextBox9" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label12" runat="server" Text="Last Name: " /></td><td><asp:TextBox ID="TextBox10" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label13" runat="server" Text="Login: " /></td><td><asp:TextBox ID="TextBox11" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label14" runat="server" Text="Department: " /></td><td><asp:TextBox ID="TextBox12" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label15" runat="server" Text="Plant: " /></td><td><asp:TextBox ID="TextBox13" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label16" runat="server" Text="BWI Empl No: " /></td><td><asp:TextBox ID="TextBox14" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label17" runat="server" Text="Plant ID No: " /></td><td><asp:TextBox ID="TextBox15" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label18" runat="server" Text="Ticket No: " /></td><td><asp:TextBox ID="TextBox16" runat="server" ForeColor="Black" Enabled="false" /></td>
                    </tr>

                    </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button3" EventName ="click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>

                    <asp:Button ID="Button3" runat="server" Text="Delete" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="Button3_Click" />
                </div>
        </div>


        </div>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function btClear() {
            var System = document.getElementById('<%= DropDownList1.ClientID %>');
            var FirstName = document.getElementById('<%= TextBox1.ClientID %>');
            var LastName = document.getElementById('<%= TextBox2.ClientID %>');
            var Login = document.getElementById('<%= TextBox3.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList4.ClientID %>');
            var BWIEmplNo = document.getElementById('<%= TextBox4.ClientID %>');
            var PlantIDNo = document.getElementById('<%= TextBox5.ClientID %>');
            var TicketNo = document.getElementById('<%= TextBox6.ClientID %>');
            System.value = "";
            FirstName.value = "";
            LastName.value = "";
            Login.value = "";
            Plant.value = "";
            BWIEmplNo.value = "";
            PlantIDNo.value = "";
            TicketNo.value = "";
        }


        function showAlert( text ) {
            alert(text);
        }



    </script> 


</asp:Content>
