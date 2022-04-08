<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master"
  CodeBehind="fr_msg.aspx.vb" Inherits="ItauSelect.fr_msg" Title="Psi Site do CRP SP - Eventos" %>

<%@ Import Namespace="ItauSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />
  <p class="titulo-de-pagina">
    <%= SessaoInformativo.MensagemTitulo %>
  </p>
  <br /><br /><p class="corridobold">
    <%= SessaoInformativo.MensagemComplemento %></p>
  <p class="corridonormal">
    <!-- <a onclick="history.go(-1)" href="#">:: voltar</a>|&nbsp; 
            <A href='<%= SessaoInformativo.MensagemURLRetorno %>'> :: voltar</A> 
      |--></p>
  <p class="corridonormal">
    &nbsp;
  </p>
  <p>
    &nbsp;
  </p>
  <p>
    &nbsp;
  </p>
  <p>
    &nbsp;
  </p>
</asp:Content>
