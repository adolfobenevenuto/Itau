Public Class Participante
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', cpf as 'Cpf', nome as 'Nome', nomecracha as 'nomecracha', email as 'email', residencial as 'residencial', comercial as 'comercial', celular as 'celular', logradouro as 'logradouro', numero as 'numero', complemento as 'complemento', bairro as 'bairro', cidade as 'cidade', estado as 'estado', cep as 'cep', titulacao as 'titulacao', local as 'local', qual as 'qual' from tbl_participante where Excluido = 0 order by nome"
  Protected Shared ReadOnly C_GET_LIST_TOTAL As String = " select * from tbl_participante where excluido = 0 order by id desc"


  Private Shared ReadOnly C_GET_LIST_PERFIL As String = "select id as 'Id', cpf as 'Cpf', nome as 'Nome', nomecracha as 'nomecracha', email as 'email', residencial as 'residencial', comercial as 'comercial', celular as 'celular', logradouro as 'logradouro', numero as 'numero', complemento as 'complemento', bairro as 'bairro', cidade as 'cidade', estado as 'estado', cep as 'cep', titulacao as 'titulacao', local as 'local', qual as 'qual' from tbl_participante where Excluido = 0 order by nome"

  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_participante where id = @id"
  Private Shared ReadOnly C_GET_DATA_CPF As String = "select * from tbl_participante where cpf = @cpf and Excluido = 0 "
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_participante (cpf, nome, nomecracha, email, residencial, comercial, celular, logradouro, numero, complemento, bairro, cidade, estado, cep, titulacao, local, qual,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@cpf, @nome, @nomecracha, @email, @residencial, @comercial, @celular, @logradouro, @numero, @complemento, @bairro, @cidade, @estado, @cep, @titulacao, @local, @qual,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_participante where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_participante set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_participante set cpf = @cpf, nome = @nome, nomecracha = @nomecracha, email = @email, residencial = @residencial, comercial = @comercial, celular = @celular, logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, titulacao = @titulacao, local = @local, qual = @qual where id = @id "

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramcpf As New SqlParameter("@cpf", SqlDbType.VarChar)
  Private _paramnome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramnomecracha As New SqlParameter("@nomecracha", SqlDbType.VarChar)
  Private _paramemail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramresidencial As New SqlParameter("@residencial", SqlDbType.VarChar)
  Private _paramcomercial As New SqlParameter("@comercial", SqlDbType.VarChar)
  Private _paramcelular As New SqlParameter("@celular", SqlDbType.VarChar)
  Private _paramlogradouro As New SqlParameter("@logradouro", SqlDbType.VarChar)
  Private _paramnumero As New SqlParameter("@numero", SqlDbType.VarChar)
  Private _paramcomplemento As New SqlParameter("@complemento", SqlDbType.VarChar)
  Private _parambairro As New SqlParameter("@bairro", SqlDbType.VarChar)
  Private _paramcidade As New SqlParameter("@cidade", SqlDbType.VarChar)
  Private _paramestado As New SqlParameter("@estado", SqlDbType.VarChar)
  Private _paramcep As New SqlParameter("@cep", SqlDbType.VarChar)
  Private _paramtitulacao As New SqlParameter("@titulacao", SqlDbType.VarChar)
  Private _paramlocal As New SqlParameter("@local", SqlDbType.VarChar)
  Private _paramqual As New SqlParameter("@qual", SqlDbType.VarChar)


  ' propriedades
  Private _id As Integer
  Private _cpf As String
  Private _nome As String
  Private _nomecracha As String
  Private _email As String
  Private _residencial As String
  Private _comercial As String
  Private _celular As String
  Private _logradouro As String
  Private _numero As String
  Private _complemento As String
  Private _bairro As String
  Private _cidade As String
  Private _estado As String
  Private _cep As String
  Private _titulacao As String
  Private _local As String
  Private _qual As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Participante
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
    Throw New Exception("Participante não encotrado.")

  End Function

  Public Shared Function ConsultarTotal() As Object

    Dim ret As New Participante

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_LIST_TOTAL)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Participante não encotrado.")

  End Function
  Public Shared Function ConsultarCPF(ByVal xcpf As String) As Object

    Dim ret As New Participante
    Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = xcpf

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("CPF não encontrado.")

  End Function

  Public Shared Function ConsultarIDAutor(ByVal xcpf As String) As Object

    Dim ret As New Participante
    Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = xcpf

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("CPF não encontrado.")

  End Function

  Public Shared Function ConsultarCPFCadastrado(ByVal cpf As String) As Object

    Dim ret As New Participante
    Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = cpf

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      '      ret.PopularDados(reader)
      '     Return ret

      Throw New Exception("CPF encotrado.")

    Else
      ' retorna novo objeto
      'Throw New Exception("CPF não encotrado.")

    End If


  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function
  Public Shared Function ListarTotalInscritos() As IList

    'retorno
    Return ListaHelper.ListarRegistros(C_GET_LIST_TOTAL)

  End Function
  Public Shared Function ListarPerfil() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_PERFIL)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramcpf.Value = _cpf
    _paramNome.Value = _nome
    _paramnomecracha.Value = _nomecracha
    _paramemail.Value = _email
    _paramresidencial.Value = _residencial
    _paramcomercial.Value = _comercial
    _paramcelular.Value = _celular
    _paramlogradouro.Value = _logradouro
    _paramnumero.Value = _numero
    _paramcomplemento.Value = _complemento
    _parambairro.Value = _bairro
    _paramcidade.Value = _cidade
    _paramestado.Value = _estado
    _paramcep.Value = _cep
    _paramtitulacao.Value = _titulacao
    _paramlocal.Value = _local
    _paramqual.Value = _qual

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Cpf = reader("cpf")
    Me.Nome = reader("nome")
    Me.nomecracha = reader("nomecracha")
    Me.email = reader("email")
    Me.residencial = reader("residencial")
    Me.comercial = reader("comercial")
    Me.celular = reader("celular")
    Me.logradouro = reader("logradouro")
    Me.numero = reader("numero")
    Me.complemento = reader("complemento")
    Me.bairro = reader("bairro")
    Me.cidade = reader("cidade")
    Me.estado = reader("estado")
    Me.cep = reader("cep")
    Me.titulacao = reader("titulacao")
    Me.local = reader("local")
    Me.Qual = reader("qual")


  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    '   PermissaoGlobal.VerificarPermissao("Participante", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramCpf, _paramNome, _paramnomecracha, _paramemail, _paramresidencial, _paramcomercial, _paramcelular, _paramlogradouro, _paramnumero, _paramcomplemento, _parambairro, _paramcidade, _paramestado, _paramcep, _paramtitulacao, _paramlocal, _paramqual)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("Participante", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramCpf, _paramNome, _paramnomecracha, _paramemail, _paramresidencial, _paramcomercial, _paramcelular, _paramlogradouro, _paramnumero, _paramcomplemento, _parambairro, _paramcidade, _paramestado, _paramcep, _paramtitulacao, _paramlocal, _paramqual)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("Participante", "excluir")

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

  Public Property Cpf() As String
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

  Public Property Nomecracha() As String
    Get
      Return _nomecracha
    End Get
    Set(ByVal Value As String)
      _nomecracha = Value
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
  Public Property Residencial() As String
    Get
      Return _residencial
    End Get
    Set(ByVal Value As String)
      _residencial = Value
    End Set
  End Property
  Public Property Comercial() As String
    Get
      Return _comercial
    End Get
    Set(ByVal Value As String)
      _comercial = Value
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
  Public Property Logradouro() As String
    Get
      Return _logradouro
    End Get
    Set(ByVal Value As String)
      _logradouro = Value
    End Set
  End Property
  Public Property Numero() As String
    Get
      Return _numero
    End Get
    Set(ByVal Value As String)
      _numero = Value
    End Set
  End Property
  Public Property Complemento() As String
    Get
      Return _complemento
    End Get
    Set(ByVal Value As String)
      _complemento = Value
    End Set
  End Property
  Public Property Bairro() As String
    Get
      Return _bairro
    End Get
    Set(ByVal Value As String)
      _bairro = Value
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
  Public Property Cep() As String
    Get
      Return _cep
    End Get
    Set(ByVal Value As String)
      _cep = Value
    End Set
  End Property
  Public Property Titulacao() As String
    Get
      Return _titulacao
    End Get
    Set(ByVal Value As String)
      _titulacao = Value
    End Set
  End Property
  Public Property Local() As String
    Get
      Return _local
    End Get
    Set(ByVal Value As String)
      _local = Value
    End Set
  End Property
  Public Property Qual() As String
    Get
      Return _qual
    End Get
    Set(ByVal Value As String)
      _qual = Value
    End Set
  End Property

#End Region

End Class
