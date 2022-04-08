Public Class _CriaUsuario
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_usu as 'Id', inscricao as 'Inscricao', cpf as 'CPF', nome as 'Nome', logon as 'Logon', senha as 'Senha', telefone as 'telefone', email as 'Email' from tbl_usuario_evento where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_usuario_evento where id_usu = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_link (inscricao,cpf,nome,logon,senha,telefone,email,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@inscricao,@cpf,@nome,@logon,@senha,@telefone,@email,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_usuario_evento where id_usu = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_usuario_evento set excluido = 1 where id_usu = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_usuario_evento set inscricao = @inscricao, cpf = @cpf, nome = @nome, logon = @logon, senha = @senha, telefone = @telefone, email = @email, dt_atualizacao = getdate() where id_usu = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramInscricao As New SqlParameter("@inscricao", SqlDbType.VarChar)
  Private _paramCpf As New SqlParameter("@cpf", SqlDbType.VarChar)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramLogon As New SqlParameter("@logon", SqlDbType.VarChar)
  Private _paramSenha As New SqlParameter("@senha", SqlDbType.VarChar)
  Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _inscricao As String
  Private _cpf As String
  Private _nome As String
  Private _logon As String
  Private _senha As String
  Private _telefone As String
  Private _email As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New CriaUsuario
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
    Throw New Exception("Usuário não encontrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramInscricao.Value = _inscricao
    _paramCpf.Value = _cpf
    _paramNome.Value = _nome
    _paramLogon.Value = _logon
    _paramSenha.Value = _senha
    _paramTelefone.Value = _telefone
    _paramEmail.Value = _email

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id_usu")
    Me.inscricao = reader("inscricao")
    Me.cpf = reader("cpf")
    Me.Nome = reader("nome")
    Me.logon = reader("Logon")
    Me.senha = reader("senha")
    Me.telefone = reader("telefone")
    Me.email = reader("email")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("CriaUsuario", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramInscricao, _paramCpf, _paramNome, _paramLogon, _paramSenha, _paramTelefone, _paramEmail)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("CriaUsuario", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramInscricao, _paramCpf, _paramNome, _paramLogon, _paramSenha, _paramTelefone, _paramEmail)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("CriaUsuario", "excluir")

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

  Public Property Inscricao() As String
    Get
      Return _inscricao
    End Get
    Set(ByVal Value As String)
      _inscricao = Value
    End Set
  End Property

  Public Property CPF() As String
    Get
      Return _cpf
    End Get
    Set(ByVal Value As String)
      _cpf = Value
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

  Public Property Senha() As String
    Get
      Return _senha
    End Get
    Set(ByVal Value As String)
      _senha = Value
    End Set
  End Property

  Public Property Telefone() As String
    Get
      Return _telefone
    End Get
    Set(ByVal Value As String)
      _telefone = Value
    End Set
  End Property

  Public Property email() As String
    Get
      Return _email
    End Get
    Set(ByVal Value As String)
      _email = Value
    End Set
  End Property

#End Region

End Class
