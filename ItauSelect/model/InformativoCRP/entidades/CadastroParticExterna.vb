Public Class CadastroParticExterna
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', cargo as 'Cargo', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_CONSELHEIRO_erro As String = "SELECT distinct a.nome as 'Nome', min(a.id) as 'Id' from tbl_partc_ativid_externa a where Excluido = 0 and status = 1 group by a.nome"
  Private Shared ReadOnly C_GET_LIST_USUARIO As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where assinatura = '{0}' and Excluido = 0 and status = 1 order by nome"
  Private Shared ReadOnly C_GET_LIST_PARTICIEXTERNA As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where assinatura = '{0}' and Excluido = 0 and status = 1 order by nome"
  Private Shared ReadOnly C_GET_LIST_DIRETORIA As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where assinatura = 'Diretoria' and Excluido = 0 and status = 1 order by nome"
  Private Shared ReadOnly C_GET_LIST_CONSELHEIRO As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where assinatura = 'Conselheiro' and Excluido = 0 and status = 1 order by nome"
  Private Shared ReadOnly C_GET_LIST_RELATORIO As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where assinatura = {0} and Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_GESTORES As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 1 and cargo = 3 order by nome"
  Private Shared ReadOnly C_GET_LIST_CONVIDADOS As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 1 and cargo = 4 order by nome"
  Private Shared ReadOnly C_GET_LIST_PENDENTE As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', cargo as 'Cargo', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_ENCAMINHADOS As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', data_fim as 'Data_Fim', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', cargo as 'Cargo', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 1 order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_partc_ativid_externa where id = @id"
  Private Shared ReadOnly C_GET_DATA_ASSINATURA As String = "select * from tbl_partc_ativid_externa where assinatura = @assinatura"
  Private Shared ReadOnly C_GET_DATA_PENDENTE As String = "select * from tbl_partc_ativid_externa where id = @id and status = 0"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_partc_ativid_externa (nome, organizacao, data_partic, data_fim, localizacao, representante_crp, outros_partic, atividades, assuntos, encaminhamentos, contatos, tarefas, data_reuniao, avaliacao_representante, assinatura, data_cadastro, encaminhamento_diretoria, cargo,status,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@nome, @organizacao, @data_partic, @data_fim, @localizacao, @representante_crp, @outros_partic, @atividades, @assuntos, @encaminhamentos, @contatos, @tarefas, @data_reuniao, @avaliacao_representante, @assinatura, @data_cadastro, @encaminhamento_diretoria, @cargo, @status,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_partc_ativid_externa where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_partc_ativid_externa set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_partc_ativid_externa set nome = @nome, organizacao = @organizacao, data_partic = @data_partic, data_fim = @data_fim, localizacao = @localizacao, representante_crp = @representante_crp, outros_partic = @outros_partic, atividades = @atividades, assuntos = @assuntos, encaminhamentos = @encaminhamentos, contatos = @contatos, tarefas = @tarefas, data_reuniao = @data_reuniao, avaliacao_representante = @avaliacao_representante, assinatura = @assinatura, data_cadastro = @data_cadastro, encaminhamento_diretoria = @encaminhamento_diretoria, cargo = @cargo, status = @status where id = @id"
  Private Shared ReadOnly C_UPDATE_PENDENTE As String = "update tbl_partc_ativid_externa set nome = @nome, organizacao = @organizacao, data_partic = @data_partic, data_fim = @data_fim, localizacao = @localizacao, representante_crp = @representante_crp, outros_partic = @outros_partic, atividades = @atividades, assuntos = @assuntos, encaminhamentos = @encaminhamentos, contatos = @contatos, tarefas = @tarefas, data_reuniao = @data_reuniao, avaliacao_representante = @avaliacao_representante, assinatura = @assinatura, data_cadastro = @data_cadastro, encaminhamento_diretoria = @encaminhamento_diretoria, cargo = @cargo, status = 1 where id = @id"
  Private Shared ReadOnly C_GET_LIST_CADASTRO_USUARIO As String = "select * from tbl_partc_ativid_externa where Excluido = 0 and assinatura = {0} order by nome"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramOrganizacao As New SqlParameter("@Organizacao", SqlDbType.VarChar)
  Private _paramData_partic As New SqlParameter("@data_partic", SqlDbType.VarChar)
  Private _paramData_fim As New SqlParameter("@data_fim", SqlDbType.VarChar)
  Private _paramLocalizacao As New SqlParameter("@localizacao", SqlDbType.VarChar)
  Private _paramRepresentante_crp As New SqlParameter("@representante_crp", SqlDbType.Text)
  Private _paramOutros_partic As New SqlParameter("@outros_partic", SqlDbType.Text)
  Private _paramAtividades As New SqlParameter("@atividades", SqlDbType.Text)
  Private _paramAssuntos As New SqlParameter("@assuntos", SqlDbType.Text)
  Private _paramEncaminhamentos As New SqlParameter("@encaminhamentos", SqlDbType.Text)
  Private _paramContatos As New SqlParameter("@contatos", SqlDbType.Text)
  Private _paramTarefas As New SqlParameter("@tarefas", SqlDbType.Text)
  Private _paramData_reuniao As New SqlParameter("@data_reuniao", SqlDbType.Text)
  Private _paramAvaliacao_representante As New SqlParameter("@avaliacao_representante", SqlDbType.Text)
  Private _paramAssinatura As New SqlParameter("@assinatura", SqlDbType.VarChar)
  Private _paramData_cadastro As New SqlParameter("@data_cadastro", SqlDbType.VarChar)
  Private _paramEncaminhamento_diretoria As New SqlParameter("@encaminhamento_diretoria", SqlDbType.VarChar)
  Private _paramCargo As New SqlParameter("@cargo", SqlDbType.Int)
  Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _nome As String
  Private _organizacao As String
  Private _data_partic As String
  Private _data_fim As String
  Private _localizacao As String
  Private _representante_crp As String
  Private _outros_partic As String
  Private _atividades As String
  Private _assuntos As String
  Private _encaminhamentos As String
  Private _contatos As String
  Private _tarefas As String
  Private _data_reuniao As String
  Private _avaliacao_representante As String
  Private _assinatura As String
  Private _data_cadastro As String
  Private _encaminhamento_diretoria As String
  Private _cargo As Integer
  Private _status As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New CadastroParticExterna
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
    Throw New Exception("Participação não encotrado.")

  End Function

  Public Shared Function ConsultarAssinatura(ByVal assinatura As String) As Object

    Dim ret As New CadastroParticExterna
    Dim param As New SqlParameter("@assinatura", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = assinatura

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_ASSINATURA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Participação não encotrado.")

  End Function

  Public Shared Function ConsultarUsuario(ByVal assinatura As String) As Object

    Dim ret As New CadastroParticExterna
    Dim param As New SqlParameter("@assinatura", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = assinatura

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_LIST_USUARIO, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Participação não encotrado.")

  End Function

  Public Shared Function ConsultarPendente(ByVal id As Integer) As Object

    Dim ret As New CadastroParticExterna
    Dim param As New SqlParameter("@id", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_PENDENTE, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Participação não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function


  Public Shared Function ListarUsuario(ByVal xnome As String) As IList

    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_CADASTRO_USUARIO, xnome))

  End Function


  Public Shared Function ListarID(ByVal id As Integer) As IList

    'retorna lista
    'Return ListaHelper.ListarRegistros(C_GET_LIST)
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, id))

  End Function
  Public Shared Function ListarDiretoria() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_DIRETORIA)

  End Function


  Public Shared Function ListarConselheiro() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_CONSELHEIRO)

  End Function
  Public Shared Function ListarGestores() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_GESTORES)

  End Function
  Public Shared Function ListarConvidados() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_CONVIDADOS)

  End Function
  Public Shared Function ListarPendente() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_PENDENTE)

  End Function
  Public Shared Function ListarEncaminhados() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ENCAMINHADOS)

  End Function
  Public Shared Function ListarRelatorio() As IList

    Dim sql As String

    sql = "'Adolfo'"

    'Monta consulta
    'sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and ")
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioDiretoria() As IList

    Dim sql As String

    sql = "'Diretoria'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioConselheiro() As IList

    Dim sql As String

    sql = "'Conselheiro'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioGestor() As IList

    Dim sql As String

    sql = "'Gestor'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioConvidado() As IList

    Dim sql As String

    sql = "'Convidado'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioAndreTorres() As IList

    Dim sql As String

    sql = "'Andréa Torres'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioOliverZanculPrado() As IList

    Dim sql As String

    sql = "'Oliver Zancul Prado'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioAndreaFerreiraMartins() As IList

    Dim sql As String

    sql = "'Andrea Ferreira Martins'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioLeandroGabarra() As IList

    Dim sql As String

    sql = "'Leandro Gabarra'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariadaGracaMarchinaGoncalves() As IList

    Dim sql As String

    sql = "'Maria da Graça Marchina Gonçalves'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariaErminiaCiliberti() As IList

    Dim sql As String

    sql = "'Maria Ermínia Ciliberti'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioLuciaFonsecadeToledo() As IList

    Dim sql As String

    sql = "'Lúcia Fonseca de Toledo'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioAnaPaulaPereiraJardim() As IList

    Dim sql As String

    sql = "'Ana Paula Pereira Jardim'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioCarmemSilviaRotandanoTaverna() As IList

    Dim sql As String

    sql = "'Carmem Sílvia Rotandano Taverna'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioChicaHatakeyamaGuimaraes() As IList

    Dim sql As String

    sql = "'Chica Hatakeyama Guimarães'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioDanielaFogagnoli() As IList

    Dim sql As String

    sql = "'Daniela Fogagnoli'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioDeboraCristinaFonseca() As IList

    Dim sql As String

    sql = "'Débora Cristina Fonseca'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioElcimaraMeireDaRochaMantovani() As IList

    Dim sql As String

    sql = "'Elcimara Meire Da Rocha Mantovani'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioElcioDosSantosSiqueira() As IList

    Dim sql As String

    sql = "'Élcio Dos Santos Sequeira'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioEldaVarandaDunleyGuedesMachado() As IList

    Dim sql As String

    sql = "'Elda Varanda Dunley Guedes Machado'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  'Public Shared Function ListarRelatorioEldaVarandaDunleyGuedesMachado() As IList

  '  Dim sql As String

  '  sql = "'Elda Varanda Dunley Guedes Machado'"

  '  'Monta consulta
  '  sql = String.Format(C_GET_LIST_RELATORIO, sql)

  '  'Retorna lista
  '  Return ListaHelper.ListarRegistros(sql)

  'End Function
  Public Shared Function ListarRelatorioFatimaReginaRianiCosta() As IList

    Dim sql As String

    sql = "'Fátima Regina Riani Costa'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioJoseRobertoHeloani() As IList

    Dim sql As String

    sql = "'José Roberto Heloani'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariaCristinaBarrosMacielPellini() As IList

    Dim sql As String

    sql = "'Maria Cristina Barros Maciel Pellini'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariaJoseMedinadaRochaBerto() As IList

    Dim sql As String

    sql = "'Maria José Medina da Rocha Berto'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMarileneProencaRebellodeSouza() As IList

    Dim sql As String

    sql = "'Marilene Proença Rebello de Souza'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioSandraHelenaSposito() As IList

    Dim sql As String

    sql = "'Sandra Helena Sposito'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioValeriaCastroAlvesCardosoPenachini() As IList

    Dim sql As String

    sql = "'Valéria Castro Alves Cardoso Penachini'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioVeraLuciaFasanellaPompilio() As IList

    Dim sql As String

    sql = "'Vera Lúcia Fasanella Pompílio'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioZuleikaFatimaVitorianoOlivan() As IList

    Dim sql As String

    sql = "'Zuleika Fátima Vitoriano Olivan'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioAnaMariaBenedettiAlvesGarcia() As IList

    Dim sql As String

    sql = "'Ana Maria Benedetti Alves Garcia'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMarciaPolacchiniCartapattidaSilva() As IList

    Dim sql As String

    sql = "'Marcia Polacchini Cartapatti da Silva'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariaOrleneDare() As IList

    Dim sql As String

    sql = "'Maria Orlene Daré'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioOsmarinaDiasAlves() As IList

    Dim sql As String

    sql = "'Osmarina Dias Alves'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioRegianeAparecidaPiva() As IList

    Dim sql As String

    sql = "'Regiane Aparecida Piva'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioVeraluciaPavaniJanjulio() As IList

    Dim sql As String

    sql = "'Veralúcia Pavani Janjúlio'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariaAngelaMedeirosPala() As IList

    Dim sql As String

    sql = "'Maria Angela Medeiros Pala'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMarisaSeixasTardelli() As IList

    Dim sql As String

    sql = "'Marisa Seixas Tardelli'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioRaulAragaoMartins() As IList

    Dim sql As String

    sql = "'Raul Aragão Martins'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarRelatorioMariaAuxiliadoadeAlmeidaCunhaArantes() As IList

    Dim sql As String

    sql = "'Maria Auxiliadora de Almeida Cunha Arantes'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function


  Public Shared Function ListarRelatorioSueliFerreiraSchiavo() As IList

    Dim sql As String

    sql = "'Sueli Ferreira Schiavo'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioAdrianaEikoMatsumoto() As IList

    Dim sql As String

    sql = "'Adriana Eiko Matsumoto'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioPatriciaGarciadeSouza() As IList

    Dim sql As String

    sql = "'Patricia Garcia de Souza'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioLumenaCeliTeixeira() As IList

    Dim sql As String

    sql = "'Lumena Celi Teixeira'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioElisaZanerattoRosa() As IList

    Dim sql As String

    sql = "'Elisa Zaneratto Rosa'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioMariaIzabeldoNascimentoMarques() As IList

    Dim sql As String

    sql = "'Maria Izabel do Nascimento Marques'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarRelatorioAndréiaDeContoGarbin() As IList

    Dim sql As String

    sql = "'Andréia De Conto Garbin'"

    'Monta consulta
    sql = String.Format(C_GET_LIST_RELATORIO, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function
#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramNome.Value = _nome
    _paramOrganizacao.Value = _organizacao
    _paramData_partic.Value = _data_partic
    _paramData_fim.Value = _data_fim
    _paramLocalizacao.Value = _localizacao
    _paramRepresentante_crp.Value = _representante_crp
    _paramOutros_partic.Value = _outros_partic
    _paramAtividades.Value = _atividades
    _paramAssuntos.Value = _assuntos
    _paramEncaminhamentos.Value = _encaminhamentos
    _paramContatos.Value = _contatos
    _paramTarefas.Value = _tarefas
    _paramData_reuniao.Value = _data_reuniao
    _paramAvaliacao_representante.Value = _avaliacao_representante
    _paramAssinatura.Value = _assinatura
    _paramData_cadastro.Value = _data_cadastro
    _paramEncaminhamento_diretoria.Value = _encaminhamento_diretoria
    _paramCargo.Value = _cargo
    _paramStatus.Value = _status

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Nome = reader("nome")
    Me.Organizacao = reader("organizacao")
    Me.data_partic = reader("data_partic")
    Me.data_fim = reader("data_fim")
    Me.localizacao = reader("localizacao")
    Me.representante_crp = reader("representante_crp")
    Me.outros_partic = reader("outros_partic")
    Me.atividades = reader("atividades")
    Me.assuntos = reader("assuntos")
    Me.encaminhamentos = reader("encaminhamentos")
    Me.contatos = reader("contatos")
    Me.tarefas = reader("tarefas")
    Me.data_reuniao = reader("data_reuniao")
    Me.avaliacao_representante = reader("avaliacao_representante")
    Me.assinatura = reader("assinatura")
    Me.data_cadastro = reader("data_cadastro")
    Me.encaminhamento_diretoria = reader("encaminhamento_diretoria")
    Me.cargo = reader("cargo")
    Me.status = reader("status")

  End Sub

  Public Sub Inserir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramOrganizacao, _paramData_partic, _paramData_fim, _paramLocalizacao, _paramRepresentante_crp, _paramOutros_partic, _paramAtividades, _paramAssuntos, _paramEncaminhamentos, _paramContatos, _paramTarefas, _paramData_reuniao, _paramAvaliacao_representante, _paramAssinatura, _paramData_cadastro, _paramEncaminhamento_diretoria, _paramCargo, _paramStatus)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramOrganizacao, _paramData_partic, _paramData_fim, _paramLocalizacao, _paramRepresentante_crp, _paramOutros_partic, _paramAtividades, _paramAssuntos, _paramEncaminhamentos, _paramContatos, _paramTarefas, _paramData_reuniao, _paramAvaliacao_representante, _paramAssinatura, _paramData_cadastro, _paramEncaminhamento_diretoria, _paramCargo, _paramStatus)

  End Sub

  Public Sub AlterarPendente()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_PENDENTE, _paramId, _paramNome, _paramOrganizacao, _paramData_partic, _paramData_fim, _paramLocalizacao, _paramRepresentante_crp, _paramOutros_partic, _paramAtividades, _paramAssuntos, _paramEncaminhamentos, _paramContatos, _paramTarefas, _paramData_reuniao, _paramAvaliacao_representante, _paramAssinatura, _paramData_cadastro, _paramEncaminhamento_diretoria, _paramCargo, _paramStatus)

  End Sub

  Public Sub Excluir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "excluir")

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

  Public Property Nome() As String
    Get
      Return _nome
    End Get
    Set(ByVal Value As String)
      _nome = Value
    End Set
  End Property

  Public Property Organizacao() As String
    Get
      Return _organizacao
    End Get
    Set(ByVal Value As String)
      _organizacao = Value
    End Set
  End Property

  Public Property data_partic() As String
    Get
      Return _data_partic
    End Get
    Set(ByVal Value As String)
      _data_partic = Value
    End Set
  End Property
  Public Property data_fim() As String
    Get
      Return _data_fim
    End Get
    Set(ByVal Value As String)
      _data_fim = Value
    End Set
  End Property

  Public Property localizacao() As String
    Get
      Return _localizacao
    End Get
    Set(ByVal Value As String)
      _localizacao = Value
    End Set
  End Property

  Public Property representante_crp() As String
    Get
      Return _representante_crp
    End Get
    Set(ByVal Value As String)
      _representante_crp = Value
    End Set
  End Property

  Public Property outros_partic() As String
    Get
      Return _outros_partic
    End Get
    Set(ByVal Value As String)
      _outros_partic = Value
    End Set
  End Property

  Public Property atividades() As String
    Get
      Return _atividades
    End Get
    Set(ByVal Value As String)
      _atividades = Value
    End Set
  End Property

  Public Property assuntos() As String
    Get
      Return _assuntos
    End Get
    Set(ByVal Value As String)
      _assuntos = Value
    End Set
  End Property

  Public Property encaminhamentos() As String
    Get
      Return _encaminhamentos
    End Get
    Set(ByVal Value As String)
      _encaminhamentos = Value
    End Set
  End Property

  Public Property contatos() As String
    Get
      Return _contatos
    End Get
    Set(ByVal Value As String)
      _contatos = Value
    End Set
  End Property

  Public Property tarefas() As String
    Get
      Return _tarefas
    End Get
    Set(ByVal Value As String)
      _tarefas = Value
    End Set
  End Property

  Public Property data_reuniao() As String
    Get
      Return _data_reuniao
    End Get
    Set(ByVal Value As String)
      _data_reuniao = Value
    End Set
  End Property

  Public Property avaliacao_representante() As String
    Get
      Return _avaliacao_representante
    End Get
    Set(ByVal Value As String)
      _avaliacao_representante = Value
    End Set
  End Property

  Public Property assinatura() As String
    Get
      Return _assinatura
    End Get
    Set(ByVal Value As String)
      _assinatura = Value
    End Set
  End Property

  Public Property data_cadastro() As String
    Get
      Return _data_cadastro
    End Get
    Set(ByVal Value As String)
      _data_cadastro = Value
    End Set
  End Property

  Public Property encaminhamento_diretoria() As String
    Get
      Return _encaminhamento_diretoria
    End Get
    Set(ByVal Value As String)
      _encaminhamento_diretoria = Value
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

  Public Property status() As String
    Get
      Return _status
    End Get
    Set(ByVal Value As String)
      _status = Value
    End Set
  End Property

