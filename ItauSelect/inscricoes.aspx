
<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master" CodeBehind="inscricoes.aspx.vb" Inherits="ItauSelect.inscricoes" 
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <script type="text/javascript">
			var isOpen = false;
			function showDiv()
			{
				if(isOpen)
				{
				  document.getElementById('hiddenDiv').style.display = 'none';
				}
				else
				{
				  document.getElementById('hiddenDiv').style.display = 'block';
				}
				isOpen = !isOpen;
		}

		function closeDiv() {
		  if (isOpen) {
		    document.getElementById('hiddenDiv').style.display = 'none';
		  }
		  else {
		    document.getElementById('hiddenDiv').style.display = 'block';
		  }
		  isOpen = !isOpen;
		}
		  
	  </script>
      
   <center>      
<div class="caixag">

<p class="titulo">Inscrições</p>


<p class="corridonormal">
  &nbsp;</p>
                        <hr />
                         <p class="corridonormal">
  Estudante de Psicologia selecione o evento que você deseja se inscrever:<br />
  <asp:RadioButton ID="RdoBtnEncEstudante17" runat="server" 
    GroupName="Encontros" 
    Text="1/7 - Encontros com Estudantes às 17h - Atividade já realizada!" 
    AutoPostBack="True" />
  <br />
                     </p>
                         <p class="corridonormal">
                           Profissional Professoras/es-Supervisoras/es selecione o evento que você deseja se inscrever:<br />
                           <asp:RadioButton ID="RdoBtnEncProfessores17" runat="server"  
                             GroupName="Encontros" 
                             Text="2/7 às 17h - Atividade já realizada!" AutoPostBack="True" 
                             Checked="True" Enabled="False" />
                           <br />
                           </p>



<%--<p class="corridonormal">
  Coordenadoras/es de curso e responsáveis técnicas/os selecione o evento que você deseja se inscrever:<br />
  <asp:RadioButton ID="RdoBtnEncCoordenadoresRibPreto10h" runat="server"  GroupName="Encontros" 
    Text="3/7 às 10h, Subsede de Ribeirão Preto " AutoPostBack="True" /><br />
      <asp:RadioButton ID="RdoBtnEncCoordenadoresGrandeABC13h" runat="server" GroupName="Encontros"  
    Text="3/7 às 13h, Subsede do Grande ABC " AutoPostBack="True" /><br />
      <asp:RadioButton ID="RdoBtnEncCoordenadoresCampinas15h" runat="server"  GroupName="Encontros" 
    Text="3/7 às 15h, Subsede de Campinas" AutoPostBack="True" /><br />
    <asp:RadioButton ID="RdoBtnEncCoordenadoresBauru15h" runat="server"  GroupName="Encontros" 
    Text="3/7 às 15h, Subsede de Bauru" AutoPostBack="True" /><br />
      <asp:RadioButton ID="RdoBtnEncCoordenadoresSjRPreto15h" runat="server"  GroupName="Encontros" 
    Text="3/7 às 15h, Subsede de São José do Rio Preto " AutoPostBack="True" /><br />
      <asp:RadioButton ID="RdoBtnEncCoordenadoresMetropolitana17h" 
    runat="server"  GroupName="Encontros" 
    Text="3/7 às 17h, Subsede Metropolitana " AutoPostBack="True" /><br />
      <asp:RadioButton ID="RdoBtnEncCoordenadoresSantos17h" runat="server"  GroupName="Encontros" 
    Text="3/7 às 17h, Subsede da Baixada Santista e Vale do Ribeira " 
    AutoPostBack="True" /><br />
         <asp:RadioButton ID="RdoBtnEncCoordenadoresAssis17h" runat="server"  GroupName="Encontros" 
    Text="3/7 às 17h, Subsede de Assis " AutoPostBack="True" /><br />
                     </p>--%>
                         <p class="corridonormal">
                          
                           <asp:Label ID="LblTexto" runat="server" Text="Label"></asp:Label>

<asp:Label ID="LblCpf" runat="server" CssClass="corridobold" ForeColor="Red"></asp:Label>
      &nbsp;<asp:Label ID="LblEstudante" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                             ControlToValidate="TxtCrp" ErrorMessage="*">*</asp:RequiredFieldValidator>
        
        <asp:TextBox ID="TxtCrp" runat="server" MaxLength="10"></asp:TextBox>
        <br />
                     </p>
 <p class="corridonormal">
        CPF:<br />
        <asp:TextBox ID="TxtCPF" runat="server" Width="535px" MaxLength="13"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqValCPF" runat="server" ControlToValidate="TxtCPF"
            ErrorMessage="CPF">*</asp:RequiredFieldValidator>
      <asp:CustomValidator ID="cvCPF" runat="server" ControlToValidate="TxtCPF" 
          ErrorMessage="CPF Inválido!">*</asp:CustomValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
          ControlToValidate="TxtCPF" ErrorMessage="CPF">*</asp:RequiredFieldValidator>
    </p>
    <p class="corridonormal">
        Nome completo / nome social:<br />
        <asp:TextBox ID="TxtNomeCompleto" runat="server" Width="535px" MaxLength="150"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqValNome" runat="server" ControlToValidate="TxtNomeCompleto"
            ErrorMessage="Nome completo">*</asp:RequiredFieldValidator>
    </p>
    <p class="corridonormal">
        E-mail:<br />
        <asp:TextBox ID="TxtEmail" runat="server" Width="535px" MaxLength="150"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqValEmail" runat="server" ControlToValidate="TxtEmail"
            ErrorMessage="E-mail">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegExpValEmail" runat="server" ControlToValidate="TxtEmail"
            ErrorMessage="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">E-mail inválido!</asp:RegularExpressionValidator>
    </p>
 
  <p class="corridonormal">
      Cidade:<br />
    <asp:TextBox ID="TxtCidade" runat="server" MaxLength="70" Width="535px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RvCidade" runat="server" ControlToValidate="TxtCidade"
      ErrorMessage="Cidade">*</asp:RequiredFieldValidator>
  </p>
  
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="bottom"><p class="corridonormal">Telefones<br />
Residencial/contato:<br />
<asp:TextBox ID="TxtResidencial" runat="server" MaxLength="13"></asp:TextBox><asp:RequiredFieldValidator ID="ReqValResidencial" runat="server" ControlToValidate="TxtResidencial"
                        ErrorMessage="Residencial e/ou contato">*</asp:RequiredFieldValidator>
              </p></td>
            <td valign="bottom"><p class="corridonormal"> Comercial (opcional):<br />
            <asp:TextBox ID="TxtComercial" runat="server" MaxLength="13"></asp:TextBox>
              </p></td>
            <td valign="bottom">
            <p class="corridonormal"> Celular (opcional):<br />
            <asp:TextBox ID="TxtCelular" runat="server" MaxLength="13"></asp:TextBox>
              </p></td>
          </tr>
  </table>
        
    <p class="corridonormal">
      Instituição/Unidade a que est&aacute; vinculado (opcional):<br />
        <asp:TextBox ID="TxtInstituicao" runat="server" Width="535px" MaxLength="145"></asp:TextBox>
