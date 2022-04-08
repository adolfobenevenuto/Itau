<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/trabalhos/SiteMasterTrabalhos.Master" CodeBehind="ver.aspx.vb" Inherits="ItauSelect._default4" 
     %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
    <div class="container">
      <a class="navbar-brand js-scroll-trigger" href="#page-top"><img src="../img/logo.jpg" />
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">

          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="proposta.aspx#about">Enviar proposta</a>
          </li>
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="sair.aspx">Sair</a>
          </li>
          </ul>
      </div>
    </div>
  </nav>

  <header class="bg-secondary-crpsp">
    <div class="container text-center">
      <h1></h1>
    </div>
  </header>

  <section id="about">
    <div class="container">
      <div class="row">
        <div class="col-lg-8 mx-auto">
          <h2>Minhas propostas<br />
            <asp:Label ID="LblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                  </h2>
          <p class="lead"> <asp:DataGrid ID="GrdInscritos" runat="server" Width="740px" 
              CellPadding="3" AllowPaging="True"
          AutoGenerateColumns="False" Font-Size="Small" PageSize="50" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
          <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
          <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510"></ItemStyle>
          <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
          <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>
          <Columns>
            <asp:BoundColumn Visible="False" DataField="Id_trab" HeaderText="Id_trab"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Evento">
              <HeaderStyle Width="50%"></HeaderStyle>
              <ItemTemplate>
               <%#DataBinder.Eval(Container.DataItem, "evento")%>   <asp:LinkButton ID="lnkNome" runat="server" CommandName="Select" CausesValidation="False"> 
       </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Eixo">
              <HeaderStyle Width="30%"></HeaderStyle>
              <ItemTemplate>
             <%#DataBinder.Eval(Container.DataItem, "eixo")%>    <asp:LinkButton ID="lnkLink" runat="server" CausesValidation="False" CommandName="Select"> 
        </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Proposta">
              <ItemTemplate>
                <%#DataBinder.Eval(Container.DataItem, "proposta")%>    <asp:LinkButton ID="lnkDescricao" runat="server" CommandName="Select" CausesValidation="False"> 
     </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
           
          </Columns>
          <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" PageButtonCount="5"
            Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
                  </p>
        </div>
      </div>
    </div>
  </section>

 <%-- <section id="contato">
    <div class="container">
      <div class="row">
        <div class="col-lg-8 mx-auto">
          <h2>Contato</h2>
          <p class="lead"> <p class="lead">E-mail: <a href="mailto:xxxxxxxxx@crpsp.org.br">
            xxxxxxxxx@crpsp.org.br</a> </p></p>
        </div>
      </div>
    </div>
  </section>--%>
 
  <!-- Footer -->
  <footer class="py-5 bg-dark">
    <div class="container">
     
      <p class="m-0 text-center text-white">Conselho Regional de Psicologia 6ª Região - São Paulo <br />
      <a href="https://www.crpsp.org" target="_blank">www.crpsp.org.br</a></p>
    </div>
    <!-- /.container -->
  </footer>

  <!-- Bootstrap core JavaScript -->
  <script src="../vendor/jquery/jquery.min.js"></script>
  <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Plugin JavaScript -->
  <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom JavaScript for this theme -->
  <script src="../js/scrolling-nav.js"></script>
</asp:Content>
