Public Class Boletins
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_EMAIL_REPETIDO As String = "select TOP 100 * from tbl_informativo where Excluido = 0 and email = @email"
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', nome as 'Nome', sobrenome as 'Sobrenome', email as 'Email', sede as 'Sede', subsede as 'Subsede', status as 'Status' from tbl_informativo where Excluido = 0 order by email"
  Private Shared ReadOnly C_GET_LIST_BUSCAR As String = "select id as 'Id', nome as 'Nome', sobrenome as 'Sobrenome', email as 'Email', sede as 'Sede', subsede as 'Subsede', status as 'Status' from tbl_informativo where email like {0} and Excluido = 0  order by email"
  Private Shared ReadOnly C_GET_LIST_PERFIL As String = "select id as 'Id', nome as 'Nome', sobrenome as 'Sobrenome', email as 'Email', sede as 'Sede', subsede as 'Subsede', status as 'Status' from tbl_informativo where Excluido = 0 and {0} = '1' order by email"
  Private Shared ReadOnly C_GET_LIST_ENVIAR As String = "select id as 'Id', nome as 'Nome', sobrenome as 'Sobrenome', email as 'Email', sede as 'Sede', subsede as 'Subsede', status as 'Status' from tbl_informativo where Excluido = 0 and status = 'Não' order by nome"
  Private Shared ReadOnly C_GET_LIST_ENVIADOS As String = "select count(nome) as 'Total' from tbl_informativo where Excluido = 0 and {0} = '1' and status = 'Sim'"
  Private Shared ReadOnly C_GET_LIST_EMAIL As String = "select count(nome) as 'TotalEmail' from tbl_informativo where Excluido = 0 and {0} = '1' and status = 'Sim' or status = 'Não'"
  Private Shared ReadOnly C_GET_DATA As String = "select TOP 100 * from tbl_informativo where id = @id"
  Private Shared ReadOnly C_GET_DATA_EMAIL As String = "select TOP 1 * from tbl_informativo where status = 'Não' and {0} = '1' and 'precisa pensar aqui' order by id desc"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_informativo (nome,email,sede, subsede, status,assis,bauru,campinas,abc,ribeirao,santos,saojose,taubate,sp,dh,saude,ca,sm,educacao,traborg,sppj,excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
                                               "values(@nome, @email, @sede, @subsede, @status,@assis,@bauru,@campinas,@abc,@ribeirao,@santos,@saojose,@taubate,@sp,@dh,@saude,@ca,@sm,@educacao,@traborg,@sppj,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_informativo where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "delete from tbl_informativo where id = @id"
  Private Shared ReadOnly C_DELETE_CADASTRO As String = "update tbl_informativo set status = 'Excluido' where email = @email"
  Private Shared ReadOnly C_UPDATE_STATUS As String = "update tbl_informativo set status = 'Não'"
  Private Shared ReadOnly C_UPDATE_STATUS_TOTAL As String = "update tbl_informativo set status = 'Não' where {0} = '1' and status = 'Sim'"

  Private Shared ReadOnly C_UPDATE_STATUS_ENVIADO As String = "update tbl_informativo set status = 'Sim'"
  Private Shared ReadOnly C_UPDATE_STATUS_ENVIADO_EMAIL As String = "update tbl_informativo set status = 'Sim' where id = @id"
  Private Shared ReadOnly C_UPDATE_STATUS_ENVIADO_EMAIL_ERRO As String = "update tbl_informativo set status = 'Err' where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_informativo set nome = @nome, email = @email, sede = @sede, subsede = @subsede, status = @status,assis = @assis,bauru = @bauru,campinas = @campinas,abc = @abc,ribeirao = @ribeirao,santos = @santos,saojose = @saojose,taubate = @taubate,sp = @sp,dh = @dh,saude = @saude,ca = @ca,sm = @sm,educacao = @educacao,traborg = @traborg,sppj = @sppj where id = @id"
  Private Shared ReadOnly C_UPDATE_VALIDAR As String = "update tbl_informativo set status = 'Não' where id = @id"
  Private Shared ReadOnly C_SELECT_VALIDAR As String = "select top 1 * from tbl_informativo order by id desc"
  Private Shared ReadOnly C_UPDATE_CADASTRO As String = "update tbl_informativo set nome = @nome, email = @email, sede = @sede, subsede = @subsede, status = @status,assis = @assis,bauru = @bauru,campinas = @campinas,abc = @abc,ribeirao = @ribeirao,santos = @santos,saojose = @saojose,taubate = @taubate,sp = @sp, dh = @dh,saude = @saude,ca = @ca,sm = @sm,educacao = @educacao,traborg = @traborg,sppj = @sppj where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramSobrenome As New SqlParameter("@sobrenome", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramSede As New SqlParameter("@sede", SqlDbType.VarChar)
  Private _paramSubsede As New SqlParameter("@subsede", SqlDbType.VarChar)
  Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)
  Private _paramassis As New SqlParameter("@assis", SqlDbType.Int)
  Private _parambauru As New SqlParameter("@bauru", SqlDbType.Int)
  Private _paramcampinas As New SqlParameter("@campinas", SqlDbType.Int)
  Private _paramabc As New SqlParameter("@abc", SqlDbType.Int)
  Private _paramribeirao As New SqlParameter("@ribeirao", SqlDbType.Int)
  Private _paramsantos As New SqlParameter("@santos", SqlDbType.Int)
  Private _paramsaojose As New SqlParameter("@saojose", SqlDbType.Int)
  Private _paramtaubate As New SqlParameter("@taubate", SqlDbType.Int)
  Private _paramsp As New SqlParameter("@sp", SqlDbType.Int)
  Private _paramDH As New SqlParameter("@dh", SqlDbType.Int)
  Private _paramsaude As New SqlParameter("@saude", SqlDbType.Int)
  Private _paramCA As New SqlParameter("@ca", SqlDbType.Int)
  Private _paramSM As New SqlParameter("@sm", SqlDbType.Int)
  Private _parameducacao As New SqlParameter("@educacao", SqlDbType.Int)
  Private _paramtraborg As New SqlParameter("@traborg", SqlDbType.Int)
  Private _paramSPPJ As New SqlParameter("@sppj", SqlDbType.Int)


  ' propriedades
  Private _id As Integer
  Private _nome As String
  Private _sobrenome As String
  Private _email As String
  Private _sede As String
  Private _subsede As String
  Private _status As String
  Private _assis As Integer
  Private _bauru As Integer
  Private _campinas As Integer
  Private _abc As Integer
  Private _ribeirao As Integer
  Private _santos As Integer
  Private _saojose As Integer
  Private _taubate As Integer
  Private _sp As Integer
  Private _DH As Integer
  Private _saude As Integer
  Private _CA As Integer
  Private _SM As Integer
  Private _educacao As Integer
  Private _traborg As Integer
  Private _SPPJ As Integer

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Boletins
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
    Throw New Exception("Cadastro não encontrado.")

  End Function

  Public Shared Function EmailCadastrado(ByVal email As String) As Object

    Dim ret As New Boletins
    Dim param As New SqlParameter("@email", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = email


    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_EMAIL_REPETIDO, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    Else
      ' retorna novo objeto
      Throw New Exception("Email não encontrado.")

    End If


  End Function
  Public Shared Function ValidarEmail() As Object


    Dim ret As New Boletins

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_SELECT_VALIDAR)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    Else
      ' retorna novo objeto
      Throw New Exception("Id não encontrado.")

    End If

  End Function

  Public Shared Function ConsultarEmail(ByVal xperfil As String) As Object

    Dim ret As New Boletins
    Dim sql As String
    sql = xperfil

    'Monta consulta sql
    sql = String.Format(C_GET_DATA_EMAIL, sql)

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(sql)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    Else
      ' retorna novo objeto
      Throw New Exception("Email não encontrado.")

    End If

  End Function
  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function
  Public Shared Function BuscarEmail(ByVal busca As String) As IList

    ' Dim ret As New Boletins

    Dim sql, xbusca As String
    xbusca = Convert.ToString("'" + busca + "'")

    sql = String.Format(C_GET_LIST_BUSCAR, xbusca)

    'Return ret
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarPerfil(ByVal xperfil As String) As IList

    Dim sql As String
    sql = xperfil

    'Monta consulta sql
    sql = String.Format(C_GET_LIST_PERFIL, sql)

    Return ListaHelper.ListarRegistros(sql)

  End Function
  Public Shared Function ListarEnviar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_ENVIAR)

  End Function
  Public Shared Function ListarEmail(ByVal xperfil As String) As IList

    Dim sql As String
    sql = xperfil

    'Monta consulta sql
    sql = String.Format(C_GET_LIST_EMAIL, sql)

    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarEnviados(ByVal xperfil As String) As IList

    Dim sql As String
    sql = xperfil

    'Monta consulta sql
    sql = String.Format(C_GET_LIST_ENVIADOS, sql)

    Return ListaHelper.ListarRegistros(sql)


  End Function


