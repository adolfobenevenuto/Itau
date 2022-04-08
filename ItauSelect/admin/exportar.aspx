<%@ Page Language="vb" AutoEventWireup="false" Codebehind="exportar.aspx.vb" Inherits="ItauSelect.exportar"  ResponseEncoding="iso-8859-1" uiCulture="pt-BR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- responseEncoding="iso-8859-1" -->
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title>Psi Site do CRP SP - Exportar inscrições</title>
  <link href="../evento.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" /></head>
<body bgcolor="#FFFFFF">
  <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
    <tr>
      <td align="left" valign="middle" background="img_menu/fundo-excel.gif" style="height: 69px">
        <p class="titulo">
          Exportar inscrições de participantes<br />
          <asp:Button ID="Button1" runat="server" Text="GERAR ARQUIVO NO EXCEL" /></p></td>
      <td align="right" valign="middle" background="img_menu/fundo-excel.gif" style="height: 69px">
        &nbsp;&nbsp;
      </td>
    </tr>
    <tr>
      <td colspan="2">
        &nbsp;<asp:DataGrid ID="GrdExportExcel" runat="server" Width="95%" 
          CellPadding="4" AllowPaging="True"
          AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
          BorderWidth="1px" Font-Size="Small" PageSize="500" >
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <SelectedItemStyle BackColor="#FFC0C0" Font-Bold="True" ForeColor="#CCFF99" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Mode="NumericPages"
          PageButtonCount="5" />
        <ItemStyle BackColor="White" ForeColor="#003399" />
        <Columns>
          <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="false"></asp:BoundColumn>
               <asp:TemplateColumn HeaderText="Local">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "congresso")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
           <asp:TemplateColumn HeaderText="CRP">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "crp")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
           <asp:TemplateColumn HeaderText="CPF">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "cpf")%> 
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
          <asp:TemplateColumn HeaderText="Logon">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "logon")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Senha">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "senha")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Cidade">
            <ItemTemplate>
                     <%# DataBinder.Eval(Container.DataItem,"cidade") %> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Telefone">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "telefone")%> 
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

         <asp:TemplateColumn HeaderText="Instituicao">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "instituicao")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Possui necessidade?">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "possui_neces")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Baixa visao">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "baixa_visao")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Cegueira">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "cegueira")%> 
            </ItemTemplate>
          </asp:TemplateColumn>

          <asp:TemplateColumn HeaderText="Surdez">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "surdez")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Defic. fisica">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "defic_fisica")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Defic. intelectual">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "defic_intelectual")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Outra">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "outra")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Qual">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "outral_qual")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Recursos de apoio">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "neces_atend")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Braille">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "braille")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Guia">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "guia")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Libras">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "libras")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Guia Interprete">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "guia_inter")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Outras necessidades">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "outro_meces")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Qual">
            <ItemTemplate>
                     <%#DataBinder.Eval(Container.DataItem, "qual_atend")%> 
            </ItemTemplate>
          </asp:TemplateColumn>
          </Columns>
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
      </asp:DataGrid></td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">&nbsp;</td>
    </tr>
    </table>
  <p class="subtitulo">&nbsp;
    </p>
    </div>
  </form>
</body>
</html>
