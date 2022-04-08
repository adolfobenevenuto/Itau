<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMasterEvento.Master"
  Codebehind="default.aspx.vb" Inherits="ItauSelect._default1" Title="Administrar inscrições"
  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <script type="text/javascript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
//-->
</script>
<div align="center" valign="center">
  <table width="80%" border="0" cellspacing="0" cellpadding="0" >
    <tr>
      <td align="left" valign="middle">
        &nbsp;</td>
      <td align="right" valign="middle">&nbsp;
        </td>
    </tr>
    <tr>
      <td align="left" valign="middle">
        <p class="titulo">
          Envio de propostas<br /><asp:Label ID="LblResultado" runat="server" ForeColor="Red"></asp:Label></p></td>
      <td align="right" valign="middle"><a href="#" onclick="MM_openBrWindow('exportar.aspx','popup','status=yes,menubar=yes,scrollbars=yes,resizable=yes,width=750,height=550')"><img src="img_menu/exportarexcel.gif" width="125" height="35" border="0" /></a>
      </td>
    </tr>
    <tr>
      <td colspan="2" align="center">
        <p class="corridonormal">&nbsp;<center>
          <asp:DataGrid ID="GrdInscritos" runat="server" Width="90%" CellPadding="4" AllowPaging="True"
          AutoGenerateColumns="False" Font-Size="Small" PageSize="50" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
          <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
          <ItemStyle BackColor="White" ForeColor="#003399"></ItemStyle>
          <HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
          <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>
          <Columns>
            <asp:BoundColumn Visible="False" DataField="Id" HeaderText="Id"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Nome">
              <HeaderStyle Width="50%"></HeaderStyle>
              <ItemTemplate>
                <asp:LinkButton ID="lnkNome" runat="server" CommandName="Select" CausesValidation="False"> 
        <%# DataBinder.Eval(Container.DataItem,"Nome") %> </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="E-mail">
              <HeaderStyle Width="50%"></HeaderStyle>
              <ItemTemplate>
                <asp:LinkButton ID="lnkLink" runat="server" CausesValidation="False" CommandName="Select"> 
        <%# DataBinder.Eval(Container.DataItem,"email") %> </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="CPF" Visible="false">
              <ItemTemplate>
                <asp:LinkButton ID="lnkDescricao" runat="server" CommandName="Select" CausesValidation="False"> 
        <%# DataBinder.Eval(Container.DataItem,"cpf") %> </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
          <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" PageButtonCount="5"
            Mode="NumericPages"></PagerStyle>
        </asp:DataGrid></center>
        </p>
      </td>
    </tr>
  </table>
  <p class="subtitulo">
    Inscrições</p>
  <p class="corridonormal">
    <asp:Label ID="LblId" runat="server"></asp:Label>&nbsp;</p>
  <p class="corridonormal">
    Nº CRP:<br />
    <asp:TextBox ID="TxtCrp" runat="server" MaxLength="10"></asp:TextBox></p>
  <p class="corridonormal">
    CPF:<br />
    <asp:TextBox ID="TxtCPF" runat="server" MaxLength="13" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCPF"
      ErrorMessage="CPF">*</asp:RequiredFieldValidator>
    <asp:CustomValidator ID="cvCPF" runat="server" ControlToValidate="TxtCPF" ErrorMessage="CPF Inválido!">*</asp:CustomValidator></p>
  <p class="corridonormal">
    Nome completo:<br />
    <asp:TextBox ID="TxtNomeCompleto" runat="server" MaxLength="175" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNomeCompleto"
      ErrorMessage="Nome completo">*</asp:RequiredFieldValidator></p>
  <p class="corridonormal">
    Nome para crachá:<br />
    <asp:TextBox ID="TxtNomeCracha" runat="server" MaxLength="15" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtNomeCracha"
      ErrorMessage="Nome para caracha">*</asp:RequiredFieldValidator></p>
  <p class="corridonormal">
    E-mail:<br />
    <asp:TextBox ID="TxtEmail" runat="server" MaxLength="175" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtEmail"
      ErrorMessage="E-mail">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail"
      ErrorMessage="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">E-mail 
  inválido!</asp:RegularExpressionValidator></p>
  <p class="corridonormal">
    Cidade:<br />
    <asp:TextBox ID="TxtCidade" runat="server" MaxLength="175" Width="400px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqValCidade" runat="server" ControlToValidate="TxtCidade"
      ErrorMessage="Cidade">*</asp:RequiredFieldValidator></p>
  
   <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; color: #000000" class="corridonormal">
      <tr>
        <td style="width: 15px" rowspan="3">&nbsp;
          </td>
        <td style="width: 173px">
          <b>Telefones</b></td>
        <td style="width: 100px">
        </td>
        <td style="width: 94px">
        </td>
      </tr>
      <tr>
        <td style="width: 173px">
          Residencial e/ou contato:</td>
        <td style="width: 100px">
          Comercial:</td>
        <td style="width: 94px">
          Celular:</td>
      </tr>
      <tr>
        <td style="width: 173px">
          <asp:TextBox ID="TxtResidencial" runat="server" MaxLength="13" onkeypress="return txtBoxFormat(this, '(99)9999-9999', event);"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtResidencial"
            ErrorMessage="Residencial e/ou contato">*</asp:RequiredFieldValidator></td>
        <td style="width: 100px; color: #000000">
          <asp:TextBox ID="TxtComercial" runat="server" MaxLength="13" onkeypress="return txtBoxFormat(this, '(99)9999-9999', event);"></asp:TextBox></td>
        <td style="width: 94px; color: #000000">
          <asp:TextBox ID="TxtCelular" runat="server" MaxLength="13" onkeypress="return txtBoxFormat(this, '(99)9999-9999', event);"></asp:TextBox></td>
      </tr>
    </table>
    </p>
    <p class="corridonormal">
      Instituição:<br />
      <asp:TextBox ID="TxtInstituicao" runat="server" MaxLength="145" Width="400px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtInstituicao"
        ErrorMessage="Instituição">*</asp:RequiredFieldValidator></p>
    <p class="corridonormal">

