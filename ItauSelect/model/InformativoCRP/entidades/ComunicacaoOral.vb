Public Class ComunicacaoOral
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'id', id_usu as 'Id_usu', autor as 'Autor', titulo as 'Titulo', natureza as 'Natureza', financiador as 'Financiador', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status', tipo_insc as 'Tipo_Insc' from tbl_comunicacao_encontro where Excluido = 0 order by titulo"
  Private Shared ReadOnly C_GET_LIST_EM_AVALIACAO As String = "select id as 'id', id_usu as 'Id_usu', autor as 'Autor', titulo as 'Titulo', natureza as 'Natureza', financiador as 'Financiador', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status', tipo_insc as 'Tipo_Insc' from tbl_comunicacao_encontro where Excluido = 0 and status = 'Em avaliação' order by titulo"
  Private Shared ReadOnly C_GET_LIST_USUARIO As String = "select id as 'id', id_usu as 'Id_usu', autor as 'Autor', titulo as 'Titulo', natureza as 'Natureza', financiador as 'Financiador', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status', tipo_insc as 'Tipo_Insc' from tbl_comunicacao_encontro where id_usu = {0} and Excluido = 0 order by titulo"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_comunicacao_encontro where id = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_comunicacao_encontro (id_usu, autor, titulo, natureza, financiador, resumo, outros_autores, palavra, status,tipo_insc,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@id_usu, @autor, @titulo, @natureza, @financiador, @resumo, @outros_autores, @palavra, @status,@tipo_insc,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_comunicacao_encontro where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_comunicacao_encontro set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_comunicacao_encontro set id_usu = @id_usu, autor = @autor, titulo = @titulo, natureza = @natureza, financiador = @financiador, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = @status, tipo_insc = @tipo_insc where id = @id"
  Private Shared ReadOnly C_UPDATE_APROVADO As String = "update tbl_comunicacao_encontro set id_usu = @id_usu, autor = @autor, titulo = @titulo, natureza = @natureza, financiador = @financiador, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = 'Aprovado' where id = @id"
  Private Shared ReadOnly C_UPDATE_REPROVADO As String = "update tbl_comunicacao_encontro set id_usu = @id_usu, autor = @autor, titulo = @titulo, natureza = @natureza, financiador = @financiador, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = 'Reprovado' where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramid_usu As New SqlParameter("@id_usu", SqlDbType.Int)
  Private _paramautor As New SqlParameter("@autor", SqlDbType.VarChar)
  Private _paramtitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramnatureza As New SqlParameter("@natureza", SqlDbType.VarChar)
  Private _paramfinanciador As New SqlParameter("@financiador", SqlDbType.VarChar)
  Private _paramresumo As New SqlParameter("@resumo", SqlDbType.VarChar)
  Private _paramoutros_autores As New SqlParameter("@outros_autores", SqlDbType.VarChar)
  Private _parampalavra As New SqlParameter("@palavra", SqlDbType.VarChar)
  Private _paramstatus As New SqlParameter("@status", SqlDbType.VarChar)
  Private _paramtipo_insc As New SqlParameter("@tipo_insc", SqlDbType.VarChar)


  ' propriedades
  Private _id As Integer
  Private _id_usu As Integer
  Private _autor As String
  Private _titulo As String
  Private _natureza As String
  Private _financiador As String
  Private _resumo As String
  Private _outros_autores As String
  Private _palavra As String
  Private _status As String
  Private _tipo_insc As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New ComunicacaoOral
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
    Throw New Exception("Poster não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

  Public Shared Function ListarEmAvaliacao() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_EM_AVALIACAO)

  End Function

  Public Shared Function ListarComunicacaoOralUsuario(ByVal id_usu As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_USUARIO, id_usu))

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramid_usu.Value = _id_usu
    _paramautor.Value = _autor
    _paramtitulo.Value = _titulo
    _paramnatureza.Value = _natureza
    _paramfinanciador.Value = _financiador
    _paramresumo.Value = _resumo
    _paramoutros_autores.Value = _outros_autores
    _parampalavra.Value = _palavra
    _paramstatus.Value = _status
    _paramtipo_insc.Value = _tipo_insc

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.id_usu = reader("id_usu")
    Me.autor = reader("autor")
    Me.titulo = reader("titulo")
    Me.natureza = reader("natureza")
    Me.financiador = reader("financiador")
    Me.resumo = reader("resumo")
    Me.outros_autores = reader("outros_autores")
    Me.palavra = reader("palavra")
    Me.status = reader("status")
    Me.tipo_insc = reader("tipo_insc")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    '  PermissaoGlobal.VerificarPermissao("link", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramid_usu, _paramautor, _paramtitulo, _paramnatureza, _paramfinanciador, _paramresumo, _paramoutros_autores, _parampalavra, _paramstatus, _paramtipo_insc)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramid_usu, _paramautor, _paramtitulo, _paramnatureza, _paramfinanciador, _paramresumo, _paramoutros_autores, _parampalavra, _paramstatus, _paramtipo_insc)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("link", "excluir")

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

  Public Property id_usu() As Integer
    Get
      Return _id_usu
    End Get
    Set(ByVal Value As Integer)
      _id_usu = Value
    End Set
  End Property

  Public Property autor() As String
    Get
      Return _autor
    End Get
    Set(ByVal Value As String)
      _autor = Value
    End Set
  End Property

  Public Property titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property
  Public Property natureza() As String
    Get
      Return _natureza
    End Get
    Set(ByVal Value As String)
      _natureza = Value
    End Set
  End Property
  Public Property financiador() As String
    Get
      Return _financiador
    End Get
    Set(ByVal Value As String)
      _financiador = Value
    End Set
  End Property

  Public Property resumo() As String
    Get
      Return _resumo
    End Get
    Set(ByVal Value As String)
      _resumo = Value
    End Set
  End Property

  Public Property outros_autores() As String
    Get
      Return _outros_autores
    End Get
    Set(ByVal Value As String)
      _outros_autores = Value
    End Set
  End Property
  Public Property palavra() As String
    Get
      Return _palavra
    End Get
    Set(ByVal Value As String)
      _palavra = Value
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

  Public Property tipo_insc() As String
    Get
      Return _tipo_insc
    End Get
    Set(ByVal Value As String)
      _tipo_insc = Value
    End Set
  End Property
#End Region

End Class
