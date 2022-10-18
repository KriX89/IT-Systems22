<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthGroupEdit.aspx.cs" Inherits="Aplikacja_1._0._2.AuthGroupEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:80%;">
        <div class="row">
                <div class="col-md-8" style="text-align:center">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>   
                                <asp:GridView runat="server" ID="GridView2" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
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
                        <td><asp:Label ID="Label1" runat="server" Text="Authentication Group Name: " /></td><td><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Mode: " /></td><td><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Active: " /></td><td><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></td>
                    </tr>
                    </table>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>

                    <asp:Button ID="Button1" runat="server" Text="Add Authentication Group" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to add?')" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="return confirm('Are you sure you want to edit?')" OnClick="Button2_Click" />
                    </div>
        </div>
   </div>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        function showAlert(text) {
            alert(text);
        }


    </script> 

</asp:Content>