#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramNome.Value = _nome
    _paramSobrenome.Value() = _sobrenome
    _paramEmail.Value = _email
    _paramSede.Value = _sede
    _paramSubsede.Value = _subsede
    _paramStatus.Value = _status
    _paramassis.Value = _assis
    _parambauru.Value = _bauru
    _paramcampinas.Value = _campinas
    _paramabc.Value = _abc
    _paramribeirao.Value = _ribeirao
    _paramsantos.Value = _santos
    _paramsaojose.Value = _saojose
    _paramtaubate.Value = _taubate
    _paramsp.Value = _sp
    _paramDH.Value = _DH
    _paramsaude.Value = _saude
    _paramCA.Value = _CA
    _paramSM.Value = _SM
    _parameducacao.Value = _educacao
    _paramtraborg.Value = _traborg
    _paramSPPJ.Value = _SPPJ


  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Nome = reader("nome")
    Me.Sobrenome = reader("sobrenome")
    Me.Email = reader("email")
    Me.Sede = reader("sede")
    Me.subsede = reader("subsede")
    Me.status = reader("status")
    Me.assis = reader("assis")
    Me.bauru = reader("bauru")
    Me.campinas = reader("campinas")
    Me.abc = reader("abc")
    Me.ribeirao = reader("ribeirao")
    Me.santos = reader("santos")
    Me.saojose = reader("saojose")
    Me.taubate = reader("taubate")
    Me.sp = reader("sp")
    Me.DH = reader("DH")
    Me.saude = reader("saude")
    Me.CA = reader("CA")
    Me.SM = reader("SM")
    Me.educacao = reader("educacao")
    Me.traborg = reader("traborg")
    Me.SPPJ = reader("SPPJ")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "inserir")


    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramEmail, _paramSede, _paramSubsede, _paramStatus, _paramassis, _parambauru, _paramcampinas, _paramabc, _paramribeirao, _paramsantos, _paramsaojose, _paramtaubate, _paramsp, _paramDH, _paramsaude, _paramCA, _paramSM, _parameducacao, _paramtraborg, _paramSPPJ)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub UpdateValidar(ByVal xid As String)

    _paramId.Value = xid

    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_VALIDAR, _paramId)

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramEmail, _paramSede, _paramSubsede, _paramStatus, _paramassis, _parambauru, _paramcampinas, _paramabc, _paramribeirao, _paramsantos, _paramsaojose, _paramtaubate, _paramsp, _paramDH, _paramsaude, _paramCA, _paramSM, _parameducacao, _paramtraborg, _paramSPPJ)

  End Sub
  Public Sub AlterarContato(ByVal id As Integer)


    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramEmail, _paramSede, _paramSubsede, _paramStatus, _paramassis, _parambauru, _paramcampinas, _paramabc, _paramribeirao, _paramsantos, _paramsaojose, _paramtaubate, _paramsp)

  End Sub

  Public Sub AlterarContatoCadastro()


    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_CADASTRO, _paramNome, _paramEmail, _paramSede, _paramSubsede, _paramStatus, _paramassis, _parambauru, _paramcampinas, _paramabc, _paramribeirao, _paramsantos, _paramsaojose, _paramtaubate, _paramsp, _paramDH, _paramsaude, _paramCA, _paramSM, _parameducacao, _paramtraborg, _paramSPPJ, _paramId)

  End Sub

  Public Sub AlterarStatus(ByVal id As Integer)

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

    ' prepara parametro
    _paramId.Value = id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_STATUS, _paramId)

  End Sub
  Public Sub AlterarStatusTotal(ByVal xperfil As String)

    Dim ret As New Boletins
    Dim sql As String
    sql = xperfil

    'Monta consulta sql
    sql = String.Format(C_UPDATE_STATUS_TOTAL, sql)

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(sql)

  End Sub
  Public Sub AlterarStatusEnviado(ByVal id As Integer)

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

    ' prepara parametro
    _paramId.Value = id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_STATUS_ENVIADO, _paramId)

  End Sub

  Public Sub AlterarStatusEnviandoEmail(ByVal id As Integer)

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

    ' prepara parametro
    _paramId.Value = id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_STATUS_ENVIADO_EMAIL, _paramId)

  End Sub

  Public Sub AlterarStatusEnviandoEmailErro(ByVal id As Integer)

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

    ' prepara parametro
    _paramId.Value = id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_STATUS_ENVIADO_EMAIL_ERRO, _paramId)

  End Sub
  Public Sub Excluir()

    'Chamada para verificacao de perfil
    '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub
  Public Sub ExcluirContato(ByVal id As Integer)

    ' prepara parametro
    _paramId.Value = id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

  Public Sub ExcluirContatoCadastro(ByVal email As String)

    ' prepara parametro
    _paramEmail.Value = email

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE_CADASTRO, _paramEmail)

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
  Public Property Sobrenome() As String
    Get
      Return _sobrenome
    End Get
    Set(ByVal Value As String)
      _sobrenome = Value
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
  Public Property Sede() As String
    Get
      Return _sede
    End Get
    Set(ByVal Value As String)
      _sede = Value
    End Set
  End Property

  Public Property subsede() As String
    Get
      Return _subsede
    End Get
    Set(ByVal Value As String)
      _subsede = Value
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
  Public Property assis() As Integer
    Get
      Return _assis
    End Get
    Set(ByVal Value As Integer)
      _assis = Value
    End Set
  End Property
  Public Property bauru() As Integer
    Get
      Return _bauru
    End Get
    Set(ByVal Value As Integer)
      _bauru = Value
    End Set
  End Property
  Public Property campinas() As Integer
    Get
      Return _campinas
    End Get
    Set(ByVal Value As Integer)
      _campinas = Value
    End Set
  End Property
  Public Property abc() As Integer
    Get
      Return _abc
    End Get
    Set(ByVal Value As Integer)
      _abc = Value
    End Set
  End Property
  Public Property ribeirao() As Integer
    Get
      Return _ribeirao
    End Get
    Set(ByVal Value As Integer)
      _ribeirao = Value
    End Set
  End Property
  Public Property santos() As Integer
    Get
      Return _santos
    End Get
    Set(ByVal Value As Integer)
      _santos = Value
    End Set
  End Property
  Public Property saojose() As Integer
    Get
      Return _saojose
    End Get
    Set(ByVal Value As Integer)
      _saojose = Value
    End Set
  End Property
  Public Property taubate() As Integer
    Get
      Return _taubate
    End Get
    Set(ByVal Value As Integer)
      _taubate = Value
    End Set
  End Property
  Public Property sp() As Integer
    Get
      Return _sp
    End Get
    Set(ByVal Value As Integer)
      _sp = Value
    End Set
  End Property
  Public Property DH() As Integer
    Get
      Return _DH
    End Get
    Set(ByVal Value As Integer)
      _DH = Value
    End Set
  End Property
  Public Property saude() As Integer
    Get
      Return _saude
    End Get
    Set(ByVal Value As Integer)
      _saude = Value
    End Set
  End Property
  Public Property CA() As Integer
    Get
      Return _CA
    End Get
    Set(ByVal Value As Integer)
      _CA = Value
    End Set
  End Property
  Public Property sm() As Integer
    Get
      Return _SM
    End Get
    Set(ByVal Value As Integer)
      _SM = Value
    End Set
  End Property
  Public Property educacao() As Integer
    Get
      Return _educacao
    End Get
    Set(ByVal Value As Integer)
      _educacao = Value
    End Set
  End Property
  Public Property traborg() As Integer
    Get
      Return _traborg
    End Get
    Set(ByVal Value As Integer)
      _traborg = Value
    End Set
  End Property
  Public Property SPPJ() As Integer
    Get
      Return _SPPJ
    End Get
    Set(ByVal Value As Integer)
      _SPPJ = Value
    End Set
  End Property