#End Region

End Class

'Public Class CadastroParticExterna
'  Inherits BaseEntidade

'#Region "Member Variables"

'  ' constantes para SQL
'  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 order by nome"
'  Private Shared ReadOnly C_GET_LIST_CONSELHEIRO As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 1 order by nome"
'  Private Shared ReadOnly C_GET_LIST_GESTORES As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 1  order by nome"
'  Private Shared ReadOnly C_GET_LIST_CONVIDADOS As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 1 order by nome"
'  Private Shared ReadOnly C_GET_LIST_PENDENTE As String = "select id as 'Id', nome as 'Nome', organizacao as 'Organizacao', data_partic as 'Data_partic', localizacao as 'Localizacao', representante_crp as 'Representante_crp', outros_partic as 'Outros_partic', atividades as 'Atividades', assuntos as 'Assuntos', encaminhamentos as 'Encaminhamentos', contatos as 'Contatos', tarefas as 'Tarefas', data_reuniao as 'Data_reuniao', avaliacao_representante as 'Avaliacao_representante', assinatura as 'Assinatura', data_cadastro as 'Data_cadastro', encaminhamento_diretoria as 'Encaminhamento_diretoria', status as 'Status' from tbl_partc_ativid_externa where Excluido = 0 and status = 0 order by nome"
'  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_partc_ativid_externa where id = @id"
'  Private Shared ReadOnly C_GET_DATA_PENDENTE As String = "select * from tbl_partc_ativid_externa where id = @id and status = 0"
'  Private Shared ReadOnly C_INSERT As String = "insert into tbl_partc_ativid_externa (nome, organizacao, data_partic, localizacao, representante_crp, outros_partic, atividades, assuntos, encaminhamentos, contatos, tarefas, data_reuniao, avaliacao_representante, assinatura, data_cadastro, encaminhamento_diretoria, status,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
'                                               "values(@nome, @organizacao, @data_partic, @localizacao, @representante_crp, @outros_partic, @atividades, @assuntos, @encaminhamentos, @contatos, @tarefas, @data_reuniao, @avaliacao_representante, @assinatura, @data_cadastro, @encaminhamento_diretoria, @status,0,1,getdate(),1,getdate());" + _
'                                               "select * from tbl_partc_ativid_externa where id = @@identity"
'  Private Shared ReadOnly C_DELETE As String = "update tbl_partc_ativid_externa set excluido = 1 where id = @id"
'  Private Shared ReadOnly C_UPDATE As String = "update tbl_partc_ativid_externa set nome = @nome, organizacao = @organizacao, data_partic = @data_partic, localizacao = @localizacao, representante_crp = @representante_crp, outros_partic = @outros_partic, atividades = @atividades, assuntos = @assuntos, encaminhamentos = @encaminhamentos, contatos = @contatos, tarefas = @tarefas, data_reuniao = @data_reuniao, avaliacao_representante = @avaliacao_representante, assinatura = @assinatura, data_cadastro = @data_cadastro, encaminhamento_diretoria = @encaminhamento_diretoria, status = @status where id = @id"
'  Private Shared ReadOnly C_UPDATE_PENDENTE As String = "update tbl_partc_ativid_externa set nome = @nome, organizacao = @organizacao, data_partic = @data_partic, localizacao = @localizacao, representante_crp = @representante_crp, outros_partic = @outros_partic, atividades = @atividades, assuntos = @assuntos, encaminhamentos = @encaminhamentos, contatos = @contatos, tarefas = @tarefas, data_reuniao = @data_reuniao, avaliacao_representante = @avaliacao_representante, assinatura = @assinatura, data_cadastro = @data_cadastro, encaminhamento_diretoria = @encaminhamento_diretoria, status = 1 where id = @id"

