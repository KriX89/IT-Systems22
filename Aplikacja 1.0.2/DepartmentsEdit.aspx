<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentsEdit.aspx.cs" Inherits="Aplikacja_1._0._2.DepartmentsEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:60%;">
        <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div class="col-md-8" style="text-align:center">
                <asp:GridView runat="server" ID="GridView1" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover"  AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_OnPageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                </asp:GridView>
                </div>

                <div class="col-md-4" style="text-align:center; background-color:rgb(128, 128, 128, 0.7); color:white">
                    <asp:HiddenField id="HiddenTextBox" runat="server" />
                    <table style="width: 100%;">
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Plant Name: " /></td><td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Department Name: " /></td><td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Active: " /></td><td><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></td>
                    </tr>
                    </table>

                    <asp:Button ID="Button1" runat="server" Text="Add Department" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to add?')" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to edit?')" OnClick="Button2_Click" />
                </div>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName ="click" />
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">


        function showAlert(text) {
            alert(text);
        }

    </script> 

</asp:Content>