#End Region

End Class

'Public Class Boletins
'    Inherits BaseEntidade

'#Region "Member Variables"

'    ' constantes para SQL
'    Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', nome as 'Nome', sobrenome as 'Sobrenome', sede as 'Sede', subsede as 'Subsede', status as 'Status' from tbl_informativo where Excluido = 0 order by nome"
'    Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_informativo where id = @id"
'    Private Shared ReadOnly C_INSERT As String = "insert into tbl_informativo (nome, sobrenome, sede, subsede, status, excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
'                                                 "values(@nome, @sobrenome, @sede, @subsede, @status,0,1,getdate(),1,getdate());" + _
'                                                 "select * from tbl_informativo where id = @@identity"
'    Private Shared ReadOnly C_DELETE As String = "update tbl_informativo set excluido = 1 where id = @id"
'    Private Shared ReadOnly C_UPDATE As String = "update tbl_informativo set nome = @nome, sobrenome = @sobrenome, sede = @sede, subsede = @subsede, status = @status where id = @id"

'    ' parametros
'    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
'    Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
'    Private _paramSobrenome As New SqlParameter("@sobrenome", SqlDbType.VarChar)
'    Private _paramSede As New SqlParameter("@sede", SqlDbType.VarChar)
'    Private _paramSubsede As New SqlParameter("@subsede", SqlDbType.VarChar)
'    Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)

