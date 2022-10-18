<%@ Page Title="Lokalizacje" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lokalizacja.aspx.cs" Inherits="Aplikacja_1._0._2.Lokalizacja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" aria-atomic="False">

    <div class="row" style="margin-left: 20px">
    <div class="col-md-9">
    <asp:Label ID="Label1" runat="server" Text="Indeks: " /> 
    <asp:TextBox ID="TextBox1" runat="server" Width="212px" autocomplete="off" />
    <input id="Button3" title="Wyczyść" type="button" value="&lt;-" onclick="ResetMe()" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="ukryj_tabele()" Text="WYSZUKAJ"  />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="ukryj_tabele()" Text="ODŚWIEŻ" Width="102px" />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="ZAPISZ DO EXCEL" Width="140px" />
    </div>
    <div class="col-md-3" style="text-align:end">
        <asp:Button ID="Button5" runat="server" Text="INSTRUKCJA" title="Instrukcja dla użytkownika" OnClientClick="window.open('Instrukcja.aspx')" />
    </div>
    </div>

        
        
        


        


<div style="margin-left: 20px">
        <asp:CheckBox ID="CheckBox5" runat="server" Text=" - Dokładne dopasowanie"  />
        <br />

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BWI_QUALITYConnectionString %>" SelectCommand="SELECT [PN] as Indeks, [Nazwa], [Typ], [Strefa], [Regal], [Poziom], [Pozycja], [IloscStandardowa], [Pojemnik], [Wymiary], [Nosnosc], [IloscKK], [Min], [Max], [Wydzial] FROM [Kanban_v1]"></asp:SqlDataSource>

        <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text=" - OA " />
    &nbsp;
        <asp:CheckBox ID="CheckBox2" runat="server" Checked="True" Text="- OC " />
   &nbsp;
        <asp:CheckBox ID="CheckBox3" runat="server" Checked="True" Text=" - OT " />
    &nbsp;
        <asp:CheckBox ID="CheckBox4" runat="server" Checked="True" Text=" - LL " />
        <br />