'  ' parametros
'  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
'  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
'  Private _paramOrganizacao As New SqlParameter("@Organizacao", SqlDbType.VarChar)
'  Private _paramData_partic As New SqlParameter("@data_partic", SqlDbType.VarChar)
'  Private _paramLocalizacao As New SqlParameter("@localizacao", SqlDbType.VarChar)
'  Private _paramRepresentante_crp As New SqlParameter("@representante_crp", SqlDbType.VarChar)
'  Private _paramOutros_partic As New SqlParameter("@outros_partic", SqlDbType.VarChar)
'  Private _paramAtividades As New SqlParameter("@atividades", SqlDbType.VarChar)
'  Private _paramAssuntos As New SqlParameter("@assuntos", SqlDbType.VarChar)
'  Private _paramEncaminhamentos As New SqlParameter("@encaminhamentos", SqlDbType.VarChar)
'  Private _paramContatos As New SqlParameter("@contatos", SqlDbType.VarChar)
'  Private _paramTarefas As New SqlParameter("@tarefas", SqlDbType.VarChar)
'  Private _paramData_reuniao As New SqlParameter("@data_reuniao", SqlDbType.VarChar)
'  Private _paramAvaliacao_representante As New SqlParameter("@avaliacao_representante", SqlDbType.VarChar)
'  Private _paramAssinatura As New SqlParameter("@assinatura", SqlDbType.VarChar)
'  Private _paramData_cadastro As New SqlParameter("@data_cadastro", SqlDbType.VarChar)
'  Private _paramEncaminhamento_diretoria As New SqlParameter("@encaminhamento_diretoria", SqlDbType.VarChar)
'  Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)