'    ' propriedades
'    Private _id As Integer
'    Private _nome As String
'    Private _sobrenome As String
'    Private _sede As String
'    Private _subsede As String
'    Private _status As String

'#End Region

'#Region "Static Methods"

'    Public Shared Function Consultar(ByVal id As Integer) As Object

'        Dim ret As New Boletins
'        Dim param As New SqlParameter("@id", SqlDbType.Int)

'        ' prepara parametro
'        param.Value = id

'        ' executa comando no db
'        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

'        ' verifica se encontrou o registro
'        If (reader.Read()) Then

'            ret.PopularDados(reader)
'            Return ret

'        End If

'        ' retorna novo objeto
'        Throw New Exception("Cadastro não encotrado.")

'    End Function

'    Public Shared Function Listar() As IList

'        'retorna lista
'        Return ListaHelper.ListarRegistros(C_GET_LIST)

'    End Function

'#End Region

'#Region "Private Functions"

'    Private Sub AtualizarParametros()

'        _paramNome.Value = _nome
'        _paramSobrenome.Value = _sobrenome
'        _paramSede.Value = _sede
'        _paramSubsede.Value = _subsede
'        _paramStatus.Value = _status

'    End Sub

'#End Region

'#Region "Public Methods"

'    Public Overrides Sub PopularDados(ByVal reader As IDataReader)

