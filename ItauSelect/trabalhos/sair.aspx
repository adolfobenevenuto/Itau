<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/trabalhos/SiteMasterTrabalhos.Master" CodeBehind="sair.aspx.vb" Inherits="ItauSelect._default3" 
     %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
    .style1
    {
      font-weight: bold;
    }
  </style>
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
            <a class="nav-link js-scroll-trigger" href="default.aspx">Início</a>
          </li> 
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="ver.aspx">Meus Trabalhos</a>
          </li>
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="comunicacao.aspx#about">Comunicação Oral</a>
          </li>
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="video.aspx">Vídeo-Relato</a>
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
          <h2>Sair<br />
            <asp:Label ID="LblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                  </h2>
          <p class="lead">Aguarde...
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
