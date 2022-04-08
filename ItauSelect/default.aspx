<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteMaster.Master" CodeBehind="default.aspx.vb" Inherits="ItauSelect._default" 
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
    <div class="container">
      <a class="navbar-brand js-scroll-trigger" href="http://www.crpsp.org.br/cnp/"><img src="img/logo.png" alt="11 CNP" title="11 CNP" /></a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#about"><font color="red">Apresentação</font></a>
          </li>
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#programa"><font color="red">Programação</font></a>
          </li>
			 <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#inscricoes"><font color="red">Inscrições</font></a>
          </li>

       <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#duvidas"><font color="red">Dúvidas Frequentes</font></a>
          </li>
        <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#contato"><font color="red">Contato</font></a>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <section id="about">
    <div class="container1">
      <div class="row">
        <div class="col-lg-8 mx-auto">
        
    
            
              <h2>Apresentação</h2>
       <strong>
          
            As diretrizes de atuação do Sistema Conselhos de Psicologia são definidas, ... </strong></div>
      </div>
		
    </div>
	  
  </section>

  <%-- <section id="services" class="bg-light">
    <div class="container2">
      <div class="row">
        <div class="col-lg-8 mx-auto">
          <h2>Regimento</h2>
          <p class="lead">texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento texto do regimento 
          
          
</p>
        </div>
      </div>
    </div>
  </section> --%>

  <section id="programa">
    <div class="container3">
      <div class="row">
        <div class="col-lg-8 mx-auto">
          <h2>Programação</h2>
			<br>

<strong>Pré-COREP da Subsede São José do Rio Preto&nbsp;</strong> <br>
  <strong>Data:</strong> 01/12/2021. - <strong>Horário:</strong> das 19h às 22h.<br /> 
        </div>
      </div>
    </div>
  </section>
  
<section id="inscricoes">
    <div class="container4">
      <div class="row">
        <div class="col-lg-8 mx-auto">
			<h2>Inscrições</h2>
		 <p class="lead">
		<strong>Pré-COREP da Subsede São José do Rio Preto</strong>
<br>
<strong> Data: 01/12/2021</strong><br />
<strong><a href="inscricoes.aspx" target="_parent">Inscreva-se</a> <br />
<strong><a href="login.aspx" target="_parent">Enviar trabalhos</a> </strong><br />
			 
			</p>

 
         
        </div>
      </div>
    </div>
  </section>



<div class="modal fade" id="Div1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Enviar trabalho<br />
        | <a href="esqueceu.aspx" target="_blank">Esqueceu senha</a> |</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <form>
          <div class="form-group">
            <label for="recipient-name" class="col-form-label">Email:</label>
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" MaxLength="150"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="message-text" class="col-form-label">Senha:</label>
            <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="Password" MaxLength="6"></asp:TextBox>
          </div>
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
        
        <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Entrar" CausesValidation="false"></asp:Button>
      </div>
    </div>
  </div>
</div>

       
               
        </div>
      </div>
    </div>
  </section>


 <section id="duvidas">
    <div class="container5">
      <div class="row">
        <div class="col-lg-8 mx-auto">
          <h2>Dúvidas Frequentes</h2>
          <p class="lead"> <b class="style1">1) Quantas propostas avulsas poderão ser enviadas?
 
            </b>

</p>
        </div>
      </div>
    </div>
  </section>
    <section id="contato">
    <div class="container6">
      <div class="row">
        <div class="col-lg-8 mx-auto">
          <h2>Contato</h2>
          <p class="lead"> <a href="mailto:11cnp@crpsp.org.br">11cnp@crpsp.org.br</a> </p>
        </div>
      </div>
    </div>
  </section> 
 
  <!-- Footer -->
  <footer class="py-5 bg-dark">
    <div class="container1">
     
      <p class="m-0 text-center text-white">Conselho Regional de Psicologia 6ª Região - São Paulo <br />
      <a href="https://www.crpsp.org" target="_blank">www.crpsp.org.br</a></p>
    </div>
    <!-- /.container -->
  </footer>

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Plugin JavaScript -->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom JavaScript for this theme -->
  <script src="js/scrolling-nav.js"></script>
  </asp:Content>