'        'popula propriedades da tabela links (criador, atualizador etc.)
'        MyBase.PopularDados(reader)

'        'popular proiedades
'        Me.Id = reader("id")
'        Me.Nome = reader("nome")
'        Me.Sobrenome = reader("sobrenome")
'        Me.Sede = reader("sede")
'        Me.Subsede = reader("subsede")
'        Me.Status = reader("status")

'    End Sub

'    Public Sub Inserir()

'        'Chamada para verificacao de perfil
'        '        PermissaoGlobal.VerificarPermissao("Boletins", "inserir")


'        ' prepara parametros
'        AtualizarParametros()

'        ' executa comando no db
'        Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramSobrenome, _paramSede, _paramSubsede, _paramStatus)

'        If (ret.Read()) Then
'            PopularDados(ret)
'        End If

'        'fecha reader
'        ret.Close()

'    End Sub

'    Public Sub Alterar()

'        'Chamada para verificacao de perfil
'        '        PermissaoGlobal.VerificarPermissao("Boletins", "alterar")

'        ' prepara parametros
'        _paramId.Value = Me._id
'        AtualizarParametros()

'        ' executa comando no db
'        SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramSobrenome, _paramSede, _paramSubsede, _paramStatus)

'    End Sub

'    Public Sub Excluir()

'        'Chamada para verificacao de perfil
'        '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

'        ' prepara parametro
'        _paramId.Value = Me._id

'        ' executa comando no db
'        SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

'    End Sub

'#End Region

'#Region "Public Properties"

'    Public Property Id() As Integer
'        Get
'            Return _id
'        End Get
'        Set(ByVal Value As Integer)
'            _id = Value
'        End Set
'    End Property

'    Public Property Nome() As String
'        Get
'            Return _nome
'        End Get
'        Set(ByVal Value As String)
'            _nome = Value
'        End Set
'    End Property

'    Public Property Sobrenome() As String
'        Get
'            Return _sobrenome
'        End Get
'        Set(ByVal Value As String)
'            _sobrenome = Value
'        End Set
'    End Property

'    Public Property Sede() As String
'        Get
'            Return _sede
'        End Get
'        Set(ByVal Value As String)
'            _sede = Value
'        End Set
'    End Property

'    Public Property subsede() As String
'        Get
'            Return _subsede
'        End Get
'        Set(ByVal Value As String)
'            _subsede = Value
'        End Set
'    End Property
'    Public Property status() As String
'        Get
'            Return _status
'        End Get
'        Set(ByVal Value As String)
'            _status = Value
'        End Set
'    End Property

'#End Region

'End Class
