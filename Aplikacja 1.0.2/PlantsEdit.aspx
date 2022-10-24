<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlantsEdit.aspx.cs" Inherits="Aplikacja_1._0._2.PlantsEdit"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>


    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
  <ContentTemplate>    
  <div id="AddModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label17" runat="server" Text="Add new plant" />
        </div>
      <div class="modal-body">   
        <asp:HiddenField id="HiddenTextBox" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="Plant Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Active: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></div>
        </div>         
        </div>
       </div>

      <div class="modal-footer" style="text-align:center">
         
                    <asp:Button ID="Button1" runat="server" Text="Add plant" ForeColor="Black" OnClientClick="closeAddModal()" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="closeAddModal()" OnClick="Button2_Click" />
                    <input id="Button10" type="button" value="Cancel" style="color:black" onclick="closeAddModal()" />
      </div>
    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


    <div style="margin-left:auto; margin-right:auto; width:45%;">
        <div class="row">
            <asp:Button ID="Button4" class="naglowektab" runat="server" Text="PLANTS" OnClientClick="return false;" Style="cursor:default"/>
         <asp:Button ID="Button8" Style="background-image: url(../image/plus.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Add new" OnClick="Button7_Click" />
        <asp:Button ID="Button9" Style="background-image: url(../image/edit.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Change selected" OnClick="Button8_Click" />
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="GridView2" HeaderStyle-BackColor="#003399" HeaderStyle-BorderColor="#003300" HeaderStyle-ForeColor="White" CssClass="table table-condensed table-hover" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
        </div>
   </div>



    <script type="text/javascript">

        function showAlert(text) {
            alert(text);
        }


        function openAddModal() {
            $('#AddModal').modal('show');
        }
        function closeAddModal() {
            $("#AddModal").modal('hide');
        }


    </script> 


</asp:Content>