'  ' propriedades
'  Private _id As Integer
'  Private _nome As String
'  Private _organizacao As String
'  Private _data_partic As String
'  Private _localizacao As String
'  Private _representante_crp As String
'  Private _outros_partic As String
'  Private _atividades As String
'  Private _assuntos As String
'  Private _encaminhamentos As String
'  Private _contatos As String
'  Private _tarefas As String
'  Private _data_reuniao As String
'  Private _avaliacao_representante As String
'  Private _assinatura As String
'  Private _data_cadastro As String
'  Private _encaminhamento_diretoria As String
'  Private _status As String

'#End Region

'#Region "Static Methods"

'  Public Shared Function Consultar(ByVal id As Integer) As Object

'    Dim ret As New CadastroParticExterna
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
'    Throw New Exception("Participação não encotrado.")

'  End Function

'  Public Shared Function ConsultarPendente(ByVal id As Integer) As Object

'    Dim ret As New CadastroParticExterna
'    Dim param As New SqlParameter("@id", SqlDbType.Int)

'    ' prepara parametro
'    param.Value = id

'    ' executa comando no db
'    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_PENDENTE, param)

'    ' verifica se encontrou o registro
'    If (reader.Read()) Then

'      ret.PopularDados(reader)
'      Return ret

'    End If

