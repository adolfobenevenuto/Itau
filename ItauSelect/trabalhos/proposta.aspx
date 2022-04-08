<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/trabalhos/SiteMasterTrabalhos.Master" CodeBehind="proposta.aspx.vb" Inherits="ItauSelect.proposta" 
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <script language="javascript" type="text/javascript">       
        function getText(txtbox, e){
            var maxlength = 250;
            var keyCode;
            if (window.event)
                keyCode = window.event.keyCode;
            else
                keyCode = e.which;

            switch (keyCode){
                case 8 :
                    return true;
                default :
                    if (txtbox.value.length == maxlength)
                        return false;
                    else
                        setText(txtbox);
            }
            return true;
        }        
        function setText(txtbox){
            document.getElementById('<%=lblCount.ClientID %>').innerHTML = txtbox.value.length.toString();
        }
    </script>       --%>
    
     <style type="text/css">
    .style1
    {
      font-weight: bold;
    }
    </style>


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
            <a class="nav-link js-scroll-trigger" href="ver.aspx">Minhas propostas</a>&nbsp;
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
          <h2>Proposta<br />
            <asp:Label ID="LblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                  </h2>
        <!--  <p class="style2">Inscrição de trabalhos encerradas!</p>  -->
          <p class="lead"><b class="style1">Título do evento:</b><br />
            <asp:DropDownList ID="DrpEvento" runat="server" Width="80%">
<asp:ListItem>27/08/21 - 10h - Mostra Live - Eixo 03</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - COE</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - COF</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - CDHPP</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - CPAP - Comissão de Psicoterapias e   Avaliação Psicológica</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - Comissão História e Memória da Psicologia</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - COMISSÃO GESTORA</asp:ListItem>
 <asp:ListItem>REUNIÃO / ATIVIDADE - OUTRAS COMISSÕES ESTADUAIS</asp:ListItem>
 <asp:ListItem>REUNIÕES / ATIVIDADES DE NÚCLEOS E GTS</asp:ListItem>
       </asp:DropDownList>
            <br />
            <br />
                        <b class="style1">Região:</b><br />
              <asp:DropDownList ID="DrpRegiao" runat="server" Width="80%">
 <asp:ListItem>Alto Tietê</asp:ListItem>
 <asp:ListItem>Assis</asp:ListItem>
 <asp:ListItem>Baixada Santista e Vale do Ribeira</asp:ListItem>
 <asp:ListItem>Bauru</asp:ListItem>
 <asp:ListItem>Campinas</asp:ListItem>
 <asp:ListItem>Grande ABC</asp:ListItem>
 <asp:ListItem>Metropolitana</asp:ListItem>
 <asp:ListItem>Ribeirão Preto</asp:ListItem>
 <asp:ListItem>São José do Rio Preto</asp:ListItem>
 <asp:ListItem>Sorocaba</asp:ListItem>
 <asp:ListItem>Vale do Paraíba e Litoral Norte</asp:ListItem>
 </asp:DropDownList>
 <br />
            <br />
                        <b class="style1">Eixo:</b><br />
            <asp:DropDownList ID="DrpEixo" runat="server" Width="80%">
              <asp:ListItem>1) Organização Democrática e Participativa do Sistema Conselhos no Enfrentamento da Pandemia. </asp:ListItem>
              <asp:ListItem>2) Defesa do Estado Democrático e dos Direitos Humanos via Políticas Públicas.</asp:ListItem>
              <asp:ListItem>3) O fazer ético e científico da Psicologia no trabalho em saúde mental</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
              ControlToValidate="DrpEixo" ErrorMessage="Selecione o eixo">Selecione o eixo</asp:RequiredFieldValidator>
                  </p>
                  <p class="lead">Âmbito:<br />
                    <asp:DropDownList ID="DrpAmbito" runat="server" Width="80%">
                      <asp:ListItem>Regional</asp:ListItem>
                      <asp:ListItem>Nacional</asp:ListItem>
                      <asp:ListItem>Regional e Nacional</asp:ListItem>
                          </asp:DropDownList>
                    <br />
                    <br />
                    Palavras-chave:<br />
            
            <asp:DropDownList ID="DrpPalavra1" runat="server" Width="80%">
               <asp:ListItem></asp:ListItem>
                   <asp:ListItem>Acessibilidade</asp:ListItem>
