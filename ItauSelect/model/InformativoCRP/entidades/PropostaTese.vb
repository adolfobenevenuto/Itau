
Public Class PropostaTese
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_trab AS 'Id_Trab', id_usu AS 'Id_Usu', evento as Evento, regiao as Regiao, eixo as Eixo, ambito as Ambito, palavra1 as Palavra1, palavra2 as Palavra2, palavra3 as Palavra3, proposta as Proposta, status as Status from tbl_eventos_trabalhos_cnp_2022 where Excluido = 0 order by evento"
  Private Shared ReadOnly C_GET_LIST_TRABALHOS As String = "select id_trab AS 'Id_Trab', id_usu AS 'Id_Usu', , evento as Evento, regiao as Regiao, eixo as Eixo, ambito as Ambito, palavra1 as Palavra1, palavra2 as Palavra2, palavra3 as Palavra3, proposta as Proposta, status as Status from tbl_eventos_trabalhos_cnp_2022 where {0} and Excluido = 0 "


  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_eventos_trabalhos_cnp_2022 where id_trab = @id_trab"
  Private Shared ReadOnly C_GET_DATA_USU As String = "select * from tbl_eventos_trabalhos_cnp_2022 where id_usu = @id_usu"
  Private Shared ReadOnly C_GET_DATA_USU_count As String = "select count(*) as 'total' from tbl_eventos_trabalhos_cnp_2022 where id_usu = @id_usu and status = 'COMUNICAÇÃO ORAL'"
  Private Shared ReadOnly C_GET_DATA_USU_count_VIDEO As String = "select count(*) as 'total' from tbl_eventos_trabalhos_cnp_2022 where id_usu = @id_usu and status = 'VÍDEOS'"

  Private Shared ReadOnly C_INSERT As String = "insert into tbl_eventos_trabalhos_cnp_2022 ( id_usu, evento, regiao, eixo, ambito, palavra1, palavra2, palavra3, proposta, status, excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(  @id_usu, @evento, @regiao, @eixo, @ambito, @palavra1, @palavra2, @palavra3, @proposta, @status,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_eventos_trabalhos_cnp_2022 where id_trab = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_eventos_trabalhos_cnp_2022 set excluido = 1 where id_trab = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_eventos_trabalhos_cnp_2022 set id_usu = @id_usu, evento = @evento, regiao = @regiao, eixo = @eixo, ambito = @ambito, palavra1 = @palavra1, palavra2 = @palavra2, palavra3 = @palavra3, proposta = @proposta, status = @status where id_trab = @id"

  Private Shared ReadOnly C_UPDATE_APROVADO As String = "update tbl_eventos_trabalhos_cnp_2022 set  status = 'APROVADO' where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_APROVADO_COF_ALTERAR As String = "update tbl_eventos_trabalhos_cnp_2022 set  status = 'AVAL COF',  where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_REPROVADO_COF_ALTERAR As String = "update tbl_eventos_trabalhos_cnp_2022 set  status = 'REPROV COF',  where id_trab = @id_trab"

  Private Shared ReadOnly C_UPDATE_APROVADO_COF As String = "update tbl_eventos_trabalhos_cnp_2022 set  status = 'APROVADO COF' where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_REPROVADO As String = "update tbl_eventos_trabalhos_cnp_2022 set  status = 'REPROVADO'  where id_trab = @id_trab"
  Private Shared ReadOnly C_UPDATE_REPROVADO_COF As String = "update tbl_eventos_trabalhos_cnp_2022 set  status = 'REPROVADO COF' where id_trab = @id_trab"

  ' parametros
  Private _paramId_trab As New SqlParameter("@id_trab", SqlDbType.Int)
  Private _paramId_usu As New SqlParameter("@id_usu", SqlDbType.Int)
  Private _paramEvento As New SqlParameter("@evento", SqlDbType.VarChar)
  Private _paramRegiao As New SqlParameter("@regiao", SqlDbType.VarChar)
  Private _paramEixo As New SqlParameter("@eixo", SqlDbType.VarChar)
  Private _paramAmbito As New SqlParameter("@ambito", SqlDbType.VarChar)
  Private _paramPalavra1 As New SqlParameter("@palavra1", SqlDbType.VarChar)
  Private _paramPalavra2 As New SqlParameter("@palavra2", SqlDbType.VarChar)
  Private _paramPalavra3 As New SqlParameter("@palavra3", SqlDbType.VarChar)
  Private _paramProposta As New SqlParameter("@proposta", SqlDbType.VarChar)
  Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)
  Private _paramTotal As New SqlParameter("@total", SqlDbType.Int)

  'Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)
  
  ' propriedades
  Private _id_trab As Integer
  Private _id_usu As Integer
  Private _evento As String
  Private _regiao As String
  Private _eixo As String
  Private _ambito As String
  Private _palavra1 As String
  Private _palavra2 As String
  Private _palavra3 As String
  Private _proposta As String
  Private _status As String
  Private _total As Integer
  


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
    _paramEvento.Value = _evento
    _paramRegiao.Value = _regiao
    _paramEixo.Value = _eixo
    _paramAmbito.Value = _ambito
    _paramPalavra1.Value = _palavra1
    _paramPalavra2.Value = _palavra2
    _paramPalavra3.Value = _palavra3
    _paramProposta.Value = _proposta
    _paramStatus.Value = _status


  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.id_trab = reader("id_trab")
    Me.id_usu = reader("id_usu")
    Me.Evento = reader("evento")
    Me.regiao = reader("regiao")
    Me.Eixo = reader("eixo")
    Me.ambito = reader("ambito")
    Me.palavra1 = reader("palavra1")
    Me.palavra2 = reader("palavra2")
    Me.palavra3 = reader("palavra3")
    Me.proposta = reader("proposta")
    Me.Status = reader("status")

  End Sub

  Public Sub PopularDadosTrabalhos(ByVal reader As IDataReader)

    '    'popula propriedades da tabela links (criador, atualizador etc.)
    '    MyBase.PopularDados(reader)

    'popular proiedades
    Me.id_trab = reader("id_trab")
    Me.id_usu = reader("id_usu")
    Me.Evento = reader("evento")
    Me.regiao = reader("regiao")
    Me.Eixo = reader("eixo")
    Me.ambito = reader("ambito")
    Me.palavra1 = reader("palavra1")
    Me.palavra2 = reader("palavra2")
    Me.palavra3 = reader("palavra3")
    Me.proposta = reader("proposta")
    Me.Status = reader("status")

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
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramId_usu, _paramEvento, _paramRegiao, _paramEixo, _paramAmbito, _paramPalavra1, _paramPalavra2, _paramPalavra3, _paramProposta, _paramStatus)

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
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId_trab, _paramId_usu, _paramEvento, _paramRegiao, _paramEixo, _paramAmbito, _paramPalavra1, _paramPalavra2, _paramPalavra3, _paramProposta, _paramStatus) ', _paramNome, _paramLogon, _paramInstituicao, _paramTitulo, _paramCategoria, _paramResumo, _paramStatus, _paramId_Par, _paramLinkvideo, _paramLinkyoutube, _paramLinkarquivo, _paramObs, _paramOutros1, _paramEmailoutros1, _paramOutros2, _paramEmailoutros2, _paramOutros3, _paramEmailoutros3, _paramOutros4, _paramEmailoutros4, _paramEixo, _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub
  Public Sub AlterarAprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_APROVADO, _paramId_trab, _paramId_usu, _paramEvento, _paramRegiao, _paramEixo, _paramAmbito, _paramPalavra1, _paramPalavra2, _paramPalavra3, _paramProposta, _paramStatus) ', _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub

  Public Sub AlterarAprovadoCOFAprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_APROVADO_COF_ALTERAR, _paramId_trab) ', _paramComentario)

  End Sub

  Public Sub AlterarReprovadoCOFAprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_REPROVADO_COF_ALTERAR, _paramId_trab) ', _paramComentario)

  End Sub


  Public Sub AlterarAprovadoCOF()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_APROVADO_COF, _paramId_trab) ', _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub

  Public Sub AlterarReprovado()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_REPROVADO, _paramId_trab) ', _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

  End Sub

  Public Sub AlterarReprovadoCof()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("TrabalhosMostra", "alterar")


    ' prepara parametros
    _paramId_trab.Value = Me._id_trab
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_REPROVADO_COF, _paramId_trab) ', _paramArea, _paramProcesso, _paramClassificacao, _paramComentario)

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

  Public Property evento() As String
    Get
      Return _evento
    End Get
    Set(ByVal Value As String)
      _evento = Value
    End Set
  End Property

  Public Property regiao() As String
    Get
      Return _regiao
    End Get
    Set(ByVal Value As String)
      _regiao = Value
    End Set
  End Property

  Public Property eixo() As String
    Get
      Return _eixo
    End Get
    Set(ByVal Value As String)
      _eixo = Value
    End Set
  End Property

  Public Property ambito() As String
    Get
      Return _ambito

    End Get
    Set(ByVal Value As String)
      _ambito = Value
    End Set
  End Property
  Public Property palavra1() As String
    Get
      Return _palavra1

    End Get
    Set(ByVal Value As String)
      _palavra1 = Value
    End Set
  End Property
  Public Property palavra2() As String
    Get
      Return _palavra2

    End Get
    Set(ByVal Value As String)
      _palavra2 = Value
    End Set
  End Property
  Public Property palavra3() As String
    Get
      Return _palavra3

    End Get
    Set(ByVal Value As String)
      _palavra3 = Value
    End Set
  End Property
  Public Property proposta() As String
    Get
      Return _proposta

    End Get
    Set(ByVal Value As String)
      _proposta = Value
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
 
  Public Property total() As Integer
    Get
      Return _total
    End Get
    Set(ByVal Value As Integer)
      _total = Value
    End Set
  End Property

  

#End Region

End Class
