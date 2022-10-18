<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlantsDepartView.aspx.cs" Inherits="Aplikacja_1._0._2.PlantsDepartView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:60%;">
        <div class="row">
                <div class="col-md-3" style="text-align:center">
                        <br><asp:Label ID="Label1" runat="server" ForeColor="White" Font-Size="Larger" Text="Plants" /><br>
                        <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" />
                    </div>
                    <div class="col-md-9" style="text-align:center">
                        <table style="width: 100%; color:white; background-color:#373636cd"">
                        <tr style="padding: 20px 20px 20px 20px;">
                            <td><asp:Label ID="Label3" runat="server" Text="Plant: " /><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></td>
                            <td><asp:Label ID="Label4" runat="server" Text="Department: " /><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></td>
                            <td><asp:Label ID="Label7" runat="server" Text="Active: " /><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></td>
                            <td><asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClick="Button1_Click" /></td>
                        </tr>
                        </table>
                        <br><asp:Label ID="Label2" runat="server" ForeColor="White" Font-Size="Larger" Text="Departments" /><br>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView runat="server" ID="GridView1" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed "  AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_OnPageIndexChanging">
                                <PagerStyle CssClass="pagination-ys" BackColor="#003399" BorderColor="White" ForeColor="Black" />
                                </asp:GridView>
                                
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
                            </Triggers>
                            </asp:UpdatePanel>
                    </div>
            </div>
        </div>
</asp:Content>
