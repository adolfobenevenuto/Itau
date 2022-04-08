<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMasterEvento.Master" CodeBehind="parecerista.aspx.vb" Inherits="ItauSelect.parecerista" 
     %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>
 <br />
<br />

 <div class="caixa">
 <center><img src="topo-adm.jpg" /></center>
 <br />
<br />

<p class="titulo">
    Avaliar trabalhos</p>
<p class="subtitulo">    II Mostra Virtual de Práticas da Psicologia</p>
<p class="corridonormal"><asp:Label ID="LblMsg" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
    E-mail:<br />
    <asp:TextBox ID="TxtEmailLogin" runat="server" Width="80%"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
      ControlToValidate="TxtEmailLogin" ErrorMessage="Email">*</asp:RequiredFieldValidator>
  <br />
<br />

    Senha:<br />
    <asp:TextBox ID="TxtSenhaLogin" runat="server" Width="80%" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
      ControlToValidate="TxtSenhaLogin" ErrorMessage="Senha">*</asp:RequiredFieldValidator>
  <br />
<br />

    <asp:Button ID="btnentrar" runat="server" Text="Entrar" />
<br />
<br />

  <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
    HeaderText="Você deve preencher os seguintes campos:" ShowMessageBox="True" />
  <br />

  </p>
  <br />
<br />

</div>

</center>
</asp:Content>