'    ' retorna novo objeto
'    Throw New Exception("Participação não encotrado.")

'  End Function

'  Public Shared Function Listar() As IList

'    'retorna lista
'    Return ListaHelper.ListarRegistros(C_GET_LIST)

'  End Function
'  Public Shared Function ListarConselheiro() As IList

'    'retorna lista
'    Return ListaHelper.ListarRegistros(C_GET_LIST_CONSELHEIRO)

'  End Function
'  Public Shared Function ListarGestores() As IList

'    'retorna lista
'    Return ListaHelper.ListarRegistros(C_GET_LIST_GESTORES)

'  End Function
'  Public Shared Function ListarConvidados() As IList

'    'retorna lista
'    Return ListaHelper.ListarRegistros(C_GET_LIST_CONVIDADOS)

'  End Function
'  Public Shared Function ListarPendente() As IList

'    'retorna lista
'    Return ListaHelper.ListarRegistros(C_GET_LIST_PENDENTE)

'  End Function
'#End Region

'#Region "Private Functions"

'  Private Sub AtualizarParametros()

'    _paramId.Value = _id
'    _paramNome.Value = _nome
'    _paramOrganizacao.Value = _organizacao
'    _paramData_partic.Value = _data_partic
'    _paramLocalizacao.Value = _localizacao
'    _paramRepresentante_crp.Value = _representante_crp
'    _paramOutros_partic.Value = _outros_partic
'    _paramAtividades.Value = _atividades
'    _paramAssuntos.Value = _assuntos
'    _paramEncaminhamentos.Value = _encaminhamentos
'    _paramContatos.Value = _contatos
'    _paramTarefas.Value = _tarefas
'    _paramData_reuniao.Value = _data_reuniao
'    _paramAvaliacao_representante.Value = _avaliacao_representante
'    _paramAssinatura.Value = _assinatura
'    _paramData_cadastro.Value = _data_cadastro
'    _paramEncaminhamento_diretoria.Value = _encaminhamento_diretoria
'    _paramStatus.Value = _status

