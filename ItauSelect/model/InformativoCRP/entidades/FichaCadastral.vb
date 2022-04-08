Public Class FichaCadastral
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_DIRETORIA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Diretoria' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_CONSELHEIRO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Conselheiro' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_GESTOR As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Gestor' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_CONVIDADO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Convidado' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_OLIVERZANCUL As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Oliver Zancul Prado' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ANDREAFERREIRAMARTINS As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Andrea Ferreira Martins' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_LEANDROGABARRA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Leandro Gabarra' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIADAGRACAGONCALVEZ As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria da Graça Marchina Gonçalves' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIAERMINIACILIBERTI As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria Ermínia Ciliberti' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_LUCIAFONSECATOLEDO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Lúcia Fonseca de Toledo' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ANAPAULAPEREIRA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Ana Paula Pereira Jardim' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_CARMEMSILVATAVERNA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Carmem Sílvia Rotandano Taverna' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_CHICAHATAKEYAMAGUIMARES As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Chica Hatakeyama Guimarães' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_DANIELAFOGAGNOLI As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Daniela Fogagnoli' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_DEBORACRISTINA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Débora Cristina Fonseca' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ELCIMARAMEIRE As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Elcimara Meire Da Rocha Mantovani' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ELCIODOSSANTOS As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Élcio Dos Santos Sequeira' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ELDAVARANDA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Elda Varanda Dunley Guedes Machado' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_FATIMAREGINA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Fátima Regina Riani Costa' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_JOSEROBERTO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'José Roberto Heloani' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIACRISTINABARROS As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria Cristina Barros Maciel Pellini' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIAJOSEMEDINA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria José Medina da Rocha Berto' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARILENEPROENCA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Marilene Proença Rebello de Souza' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_SANDRAHELENA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Sandra Helena Sposito' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_VALERIACASTROALVES As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Valéria Castro Alves Cardoso Penachini' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_VERALUCIAFASANELLA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Vera Lúcia Fasanella Pompílio' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ZULEIKAFATIMA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Zuleika Fátima Vitoriano Olivan' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ANAMARIABENEDETTI As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Ana Maria Benedetti Alves Garcia' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARCIAPOLACCHINI As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Marcia Polacchini Cartapatti da Silva' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIAORLENE As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria Orlene Daré' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_OSMARINADIAS As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Osmarina Dias Alves' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_REGIANEaPARECIDAPIVA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Regiane Aparecida Piva' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_VERALUCIAPAVANIJANJULIO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Veralúcia Pavani Janjúlio' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIAANGELAMEDEIROSPALA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria Angela Medeiros Pala' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARISASEIXASTARDELLI As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Marisa Seixas Tardelli' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_RAULARAGAOMARTINS As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Raul Aragão Martins' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIAAUXILIADORADEALMEIDACUNHAARANTES As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria Auxiliadora de Almeida Cunha Arantes' and Excluido = 0 order by nome"


  Private Shared ReadOnly C_GET_LIST_SUELIFERREIRASCHIAVO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Sueli Ferreira Schiavo' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ADRIANAEIKOMATSUMOTO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Adriana Eiko Matsumoto' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_PATRICIAGARCIADESOUZA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Patricia Garcia de Souza' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_LUMENACELITEIXEIRA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Lumena Celi Teixeira' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ELISAZANERATTOROSA As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Elisa Zaneratto Rosa' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_MARIAIZABELDONASCIMENTOMARQUES As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Maria Izabel do Nascimento Marques' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ANDREIADECONTOGARBIN As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Andréia De Conto Garbin' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ANDREATORRES As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = 'Andréa Torres' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_USUARIO As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas', cargo as 'Cargo' from tbl_partic_orgao_controle where nome = '{0}' and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_partic_orgao_controle where id = @id"
  Private Shared ReadOnly C_GET_DATA_REGIAO As String = "select regiao from tbl_partic_orgao_controle where id = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_partic_orgao_controle (regiao,nome,representante,colocacao,segmento,dt_inicio_mandato,dt_fim_mandato,leis,atas,cargo,excluido,criador,dt_criacao,atualizador,dt_atualizacao)" + _
                                               "values(@regiao,@nome,@representante,@colocacao,@segmento,@dt_inicio_mandato,@dt_fim_mandato,@leis,@atas,@cargo,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_partic_orgao_controle where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_partic_orgao_controle set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_partic_orgao_controle  set regiao = @regiao,  nome = @nome,  representante = @representante,  colocacao = @colocacao,  segmento = @segmento, dt_inicio_mandato = @dt_inicio_mandato, dt_fim_mandato = @dt_fim_mandato, leis = @leis, atas = @atas, cargo = @cargo where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramRegiao As New SqlParameter("@regiao", SqlDbType.VarChar)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramRepresentante As New SqlParameter("@representante", SqlDbType.VarChar)
  Private _paramColocacao As New SqlParameter("@colocacao", SqlDbType.VarChar)
  Private _paramSegmento As New SqlParameter("@segmento", SqlDbType.VarChar)
  Private _paramDt_inicio_mandato As New SqlParameter("@dt_inicio_mandato", SqlDbType.VarChar)
  Private _paramDt_fim_mandato As New SqlParameter("@dt_fim_mandato", SqlDbType.VarChar)
  Private _paramLeis As New SqlParameter("@leis", SqlDbType.VarChar)
  Private _paramAtas As New SqlParameter("@atas", SqlDbType.VarChar)
  Private _paramCargo As New SqlParameter("@cargo", SqlDbType.Int)

  ' propriedades
  Private _id As Integer
  Private _regiao As String
  Private _nome As String
  Private _representante As String
  Private _colocacao As String
  Private _segmento As String
  Private _dt_inicio_mandato As String
  Private _dt_fim_mandato As String
  Private _leis As String
  Private _atas As String
  Private _cargo As String

