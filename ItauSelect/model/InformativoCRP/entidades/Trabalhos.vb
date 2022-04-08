
Public Class TrabalhosMostra
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_trab AS 'Id_Trab', id_usu AS 'Id_Usu', nome AS 'Nome', logon AS 'Logon', instituicao AS 'Instituicao', titulo as 'Titulo', categoria AS 'Categoria', resumo AS 'Resumo', status AS 'Status', id_par AS 'Id_Par', linkvideo AS 'Linkvideo', linkyoutube AS 'Linkyoutube', linkarquivo AS 'Linkarquivo', obs AS 'Obs', outros1 as 'Outros1', emailoutros1 as Emailoutros1, outros2 as 'Outros2', emailoutros2 as Emailoutros2, outros3 as 'Outros3', emailoutros3 as Emailoutros3, outros4 as 'Outros4', emailoutros4 as Emailoutros4, eixo as 'Eixo', area as 'Area', processo as 'Processo', classificacao as 'Classificacao', comentario as 'Comentario' from tbl_eventos_trabalhos_2021 where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_LIST_TRABALHOS As String = "select id_trab AS 'Id_Trab', id_usu AS 'Id_Usu', nome AS 'Nome', logon AS 'Logon', instituicao AS 'Instituicao', titulo as 'Titulo', categoria AS 'Categoria', resumo AS 'Resumo', status AS 'Status', id_par AS 'Id_Par', linkvideo AS 'Linkvideo', linkyoutube AS 'Linkyoutube', linkarquivo AS 'Linkarquivo', obs AS 'Obs', outros1 as 'Outros1', emailoutros1 as Emailoutros1, outros2 as 'Outros2', emailoutros2 as Emailoutros2, outros3 as 'Outros3', emailoutros3 as Emailoutros3, outros4 as 'Outros4', emailoutros4 as Emailoutros4, eixo as 'Eixo', area as 'Area', processo as 'Processo', classificacao as 'Classificacao', comentario as 'Comentario' from tbl_eventos_trabalhos_2021 where {0} and Excluido = 0 order by nome"


  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_eventos_trabalhos_2021 where id_trab = @id_trab"
  Private Shared ReadOnly C_GET_DATA_USU As String = "select * from tbl_eventos_trabalhos_2021 where id_usu = @id_usu"
  Private Shared ReadOnly C_GET_DATA_USU_count As String = "select count(*) as 'total' from tbl_eventos_trabalhos_2021 where id_usu = @id_usu and categoria = 'COMUNICAÇÃO ORAL'"
  Private Shared ReadOnly C_GET_DATA_USU_count_VIDEO As String = "select count(*) as 'total' from tbl_eventos_trabalhos_2021 where id_usu = @id_usu and categoria = 'VÍDEOS'"

  Private Shared ReadOnly C_INSERT As String = "insert into tbl_eventos_trabalhos_2021 ( id_usu, nome, logon, instituicao, titulo, categoria, resumo, status, id_par, linkvideo, linkyoutube, linkarquivo, obs, excluido,criador,dt_criacao,atualizador,dt_atualizacao, outros1, emailoutros1, outros2, emailoutros2, outros3, emailoutros3, outros4, emailoutros4, eixo, area, processo, classificacao, comentario) " + _
                                               "values( @id_usu, @nome, @logon, @instituicao, @titulo, @categoria, @resumo, @status, @id_par, @linkvideo, @linkyoutube, @linkarquivo, @obs,0,1,getdate(),1,getdate(), @outros1, @emailoutros1, @outros2, @emailoutros2, @outros3, @emailoutros3, @outros4, @emailoutros4, @eixo, @area, @processo, @classificacao, @comentario);" + _
                                               "select * from tbl_eventos_trabalhos_2021 where id_trab = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_eventos_trabalhos_2021 set excluido = 1 where id_trab = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_eventos_trabalhos_2021 set id_usu = @id_usu, nome = @nome, logon = @logon, instituicao = @instituicao, titulo = @titulo, categoria = @categoria, resumo = @resumo, status = @status, id_par = @id_par, linkvideo = @linkvideo, linkyoutube = @linkyoutube, linkarquivo = @linkarquivo, obs = @obs, outros1 = @outros1, emailoutros1 = @emailoutros1,  outros2 = @outros2, emailoutros2 = @emailoutros2,  outros3 = @outros3, emailoutros3 = @emailoutros3,  outros4 = @outros4, emailoutros4 = @emailoutros4, eixo = @eixo, area = @area, processo = @processo, classificacao = @classificacao, comentario = @comentario where id_trab = @id"

  Private Shared ReadOnly C_UPDATE_APROVADO As String = "update tbl_eventos_trabalhos_2021 set  status = 'APROVADO',  area = @area, processo = @processo, classificacao = @classificacao, comentario = @comentario where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_APROVADO_COF_ALTERAR As String = "update tbl_eventos_trabalhos_2021 set  status = 'AVAL COF',  comentario = @comentario where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_REPROVADO_COF_ALTERAR As String = "update tbl_eventos_trabalhos_2021 set  status = 'REPROV COF',  comentario = @comentario where id_trab = @id_trab"

  Private Shared ReadOnly C_UPDATE_APROVADO_COF As String = "update tbl_eventos_trabalhos_2021 set  status = 'APROVADO COF',  area = @area, processo = @processo, classificacao = @classificacao, comentario = @comentario where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_REPROVADO As String = "update tbl_eventos_trabalhos_2021 set  status = 'REPROVADO',  area = @area, processo = @processo, classificacao = @classificacao, comentario = @comentario where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_REPROVADO_COF As String = "update tbl_eventos_trabalhos_2021 set  status = 'REPROVADO COF',  area = @area, processo = @processo, classificacao = @classificacao, comentario = @comentario where id_trab = @id_trab"

  ' parametros
  Private _paramId_trab As New SqlParameter("@id_trab", SqlDbType.Int)
  Private _paramId_usu As New SqlParameter("@id_usu", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramLogon As New SqlParameter("@logon", SqlDbType.VarChar)
  Private _paramInstituicao As New SqlParameter("@instituicao", SqlDbType.VarChar)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramCategoria As New SqlParameter("@categoria", SqlDbType.VarChar)
  Private _paramResumo As New SqlParameter("@resumo", SqlDbType.VarChar)
  Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)
  Private _paramId_Par As New SqlParameter("@id_par", SqlDbType.Int)
  Private _paramLinkvideo As New SqlParameter("@linkvideo", SqlDbType.VarChar)
  Private _paramLinkyoutube As New SqlParameter("@linkyoutube", SqlDbType.VarChar)
  Private _paramLinkarquivo As New SqlParameter("@linkarquivo", SqlDbType.VarChar)
  Private _paramObs As New SqlParameter("@obs", SqlDbType.VarChar)
  Private _paramTotal As New SqlParameter("@total", SqlDbType.Int)
  Private _paramOutros1 As New SqlParameter("@outros1", SqlDbType.VarChar)
  Private _paramEmailoutros1 As New SqlParameter("@emailoutros1", SqlDbType.VarChar)
  Private _paramOutros2 As New SqlParameter("@outros2", SqlDbType.VarChar)
  Private _paramEmailoutros2 As New SqlParameter("@emailoutros2", SqlDbType.VarChar)
  Private _paramOutros3 As New SqlParameter("@outros3", SqlDbType.VarChar)
  Private _paramEmailoutros3 As New SqlParameter("@emailoutros3", SqlDbType.VarChar)
  Private _paramOutros4 As New SqlParameter("@outros4", SqlDbType.VarChar)
  Private _paramEmailoutros4 As New SqlParameter("@emailoutros4", SqlDbType.VarChar)
  Private _paramEixo As New SqlParameter("@eixo", SqlDbType.VarChar)
  Private _paramArea As New SqlParameter("@area", SqlDbType.VarChar)
  Private _paramProcesso As New SqlParameter("@processo", SqlDbType.VarChar)
  Private _paramClassificacao As New SqlParameter("@classificacao", SqlDbType.VarChar)
  Private _paramComentario As New SqlParameter("@comentario", SqlDbType.VarChar)

  ' propriedades
  Private _id_trab As Integer
  Private _id_usu As Integer
  Private _nome As String
  Private _logon As String
  Private _instituicao As String
  Private _titulo As String
  Private _categoria As String
  Private _resumo As String
  Private _status As String
  Private _id_par As String
  Private _linkvideo As String
  Private _linkyoutube As String
  Private _linkarquivo As String
  Private _obs As String
  Private _total As Integer
  Private _outros1 As String
  Private _emailoutros1 As String
  Private _outros2 As String
  Private _emailoutros2 As String
  Private _outros3 As String
  Private _emailoutros3 As String
  Private _outros4 As String
  Private _emailoutros4 As String
  Private _eixo As String
  Private _area As String
  Private _processo As String
  Private _classificacao As String
  Private _comentario As String


