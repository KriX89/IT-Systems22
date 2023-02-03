<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmplEdit.aspx.cs" Inherits="Aplikacja_1._0._2.EmplEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>

  <asp:UpdatePanel ID="UpdatePanel6" runat="server">
  <ContentTemplate>    
  <div id="KomunikatModal" class="modal fade bd-example-modal-sm" role="dialog">
  <<div class="modal-dialog modal-sm">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-body">

          <div class="row" style="height: 80px">
            <div class="col-md-4" style="text-align:center"><asp:Image ID="Image1" runat="server" Height="60px" Width="60px" BackColor="#ebebeb" ImageAlign="AbsMiddle" ImageUrl="../image/info_icon.png" /> </div>
            <div class="col-md-8" style="text-align:left"><asp:Label ID="Label29" runat="server" Font-Size="Larger" Text="Komunikat" /></div>
        </div>

         <center> <input id="Button27" type="button" value="OK" style="width:80px" onclick="closeKomunikatModal()" /></center>
    </div>


    </div>

  </div>
  </div>
  </ContentTemplate>
  <Triggers>
      <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>



  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
  <ContentTemplate>    
  <div id="filtrModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label19" runat="server" Text="Group members filter" />
        </div>
      <div class="modal-body">   

        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label8" runat="server" Text="First Name: "/></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label10" runat="server" Text="Department: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList3" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>

        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label11" runat="server" Text="Plant: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:DropDownList ID="DropDownList4" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>         
        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label12" runat="server" Text="BWI Emploee No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>  

        <div class="row" style="height: 30px;">
            <div class="col-md-5" style="text-align:center"><asp:Label ID="Label13" runat="server" Text="Plant ID No: " /></div>
            <div class ="col-md-7" style="text-align:left"><asp:TextBox ID="TextBox8" runat="server" Width="100%" ForeColor="Black" /></div>
        </div>     


        </div>
    </div>

      <div class="modal-footer" style="text-align:center">
          <asp:Button ID="Button3" runat="server" Text="Search" ForeColor="Black" OnClientClick="closeFiltrModal()" OnClick="Button3_Click" />
          <input id="Button11" type="button" value="Clear" style="color:black" onclick="btClear()" />
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


  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
  <ContentTemplate>    
  <div id="AddModal" class="modal fade bd-example-modal-lg" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
        <div class="modal-header" style="text-align:center">
            <asp:Label ID="Label16" runat="server" Text="Add new system" />
        </div>
      <div class="modal-body">   
        <asp:HiddenField ID="HiddenEmpID" runat="server" />
          <asp:HiddenField ID="HiddenTreining" runat="server" />
        <div style="margin-left:auto; margin-right:auto; width:100%;">
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label1" runat="server" Text="First Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Last Name: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" /></div>
        </div>
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Plant: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList2" runat="server" ForeColor="Black" /></div>
        </div>
        
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>  
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Department: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" /></div>
        </div>
            </ContentTemplate>
            <Triggers>
            
            </Triggers>
        </asp:UpdatePanel>

            

        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label5" runat="server" Text="BWI Emploee No.: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" /></div>
        </div>           
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label6" runat="server" Text="Plant ID No.: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-6" style="text-align:center"><asp:Label ID="Label7" runat="server" Text="Active: " /></div>
            <div class ="col-md-6" style="text-align:left"><asp:CheckBox ID="CheckBox1" runat="server" Checked="True" /></div>
        </div> 
        <div class="row" style="height: 30px;">
            <div class="col-md-12" style="text-align:center"><asp:Label ID="Label14" runat="server" ForeColor="Red" Style="display:none" Text="* required fields" /></div>
        </div>
            



                </div>
            </div>

      <div class="modal-footer" style="text-align:center">
         
                    <asp:Button ID="Button1"  runat="server" Text="Add employee" ForeColor="Black" OnClientClick="return closeAddModalValid()" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Save changes" ForeColor="Black" OnClientClick="closeAddModal()" OnClick="Button2_Click" />
                    <input id="Button10" type="button" value="Cancel" style="color:black" onclick="closeAddModal()" />
      </div>
    </div>

  </div>
  </div>
        </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Button1" EventName ="click" />
  <asp:AsyncPostBackTrigger ControlID="Button2" EventName ="click" />
  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowDataBound" />
  <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click" />
  <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>


    <div style="margin-left:auto; margin-right:auto; width:90%;">
        <div class="row">
            <asp:Button ID="Button4" class="naglowektab" runat="server" Text="EMPLOYEES" OnClientClick="return false;" Style="cursor:default"/>
            <asp:Button ID="Button5" Style="background-image: url(../image/lupa2.png); background-repeat: no-repeat "  class="button_2"  runat="server" Text="Filter" OnClick="Button5_Click" />
            <asp:Button ID="Button7" Style="background-image: url(../image/plus.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Add new" OnClick="Button7_Click" />
            <asp:Button ID="Button8" Style="background-image: url(../image/edit.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Change selected" OnClick="Button8_Click" />
            <asp:Button ID="Button9" Style="background-image: url(../image/training.png); background-repeat: no-repeat " class="button_2" runat="server" Text="Training" OnClick="Button9_Click" />
            

                <div style="margin-left:auto; margin-right:auto; width:100%; color:white; background-color:#373636cd">

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
                        <asp:AsyncPostBackTrigger ControlID="Button9" EventName ="click" />
                    <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
        </div>
   </div>



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


        function openFiltrModal() {
            $('#filtrModal').modal('show');
        }
        function closeFiltrModal() {
            $("#filtrModal").modal('hide');
        }

        function openAddModal() {
            $('#AddModal').modal('show');
        }
        function closeAddModal() {

            $("#AddModal").modal('hide');
        }

        function closeAddModalValid() {

            var FirstName = document.getElementById('<%= TextBox1.ClientID %>');
            var LastName = document.getElementById('<%= TextBox2.ClientID %>');
            var Department = document.getElementById('<%= DropDownList1.ClientID %>');
            var Plant = document.getElementById('<%= DropDownList2.ClientID %>');
            var lInfo = document.getElementById('<%= Label14.ClientID %>');

            var lFirstName = document.getElementById('<%= Label1.ClientID %>');
            var lLastName = document.getElementById('<%= Label2.ClientID %>');
            var lDepartment = document.getElementById('<%= Label4.ClientID %>');
            var lPlant = document.getElementById('<%= Label3.ClientID %>');

            if (FirstName.value == "" || LastName.value == "" || Department.value == "" || Plant.value == "")
            {
                lInfo.style.display = "block";
                lFirstName.style.color = "red";
                lLastName.style.color = "red";
                lDepartment.style.color = "red";
                lPlant.style.color = "red";
                return false;



            }
            else
            {
                $("#AddModal").modal('hide');
                return true;

            }
            

        }

        function openKomunikatModal() {
            $('#KomunikatModal').modal('show');
        }
        function closeKomunikatModal() {
            $("#KomunikatModal").modal('hide');
        }


    </script> 

</asp:Content>