<asp:ListItem>Adoção</asp:ListItem>
<asp:ListItem>APAF</asp:ListItem>
<asp:ListItem>Articulação</asp:ListItem>
<asp:ListItem>Assistência social</asp:ListItem>
<asp:ListItem>Atendimento</asp:ListItem>
<asp:ListItem>Atendimento on-line</asp:ListItem>
<asp:ListItem>Atendimento remoto</asp:ListItem>
<asp:ListItem>Atuação profissional</asp:ListItem>
<asp:ListItem>Atualização cadastral</asp:ListItem>
<asp:ListItem>Avaliação Psicológica</asp:ListItem>
<asp:ListItem>Cadastro Nacional de Psicólogas(os)</asp:ListItem>
<asp:ListItem>CNP</asp:ListItem>
<asp:ListItem>Código de Ética</asp:ListItem>
<asp:ListItem>COF e COE</asp:ListItem>
<asp:ListItem>Comunicação</asp:ListItem>
<asp:ListItem>Concursos Públicos</asp:ListItem>
<asp:ListItem>Condições de Trabalho</asp:ListItem>
<asp:ListItem>Controle Social</asp:ListItem>
<asp:ListItem>Corresponsabilidade</asp:ListItem>
<asp:ListItem>CREPOP</asp:ListItem>
<asp:ListItem>Deficiência</asp:ListItem>
<asp:ListItem>Democracia</asp:ListItem>
<asp:ListItem>Desigualdade social</asp:ListItem>
<asp:ListItem>Direitos humanos</asp:ListItem>
<asp:ListItem>Diversidade</asp:ListItem>
<asp:ListItem>Educação</asp:ListItem>
<asp:ListItem>Eleição</asp:ListItem>
<asp:ListItem>Emergências e Desastres</asp:ListItem>
<asp:ListItem>Equidade</asp:ListItem>
<asp:ListItem>Esporte</asp:ListItem>
<asp:ListItem>Estágio</asp:ListItem>
<asp:ListItem>Exercício Profissional</asp:ListItem>
<asp:ListItem>Finanças</asp:ListItem>
<asp:ListItem>Fiscalização</asp:ListItem>
<asp:ListItem>Formação</asp:ListItem>
<asp:ListItem>Garantia de direitos</asp:ListItem>
<asp:ListItem>Gestão</asp:ListItem>
<asp:ListItem>Gestão participativa</asp:ListItem>
<asp:ListItem>Impostos, taxas e emolumentos</asp:ListItem>
<asp:ListItem>Interiorização</asp:ListItem>
<asp:ListItem>Invisibilidades</asp:ListItem>
<asp:ListItem>Justiça</asp:ListItem>
<asp:ListItem>Laicidade</asp:ListItem>
<asp:ListItem>Legislação e Normas</asp:ListItem>
<asp:ListItem>Mobilidade</asp:ListItem>
<asp:ListItem>Neuropsicologia</asp:ListItem>
<asp:ListItem>Normas e orientações</asp:ListItem>
<asp:ListItem>Novas Práticas</asp:ListItem>
<asp:ListItem>Orientação</asp:ListItem>
<asp:ListItem>Pandemia</asp:ListItem>
<asp:ListItem>Parcerias</asp:ListItem>
<asp:ListItem>Participação</asp:ListItem>
<asp:ListItem>Participação e Representação</asp:ListItem>
<asp:ListItem>Pessoas com deficiência</asp:ListItem>
<asp:ListItem>Pobreza</asp:ListItem>
<asp:ListItem>Políticas Públicas</asp:ListItem>
<asp:ListItem>Porte de armas</asp:ListItem>
<asp:ListItem>Psicologia Clínica</asp:ListItem>
<asp:ListItem>Psicologia do Esporte</asp:ListItem>
<asp:ListItem>Psicologia do Trânsito</asp:ListItem>
<asp:ListItem>Psicologia em Saúde</asp:ListItem>
<asp:ListItem>Psicologia Escolar/Educacional</asp:ListItem>
<asp:ListItem>Psicologia Hospitalar</asp:ListItem>
<asp:ListItem>Psicologia Jurídica</asp:ListItem>
<asp:ListItem>Psicologia Organizacional e do Trabalho</asp:ListItem>
<asp:ListItem>Psicologia Social</asp:ListItem>
<asp:ListItem>Psicomotricidade</asp:ListItem>
<asp:ListItem>Psicopedagogia</asp:ListItem>
<asp:ListItem>Psicoterapia</asp:ListItem>
<asp:ListItem>Público</asp:ListItem>
<asp:ListItem>Referências Técnicas</asp:ListItem>
<asp:ListItem>Relações Interinstitucionais</asp:ListItem>
<asp:ListItem>Resoluções do CFP</asp:ListItem>
<asp:ListItem>Saúde</asp:ListItem>
<asp:ListItem>Saúde Mental</asp:ListItem>
<asp:ListItem>Segurança</asp:ListItem>
<asp:ListItem>Sistema de Justiça</asp:ListItem>
<asp:ListItem>SUAS</asp:ListItem>
<asp:ListItem>Supervisão</asp:ListItem>
<asp:ListItem>SUS</asp:ListItem>
<asp:ListItem>Temas emergentes da Psicologia</asp:ListItem>
<asp:ListItem>Trânsito</asp:ListItem>
<asp:ListItem>Urgência e Emergência</asp:ListItem>
<asp:ListItem>Valorização profissional</asp:ListItem>
<asp:ListItem>Votação</asp:ListItem>

                       </asp:DropDownList>

                    
                  
 <br />
            </b>
            <asp:DropDownList ID="DrpPalavra2" runat="server" Width="80%">
             <asp:ListItem></asp:ListItem>
                   <asp:ListItem>Acessibilidade</asp:ListItem>
