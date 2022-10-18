<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmplEdit.aspx.cs" Inherits="Aplikacja_1._0._2.EmplEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:90%;">
        <div class="row">
                <div class="col-md-8" style="text-align:center">
                <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">
                 <table style="width: 100%; text-align:center">
                    <tr style="padding: 20px 20px 20px 20px;">
                        <td><asp:Label ID="Label8" runat="server" Text="First Name: "/></td>
                        <td><asp:Label ID="Label9" runat="server" Text="Last Name: " /></td>
                        <td><asp:Label ID="Label10" runat="server" Text="Department: " /></td>
                        <td><asp:Label ID="Label11" runat="server" Text="Plant: " /></td>
                        <td><asp:Label ID="Label12" runat="server" Text="BWI Emploee No.: " /></td>
                        <td><asp:Label ID="Label13" runat="server" Text="Plant ID No.: " /></td>
                        <td><asp:Button ID="Button3" runat="server" Text="Search" ForeColor="Black" OnClick="Button3_Click" /></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" /></td>
                        <td><asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" /></td>
                        <td><asp:DropDownList ID="DropDownList3" runat="server" ForeColor="Black" /></td>
                        <td><asp:DropDownList ID="DropDownList4" runat="server" ForeColor="Black" /></td>
                        <td><asp:TextBox ID="TextBox7" runat="server" ForeColor="Black" /></td>
                        <td><asp:TextBox ID="TextBox8" runat="server" ForeColor="Black" /></td>
                        <td><input id="Button4" type="button" value="Clear" style="color:black" onclick="btClear()" /></td>
                    </tr>
                </table>
                </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>   
                                <asp:GridView runat="server" ID="GridView2" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" DataKeyNames="FirstName" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>

 

                    </div>
                <div class="col-md-4" style="text-align:center; background-color:rgb(128, 128, 128, 0.7); color:white">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>   
                    <table style="width: 100%;">
                        <asp:HiddenField ID="HiddenEmpID" runat="server" />
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="First Name: " /></td><td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Last Name: " /></td><td><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Plant: " /></td><td><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" AutoPostBack = "true" OnSelectedIndexChanged = "OnSelectedIndexChanged" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Department: " /></td><td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label5" runat="server" Text="BWI Emploee No.: " /></td><td><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Plant ID No.: " /></td><td><asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label7" runat="server" Text="Active: " /></td><td><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></td>
                    </tr>
                    </table>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>

                    <asp:Button ID="Button1" runat="server" Text="Add Emploee" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to add?')" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to edit?')" OnClick="Button2_Click" />
                    </div>
        </div>
   </div>


 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function btClear() {
            var FirstName = document.getElementById('<%= TextBox5.ClientID %>');
            var LastName = document.getElementById('<%= TextBox6.ClientID %>');
            var Department = document.getElementById('<%= DropDownList3.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList4.ClientID %>');
            var BWIEmplNo = document.getElementById('<%= TextBox7.ClientID %>');
            var PlantIDNo = document.getElementById('<%= TextBox8.ClientID %>');

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

    </script> 

</asp:Content>




