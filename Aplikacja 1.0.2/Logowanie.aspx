<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logowanie.aspx.cs" Inherits="Aplikacja_1._0._2.Lokalizacja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div aria-atomic="False" style="text-align:center; font-size: xx-large;">
        <br>
        <asp:Label ID="Label1" runat="server"   Text="Identity & Access Management " Font-Bold="True" ForeColor="White"></asp:Label>
    </div> 

    <asp:Panel ID="Panel1" runat="server" Visible ="true">

             <div class="centerDiv"   style="text-align:center">
             </div>
            <div class="centerDiv2"   style="text-align:center">
            <h1 style="font-size: 14px">
            <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Please login"></asp:Label>
            </h1>
            <input id="uname1" type="text" runat="server" placeholder="login" autocomplete="off" > 
            <br>
            <br>
            <input id="psw1" type="password" runat="server" placeholder="password" autocomplete="off" > 
            <br>      
                <br>
                <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red" />
                <br>
                <asp:Button ID="Button7" runat="server" Height="25px" OnClick="Button1_Click1" Text="Login" Width="80px" />
                
                <asp:Button ID="Button8" runat="server" Height="25px" OnClick="Button8_Click" Text="Cancel" Width="80px" />
                <br>
            </div>
    </asp:Panel>





    



   






 



    <script type="text/javascript" language="javascript">



        function ResetMe() {

            return false;
        }






        window.onload = function zmniejsz_menu() {

            document.getElementById("Image1").style.height = "40px";
            document.getElementById("Image2").style.height = "35px";
            document.getElementById("Image2").style.width = "35px";
        }

        function ukryj_tabele() {
            document.getElementById('target').style.display = 'none';
        }



        function pageLoad() {
            var table = document.getElementById("TableHeader");
            var temp = 0;
            var naglowek = document.getElementById('naglowek');
            var panel1 = document.getElementById('panel11');


            if (panel1.clientHeight < panel1.scrollHeight) { naglowek.style.width = "calc(100% - 17px)"; }
            else { naglowek.style.width = "100%"; }



            for (var i = grid.rows[0].cells.length - 1; i > -1; i--) {
                table.rows[0].cells[i].style.width = (parseInt(grid.rows[0].cells[i].offsetWidth)) + 'px';


            }
        } 


        function zmianazaznaczenia()
        {
            if (zaznaczenie1.checked)
               zaznaczenie2.checked = false;
        }

        function zmianazaznaczenia2() {
            if (zaznaczenie2.checked)
                zaznaczenie1.checked = false;
                }


        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox" && objRef != inputList[i] && GridView.rows[i].style['display'] == '') {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }

                }

            }

        }



        function Filter() {


            if (btzalogowany.value == "Wyloguj") {

                var rows = tblGrid.rows;
                var znaleziono = false;
                var i = 0, row, cell;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    cell = row.cells[2];
                    if (calatabela.checked)
                    {
                        var found = false;
                        for (var j = 0; j < row.cells.length; j++) {
                            cell = row.cells[j];
                            if (cell.innerHTML.toUpperCase().indexOf(txtKeyword.value.toUpperCase()) >= 0) {
                                found = true;
                                znaleziono = true;
                                break;
                            }
                        }
                        if (!found) {
                            row.style['display'] = 'none';

                        }
                        else {
                            row.style.display = '';
                        }
                    }
                    else { 
                    if (dokladne.checked) {
                        if (cell.innerHTML.length == txtKeyword.value.length && cell.innerHTML.indexOf(txtKeyword.value) >= 0) {
                            row.style.display = '';
                            row2.style.display = '';
                            znaleziono = true;
                        }
                        else {
                            row.style['display'] = 'none';
                            row2.style['display'] = 'none';
                        }
                    }
                    else {
                        if (cell.innerHTML.indexOf(txtKeyword.value) >= 0) {
                            row.style.display = '';
                            row2.style.display = '';
                            znaleziono = true;
                        }
                        else {
                            row.style['display'] = 'none';
                            row2.style['display'] = 'none';
                        }

                        }
                    }

                }

                if (znaleziono == false) { alert("Nie znaleziono rekordów do wyświetlenia"); }
                return false;  
                
                
            }

            else {
                return true;
            }

            
        }







    </script>





</asp:Content>
