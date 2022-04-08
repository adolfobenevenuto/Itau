<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master" CodeBehind="esqueceu.aspx.vb" Inherits="ItauSelect.esqueceu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
 <p class="titulo"> .:: Esqueceu senha<br />
   <asp:Label ID="LblResultado" runat="server"></asp:Label>
&nbsp;</p>
 <p class="corridonormal">Preencha o formulário abaixo para receber em seu e-mail sua senha.<br />
   </p>
  <p class="corridonormal">E-mail:<br />
    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
  </p>
  <p class="corridonormal">Confirmar e-mail:<br />
    <asp:TextBox ID="TxtEmailConfirmar" runat="server"></asp:TextBox>
  </p>
  <p class="corridonormal">
    <asp:Button ID="BtnEnviar" runat="server" Text="Enviar senha por email!" />
  </p>
 
</asp:Content>
