<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master"
  CodeBehind="trabalhos.aspx.vb" Inherits="ItauSelect.trabalhos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="caixag">

<p class="titulo">Inscri��o de trabalho</p>
<p class="subtitulo">Seu trabalho dever� conter, no m�ximo, 400 caracteres.</span></li>



  <div id="footer">
	<div id="contato">
        <fieldset>
            <legend></legend>
            <div>
            <p class="corridonormal">Nome completo:<br />
    <asp:TextBox ID="TxtNome" runat="server" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqValNome" runat="server" ErrorMessage="Nome" ControlToValidate="TxtNome">Nome</asp:RequiredFieldValidator>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="ReqValNome">
    </cc1:ValidatorCalloutExtender>
              <br /></p>
      <p class="corridonormal">CPF:<br />
    <asp:TextBox ID="Txtcpf" runat="server" Width="400px"></asp:TextBox>
              <br /></p>
              
    <p class="corridonormal">Telefone:<br />           
    <asp:TextBox ID="Txttelefone" runat="server" Width="400px"></asp:TextBox>
            </div></p>
            <div>

<p class="corridonormal">
    E-mail:<br />
    <asp:TextBox ID="TxtEmail" runat="server" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RevValEmail" runat="server" ErrorMessage="E-mail"
      ControlToValidate="TxtEmail">E-mail</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegExpValEmail" runat="server" ErrorMessage="E-mail inv�lido!"
      ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">E-mail inv�lido!</asp:RegularExpressionValidator>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RevValEmail">
    </cc1:ValidatorCalloutExtender>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegExpValEmail">
    </cc1:ValidatorCalloutExtender>
</p>
            </div>

            <div class="textarea">
<p class="corridonormal">    Texto:<br />
    <asp:TextBox ID="TxtMsg" runat="server" Height="287px" TextMode="MultiLine" 
    Width="800px" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqValMensagem" runat="server" ErrorMessage="Mensagem"
      ControlToValidate="TxtMsg">Mensagem</asp:RequiredFieldValidator>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="ReqValMensagem">
    </cc1:ValidatorCalloutExtender>
</p>
            </div>
<br />              <br /><asp:Button ID="BtnEnviar" runat="server" Text="&nbsp;&nbsp;Enviar&nbsp;&nbsp;" />&nbsp;</p>

        </fieldset>
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="corridobold"
      HeaderText="Voc� deve preencher os seguintes campos:" Width="404px" ShowMessageBox="True"
      ShowSummary="False" />      
    </div>

</div>

</div>    
</asp:Content>
