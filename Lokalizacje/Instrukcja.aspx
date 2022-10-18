<%@ Page Title="Lokalizacje - Instrukcja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instrukcja.aspx.cs" Inherits="Aplikacja_1._0._2.Instrukcja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
  <!--  <iframe src="/instr/instrukcja2.pdf#toolbar=0" width="100%" height="800px">
    </iframe> -->
   <!-- <embed src="/instr/instrukcja2.pdf#toolbar=0" style="width:100%; height:80vh;"> -->

    <object data="/instr/instrukcja2.pdf#toolbar=0" type="application/pdf" style="width:100%; height:80vh;">
        <div style="text-align:center; font-size:large">Nie można wyswietlić pliku pdf, zainstaluj wtyczkę Acrobat Reader lub użyj innej przegladarki.</div>
    </object>

</asp:Content>
