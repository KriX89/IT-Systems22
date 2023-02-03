<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlantsDepartView.aspx.cs" Inherits="Aplikacja_1._0._2.PlantsDepartView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


      <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>    
  <div id="filtrModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Departments filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Plant: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Department: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="Active: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></div>
        </div>


        </div>
    </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button1" runat="server" Text="Search" ForeColor="Black" OnClientClick="closeFiltrModal()" OnClick="Button1_Click" />
          <input id="Button2" type="button" value="Clear" style="color:black" onclick="btClear()" />
          <input id="Button6" type="button" value="Cancel" style="color:black" onclick="closeFiltrModal()" />
      </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


    <br>
    <br>
    <div style="margin-left:auto; margin-right:auto; width:60%;">
        <div class="row">
                <div class="col-md-3">
                        <asp:Button ID="Button3" class="naglowektab" runat="server" Text="PLANTS" OnClientClick="return false;" Style="cursor:default"/>
                        <asp:GridView runat="server" ID="GridView2" Width="100%" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed" />
                    </div>
                    <div class="col-md-9">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="Button4" class="naglowektab" runat="server" Text="DEPARTMENTS" OnClientClick="return false;" Style="cursor:default"/>
                                <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Filter" OnClick="Button5_Click" />
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

    <script type="text/javascript">
        function btClear() {

            var Department = document.getElementById('<%= DropDownList1.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList2.ClientID %>');

            Department.value = "";
            Plant.value = "";

        }

        function openFiltrModal() {
            $('#filtrModal').modal('show');
        }
        function closeFiltrModal() {
            $("#filtrModal").modal('hide');
        }

    </script> 

</asp:Content>