&nbsp;    &nbsp;&nbsp;
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TxtInstituicao" ErrorMessage="Instituição /Unidade">*</asp:RequiredFieldValidator>
    </p><br />

           <p class="corridonormal">
         <strong>Recursos de apoio</strong>

<br />



Possui alguma deficiência?<br />
   <asp:RadioButton ID="RdoBtnDeficienciaSim" GroupName="deficiencia" runat="server" Text="Sim" onClick="javascript:showDiv()" />&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RdoBtnDeficienciaNao" GroupName="deficiencia"
     runat="server"  Text="Não" Checked="true" onClick="javascript:closeDiv()" />
  </p>
  <div id="hiddenDiv" style="display:none">
  <asp:Panel ID="PnlDeficiencia" runat="server">
    <p class="corridonormal">
Indique a deficiência:<br />

	       <asp:CheckBox ID="ChkBaixaVisao" runat="server" Text="Baixa Visão" />
&nbsp;<br />
      <asp:CheckBox ID="ChkCegueira" runat="server" Text="Cegueira" />
      &nbsp;<br />

	       <asp:CheckBox ID="ChkSurdez" Text="Surdez" runat="server" />
         <br />

	<asp:CheckBox ID="ChkDeficienciaFisica" Text="Deficiência Física" runat="server" />	
      <br />
      <asp:CheckBox ID="ChkDeficienciaIntelectual" runat="server" 
        Text="Deficiência intelectual" />
    <br />

	<asp:CheckBox ID="ChkOutradeficiencia" Text="Outra" runat="server" /> 
    &nbsp;-
    Qual: 
    <asp:TextBox ID="TxtQualDeficiencia" runat="server" MaxLength="150" 
      Width="350px"></asp:TextBox>
    </p>
  </asp:Panel>
  <asp:Panel ID="PnlNecessidadeRecurso" runat="server">
    <p class="corridonormal">
      <strong>Atendimento diferenciado</strong>
  </p>
    <p class="corridonormal">
      Necessita de recurso específico?
      <br />
        <asp:RadioButton ID="RdoBtnRecursoSim" GroupName="recurso" runat="server" Text="Sim" /><asp:RadioButton ID="RdoBtnRecursoNao" GroupName="recurso"
     runat="server"  Text="Não" Checked="true" />
    </p>
       <p class="corridonormal">
      <asp:CheckBox ID="ChkBraille" runat="server" Text="Braille" />
      <br />
      <asp:CheckBox ID="ChkGuia" runat="server" Text="Guia" />
      <br />
      <asp:CheckBox ID="ChkLibras" runat="server" Text="Libras" />
      <br />
      <asp:CheckBox ID="ChkGuiaInter" runat="server" Text="Guia Intérprete" />
      <br />
      <asp:CheckBox ID="ChkOutroRecurso" runat="server" 
        Text="Outro" />
      &nbsp;<asp:Label ID="LblQual" runat="server" CssClass="corridonormal" Text="Qual:" 
        Visible="False"></asp:Label>
      <asp:TextBox ID="TxtQualAtendimento" runat="server" MaxLength="150" 
        Width="350px"></asp:TextBox>
    </p>
   
</asp:Panel>
  </div>
  <p class="corridonormal">
      <br />  
      <asp:Button ID="BtnEnviar" runat="server" 
        Text="Inscrições on-lines! " Width="304px" />        
  </p>
 <p class="corridonormal">
        &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="corridobold"
            HeaderText="Você deve preencher os seguintes campos:" ShowMessageBox="True" Width="423px" ShowSummary="False" />
   <p>
</p>

<!--
<br />
<br />

  <p class="corridonormal">       <font color="#FF0000">Inscrições on line encerradas. Compareça e se inscreva pessoalmente.</font><br />


<br />
Departamento de Eventos do CRP SP:
       
       <br />


    
    <br />
    Tel.: 11 3061.9494, ramais 337, 334, 357, 355 
    <br />
    E-mail: <a href="mailto:eventos@crpsp.org.br">eventos@crpsp.org.br</a></p>
    
    </p>
    
    
   <br />

-->


</div></center>
</asp:Content>