Possui alguma deficiência?<br />
      <asp:Label ID="LblDeficiencia" runat="server"></asp:Label>
  </p>
    <p class="corridonormal">
Indique a deficiência:<br />

	       Baixa Visão:
&nbsp;<asp:Label ID="LblBaixaVisao" runat="server"></asp:Label><br />
      Cegueira:
      &nbsp;<asp:Label ID="LblCegueira" runat="server"></asp:Label><br />

	       Surdez: <asp:Label ID="LblSurdez" runat="server"></asp:Label><br />

	    Deficiência Física:
      <asp:Label ID="LblDeficienciaFisica" runat="server"></asp:Label><br />
      Deficiência intelectual: <asp:Label ID="LblDeficienciaIntelectual" runat="server"></asp:Label><br />

	Outra:
    &nbsp;<asp:Label ID="LblOutra" runat="server"></asp:Label><br />
    Se outra sim, qual deficiência:
    <asp:Label ID="LblQualOutra" runat="server"></asp:Label>
      
    </p>
      <p class="corridonormal">
      <span class="corridobold">Atendimento diferenciado</span>
  </p>
    <p class="corridonormal">
      Necessita de recurso específico?
      <br />
  <asp:Label ID="LblRecurso" runat="server"></asp:Label>
    </p>
       <p class="corridonormal">
      Braille: <asp:Label ID="LblBraille" runat="server"></asp:Label><br />
      Guia: <asp:Label ID="LblGuia" runat="server"></asp:Label><br />
      Libras: <asp:Label ID="LblLibras" runat="server"></asp:Label><br />
         Guia intérprete:
      <asp:Label ID="LblGuiaInter" runat="server"></asp:Label><br />
      Outro: <asp:Label ID="LblOutro" runat="server"></asp:Label><br />
         Se outra sim, qual necessidade:
      <asp:Label ID="LblQualOutro" runat="server"></asp:Label><br />
    </p>
   

     <p class="corridonormal">
      Senha:<br />
      <asp:Label ID="LblSenha" runat="server"></asp:Label>
  </p>
    <p class="corridonormal">
      Congresso:<br />
      <asp:Label ID="LblCongresso" runat="server" Font-Bold="True"></asp:Label></p>
    <p>
      &nbsp;&nbsp;&nbsp;</p>
    <p>&nbsp;
      
    &nbsp;&nbsp;<asp:ValidationSummary ID="ValSumAdministracao" runat="server"
        HeaderText="Você deve preencher os seguintes campos:" ShowMessageBox="True" ShowSummary="False" />
      <p>
      <br />
      <asp:DataGrid ID="GrdExportExcel" runat="server" Width="95%" CellPadding="4" AllowPaging="True"
          AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
          BorderWidth="1px" Font-Size="Small" Visible="False">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <SelectedItemStyle BackColor="#FFC0C0" Font-Bold="True" ForeColor="#CCFF99" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Mode="NumericPages"
          PageButtonCount="5" />
        <ItemStyle BackColor="White" ForeColor="#003399" />
        <Columns>
          <asp:BoundColumn DataField="Id" HeaderText="Id"></asp:BoundColumn>
          <asp:TemplateColumn HeaderText="CRP">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "crp")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Nome">
            <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem,"Nome") %> 
            </ItemTemplate>
            <HeaderStyle Width="50%" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="E-mail">
            <ItemTemplate>
            
        <%# DataBinder.Eval(Container.DataItem,"email") %> 
            </ItemTemplate>
            <HeaderStyle Width="50%" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="CPF">
            <ItemTemplate>
                     <%# DataBinder.Eval(Container.DataItem,"cpf") %> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Cracha">
            <ItemTemplate>
                     <%# DataBinder.Eval(Container.DataItem,"cracha") %> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Residencial">
            <ItemTemplate>
                     <%# DataBinder.Eval(Container.DataItem,"residencial") %> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="CPF">
            <ItemTemplate>
                     <%# DataBinder.Eval(Container.DataItem,"cpf") %> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Residencial">
            <ItemTemplate>
                     <%# DataBinder.Eval(Container.DataItem,"residencial") %> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Comercial">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "comercial")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Celular">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "celular")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Titula&#231;&#227;o">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "titulacao")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Institui&#231;&#227;o">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "instituicao")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Necessita de algum recurso de apoio?">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "recurso")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Qual recurso">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "qual_recurso")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
        </Columns>
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
      </asp:DataGrid></p>
      
      </div>
</asp:Content>
