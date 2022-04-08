<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master" CodeBehind="login.aspx.vb" Inherits="ItauSelect.login" 
    title="Psi Site do CRP SP - Eventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <p class="titulo">Envio de propostas<span class="corridonormal"><br /> | 
   <a href=esqueceu.aspx>Esqueceu senha</a> |</span></p>
  <p class="corridonormal">
    E-mail:<br />
    <asp:TextBox ID="TxtEmail" runat="server" MaxLength="175" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmail"
      ErrorMessage="E-mail">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail"
      ErrorMessage="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></p>
  <p class="corridonormal">Senha:<br />
    <asp:TextBox ID="TxtSenha" runat="server" MaxLength="12" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtSenha"
      ErrorMessage="Senha">*</asp:RequiredFieldValidator></p>
  <p class="corridonormal">
    <br />
    <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" />&nbsp;</p>
  <p class="corridonormal">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Você deve preencher os seguintes campos:"
      ShowMessageBox="True" />
    <p>
    &nbsp;</p>
  <p>
    &nbsp;</p>
</asp:Content>
