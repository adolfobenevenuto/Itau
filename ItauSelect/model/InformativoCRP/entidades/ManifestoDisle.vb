Public Class ManifestoDisle
    Inherits BaseEntidade

#Region "Member Variables"

    ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', upper(nome) as 'Nome', upper(email) as 'email', upper(instituicao) as 'instituicao', upper(rg) as 'Rg', upper(cidade) as 'Cidade', upper(estado) as 'Estado', upper(pais) as 'Pais', coment as 'Coment' from tbl_manifesto_medicalizacao where Excluido = 0 order by id desc"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_manifesto_medicalizacao where id = @id"
  Private Shared ReadOnly C_GET_DATA_NOME_EMAIL As String = "select * from tbl_manifesto_medicalizacao where nome = @nome and email = @email"
  Private Shared ReadOnly C_GET_DATA_NOME As String = "select * from tbl_manifesto_medicalizacao where nome = @nome"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_manifesto_medicalizacao (nome, email, instituicao, rg, cidade, estado, pais, coment, excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
                                               "values(@nome, @email, @instituicao, @rg, @cidade, @estado, @pais, @coment, 0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_manifesto_medicalizacao where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_manifesto_medicalizacao set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_manifesto_medicalizacao set nome = @nome, email = @email, instituicao = @instituicao, rg = @rg, cidade = @cidade, estado = @estado, pais = @pais, coment = @coment, dt_atualizacao = getdate() where id = @id"

    ' parametros
    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
    Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
    Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
    Private _paramInstituicao As New SqlParameter("@instituicao", SqlDbType.VarChar)
    Private _paramRg As New SqlParameter("@rg", SqlDbType.VarChar)
    Private _paramCidade As New SqlParameter("@cidade", SqlDbType.VarChar)
    Private _paramEstado As New SqlParameter("@estado", SqlDbType.VarChar)
    Private _paramPais As New SqlParameter("@pais", SqlDbType.VarChar)
    Private _paramComent As New SqlParameter("@coment", SqlDbType.Text)


    ' propriedades
    Private _id As Integer
    Private _nome As String
    Private _email As String
    Private _instituicao As String
    Private _rg As String
    Private _cidade As String
    Private _estado As String
    Private _pais As String
    Private _coment As String


#End Region

#Region "Static Methods"

    Public Shared Function Consultar(ByVal id As Integer) As Object

        Dim ret As New ManifestoDisle
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
        Throw New Exception("Manifesto não encotrado.")

    End Function

    Public Shared Function ConsultarNomeEmail(ByVal nome As String, ByVal email As String) As Object

        Dim ret As New ManifestoDisle
        Dim paramXnome As New SqlParameter("@nome", SqlDbType.VarChar)
        Dim paramXemail As New SqlParameter("@email", SqlDbType.VarChar)

        ' prepara parametro
        paramXnome.Value = nome
        paramXemail.Value = email

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_NOME_EMAIL, paramXnome, paramXemail)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ' retorna novo objeto
            Throw New Exception("Manifesto não encotrado.")
            '    ret.PopularDados(reader)
            '   Return ret

        End If

        ' retorna novo objeto
        'Throw New Exception("Manifesto não encotrado.")

    End Function

    Public Shared Function ConsultarNome(ByVal nome As String) As Object

        Dim ret As New ManifestoDisle
        Dim paramXnome As New SqlParameter("@nome", SqlDbType.VarChar)

        ' prepara parametro
        paramXnome.Value = nome

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_NOME, paramXnome)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ' retorna novo objeto
            Throw New Exception("Manifesto não encotrado.")
            '    ret.PopularDados(reader)
            '   Return ret

        End If

        ' retorna novo objeto
        'Throw New Exception("Manifesto não encotrado.")

    End Function

    Public Shared Function Listar() As IList

        'retorna lista
        Return ListaHelper.ListarRegistros(C_GET_LIST)

    End Function




#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramNome.Value = _nome
    _paramEmail.Value = _email
    _paramInstituicao.Value = _instituicao
    _paramRg.Value = _rg
    _paramCidade.Value = _cidade
    _paramEstado.Value = _estado
    _paramPais.Value = _pais
    _paramComent.Value = _coment


  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Nome = reader("nome")
    Me.Email = reader("email")
    Me.Instituicao = reader("instituicao")
    Me.Rg = reader("rg")
    Me.Cidade = reader("cidade")
    Me.Estado = reader("estado")
    Me.Pais = reader("pais")
    Me.coment = reader("coment")


  End Sub


  Public Sub Inserir()

    'Chamada para verificacao de perfil
    '       PermissaoGlobal.VerificarPermissao("link", "inserir")


    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramId, _paramNome, _paramEmail, _paramInstituicao, _paramRg, _paramCidade, _paramEstado, _paramPais, _paramComent)

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
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramEmail, _paramInstituicao, _paramRg, _paramCidade, _paramEstado, _paramPais, _paramComent)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    '       PermissaoGlobal.VerificarPermissao("link", "excluir")

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

  Public Property Email() As String
    Get
      Return _email
    End Get
    Set(ByVal Value As String)
      _email = Value
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
  Public Property Rg() As String
    Get
      Return _rg
    End Get
    Set(ByVal Value As String)
      _rg = Value
    End Set
  End Property
  Public Property Cidade() As String
    Get
      Return _cidade
    End Get
    Set(ByVal Value As String)
      _cidade = Value
    End Set
  End Property
  Public Property Estado() As String
    Get
      Return _estado
    End Get
    Set(ByVal Value As String)
      _estado = Value
    End Set
  End Property

  Public Property Pais() As String
    Get
      Return _pais
    End Get
    Set(ByVal Value As String)
      _pais = Value
    End Set
  End Property

  Public Property coment() As String
    Get
      Return _coment
    End Get
    Set(ByVal Value As String)
      _coment = Value
    End Set
  End Property

#End Region

End Class
