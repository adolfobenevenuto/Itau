Public Class Noticia
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', titulo as 'Titulo', chamada as 'Chamada', noticia as 'Noticia' from tbl_noticias where Excluido = 0 {0}"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_noticias where id = @id order by id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_noticias (titulo, chamada, noticia,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                             "values(@titulo,@chamada,@noticia,0,1,getdate(),1,getdate());" + _
                                             "select * from tbl_noticias where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_noticias set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_noticias set titulo = @titulo, chamada = @chamada, noticia = @noticia where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramChamada As New SqlParameter("@chamada", SqlDbType.VarChar)
  Private _paramNoticia As New SqlParameter("@noticia", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _titulo As String
  Private _chamada As String
  Private _noticia As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Noticia
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
    Throw New Exception("Noticia não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, ""))

  End Function

  Public Shared Function ListarNoticia(ByVal id As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, " and id=" + id.ToString))

  End Function


#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramTitulo.Value = _titulo
    _paramChamada.Value = _chamada
    _paramNoticia.Value = _noticia

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Titulo = reader("titulo")
    Me.Chamada = reader("chamada")
    Me.Noticia = reader("noticia")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("noticia", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramTitulo, _paramChamada, _paramNoticia)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("noticia", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramChamada, _paramNoticia)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("noticia", "excluir")

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

  Public Property Titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property

  Public Property Chamada() As String
    Get
      Return _chamada
    End Get
    Set(ByVal Value As String)
      _chamada = Value
    End Set
  End Property

  Public Property Noticia() As String
    Get
      Return _noticia
    End Get
    Set(ByVal Value As String)
      _noticia = Value
    End Set
  End Property

#End Region

End Class

