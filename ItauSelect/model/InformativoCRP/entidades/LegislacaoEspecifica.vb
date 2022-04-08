Public Class LegislacaoEspecifica
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', nome as 'Nome', enderecolink as 'EnderecoLink',descricao as 'Descricao' from tbl_legislacaoespecifica where Excluido = 0"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_legislacaoespecifica where id = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_legislacaoespecifica (nome, descricao, enderecolink,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@nome,@descricao,@enderecolink,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_legislacaoespecifica where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_legislacaoespecifica set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_legislacaoespecifica set nome = @nome, descricao = @descricao, enderecolink = @enderecolink where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramEnderecoLink As New SqlParameter("@enderecolink", SqlDbType.VarChar)
  Private _paramDescricao As New SqlParameter("@descricao", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _nome As String
  Private _enderecolink As String
  Private _descricao As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New LegislacaoEspecifica
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
    Throw New Exception("Legislacao Especifica não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramNome.Value = _nome
    _paramEnderecoLink.Value = _enderecolink
    _paramDescricao.Value = _descricao

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Nome = reader("nome")
    Me.EnderecoLink = reader("descricao")
    Me.Descricao = reader("enderecolink")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("legislacaoespecifica", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramDescricao, _paramEnderecoLink)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("legislacaoespecifica", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramDescricao, _paramEnderecoLink)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("legislacaoespecifica", "excluir")

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

  Public Property EnderecoLink() As String
    Get
      Return _enderecolink
    End Get
    Set(ByVal Value As String)
      _enderecolink = Value
    End Set
  End Property

#End Region

End Class