'  End Sub

'#End Region

'#Region "Public Methods"

'  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

'    'popula propriedades da tabela links (criador, atualizador etc.)
'    MyBase.PopularDados(reader)

'    'popular proiedades
'    Me.Id = reader("id")
'    Me.Nome = reader("nome")
'    Me.Organizacao = reader("organizacao")
'    Me.data_partic = reader("data_partic")
'    Me.localizacao = reader("localizacao")
'    Me.representante_crp = reader("representante_crp")
'    Me.outros_partic = reader("outros_partic")
'    Me.atividades = reader("atividades")
'    Me.assuntos = reader("assuntos")
'    Me.encaminhamentos = reader("encaminhamentos")
'    Me.contatos = reader("contatos")
'    Me.tarefas = reader("tarefas")
'    Me.data_reuniao = reader("data_reuniao")
'    Me.avaliacao_representante = reader("avaliacao_representante")
'    Me.assinatura = reader("assinatura")
'    Me.data_cadastro = reader("data_cadastro")
'    Me.encaminhamento_diretoria = reader("encaminhamento_diretoria")
'    Me.status = reader("status")

'  End Sub

'  Public Sub Inserir()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "inserir")

'    ' prepara parametros
'    AtualizarParametros()

'    ' executa comando no db
'    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramOrganizacao, _paramData_partic, _paramLocalizacao, _paramRepresentante_crp, _paramOutros_partic, _paramAtividades, _paramAssuntos, _paramEncaminhamentos, _paramContatos, _paramTarefas, _paramData_reuniao, _paramAvaliacao_representante, _paramAssinatura, _paramData_cadastro, _paramEncaminhamento_diretoria, _paramStatus)

