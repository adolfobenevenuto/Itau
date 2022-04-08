Public Class Congresso
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', crp as 'Crp', cpf as 'CPF',nome as 'Nome'," + _
                                                  "cracha as 'cracha', email as 'Email', cidade as 'Cidade', residencial as 'residencial'," + _
                                                  "comercial as 'comercial', celular as 'Celular', titulacao as 'Titulacao'," + _
                                                  "instituicao as 'instituicao', recurso as 'recurso', qual_recurso as 'qual_recurso'," + _
                                                  "congresso as 'congresso', excluido as 'excluido', criador as 'Criador'," + _
                                                  "dt_criacao as 'dt_criacao', atualizador as 'atualizador', dt_atualizacao as 'dt_atualizacao' " + _
                                                  "from tbl_congresso_assistenciasocial where Excluido = 0 order by nome"

  Private Shared ReadOnly C_GET_DATA_TOTAL_EVENTO As String = "select * from tbl_congresso_assistenciasocial where Excluido = 0 and congresso = {0} order by id desc"
  Private Shared ReadOnly C_GET_DATA_CPF As String = "select * from tbl_congresso_assistenciasocial where cpf = @cpf and Excluido = 0"
  Private Shared ReadOnly C_GET_DATA_CPF_MESA As String = "select * from tbl_congresso_assistenciasocial_mesa where cpf = @cpf and Excluido = 0"

  Private Shared ReadOnly C_GET_DATA_TOTAL As String = "select * from tbl_congresso_assistenciasocial where excluido = 0 order by id desc"
  Private Shared ReadOnly C_GET_DATA_LIMITE As String = "Select count(*) as 'Totalinscritos' from tbl_congresso_assistenciasocial where Excluido = 0"
  Private Shared ReadOnly C_GET_DATA_LIMITE_ESTUDANTE As String = "Select count(*) as 'Totalinscritos' from tbl_congresso_assistenciasocial where Excluido = 0 and titulacao = 'Graduação Incompleta'"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_congresso_assistenciasocial where id = @id"

  Private Shared ReadOnly C_INSERT As String = "insert into tbl_congresso_assistenciasocial (crp, cpf, nome, cracha, email, cidade, " + _
                                               "residencial, comercial, celular, titulacao, instituicao, recurso, qual_recurso," + _
                                               "congresso, excluido, criador, dt_criacao, atualizador, dt_atualizacao)" + _
                                               "values (@crp, @cpf, @nome, @cracha, @email, @cidade, @residencial, @comercial, @celular," + _
                                               "@titulacao, @instituicao, @recurso, @qual_recurso, @congresso, 0, 1, getdate(), 1, getdate())" + _
                                               "select * from tbl_congresso_assistenciasocial where id = @@identity"

  Private Shared ReadOnly C_INSERT_MESA As String = "insert into tbl_congresso_assistenciasocial_mesa (crp, cpf, nome, cracha, email, " + _
                                               "cidade, residencial, comercial, celular, titulacao, instituicao, recurso, qual_recurso," + _
                                               "congresso, excluido, criador, dt_criacao, atualizador, dt_atualizacao)" + _
                                               "values (@crp, @cpf, @nome, @cracha, @email, @cidade, @residencial, @comercial, @celular," + _
                                               "@titulacao, @instituicao, @recurso, @qual_recurso, @congresso, 0, 1, getdate(), 1, getdate())" + _
                                               "select * from tbl_congresso_assistenciasocial_mesa where id = @@identity"


  Private Shared ReadOnly C_DELETE As String = "update tbl_congresso_assistenciasocial set excluido = 1 where id = @id"

  Private Shared ReadOnly C_UPDATE As String = "update tbl_congresso_assistenciasocial set crp = @crp, cpf = @cpf, nome = @nome, cracha =@cracha, email =@email," + _
                                               "cidade = @cidade, residencial = @residencial, comercial = @comercial, celular =@celular, titulacao = @titulacao," + _
                                               "instituicao = @instituicao, recurso = @recurso, qual_recurso = @qual_recurso, congresso = @congresso," + _
                                               "dt_atualizacao = getdate() where id = @id"


  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramCrp As New SqlParameter("@crp", SqlDbType.VarChar)
  Private _paramCpf As New SqlParameter("@cpf", SqlDbType.VarChar)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramCracha As New SqlParameter("@cracha", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramCidade As New SqlParameter("@cidade", SqlDbType.VarChar)
  Private _paramResidencial As New SqlParameter("@residencial", SqlDbType.VarChar)
  Private _paramComercial As New SqlParameter("@comercial", SqlDbType.VarChar)
  Private _paramCelular As New SqlParameter("@celular", SqlDbType.VarChar)
  Private _paramTitulacao As New SqlParameter("@titulacao", SqlDbType.VarChar)
  Private _paramInstituicao As New SqlParameter("@instituicao", SqlDbType.VarChar)
  Private _paramRecurso As New SqlParameter("@recurso", SqlDbType.VarChar)
  Private _paramQual_recurso As New SqlParameter("@qual_recurso", SqlDbType.VarChar)
  Private _paramCongresso As New SqlParameter("@congresso", SqlDbType.VarChar)



  ' propriedades
  Private _id As Integer
  Private _crp As String
  Private _cpf As String
  Private _nome As String
  Private _cracha As String
  Private _email As String
  Private _cidade As String
  Private _residencial As String
  Private _comercial As String
  Private _celular As String
  Private _titulacao As String
  Private _instituicao As String
  Private _recurso As String
  Private _qual_recurso As String
  Private _congresso As String
  Private _Totalinscritos As Integer

#End Region

#Region "Static Methods"

  Public Shared Function Limite() As Object

    Dim ret As New Congresso
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_LIMITE)

    If (reader.Read()) Then

      ret.PopularDadosLimite(reader)
      Return ret

    End If


  End Function
  Public Shared Function LimiteEstudante() As Object

    Dim ret As New Congresso
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_LIMITE_ESTUDANTE)

    If (reader.Read()) Then

      ret.PopularDadosLimite(reader)
      Return ret

    End If


  End Function

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Congresso

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
  Public Shared Function ConsultarTotal() As Object

    Dim ret As New Congresso

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_TOTAL)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Participante não encotrado.")

  End Function

  Public Shared Function ConsultarTotalEvento(ByVal evento As String) As Object

    Dim ret As New Congresso

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_TOTAL_EVENTO, evento)

    'retorna lista
    '    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BOLETO, Nome))

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Participante não encotrado.")

  End Function
  Public Shared Function ConsultarCPFCadastrado(ByVal cpf As String) As Object

    Dim ret As New Congresso
    Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = cpf

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      '  ret.PopularDados(reader)
      '  Return ret
      Throw New Exception("CPF encotrado.")

      'Else
      'retorna novo objeto
      '           Throw New Exception("CPF não encotrado.")

    End If


  End Function
  Public Shared Function ConsultarCPFCadastradoMesa(ByVal cpf As String) As Object

    Dim ret As New Congresso
    Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = cpf

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF_MESA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      '  ret.PopularDados(reader)
      '  Return ret
      Throw New Exception("CPF encotrado.")

      'Else
      'retorna novo objeto
      '           Throw New Exception("CPF não encotrado.")

    End If


  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramCrp.Value = _crp
    _paramCpf.Value = _cpf
    _paramNome.Value = _nome
    _paramCracha.Value = _cracha
    _paramEmail.Value = _email
    _paramCidade.Value = _cidade
    _paramResidencial.Value = _residencial
    _paramComercial.Value = _comercial
    _paramCelular.Value = _celular
    _paramTitulacao.Value = _titulacao
    _paramInstituicao.Value = _instituicao
    _paramRecurso.Value = _recurso
    _paramQual_recurso.Value = _qual_recurso
    _paramCongresso.Value = _congresso

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Crp = reader("crp")
    Me.Cpf = reader("cpf")
    Me.Nome = reader("nome")
    Me.Cracha = reader("cracha")
    Me.Email = reader("email")
    Me.Cidade = reader("cidade")
    Me.residencial = reader("residencial")
    Me.Comercial = reader("comercial")
    Me.Celular = reader("celular")
    Me.Titulacao = reader("titulacao")
    Me.Instituicao = reader("instituicao")
    Me.Recurso = reader("recurso")
    Me.Qual_recurso = reader("qual_recurso")
    Me.Congresso = reader("congresso")

  End Sub
  Public Sub PopularDadosLimite(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    '  MyBase.PopularDados(reader)

    'popular proiedades
    Me.Totalinscritos = reader("Totalinscritos")


  End Sub
  Public Function Valido() As Boolean

    'chama a funcao validar endereco site, com o parametro
    ValidadorWebSite.Valido(Me.Congresso)

  End Function

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "inserir")

    ' valida link
    'ValidadorWebSite.Validar(_congresso)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramId, _paramCrp, _paramCpf, _paramNome, _paramCracha, _paramEmail, _paramCidade, _paramResidencial, _paramComercial, _paramCelular, _paramTitulacao, _paramInstituicao, _paramRecurso, _paramQual_recurso, _paramCongresso)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub InserirMesa()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "inserir")

    ' valida link
    'ValidadorWebSite.Validar(_congresso)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT_MESA, _paramId, _paramCrp, _paramCpf, _paramNome, _paramCracha, _paramEmail, _paramCidade, _paramResidencial, _paramComercial, _paramCelular, _paramTitulacao, _paramInstituicao, _paramRecurso, _paramQual_recurso, _paramCongresso)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    ' PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' valida link
    'ValidadorWebSite.Validar(_congresso)

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramCrp, _paramCpf, _paramNome, _paramCracha, _paramEmail, _paramCidade, _paramResidencial, _paramComercial, _paramCelular, _paramTitulacao, _paramInstituicao, _paramRecurso, _paramQual_recurso, _paramCongresso)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "excluir")

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
  Public Property Crp() As String
    Get
      Return _crp
    End Get
    Set(ByVal Value As String)
      _crp = Value
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
  Public Property Cracha() As String
    Get
      Return _cracha
    End Get

    Set(ByVal Value As String)
      _cracha = Value
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
  Public Property Cidade() As String
    Get
      Return _cidade
    End Get

    Set(ByVal Value As String)
      _cidade = Value
    End Set
  End Property

  Public Property residencial() As String
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

  Public Property Titulacao() As String
    Get
      Return _titulacao
    End Get
    Set(ByVal Value As String)
      _titulacao = Value
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

  Public Property Recurso() As String
    Get
      Return _recurso
    End Get
    Set(ByVal Value As String)
      _recurso = Value
    End Set
  End Property

  Public Property Qual_recurso() As String
    Get
      Return _qual_recurso
    End Get
    Set(ByVal Value As String)
      _qual_recurso = Value
    End Set
  End Property

  Public Property Congresso() As String
    Get
      Return _congresso
    End Get
    Set(ByVal Value As String)
      _congresso = Value
    End Set
  End Property

  Public Property Totalinscritos() As Integer
    Get
      Return _Totalinscritos
    End Get
    Set(ByVal Value As Integer)
      _Totalinscritos = Value
    End Set
  End Property
#End Region

End Class