<asp:ListItem>Adoção</asp:ListItem>
<asp:ListItem>APAF</asp:ListItem>
<asp:ListItem>Articulação</asp:ListItem>
<asp:ListItem>Assistência social</asp:ListItem>
<asp:ListItem>Atendimento</asp:ListItem>
<asp:ListItem>Atendimento on-line</asp:ListItem>
<asp:ListItem>Atendimento remoto</asp:ListItem>
<asp:ListItem>Atuação profissional</asp:ListItem>
<asp:ListItem>Atualização cadastral</asp:ListItem>
<asp:ListItem>Avaliação Psicológica</asp:ListItem>
<asp:ListItem>Cadastro Nacional de Psicólogas(os)</asp:ListItem>
<asp:ListItem>CNP</asp:ListItem>
<asp:ListItem>Código de Ética</asp:ListItem>
<asp:ListItem>COF e COE</asp:ListItem>
<asp:ListItem>Comunicação</asp:ListItem>
<asp:ListItem>Concursos Públicos</asp:ListItem>
<asp:ListItem>Condições de Trabalho</asp:ListItem>
<asp:ListItem>Controle Social</asp:ListItem>
<asp:ListItem>Corresponsabilidade</asp:ListItem>
<asp:ListItem>CREPOP</asp:ListItem>
<asp:ListItem>Deficiência</asp:ListItem>
<asp:ListItem>Democracia</asp:ListItem>
<asp:ListItem>Desigualdade social</asp:ListItem>
<asp:ListItem>Direitos humanos</asp:ListItem>
<asp:ListItem>Diversidade</asp:ListItem>
<asp:ListItem>Educação</asp:ListItem>
<asp:ListItem>Eleição</asp:ListItem>
<asp:ListItem>Emergências e Desastres</asp:ListItem>
<asp:ListItem>Equidade</asp:ListItem>
<asp:ListItem>Esporte</asp:ListItem>
<asp:ListItem>Estágio</asp:ListItem>
<asp:ListItem>Exercício Profissional</asp:ListItem>
<asp:ListItem>Finanças</asp:ListItem>
<asp:ListItem>Fiscalização</asp:ListItem>
<asp:ListItem>Formação</asp:ListItem>
<asp:ListItem>Garantia de direitos</asp:ListItem>
<asp:ListItem>Gestão</asp:ListItem>
<asp:ListItem>Gestão participativa</asp:ListItem>
<asp:ListItem>Impostos, taxas e emolumentos</asp:ListItem>
<asp:ListItem>Interiorização</asp:ListItem>
<asp:ListItem>Invisibilidades</asp:ListItem>
<asp:ListItem>Justiça</asp:ListItem>
<asp:ListItem>Laicidade</asp:ListItem>
<asp:ListItem>Legislação e Normas</asp:ListItem>
<asp:ListItem>Mobilidade</asp:ListItem>
<asp:ListItem>Neuropsicologia</asp:ListItem>
<asp:ListItem>Normas e orientações</asp:ListItem>
<asp:ListItem>Novas Práticas</asp:ListItem>
<asp:ListItem>Orientação</asp:ListItem>
<asp:ListItem>Pandemia</asp:ListItem>
<asp:ListItem>Parcerias</asp:ListItem>
<asp:ListItem>Participação</asp:ListItem>
<asp:ListItem>Participação e Representação</asp:ListItem>
<asp:ListItem>Pessoas com deficiência</asp:ListItem>
<asp:ListItem>Pobreza</asp:ListItem>
<asp:ListItem>Políticas Públicas</asp:ListItem>
<asp:ListItem>Porte de armas</asp:ListItem>
<asp:ListItem>Psicologia Clínica</asp:ListItem>
<asp:ListItem>Psicologia do Esporte</asp:ListItem>
<asp:ListItem>Psicologia do Trânsito</asp:ListItem>
<asp:ListItem>Psicologia em Saúde</asp:ListItem>
<asp:ListItem>Psicologia Escolar/Educacional</asp:ListItem>
<asp:ListItem>Psicologia Hospitalar</asp:ListItem>
<asp:ListItem>Psicologia Jurídica</asp:ListItem>
<asp:ListItem>Psicologia Organizacional e do Trabalho</asp:ListItem>
<asp:ListItem>Psicologia Social</asp:ListItem>
<asp:ListItem>Psicomotricidade</asp:ListItem>
<asp:ListItem>Psicopedagogia</asp:ListItem>
<asp:ListItem>Psicoterapia</asp:ListItem>
<asp:ListItem>Público</asp:ListItem>
<asp:ListItem>Referências Técnicas</asp:ListItem>
<asp:ListItem>Relações Interinstitucionais</asp:ListItem>
<asp:ListItem>Resoluções do CFP</asp:ListItem>
<asp:ListItem>Saúde</asp:ListItem>
<asp:ListItem>Saúde Mental</asp:ListItem>
<asp:ListItem>Segurança</asp:ListItem>
<asp:ListItem>Sistema de Justiça</asp:ListItem>
<asp:ListItem>SUAS</asp:ListItem>
<asp:ListItem>Supervisão</asp:ListItem>
<asp:ListItem>SUS</asp:ListItem>
<asp:ListItem>Temas emergentes da Psicologia</asp:ListItem>
<asp:ListItem>Trânsito</asp:ListItem>
<asp:ListItem>Urgência e Emergência</asp:ListItem>
<asp:ListItem>Valorização profissional</asp:ListItem>
<asp:ListItem>Votação</asp:ListItem>

                        </asp:DropDownList>
            <br />
            <asp:DropDownList ID="DrpPalavra3" runat="server" Width="80%">
             <asp:ListItem></asp:ListItem>
                  <asp:ListItem>Acessibilidade</asp:ListItem>