'    If (ret.Read()) Then
'      PopularDados(ret)
'    End If

'    'fecha reader
'    ret.Close()

'  End Sub

'  Public Sub Alterar()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "alterar")

'    ' prepara parametros
'    _paramId.Value = Me._id
'    AtualizarParametros()

'    ' executa comando no db
'    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramOrganizacao, _paramData_partic, _paramLocalizacao, _paramRepresentante_crp, _paramOutros_partic, _paramAtividades, _paramAssuntos, _paramEncaminhamentos, _paramContatos, _paramTarefas, _paramData_reuniao, _paramAvaliacao_representante, _paramAssinatura, _paramData_cadastro, _paramEncaminhamento_diretoria, _paramStatus)

'  End Sub

'  Public Sub AlterarPendente()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "alterar")

'    ' prepara parametros
'    _paramId.Value = Me._id
'    AtualizarParametros()

'    ' executa comando no db
'    SqlHelper.ExecuteNonQuery(C_UPDATE_PENDENTE, _paramId, _paramNome, _paramOrganizacao, _paramData_partic, _paramLocalizacao, _paramRepresentante_crp, _paramOutros_partic, _paramAtividades, _paramAssuntos, _paramEncaminhamentos, _paramContatos, _paramTarefas, _paramData_reuniao, _paramAvaliacao_representante, _paramAssinatura, _paramData_cadastro, _paramEncaminhamento_diretoria, _paramStatus)

