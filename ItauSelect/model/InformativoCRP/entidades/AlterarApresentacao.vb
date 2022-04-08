Public Class AlterarApresentacao
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_com as 'Id', id_usu as 'IdUsu', nome as 'Nome', tipo as 'Tipo', sigla as 'Sigla', areas as 'Areas', apresentacao as 'Apresentacao', titulo_apresentacao as 'TituloApresentacao', titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros' from tbl_comissao where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_comissao where id_com = @id_com"
  Private Shared ReadOnly C_INSERT As String = " "
  Private Shared ReadOnly C_DELETE As String = "update tbl_comissao set excluido = 1 where id_com = @id_com"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_comissao set nome = @nome, sigla = @sigla, apresentacao = @apresentacao, titulo_apresentacao = @titulo_apresentacao, titulo_coordenador =  @titulo_coordenador, titulo_membros = @titulo_membros where id_com = @id_com"

  ' parametros
  Private _paramId As New SqlParameter("@id_com", SqlDbType.Int)
  Private _paramIdUsu As New SqlParameter("id_usu", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramTipo As New SqlParameter("@tipo", SqlDbType.Int)
  Private _paramSigla As New SqlParameter("@sigla", SqlDbType.VarChar)
  Private _paramApresentacao As New SqlParameter("@apresentacao", SqlDbType.VarChar)
  Private _paramTituloApresentacao As New SqlParameter("@titulo_apresentacao", SqlDbType.VarChar)
  Private _paramTituloCoordenador As New SqlParameter("@titulo_coordenador", SqlDbType.VarChar)
  Private _paramTituloMembros As New SqlParameter("@titulo_coordenador", SqlDbType.VarChar)

  ' propriedades
  Private _id_com As Integer
  Private _id_usu As Integer
  Private _nome As String
  Private _tipo As Integer
  Private _sigla As String
  Private _apresentacao As String
  Private _titulo_apresentacao As String
  Private _titulo_coordenador As String
  Private _titulo_membros As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id_com As Integer) As Object

    Dim ret As New AlterarApresentacao
    Dim param As New SqlParameter("@id_com", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_com

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Comissão não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramIdUsu.Value = _id_com
    _paramNome.Value = _nome
    _paramTipo.Value = _tipo
    _paramSigla.Value = _sigla
    _paramApresentacao.Value = _apresentacao
    _paramTituloApresentacao.Value = _titulo_apresentacao
    _paramTituloCoordenador.Value = _titulo_coordenador
    _paramTituloMembros.Value = _titulo_membros

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.id_com = reader("id_com")
    Me.Nome = reader("nome")
    Me.Tipo = reader("tipo")
    Me.Sigla = reader("sigla")
    Me.Apresentacao = reader("apresentacao")
    Me.TituloApresentacao = reader("titulo_apresentacao")
    Me.TituloCoordenador = reader("titulo_coordenador")
    Me.TituloMembros = reader("titulo_membros")

  End Sub


  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("AlterarApresentacao", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramTipo, _paramSigla, _paramApresentacao, _paramTituloApresentacao, _paramTituloCoordenador, _paramTituloMembros)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("AlterarApresentacao", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id_com
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramTipo, _paramSigla, _paramApresentacao, _paramTituloApresentacao, _paramTituloCoordenador, _paramTituloMembros)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("AlterarApresentacao", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id_com

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property id_com() As Integer
    Get
      Return _id_com
    End Get
    Set(ByVal Value As Integer)
      _id_com = Value
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

  Public Property Tipo() As Integer
    Get
      Return _tipo
    End Get
    Set(ByVal Value As Integer)
      _tipo = Value
    End Set
  End Property

  Public Property Sigla() As String
    Get
      Return _sigla
    End Get
    Set(ByVal Value As String)
      _sigla = Value
    End Set
  End Property

  Public Property Apresentacao() As String
    Get
      Return _apresentacao
    End Get
    Set(ByVal Value As String)
      _apresentacao = Value
    End Set
  End Property

  Public Property TituloApresentacao() As String
    Get
      Return _titulo_apresentacao
    End Get
    Set(ByVal Value As String)
      _titulo_apresentacao = Value
    End Set
  End Property

  Public Property TituloCoordenador() As String
    Get
      Return _titulo_coordenador
    End Get
    Set(ByVal Value As String)
      _titulo_coordenador = Value
    End Set
  End Property

  Public Property TituloMembros() As String
    Get
      Return _titulo_membros
    End Get
    Set(ByVal Value As String)
      _titulo_membros = Value
    End Set
  End Property

#End Region

End Class
