<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master"
  CodeBehind="faleconosco.aspx.vb" Inherits="ItauSelect.faleconosco" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="caixag">
<section id="box">
<nav>
		<ul>
			<li class="first"><span class="titulo">
          Fale Conosco</span><br />
<span class="corridonormal">Envie também sua sugestão ou pergunta.</span></li>
		</ul>
		
</nav> 


  <div id="footer">
	<div id="contato">
        <fieldset>
            <legend>Envie uma mensagem</legend>
            <div>
            <span class="corridonormal">Nome:</span><br />
    <asp:TextBox ID="TxtNome" runat="server" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqValNome" runat="server" ErrorMessage="Nome" ControlToValidate="TxtNome">Nome</asp:RequiredFieldValidator>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="ReqValNome">
    </cc1:ValidatorCalloutExtender></div>
            <div>
<br />
   <span class="corridonormal"> E-mail:</span><br />
    <asp:TextBox ID="TxtEmail" runat="server" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RevValEmail" runat="server" ErrorMessage="E-mail"
      ControlToValidate="TxtEmail">E-mail</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegExpValEmail" runat="server" ErrorMessage="E-mail inválido!"
      ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">E-mail inválido!</asp:RegularExpressionValidator>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RevValEmail">
    </cc1:ValidatorCalloutExtender>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegExpValEmail">
    </cc1:ValidatorCalloutExtender>

            </div>
<br />
            <div class="textarea">
    <span class="corridonormal">Mensagem:</span><br />
    <asp:TextBox ID="TxtMsg" runat="server" Height="287px" TextMode="MultiLine" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqValMensagem" runat="server" ErrorMessage="Mensagem"
      ControlToValidate="TxtMsg">Mensagem</asp:RequiredFieldValidator>
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="ReqValMensagem">
    </cc1:ValidatorCalloutExtender>

            </div>
<br />              <br /><asp:Button ID="BtnEnviar" runat="server" Text="&nbsp;&nbsp;Enviar&nbsp;&nbsp;" />&nbsp;</p>

        </fieldset>
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="corridobold"
      HeaderText="Você deve preencher os seguintes campos:" Width="404px" ShowMessageBox="True"
      ShowSummary="False" />      
    </div>

</div>

		
	</section>
	
</section>
</div>    
</asp:Content>