'  End Sub

'  Public Sub Excluir()

'    ''Chamada para verificacao de perfil
'    'PermissaoGlobal.VerificarPermissao("CadastroParticExterna", "excluir")

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

'  Public Property Nome() As String
'    Get
'      Return _nome
'    End Get
'    Set(ByVal Value As String)
'      _nome = Value
'    End Set
'  End Property

'  Public Property Organizacao() As String
'    Get
'      Return _organizacao
'    End Get
'    Set(ByVal Value As String)
'      _organizacao = Value
'    End Set
'  End Property

'  Public Property data_partic() As String
'    Get
'      Return _data_partic
'    End Get
'    Set(ByVal Value As String)
'      _data_partic = Value
'    End Set
'  End Property

'  Public Property localizacao() As String
'    Get
'      Return _localizacao
'    End Get
'    Set(ByVal Value As String)
'      _localizacao = Value
'    End Set
'  End Property

'  Public Property representante_crp() As String
'    Get
'      Return _representante_crp
'    End Get
'    Set(ByVal Value As String)
'      _representante_crp = Value
'    End Set
'  End Property

'  Public Property outros_partic() As String
'    Get
'      Return _outros_partic
'    End Get
'    Set(ByVal Value As String)
'      _outros_partic = Value
'    End Set
'  End Property

'  Public Property atividades() As String
'    Get
'      Return _atividades
'    End Get
'    Set(ByVal Value As String)
'      _atividades = Value
'    End Set
'  End Property

'  Public Property assuntos() As String
'    Get
'      Return _assuntos
'    End Get
'    Set(ByVal Value As String)
'      _assuntos = Value
'    End Set
'  End Property

'  Public Property encaminhamentos() As String
'    Get
'      Return _encaminhamentos
'    End Get
'    Set(ByVal Value As String)
'      _encaminhamentos = Value
'    End Set
'  End Property

'  Public Property contatos() As String
'    Get
'      Return _contatos
'    End Get
'    Set(ByVal Value As String)
'      _contatos = Value
'    End Set
'  End Property

'  Public Property tarefas() As String
'    Get
'      Return _tarefas
'    End Get
'    Set(ByVal Value As String)
'      _tarefas = Value
'    End Set
'  End Property

'  Public Property data_reuniao() As String
'    Get
'      Return _data_reuniao
'    End Get
'    Set(ByVal Value As String)
'      _data_reuniao = Value
'    End Set
'  End Property

'  Public Property avaliacao_representante() As String
'    Get
'      Return _avaliacao_representante
'    End Get
'    Set(ByVal Value As String)
'      _avaliacao_representante = Value
'    End Set
'  End Property

'  Public Property assinatura() As String
'    Get
'      Return _assinatura
'    End Get
'    Set(ByVal Value As String)
'      _assinatura = Value
'    End Set
'  End Property

'  Public Property data_cadastro() As String
'    Get
'      Return _data_cadastro
'    End Get
'    Set(ByVal Value As String)
'      _data_cadastro = Value
'    End Set
'  End Property

'  Public Property encaminhamento_diretoria() As String
'    Get
'      Return _encaminhamento_diretoria
'    End Get
'    Set(ByVal Value As String)
'      _encaminhamento_diretoria = Value
'    End Set
'  End Property

'  Public Property status() As String
'    Get
'      Return _status
'    End Get
'    Set(ByVal Value As String)
'      _status = Value
'    End Set
'  End Property

'#End Region

'End Class