#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id_trab As Integer) As Object

    Dim ret As New TrabalhosMostra
    Dim param As New SqlParameter("@id_trab", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_trab

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function ConsultarAutor(ByVal id_usu As Integer) As Object

    Dim ret As New TrabalhosMostra
    Dim param As New SqlParameter("@id_usu", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_usu

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_USU, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function ConsultarAutorCountComunicacao(ByVal id_usu As Integer) As Object

    Dim ret As New TrabalhosMostra
    Dim param As New SqlParameter("@id_usu", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_usu

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_USU_count, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function
  Public Shared Function ConsultarAutorCountvIDEO(ByVal id_usu As Integer) As Object

    Dim ret As New TrabalhosMostra
    Dim param As New SqlParameter("@id_usu", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_usu

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_USU_count_VIDEO, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function ListarTrabalhosIdTRab(ByVal id_trab As Integer) As Object

    Dim ret As New TrabalhosMostra
    Dim param As New SqlParameter("@id_trab", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_trab

    Dim sql As String
    sql = " id_trab = " + id_trab.ToString '+ " and d.status = 'PAGO'"
    '  Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(String.Format(C_GET_LIST_TRABALHOS, sql))


    '' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTrabalhos(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

  'Public Shared Function ListarTrabalhos(ByVal xid_usu As Integer) As IList

  '  'retorna lista
  '  Return ListaHelper.ListarRegistros(C_GET_LIST_TRABALHOS)

  'End Function

  Public Shared Function ListarTrabalhos(ByVal xid_usu As String) As IList
    Dim sql As String
    sql = " id_usu = " + xid_usu.ToString '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function

  Public Shared Function ListarTrabalhosId(ByVal xid_trab As String) As IList
    Dim sql As String
    sql = " id_trab = " + xid_trab.ToString '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function
  Public Shared Function ListarTrabalhosParecerista(ByVal xid_par As String) As IList
    Dim sql As String
    sql = " id_par = " + xid_par.ToString '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function

  Public Shared Function ListarTrabalhosPareceristaComunicacaoOral(ByVal xid_par As String) As IList
    Dim sql As String
    sql = " id_par = " + xid_par.ToString + " and status = 'ENVIADO' and categoria = 'COMUNICAÇÃO ORAL' " '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function
  Public Shared Function ListarTrabalhosPareceristaComunicacaoOralCOF() As IList
    Dim sql As String
    sql = "  status = 'APROVADO COF' and categoria = 'COMUNICAÇÃO ORAL' " '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function

  Public Shared Function ListarTrabalhosPareceristaVideo(ByVal xid_par As String) As IList
    Dim sql As String
    sql = " id_par = " + xid_par.ToString + " and status = 'ENVIADO' and categoria = 'VÍDEOS' " '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function

  Public Shared Function ListarTrabalhosPareceristaVideoCOF() As IList
    Dim sql As String
    sql = " status = 'APROVADO COF' and categoria = 'VÍDEOS' " '+ " and d.status = 'PAGO'"
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TRABALHOS, sql))

  End Function
#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    '_paramId_trab.Value = _id_trab
    _paramId_usu.Value = _id_usu
    _paramNome.Value = _nome
    _paramLogon.Value = _logon
    _paramInstituicao.Value = _instituicao
    _paramTitulo.Value = _titulo
    _paramCategoria.Value = _categoria
    _paramResumo.Value = _resumo
    _paramStatus.Value = _status
    _paramId_Par.Value = _id_par
    _paramLinkvideo.Value = _linkvideo
    _paramLinkyoutube.Value = _linkyoutube
    _paramLinkarquivo.Value = _linkarquivo
    _paramObs.Value = _obs
    _paramTotal.Value = _total
    _paramOutros1.Value = _outros1
    _paramEmailoutros1.Value = _emailoutros1
    _paramOutros2.Value = _outros2
    _paramEmailoutros2.Value = _emailoutros2
    _paramOutros3.Value = _outros3
    _paramEmailoutros3.Value = _emailoutros3
    _paramOutros4.Value = _outros4
    _paramEmailoutros4.Value = _emailoutros4
    _paramEixo.Value = _eixo
    _paramArea.Value = _area
    _paramProcesso.Value = _processo
    _paramClassificacao.Value = _classificacao
    _paramComentario.Value = _comentario


  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.id_trab = reader("id_trab")
    Me.id_usu = reader("id_usu")
    Me.Nome = reader("nome")
    Me.Logon = reader("logon")
    Me.Instituicao = reader("instituicao")
    Me.Titulo = reader("titulo")
    Me.Categoria = reader("categoria")
    Me.Resumo = reader("resumo")
    Me.Status = reader("status")
    Me.Id_Par = reader("id_par")
    Me.Linkvideo = reader("linkvideo")
    Me.Linkyoutube = reader("linkyoutube")
    Me.Linkarquivo = reader("linkarquivo")
    Me.Obs = reader("obs")
    Me.Outros1 = reader("outros1")
    Me.Emailoutros1 = reader("emailoutros1")
    Me.Outros2 = reader("outros2")
    Me.Emailoutros2 = reader("emailoutros2")
    Me.Outros3 = reader("outros3")
    Me.Emailoutros3 = reader("emailoutros3")
    Me.Outros4 = reader("outros4")
    Me.Emailoutros4 = reader("emailoutros4")
    Me.Eixo = reader("eixo")
    Me.Area = reader("area")
    Me.Processo = reader("processo")
    Me.Classificacao = reader("classificacao")
    Me.Comentario = reader("comentario")

  End Sub

  Public Sub PopularDadosTrabalhos(ByVal reader As IDataReader)

    '    'popula propriedades da tabela links (criador, atualizador etc.)
    '    MyBase.PopularDados(reader)

    'popular proiedades
    Me.id_trab = reader("id_trab")
    Me.id_usu = reader("id_usu")
    Me.Nome = reader("nome")
    Me.Logon = reader("logon")
    Me.Instituicao = reader("instituicao")
    Me.Titulo = reader("titulo")
    Me.Categoria = reader("categoria")
    Me.Resumo = reader("resumo")
    Me.Status = reader("status")
    Me.Id_Par = reader("id_par")
    Me.Linkvideo = reader("linkvideo")
    Me.Linkyoutube = reader("linkyoutube")
    Me.Linkarquivo = reader("linkarquivo")
    Me.Obs = reader("obs")
    Me.Outros1 = reader("outros1")
    Me.Emailoutros1 = reader("emailoutros1")
    Me.Outros2 = reader("outros2")
    Me.Emailoutros2 = reader("emailoutros2")
    Me.Outros3 = reader("outros3")
    Me.Emailoutros3 = reader("emailoutros3")
    Me.Outros4 = reader("outros4")
    Me.Emailoutros4 = reader("emailoutros4")
    Me.Eixo = reader("eixo")
    Me.Area = reader("area")
    Me.Processo = reader("processo")
    Me.Classificacao = reader("classificacao")
    Me.Comentario = reader("comentario")

  End Sub

  Public Sub PopularDadosTotal(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    '  MyBase.PopularDados(reader)

    ''popular proiedades
    'Me.id_trab = reader("id_trab")
    'Me.id_usu = reader("id_usu")
    'Me.Nome = reader("nome")
    'Me.Logon = reader("logon")
    'Me.Instituicao = reader("instituicao")
    'Me.Titulo = reader("titulo")
    'Me.Categoria = reader("categoria")
    'Me.Resumo = reader("resumo")
    'Me.Status = reader("status")
    'Me.Id_Par = reader("id_par")
    'Me.Linkvideo = reader("linkvideo")
    'Me.Linkyoutube = reader("linkyoutube")
    'Me.Linkarquivo = reader("linkarquivo")
    'Me.Obs = reader("obs")
    Me.total = reader("total")


  End Sub


  Public Sub Inserir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramId_usu, _paramNome, _paramLogon, _paramInstituicao, _paramTitulo, _paramCategoria, _paramResumo, _paramStatus, _paramId_Par, _paramLinkvideo, _paramLinkyoutube, _paramLinkarquivo, _paramObs, _paramOutros1, _paramEmailoutros1, _paramOutros2, _paramEmailoutros2, _paramOutros3, _paramEmailoutros3, _paramOutros4, _paramEmailoutros4, _paramEixo, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId_trab, _paramId_usu, _paramNome, _paramLogon, _paramInstituicao, _paramTitulo, _paramCategoria, _paramResumo, _paramStatus, _paramId_Par, _paramLinkvideo, _paramLinkyoutube, _paramLinkarquivo, _paramObs, _paramOutros1, _paramEmailoutros1, _paramOutros2, _paramEmailoutros2, _paramOutros3, _paramEmailoutros3, _paramOutros4, _paramEmailoutros4, _paramEixo, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub
  Public Sub AlterarAprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_APROVADO, _paramId_trab, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub

  Public Sub AlterarAprovadoCOFAprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_APROVADO_COF_ALTERAR, _paramId_trab, _paramComentario)

  End Sub

  Public Sub AlterarReprovadoCOFAprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_REPROVADO_COF_ALTERAR, _paramId_trab, _paramComentario)

  End Sub


  Public Sub AlterarAprovadoCOF()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_APROVADO_COF, _paramId_trab, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub

  Public Sub AlterarReprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_REPROVADO, _paramId_trab, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub

  Public Sub AlterarReprovadoCof()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_REPROVADO_COF, _paramId_trab, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub



  Public Sub Excluir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "excluir")

    ' prepara parametro
    _paramId_trab.Value = Me._id_trab

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId_trab)

  End Sub

#End Region

#Region "Public Properties"

  Public Property id_trab() As Integer
    Get
      Return _id_trab
    End Get
    Set(ByVal Value As Integer)
      _id_trab = Value
    End Set
  End Property
  Public Property id_usu() As Integer
    Get
      Return _id_usu
    End Get
    Set(ByVal Value As Integer)
      _id_usu = Value
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

  Public Property Logon() As String
    Get
      Return _logon
    End Get
    Set(ByVal Value As String)
      _logon = Value
    End Set
  End Property

  Public Property Instituicao() As String
    Get
      Return _instituicao
    End Get
    Set(ByVal Value As String)
      _instituicao = Value
    End Set
  End Property

  Public Property Titulo() As String
    Get
      Return _titulo

    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property
  Public Property Eixo() As String
    Get
      Return _eixo

    End Get
    Set(ByVal Value As String)
      _eixo = Value
    End Set
  End Property
  Public Property Categoria() As String
    Get
      Return _categoria

    End Get
    Set(ByVal Value As String)
      _categoria = Value
    End Set
  End Property
  Public Property Resumo() As String
    Get
      Return _resumo
    End Get
    Set(ByVal Value As String)
      _resumo = Value
    End Set
  End Property
  Public Property Status() As String
    Get
      Return _status
    End Get
    Set(ByVal Value As String)
      _status = Value
    End Set
  End Property
  Public Property Id_Par() As Integer
    Get
      Return _id_par
    End Get
    Set(ByVal Value As Integer)
      _id_par = Value
    End Set
  End Property
  Public Property Linkvideo() As String
    Get
      Return _linkvideo
    End Get
    Set(ByVal Value As String)
      _linkvideo = Value
    End Set
  End Property
  Public Property Linkyoutube() As String
    Get
      Return _linkyoutube
    End Get
    Set(ByVal Value As String)
      _linkyoutube = Value
    End Set
  End Property
  Public Property Linkarquivo() As String
    Get
      Return _linkarquivo
    End Get
    Set(ByVal Value As String)
      _linkarquivo = Value
    End Set
  End Property
  Public Property Obs() As String
    Get
      Return _obs
    End Get
    Set(ByVal Value As String)
      _obs = Value
    End Set
  End Property
  Public Property Outros1() As String
    Get
      Return _outros1
    End Get
    Set(ByVal Value As String)
      _outros1 = Value
    End Set
  End Property
  Public Property Emailoutros1() As String
    Get
      Return _emailoutros1
    End Get
    Set(ByVal Value As String)
      _emailoutros1 = Value
    End Set
  End Property
  Public Property Outros2() As String
    Get
      Return _outros2
    End Get
    Set(ByVal Value As String)
      _outros2 = Value
    End Set
  End Property
  Public Property Emailoutros2() As String
    Get
      Return _emailoutros2
    End Get
    Set(ByVal Value As String)
      _emailoutros2 = Value
    End Set
  End Property
  Public Property Outros3() As String
    Get
      Return _outros3
    End Get
    Set(ByVal Value As String)
      _outros3 = Value
    End Set
  End Property
  Public Property Emailoutros3() As String
    Get
      Return _emailoutros3
    End Get
    Set(ByVal Value As String)
      _emailoutros3 = Value
    End Set
  End Property
  Public Property Outros4() As String
    Get
      Return _outros4
    End Get
    Set(ByVal Value As String)
      _outros4 = Value
    End Set
  End Property
  Public Property Emailoutros4() As String
    Get
      Return _emailoutros4
    End Get
    Set(ByVal Value As String)
      _emailoutros4 = Value
    End Set
  End Property
  Public Property total() As Integer
    Get
      Return _total
    End Get
    Set(ByVal Value As Integer)
      _total = Value
    End Set
  End Property

  Public Property Area() As String
    Get
      Return _area
    End Get
    Set(ByVal Value As String)
      _area = Value
    End Set
  End Property

  Public Property Processo() As String
    Get
      Return _processo
    End Get
    Set(ByVal Value As String)
      _processo = Value
    End Set
  End Property

  Public Property Classificacao() As String
    Get
      Return _classificacao
    End Get
    Set(ByVal Value As String)
      _classificacao = Value
    End Set
  End Property

  Public Property Comentario() As String
    Get
      Return _comentario
    End Get
    Set(ByVal Value As String)
      _comentario = Value
    End Set
  End Property

 

#End Region

End Class
