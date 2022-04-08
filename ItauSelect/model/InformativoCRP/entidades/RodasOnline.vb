
Public Class RodasOnline
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', nome as 'Nome', cpf, profissao, email, celular, roda1, roda2, roda3, roda4, roda5, libras from tbl_eventos_rodas_mostra where Excluido = 0 order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_eventos_rodas_mostra where id = @id"
  Private Shared ReadOnly C_GET_DATA_CPF_LOGON As String = "select * from tbl_eventos_rodas_mostra where cpf = @cpf or email = @email order by id desc"
  Private Shared ReadOnly C_GET_DATA_COUNT_RODA1 As String = "select count(*) as 'total' from tbl_eventos_rodas_mostra where roda1 = @roda1"
  Private Shared ReadOnly C_GET_DATA_COUNT_RODA2 As String = "select count(*) as 'total' from tbl_eventos_rodas_mostra where roda2 = @roda2"
  Private Shared ReadOnly C_GET_DATA_COUNT_RODA3 As String = "select count(*) as 'total' from tbl_eventos_rodas_mostra where roda3 = @roda3"
  Private Shared ReadOnly C_GET_DATA_COUNT_RODA4 As String = "select count(*) as 'total' from tbl_eventos_rodas_mostra where roda4 = @roda4"
  Private Shared ReadOnly C_GET_DATA_COUNT_RODA5 As String = "select count(*) as 'total' from tbl_eventos_rodas_mostra where roda5 = @roda5"

  Private Shared ReadOnly C_INSERT As String = "insert into tbl_eventos_rodas_mostra (nome,cpf, profissao, email, celular, roda1, roda2, roda3, roda4, roda5, libras,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@nome,@cpf, @profissao, @email, @celular, @roda1, @roda2, @roda3, @roda4, @roda5, @libras,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_eventos_rodas_mostra where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_eventos_rodas_mostra set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_eventos_rodas_mostra set nome = @nome, cpf = @cpf, profissao = @profissao, email = @email, celular = @celular, roda1 = @roda1, roda2 = @roda2, roda3 = @roda3, roda4 = @roda4, roda5 = @roda5, libras = @libras where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramCpf As New SqlParameter("@cpf", SqlDbType.VarChar)
  Private _paramProfissao As New SqlParameter("@profissao", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramCelular As New SqlParameter("@celular", SqlDbType.VarChar)
  Private _paramRoda1 As New SqlParameter("@roda1", SqlDbType.VarChar)
  Private _paramRoda2 As New SqlParameter("@roda2", SqlDbType.VarChar)
  Private _paramRoda3 As New SqlParameter("@roda3", SqlDbType.VarChar)
  Private _paramRoda4 As New SqlParameter("@roda4", SqlDbType.VarChar)
  Private _paramRoda5 As New SqlParameter("@roda5", SqlDbType.VarChar)
  Private _paramLibras As New SqlParameter("@libras", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _nome As String
  Private _cpf As String
  Private _profissao As String
  Private _email As String
  Private _celular As String
  Private _roda1 As String
  Private _roda2 As String
  Private _roda3 As String
  Private _roda4 As String
  Private _roda5 As String
  Private _libras As String
  Private _total As Integer


#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New RodasOnline
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

 

  Public Shared Function ConsultarCPFCadastrado(ByVal cpf As String, ByVal email As String) As Object

    Dim ret As New RodasOnline
    Dim paramCpf As New SqlParameter("@cpf", SqlDbType.VarChar)
    Dim paramEmail As New SqlParameter("@email", SqlDbType.VarChar)

    paramCpf.Value = cpf
    paramEmail.Value = Email


    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF_LOGON, paramCpf, paramEmail)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      Throw New Exception("CPF encotrado.")
      'ret.PopularDados(reader)
      'Return ret

    End If

  End Function

  Public Shared Function ConsultarRoda1(ByVal roda1 As String) As Object

    Dim ret As New RodasOnline
    Dim param As New SqlParameter("@roda1", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = roda1

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_COUNT_RODA1, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function
  Public Shared Function ConsultarRoda2(ByVal roda2 As String) As Object

    Dim ret As New RodasOnline
    Dim param As New SqlParameter("@roda2", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = roda2

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_COUNT_RODA2, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function ConsultarRoda3(ByVal roda3 As String) As Object

    Dim ret As New RodasOnline
    Dim param As New SqlParameter("@roda3", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = roda3

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_COUNT_RODA3, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function ConsultarRoda4(ByVal roda4 As String) As Object

    Dim ret As New RodasOnline
    Dim param As New SqlParameter("@roda4", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = roda4

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_COUNT_RODA4, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function ConsultarRoda5(ByVal roda5 As String) As Object

    Dim ret As New RodasOnline
    Dim param As New SqlParameter("@roda5", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = roda5

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_COUNT_RODA5, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    End If

    ' ' retorna novo objeto
    '  Throw New Exception("Trabalho não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramNome.Value = _nome
    _paramCpf.Value = _cpf
    _paramEmail.Value = _email
    _paramProfissao.Value = _profissao
    _paramCelular.Value = _celular
    _paramRoda1.Value = _roda1
    _paramRoda2.Value = _roda2
    _paramRoda3.Value = _roda3
    _paramRoda4.Value = _roda4
    _paramRoda5.Value = _roda5
    _paramLibras.Value = _libras

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Nome = reader("nome")
    Me.Cpf = reader("cpf")
    Me.Email = reader("email")
    Me.Profissao = reader("profissao")
    Me.Celular = reader("celular")
    Me.Roda1 = reader("roda1")
    Me.Roda2 = reader("roda2")
    Me.Roda3 = reader("roda3")
    Me.Roda4 = reader("roda4")
    Me.Roda5 = reader("roda5")
    Me.Libras = reader("libras")

  End Sub


  Public Sub PopularDadosTotal(ByVal reader As IDataReader)

    '  'popula propriedades da tabela links (criador, atualizador etc.)
    '  MyBase.PopularDados(reader)

    ''popular proiedades
    'Me.Id = reader("id")
    'Me.Nome = reader("nome")
    'Me.Cpf = reader("cpf")
    'Me.Email = reader("email")
    'Me.Profissao = reader("profissao")
    'Me.Celular = reader("celular")
    'Me.Roda1 = reader("roda1")
    'Me.Roda2 = reader("roda2")
    'Me.Roda3 = reader("roda3")
    'Me.Roda4 = reader("roda4")
    'Me.Roda5 = reader("roda5")
    'Me.Libras = reader("libras")
    Me.Total = reader("total")

  End Sub

  Public Sub Inserir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("RodasOnline", "inserir")


    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramCpf, _paramEmail, _paramProfissao, _paramCelular, _paramRoda1, _paramRoda2, _paramRoda3, _paramRoda4, _paramRoda5, _paramLibras)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("RodasOnline", "alterar")


    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramCpf, _paramEmail, _paramProfissao, _paramCelular, _paramRoda1, _paramRoda2, _paramRoda3, _paramRoda4, _paramRoda5, _paramLibras)

  End Sub

  Public Sub Excluir()

    ''Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("RodasOnline", "excluir")

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

  Public Property Cpf() As String
    Get
      Return _cpf
    End Get
    Set(ByVal Value As String)
      _cpf = Value
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

  Public Property Profissao() As String
    Get
      Return _profissao
    End Get
    Set(ByVal Value As String)
      _profissao = Value
    End Set
  End Property

  Public Property Celular() As String
    Get
      Return _celular
    End Get
    Set(ByVal Value As String)
      _celular = Value
    End Set
  End Property

  Public Property Roda1() As String
    Get
      Return _roda1
    End Get
    Set(ByVal Value As String)
      _roda1 = Value
    End Set
  End Property
  Public Property Roda2() As String
    Get
      Return _roda2
    End Get
    Set(ByVal Value As String)
      _roda2 = Value
    End Set
  End Property
  Public Property Roda3() As String
    Get
      Return _roda3
    End Get
    Set(ByVal Value As String)
      _roda3 = Value
    End Set
  End Property
  Public Property Roda4() As String
    Get
      Return _roda4
    End Get
    Set(ByVal Value As String)
      _roda4 = Value
    End Set
  End Property
  Public Property Roda5() As String
    Get
      Return _roda5
    End Get
    Set(ByVal Value As String)
      _roda5 = Value
    End Set
  End Property

  Public Property Libras() As String
    Get
      Return _libras
    End Get
    Set(ByVal Value As String)
      _libras = Value
    End Set
  End Property

  Public Property Total() As Integer
    Get
      Return _total
    End Get
    Set(ByVal Value As Integer)
      _total = Value
    End Set
  End Property


#End Region

End Class