#End Region

#Region "Funcao Consultar Relatorio"

  Public Shared Function ConsultarRelatorio(ByVal id As Integer) As Comissao

    'Chama metodo da classe base
    Dim param As New SqlParameter("@id", SqlDbType.Int)
    param.Value = id

    Dim ret As FichaCadastral

    ret = CType(BaseEntidade.ConsultarEntidade(New FichaCadastral, C_GET_DATA, param), FichaCadastral)

    'Se a comissao for oculta e nao estamos conectados, retorna nova comissao
    '    If (ret.Oculta And Not Usuario.UsuarioCorrente.Autenticado) Then
    'Return New Comissao
    'End If

    'Return ret

  End Function

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New FichaCadastral
    Dim param As New SqlParameter("@id", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Ficha não encontrada.")

  End Function

  Public Shared Function ConsultarRegiao(ByVal regiao As String) As Object

    Dim ret As New FichaCadastral
    Dim param As New SqlParameter("@regiao", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = regiao

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_REGIAO, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Ficha não encontrada.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

  Public Shared Function ListarDiretoria() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_DIRETORIA)

  End Function

  Public Shared Function ListarConselheiro() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_CONSELHEIRO)

  End Function

  Public Shared Function ListarGestor() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_GESTOR)

  End Function
  Public Shared Function ListarConvidado() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_CONVIDADO)

  End Function
  Public Shared Function ListarOliverZancul() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_OLIVERZANCUL)

  End Function
  Public Shared Function ListarAndreaTorres() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ANDREATORRES)

  End Function
  Public Shared Function ListarAndreaFerreiraMartins() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ANDREAFERREIRAMARTINS)

  End Function
  Public Shared Function ListarLeandroGabarra() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_LEANDROGABARRA)

  End Function
  Public Shared Function ListarMariadaGracaMarchinaGoncalves() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIADAGRACAGONCALVEZ)

  End Function
  Public Shared Function ListarMariaErminiaCiliberti() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIAERMINIACILIBERTI)

  End Function
  Public Shared Function ListarLuciaFonsecadeToledo() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_LUCIAFONSECATOLEDO)

  End Function

  Public Shared Function ListarAnaPaulaPereiraJardim() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ANAPAULAPEREIRA)

  End Function
  Public Shared Function ListarCarmemSilviaRotandanoTaverna() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_CARMEMSILVATAVERNA)

  End Function
  Public Shared Function ListarChicaHatakeyamaGuimaraes() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_CHICAHATAKEYAMAGUIMARES)

  End Function
  Public Shared Function ListarDanielaFogagnoli() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_DANIELAFOGAGNOLI)

  End Function
  Public Shared Function ListarDeboraCristinaFonseca() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_DEBORACRISTINA)

  End Function
  Public Shared Function ListarElcimaraMeireDaRochaMantovani() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ELCIMARAMEIRE)

  End Function
  Public Shared Function ListarElcioDosSantosSiqueira() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ELCIODOSSANTOS)

  End Function
  Public Shared Function ListarEldaVarandaDunleyGuedesMachado() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ELDAVARANDA)

  End Function
  Public Shared Function ListarFatimaReginaRianiCosta() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_FATIMAREGINA)

  End Function
  Public Shared Function ListarJoseRobertoHeloani() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_JOSEROBERTO)

  End Function
  Public Shared Function ListarMariaCristinaBarrosMacielPellini() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIACRISTINABARROS)

  End Function
  Public Shared Function ListarMariaJoseMedinadaRochaBerto() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIAJOSEMEDINA)

  End Function
  Public Shared Function ListarMarileneProencaRebellodeSouza() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARILENEPROENCA)

  End Function
  Public Shared Function ListarSandraHelenaSposito() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_SANDRAHELENA)

  End Function
  Public Shared Function ListarValeriaCastroAlvesCardosoPenachini() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_VALERIACASTROALVES)

  End Function
  Public Shared Function ListarVeraLuciaFasanellaPompilio() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_VERALUCIAFASANELLA)

  End Function
  Public Shared Function ListarZuleikaFatimaVitorianoOlivan() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ZULEIKAFATIMA)

  End Function
  Public Shared Function ListarAnaMariaBenedettiAlvesGarcia() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ANAMARIABENEDETTI)

  End Function
  Public Shared Function ListarMarciaPolacchiniCartapattidaSilva() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARCIAPOLACCHINI)

  End Function
  Public Shared Function ListarMariaOrleneDare() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIAORLENE)

  End Function
  Public Shared Function ListarOsmarinaDiasAlves() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_OSMARINADIAS)

  End Function

  Public Shared Function ListarRegianeAparecidaPiva() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_REGIANEaPARECIDAPIVA)

  End Function

  Public Shared Function ListarVeraluciaPavaniJanjulio() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_VERALUCIAPAVANIJANJULIO)

  End Function
  Public Shared Function ListarMariaAngelaMedeirosPala() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIAANGELAMEDEIROSPALA)

  End Function
  Public Shared Function ListarMarisaSeixasTardelli() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARISASEIXASTARDELLI)

  End Function
  Public Shared Function ListarRaulAragaoMartins() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_RAULARAGAOMARTINS)

  End Function

  Public Shared Function ListarMariaAuxiliadoadeAlmeidaCunhaArantes() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIAAUXILIADORADEALMEIDACUNHAARANTES)

  End Function












  Public Shared Function ListarSueliFerreiraSchiavo() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_SUELIFERREIRASCHIAVO)

  End Function
  Public Shared Function ListarAdrianaEikoMatsumoto() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ADRIANAEIKOMATSUMOTO)

  End Function
  Public Shared Function ListarPatriciaGarciadeSouza() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_PATRICIAGARCIADESOUZA)

  End Function
  Public Shared Function ListarLumenaCeliTeixeira() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_LUMENACELITEIXEIRA)

  End Function
  Public Shared Function ListarElisaZanerattoRosa() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ELISAZANERATTOROSA)

  End Function
  Public Shared Function ListarMariaIzabeldoNascimentoMarques() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_MARIAIZABELDONASCIMENTOMARQUES)

  End Function
  Public Shared Function ListarAndreiaDeContoGarbin() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ANDREIADECONTOGARBIN)

  End Function

  Public Shared Function ListarUsuario() As IList

    Dim sql As String
    Dim Xnome As String

    '  If Usuario.UsuarioCorrente.Nome = "Adolfo Barros Benevenuto" Then
    '  sql = IIf(Usuario.UsuarioCorrente.Autenticado, "nome = 'Adolfo Barros Benevenuto' and ", "nome = Xnome and ")
    '  Else
    '    If Usuario.UsuarioCorrente.Nome = "Oliver Zancul Prado" Then
    '      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "nome = 'Oliver Zancul Prado' and ", "nome = Xnome and ")
    '    Else
    '      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "nome = 'Bauru' and ", "nome = Xnome and ")
    '    End If
    '  End If

    Xnome = Usuario.UsuarioCorrente.Nome
    Xnome = Xnome
    sql = IIf(Usuario.UsuarioCorrente.Autenticado, Xnome, Xnome)
    'Monta consulta
    sql = String.Format(C_GET_LIST_USUARIO, sql)

    'retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramRegiao.Value = _regiao
    _paramNome.Value = _nome
    _paramRepresentante.Value = _representante
    _paramColocacao.Value = _colocacao
    _paramSegmento.Value = _segmento
    _paramDt_inicio_mandato.Value = _dt_inicio_mandato
    _paramDt_fim_mandato.Value = _dt_fim_mandato
    _paramLeis.Value = _leis
    _paramAtas.Value = _atas
    _paramCargo.Value = _cargo

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Regiao = reader("regiao")
    Me.Nome = reader("nome")
    Me.representante = reader("representante")
    Me.colocacao = reader("colocacao")
    Me.segmento = reader("segmento")
    Me.dt_inicio_mandato = reader("dt_inicio_mandato")
    Me.dt_fim_mandato = reader("dt_fim_mandato")
    Me.leis = reader("leis")
    Me.atas = reader("atas")
    Me.cargo = reader("cargo")

  End Sub

  Public Sub Inserir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("FichaCadastral", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramRegiao, _paramNome, _paramRepresentante, _paramColocacao, _paramSegmento, _paramDt_inicio_mandato, _paramDt_fim_mandato, _paramLeis, _paramAtas, _paramCargo)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("FichaCadastral", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramRegiao, _paramNome, _paramRepresentante, _paramColocacao, _paramSegmento, _paramDt_inicio_mandato, _paramDt_fim_mandato, _paramLeis, _paramAtas, _paramCargo)

  End Sub

  Public Sub Excluir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("FichaCadastral", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property

  Public Property Regiao() As String
    Get
      Return _regiao
    End Get
    Set(ByVal Value As String)
      _regiao = Value
    End Set
  End Property

  Public Property Nome() As String
    Get
      Return _nome
    End Get
    Set(ByVal Value As String)
      _nome = Value
    End Set
  End Property

  Public Property representante() As String
    Get
      Return _representante
    End Get
    Set(ByVal Value As String)
      _representante = Value
    End Set
  End Property

  Public Property colocacao() As String
    Get
      Return _colocacao
    End Get
    Set(ByVal Value As String)
      _colocacao = Value
    End Set
  End Property
  Public Property segmento() As String
    Get
      Return _segmento
    End Get
    Set(ByVal Value As String)
      _segmento = Value
    End Set
  End Property
  Public Property dt_inicio_mandato() As String
    Get
      Return _dt_inicio_mandato
    End Get
    Set(ByVal Value As String)
      _dt_inicio_mandato = Value
    End Set
  End Property
  Public Property dt_fim_mandato() As String
    Get
      Return _dt_fim_mandato
    End Get
    Set(ByVal Value As String)
      _dt_fim_mandato = Value
    End Set
  End Property
  Public Property leis() As String
    Get
      Return _leis
    End Get
    Set(ByVal Value As String)
      _leis = Value
    End Set
  End Property
  Public Property atas() As String
    Get
      Return _atas
    End Get
    Set(ByVal Value As String)
      _atas = Value
    End Set
  End Property
  Public Property cargo() As String
    Get
      Return _cargo
    End Get
    Set(ByVal Value As String)
      _cargo = Value
    End Set
  End Property
#End Region

End Class


'Public Class FichaCadastral
'  Inherits BaseEntidade

'#Region "Member Variables"

'  ' constantes para SQL
'  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', regiao as 'Regiao', nome as 'Nome', representante as 'Representante', colocacao as 'Colocacao', segmento as 'Segmento', dt_inicio_mandato as 'Dt_inicio_mandato', dt_fim_mandato as 'Dt_fim_mandato', leis as 'Leis', atas as 'Atas' from tbl_partic_orgao_controle where Excluido = 0 order by nome"
'  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_partic_orgao_controle where id = @id"
'  Private Shared ReadOnly C_INSERT As String = "insert into tbl_partic_orgao_controle (regiao,nome,representante,colocacao,segmento,dt_inicio_mandato,dt_fim_mandato,leis,atas,excluido,criador,dt_criacao,atualizador,dt_atualizacao)" + _
'                                               "values(@regiao,@nome,@representante,@colocacao,@segmento,@dt_inicio_mandato,@dt_fim_mandato,@leis,@atas,0,1,getdate(),1,getdate());" + _
'                                               "select * from tbl_partic_orgao_controle where id = @@identity"
'  Private Shared ReadOnly C_DELETE As String = "update tbl_partic_orgao_controle set excluido = 1 where id = @id"
'  Private Shared ReadOnly C_UPDATE As String = "update tbl_partic_orgao_controle  set regiao = @regiao,  set nome = @nome,  set representante = @representante,  set colocacao = @colocacao,  set segmento = @segmento, set dt_inicio_mandato = @dt_inicio_mandato, set dt_fim_mandato = @dt_fim_mandato, set leis = @leis, set atas = @atas where id = @id"

'  ' parametros
'  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
'  Private _paramRegiao As New SqlParameter("@regiao", SqlDbType.VarChar)
'  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
'  Private _paramRepresentante As New SqlParameter("@representante", SqlDbType.VarChar)
'  Private _paramColocacao As New SqlParameter("@colocacao", SqlDbType.VarChar)
'  Private _paramSegmento As New SqlParameter("@segmento", SqlDbType.VarChar)
'  Private _paramDt_inicio_mandato As New SqlParameter("@dt_inicio_mandato", SqlDbType.VarChar)
'  Private _paramDt_fim_mandato As New SqlParameter("@dt_fim_mandato", SqlDbType.VarChar)
'  Private _paramLeis As New SqlParameter("@leis", SqlDbType.VarChar)
'  Private _paramAtas As New SqlParameter("@atas", SqlDbType.VarChar)


'  ' propriedades
'  Private _id As Integer
'  Private _regiao As String
'  Private _nome As String
'  Private _representante As String
'  Private _colocacao As String
'  Private _segmento As String
'  Private _dt_inicio_mandato As String
'  Private _dt_fim_mandato As String
'  Private _leis As String
'  Private _atas As String

'#End Region

'#Region "Static Methods"

'  Public Shared Function Consultar(ByVal id As Integer) As Object

'    Dim ret As New FichaCadastral
'    Dim param As New SqlParameter("@id", SqlDbType.Int)

'    ' prepara parametro
'    param.Value = id

'    ' executa comando no db
'    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

'    ' verifica se encontrou o registro
'    If (reader.Read()) Then

'      ret.PopularDados(reader)
'      Return ret

'    End If

'    ' retorna novo objeto
'    Throw New Exception("Ficha não encontrada.")

'  End Function

'  Public Shared Function Listar() As IList

'    'retorna lista
'    Return ListaHelper.ListarRegistros(C_GET_LIST)

'  End Function

'#End Region

'#Region "Private Functions"

'  Private Sub AtualizarParametros()

'    _paramRegiao.Value = _regiao
'    _paramNome.Value = _nome
'    _paramRepresentante.Value = _representante
'    _paramColocacao.Value = _colocacao
'    _paramSegmento.Value = _segmento
'    _paramDt_inicio_mandato.Value = _dt_inicio_mandato
'    _paramDt_fim_mandato.Value = _dt_fim_mandato
'    _paramLeis.Value = _leis
'    _paramAtas.Value = _atas

'  End Sub

'#End Region

'#Region "Public Methods"

'  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

'    'popula propriedades da tabela links (criador, atualizador etc.)
'    MyBase.PopularDados(reader)

'    'popular proiedades
'    Me.Id = reader("id")
'    Me.Regiao = reader("regiao")
'    Me.Nome = reader("nome")
'    Me.representante = reader("representante")
'    Me.colocacao = reader("colocacao")
'    Me.segmento = reader("segmento")
'    Me.dt_inicio_mandato = reader("dt_inicio_mandato")
'    Me.dt_fim_mandato = reader("dt_fim_mandato")
'    Me.leis = reader("leis")
'    Me.atas = reader("atas")

'  End Sub

'  Public Sub Inserir()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("FichaCadastral", "inserir")

'    ' prepara parametros
'    AtualizarParametros()

'    ' executa comando no db
'    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramRegiao, _paramNome, _paramRepresentante, _paramColocacao, _paramSegmento, _paramDt_inicio_mandato, _paramDt_fim_mandato, _paramLeis, _paramAtas)

'    If (ret.Read()) Then
'      PopularDados(ret)
'    End If

'    'fecha reader
'    ret.Close()

'  End Sub

'  Public Sub Alterar()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("FichaCadastral", "alterar")

'    ' prepara parametros
'    _paramId.Value = Me._id
'    AtualizarParametros()

'    ' executa comando no db
'    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramRegiao, _paramNome, _paramRepresentante, _paramColocacao, _paramSegmento, _paramDt_inicio_mandato, _paramDt_fim_mandato, _paramLeis, _paramAtas)

'  End Sub

'  Public Sub Excluir()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("FichaCadastral", "excluir")

'    ' prepara parametro
'    _paramId.Value = Me._id

'    ' executa comando no db
'    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

'  End Sub

'#End Region

'#Region "Public Properties"

'  Public Property Id() As Integer
'    Get
'      Return _id
'    End Get
'    Set(ByVal Value As Integer)
'      _id = Value
'    End Set
'  End Property

'  Public Property Regiao() As String
'    Get
'      Return _regiao
'    End Get
'    Set(ByVal Value As String)
'      _regiao = Value
'    End Set
'  End Property

'  Public Property Nome() As String
'    Get
'      Return _nome
'    End Get
'    Set(ByVal Value As String)
'      _nome = Value
'    End Set
'  End Property

'  Public Property representante() As String
'    Get
'      Return _representante
'    End Get
'    Set(ByVal Value As String)
'      _representante = Value
'    End Set
'  End Property

'  Public Property colocacao() As String
'    Get
'      Return _colocacao
'    End Get
'    Set(ByVal Value As String)
'      _colocacao = Value
'    End Set
'  End Property
'  Public Property segmento() As String
'    Get
'      Return _segmento
'    End Get
'    Set(ByVal Value As String)
'      _segmento = Value
'    End Set
'  End Property
'  Public Property dt_inicio_mandato() As String
'    Get
'      Return _dt_inicio_mandato
'    End Get
'    Set(ByVal Value As String)
'      _dt_inicio_mandato = Value
'    End Set
'  End Property
'  Public Property dt_fim_mandato() As String
'    Get
'      Return _dt_fim_mandato
'    End Get
'    Set(ByVal Value As String)
'      _dt_fim_mandato = Value
'    End Set
'  End Property
'  Public Property leis() As String
'    Get
'      Return _leis
'    End Get
'    Set(ByVal Value As String)
'      _leis = Value
'    End Set
'  End Property
'  Public Property atas() As String
'    Get
'      Return _atas
'    End Get
'    Set(ByVal Value As String)
'      _atas = Value
'    End Set
'  End Property

'#End Region

'End Class
