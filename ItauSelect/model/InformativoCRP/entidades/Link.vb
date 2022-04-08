
Public Class Link
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_lnk as 'Id', nome as 'Nome', descricao as 'Descricao', link as 'Link' from tbl_link where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_link where id_lnk = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_link (nome,descricao,criador,dt_criacao,atualizador,dt_atualizacao,link,excluido) " + _
                                               "values(@nome,@descricao,1,getdate(),1,getdate(),@link,0);" + _
                                               "select * from tbl_link where id_lnk = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_link set excluido = 1 where id_lnk = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_link set nome = @nome, descricao = @descricao, link = @link where id_lnk = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramDescricao As New SqlParameter("@descricao", SqlDbType.VarChar)
  Private _paramLink As New SqlParameter("@link", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _nome As String
  Private _descricao As String
  Private _link As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Link
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
    Throw New Exception("Link não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramNome.Value = _nome
    _paramDescricao.Value = _descricao
    _paramLink.Value = _link

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id_lnk")
    Me.Nome = reader("nome")
    Me.Descricao = reader("descricao")
    Me.Link = reader("link")

  End Sub

  Public Function Valido() As Boolean

    'chama a funcao validar endereco site, com o parametro
    ValidadorWebSite.Valido(Me.Link)

  End Function

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("link", "inserir")

    ' valida link
    ValidadorWebSite.Validar(_link)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramDescricao, _paramLink)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' valida link
    ValidadorWebSite.Validar(_link)

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramDescricao, _paramLink)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("link", "excluir")

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

  Public Property Descricao() As String
    Get
      Return _descricao
    End Get
    Set(ByVal Value As String)
      _descricao = Value
    End Set
  End Property

  Public Property Link() As String
    Get
      Return _link
    End Get
    Set(ByVal Value As String)
      _link = Value
    End Set
  End Property

#End Region

End Class