<asp:ListItem>Adoção</asp:ListItem>
<asp:ListItem>APAF</asp:ListItem>
<asp:ListItem>Articulação</asp:ListItem>
<asp:ListItem>Assistência social</asp:ListItem>
<asp:ListItem>Atendimento</asp:ListItem>
<asp:ListItem>Atendimento on-line</asp:ListItem>
<asp:ListItem>Atendimento remoto</asp:ListItem>
<asp:ListItem>Atuação profissional</asp:ListItem>
<asp:ListItem>Atualização cadastral</asp:ListItem>
<asp:ListItem>Avaliação Psicológica</asp:ListItem>
<asp:ListItem>Cadastro Nacional de Psicólogas(os)</asp:ListItem>
<asp:ListItem>CNP</asp:ListItem>
<asp:ListItem>Código de Ética</asp:ListItem>
<asp:ListItem>COF e COE</asp:ListItem>
<asp:ListItem>Comunicação</asp:ListItem>
<asp:ListItem>Concursos Públicos</asp:ListItem>
<asp:ListItem>Condições de Trabalho</asp:ListItem>
<asp:ListItem>Controle Social</asp:ListItem>
<asp:ListItem>Corresponsabilidade</asp:ListItem>
<asp:ListItem>CREPOP</asp:ListItem>
<asp:ListItem>Deficiência</asp:ListItem>
<asp:ListItem>Democracia</asp:ListItem>
<asp:ListItem>Desigualdade social</asp:ListItem>
<asp:ListItem>Direitos humanos</asp:ListItem>
<asp:ListItem>Diversidade</asp:ListItem>
<asp:ListItem>Educação</asp:ListItem>
<asp:ListItem>Eleição</asp:ListItem>
<asp:ListItem>Emergências e Desastres</asp:ListItem>
<asp:ListItem>Equidade</asp:ListItem>
<asp:ListItem>Esporte</asp:ListItem>
<asp:ListItem>Estágio</asp:ListItem>
<asp:ListItem>Exercício Profissional</asp:ListItem>
<asp:ListItem>Finanças</asp:ListItem>
<asp:ListItem>Fiscalização</asp:ListItem>
<asp:ListItem>Formação</asp:ListItem>
<asp:ListItem>Garantia de direitos</asp:ListItem>
<asp:ListItem>Gestão</asp:ListItem>
<asp:ListItem>Gestão participativa</asp:ListItem>
<asp:ListItem>Impostos, taxas e emolumentos</asp:ListItem>
<asp:ListItem>Interiorização</asp:ListItem>
<asp:ListItem>Invisibilidades</asp:ListItem>
<asp:ListItem>Justiça</asp:ListItem>
<asp:ListItem>Laicidade</asp:ListItem>
<asp:ListItem>Legislação e Normas</asp:ListItem>
<asp:ListItem>Mobilidade</asp:ListItem>
<asp:ListItem>Neuropsicologia</asp:ListItem>
<asp:ListItem>Normas e orientações</asp:ListItem>
<asp:ListItem>Novas Práticas</asp:ListItem>
<asp:ListItem>Orientação</asp:ListItem>
<asp:ListItem>Pandemia</asp:ListItem>
<asp:ListItem>Parcerias</asp:ListItem>
<asp:ListItem>Participação</asp:ListItem>
<asp:ListItem>Participação e Representação</asp:ListItem>
<asp:ListItem>Pessoas com deficiência</asp:ListItem>
<asp:ListItem>Pobreza</asp:ListItem>
<asp:ListItem>Políticas Públicas</asp:ListItem>
<asp:ListItem>Porte de armas</asp:ListItem>
<asp:ListItem>Psicologia Clínica</asp:ListItem>
<asp:ListItem>Psicologia do Esporte</asp:ListItem>
<asp:ListItem>Psicologia do Trânsito</asp:ListItem>
<asp:ListItem>Psicologia em Saúde</asp:ListItem>
<asp:ListItem>Psicologia Escolar/Educacional</asp:ListItem>
<asp:ListItem>Psicologia Hospitalar</asp:ListItem>
<asp:ListItem>Psicologia Jurídica</asp:ListItem>
<asp:ListItem>Psicologia Organizacional e do Trabalho</asp:ListItem>
<asp:ListItem>Psicologia Social</asp:ListItem>
<asp:ListItem>Psicomotricidade</asp:ListItem>
<asp:ListItem>Psicopedagogia</asp:ListItem>
<asp:ListItem>Psicoterapia</asp:ListItem>
<asp:ListItem>Público</asp:ListItem>
<asp:ListItem>Referências Técnicas</asp:ListItem>
<asp:ListItem>Relações Interinstitucionais</asp:ListItem>
<asp:ListItem>Resoluções do CFP</asp:ListItem>
<asp:ListItem>Saúde</asp:ListItem>
<asp:ListItem>Saúde Mental</asp:ListItem>
<asp:ListItem>Segurança</asp:ListItem>
<asp:ListItem>Sistema de Justiça</asp:ListItem>
<asp:ListItem>SUAS</asp:ListItem>
<asp:ListItem>Supervisão</asp:ListItem>
<asp:ListItem>SUS</asp:ListItem>
<asp:ListItem>Temas emergentes da Psicologia</asp:ListItem>
<asp:ListItem>Trânsito</asp:ListItem>
<asp:ListItem>Urgência e Emergência</asp:ListItem>
<asp:ListItem>Valorização profissional</asp:ListItem>
<asp:ListItem>Votação</asp:ListItem>

                        </asp:DropDownList>
            <br />
                        <b class="style1">
            <br />
                        <b class="style1">Escreva a proposta (75 palavras):
            </b> 
            <br />
            (As propostas devem ser frases únicas, sem encaminhamentos e devem ser compatíveis com as atribuições legais do CFP e do CRP):<br />
            <asp:TextBox ID="TxtResumo" runat="server" Height="250px" TextMode="MultiLine" 
              Width="80%"  placeholder="As propostas devem ser frases únicas, sem encaminhamentos e devem ser compatíveis com as atribuições legais do CFP e do CRP"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
              ControlToValidate="TxtResumo" ErrorMessage="Resumo">Resumo</asp:RequiredFieldValidator>
           
              
              
                                    <!-- [\s\S]{0,500} -->
              
              
            <br />(até 75 palavras)             
                    <br />
                    <asp:Label ID="LblQuantidadePalavras" runat="server" ForeColor="#FF3300"></asp:Label>
            <br /><br /> 
             <asp:Button ID="BtnEnviar" runat="server" Text="Enviar proposta"></asp:Button></p>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    HeaderText="Você deve preencher os seguintes campos:" />
                  <p>
                  </p>
                  
                  
                  
           <%--       
                  <div>
        <asp:TextBox ID="txtComment" runat="server" Rows="5" TextMode="MultiLine" Width="250px"></asp:TextBox><br />
        <asp:Label ID="lblCount" runat="server" ReadOnly="true">0</asp:Label> / 250 maximum characters.</div>
        
        --%>
        
        
        </div>
      </div>
    </div>
  </section>

 
 
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