</div>

        
                <style>
                table.table_class tbody  tr th  
                {
                 text-align:center !important;
                }

                .labellocation
                {
                    text-align: right;

                    }

                </style>

        <style type="text/css">
        .GVFixedHeader
        {
            font-weight: bold;
            background-color: Green;
            position: relative;
            top: expression(this.parentNode.parentNode.parentNode.scrollTop-1);
        }
        </style>





        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="19px" RepeatDirection="Horizontal" Width="100%" Visible="False">
            <asp:ListItem Selected="True" Value="- Nazwa">- Nazwa</asp:ListItem>
            <asp:ListItem Selected="True">- Typ</asp:ListItem>
            <asp:ListItem Selected="True">- Strefa</asp:ListItem>
            <asp:ListItem Selected="True">- Regał</asp:ListItem>
            <asp:ListItem Selected="True">- Poziom</asp:ListItem>
            <asp:ListItem Selected="True">- Pozycja</asp:ListItem>
            <asp:ListItem Selected="True">- Ilość Standar.</asp:ListItem>
            <asp:ListItem Selected="True">- Pojemnik</asp:ListItem>
            <asp:ListItem Selected="True">- Wymiary</asp:ListItem>
            <asp:ListItem Selected="True">- Nośność</asp:ListItem>
            <asp:ListItem Selected="True">- Ilość KK</asp:ListItem>
            <asp:ListItem Selected="True">- Min</asp:ListItem>
            <asp:ListItem Selected="True">- Max</asp:ListItem>
            <asp:ListItem Selected="True">- Wydział</asp:ListItem>
        </asp:CheckBoxList>


     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
     <ProgressTemplate>
      <br><br>
     <center><label>Wczytywanie danych ...</label></center>
    </ProgressTemplate>  
    </asp:UpdateProgress>



                





        


        
        




        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

        <asp:Panel ID="Panel2" runat="server" CssClass="HeaderFreez" style="overflow:auto;height:20px; width:calc(100% - 17px); overflow:hidden; visibility:hidden" >
            <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" Width="100%" Height="100%"  BackColor="White" AutoGenerateColumns="False" Font-Size="Small">
                <Columns>
                    <asp:BoundField DataField="Indeks" HeaderText="Indeks" SortExpression="Indeks" />
                    <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                    <asp:BoundField DataField="Typ" HeaderText="Typ" SortExpression="Typ" />
                    <asp:BoundField DataField="Strefa" HeaderText="Strefa" SortExpression="Strefa" />
                    <asp:BoundField DataField="Regal" HeaderText="Regal" SortExpression="Regal" />
                    <asp:BoundField DataField="Poziom" HeaderText="Poziom" SortExpression="Poziom" />
                    <asp:BoundField DataField="Pozycja" HeaderText="Pozycja" SortExpression="Pozycja" />
                    <asp:BoundField DataField="IloscStandardowa" HeaderText="IloscStandardowa" SortExpression="IloscStandardowa" />
                    <asp:BoundField DataField="Pojemnik" HeaderText="Pojemnik" SortExpression="Pojemnik" />
                    <asp:BoundField DataField="Wymiary" HeaderText="Wymiary" SortExpression="Wymiary" />
                    <asp:BoundField DataField="Nosnosc" HeaderText="Nosnosc" SortExpression="Nosnosc" />
                    <asp:BoundField DataField="IloscKK" HeaderText="IloscKK" SortExpression="IloscKK" />
                    <asp:BoundField DataField="Min" HeaderText="Min" SortExpression="Min" />
                    <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" />
                    <asp:BoundField DataField="Wydzial" HeaderText="Wydzial" SortExpression="Wydzial" />
                </Columns>
            <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            </asp:GridView>    
         </asp:Panel>


        <div id="panel11" style="overflow:auto; height:700px; width:100%;" onscroll="ukryj(this)">
            <span id="target">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" Width="100%" Height="100%" BackColor="White" AutoGenerateColumns="False" Font-Size="Small">
                <Columns>
                    <asp:BoundField DataField="Indeks" HeaderText="Indeks" SortExpression="Indeks" />
                    <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                    <asp:BoundField DataField="Typ" HeaderText="Typ" SortExpression="Typ" />
                    <asp:BoundField DataField="Strefa" HeaderText="Strefa" SortExpression="Strefa" />
                    <asp:BoundField DataField="Regal" HeaderText="Regal" SortExpression="Regal" />
                    <asp:BoundField DataField="Poziom" HeaderText="Poziom" SortExpression="Poziom" />
                    <asp:BoundField DataField="Pozycja" HeaderText="Pozycja" SortExpression="Pozycja" />
                    <asp:BoundField DataField="IloscStandardowa" HeaderText="IloscStandardowa" SortExpression="IloscStandardowa" />
                    <asp:BoundField DataField="Pojemnik" HeaderText="Pojemnik" SortExpression="Pojemnik" />
                    <asp:BoundField DataField="Wymiary" HeaderText="Wymiary" SortExpression="Wymiary" />
                    <asp:BoundField DataField="Nosnosc" HeaderText="Nosnosc" SortExpression="Nosnosc" />
                    <asp:BoundField DataField="IloscKK" HeaderText="IloscKK" SortExpression="IloscKK" />
                    <asp:BoundField DataField="Min" HeaderText="Min" SortExpression="Min" />
                    <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" />
                    <asp:BoundField DataField="Wydzial" HeaderText="Wydzial" SortExpression="Wydzial" />
                </Columns>
            <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            </asp:GridView>
                </span>
       </div>
       </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
            </Triggers>
       </asp:UpdatePanel>




    </div>




 



    <script type="text/javascript" language="javascript">



        function ResetMe() {
            document.getElementById("<%= TextBox1.ClientID %>").value = ""; //odwolanie do elementu asp
            return false;
        }



        function ukryj(div) {  
            var pozycja = div.scrollTop;
            if (pozycja == 0)
                document.getElementById("<%= Panel2.ClientID %>").style.visibility = "hidden";
            else
                document.getElementById("<%= Panel2.ClientID %>").style.visibility = "visible";


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

    </script>





</asp:Content>
