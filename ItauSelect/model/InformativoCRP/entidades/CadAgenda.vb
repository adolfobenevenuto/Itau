
Public Class CadAgenda
    Inherits BaseEntidade

#Region "Member Variables"

    ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', titulo as 'Titulo', descricao as 'Descricao', data_inicio as 'Data_Inicio',data_fim as 'Data_Fim',telefone as 'Telefone', telefone1 as 'Telefone1', telefone0800 as 'Telefone0800', logradouro as 'Local',endereco as 'Endereco',email as 'Email',site as 'Site', data_inicio from tbl_agenda_geral where Excluido = 0 and data_inicio >= getdate() and status='APROVADO' order by data_inicio"
    Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_agenda_geral where id = @id"
    Private Shared ReadOnly C_GET_DATA_VERIFICAR As String = "select * from tbl_agenda_geral where titulo = @titulo"
  Private Shared ReadOnly C_CONTAR As String = "select count(*) as 'Total' from tbl_agenda_geral where status = 'ENVIADO'"
  Private Shared ReadOnly C_GET_AVALIAR As String = "select id as 'Id', titulo as 'Titulo', data_inicio as 'Data_Inicio',data_fim as 'Data_Fim',telefone as 'Telefone',telefone1 as 'Telefone_01', telefone0800 as 'Telefone_0800',logradouro as 'Local',endereco as 'Endereco',email as 'Email',site as 'Site' from tbl_agenda_geral where status = 'ENVIADO' order by data_inicio"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_agenda_geral (titulo,descricao,data_inicio,data_fim,telefone,telefone1,telefone0800,logradouro,endereco,email,site,status,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                             "values(@titulo,@descricao,@data_inicio,@data_fim,@telefone,@telefone1,@telefone0800,@logradouro,@endereco,@email,@site,'ENVIADO',0, 1,getdate(),1,getdate());" + _
                                             "select * from tbl_agenda_geral where id = @@identity"
    Private Shared ReadOnly C_DELETE As String = "update tbl_agenda_geral set excluido = 1 where id = @id"
    Private Shared ReadOnly C_STATUS As String = "update tbl_agenda_geral set status = @status where id = @id"
    Private Shared ReadOnly C_UPDATE As String = "update tbl_agenda_geral set titulo = @titulo,descricao = @descricao, data_inicio = @data_inicio,data_fim = @data_fim,telefone = @telefone,telefone1 = @telefone1,telefone0800 = @telefone0800,logradouro = @logradouro,endereco = @endereco,email = @email,site = @site where id = @id"

    ' parametros
    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
    Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
    Private _paramDescricao As New SqlParameter("@descricao", SqlDbType.VarChar)
    Private _paramData_Inicio As New SqlParameter("@data_inicio", SqlDbType.DateTime)
    Private _paramData_Fim As New SqlParameter("@data_fim", SqlDbType.DateTime)
    Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
    Private _paramTelefone1 As New SqlParameter("@telefone1", SqlDbType.VarChar)
    Private _paramTelefone0800 As New SqlParameter("@telefone0800", SqlDbType.VarChar)
    Private _paramLogradouro As New SqlParameter("@logradouro", SqlDbType.VarChar)
    Private _paramEndereco As New SqlParameter("@endereco", SqlDbType.VarChar)
    Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
    Private _paramSite As New SqlParameter("@site", SqlDbType.VarChar)

    ' propriedades
    Private _id As Integer
    Private _titulo As String
    Private _descricao As String
    Private _data_inicio As String
    Private _data_fim As String
    Private _telefone As String
    Private _telefone1 As String
    Private _telefone0800 As String
    Private _logradouro As String
    Private _endereco As String
    Private _email As String
    Private _site As String

#End Region

#Region "Static Methods"

    Public Shared Function Consultar(ByVal id As Integer) As Object

        Dim ret As New CadAgenda
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
        Throw New Exception("Evento não encotrado.")

    End Function

    Public Shared Function Verificar(ByVal xtitulo As String) As Object

        Dim ret As New CadAgenda
        Dim param As New SqlParameter("@titulo", SqlDbType.VarChar)

        ' prepara parametro
        param.Value = xtitulo

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_VERIFICAR, param)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ' retorna evento já cadastrado
            Throw New Exception("Evento já cadastrado.")

        End If


    End Function

    Public Shared Function Listar() As IList

        'retorna lista
        Return ListaHelper.ListarRegistros(C_GET_LIST)

    End Function

    Public Shared Function Avaliar() As IList
        'retorna lista
        Return ListaHelper.ListarRegistros(C_GET_AVALIAR)
    End Function

    Public Shared Function Contar() As IList
        'retorna lista
        Return ListaHelper.ListarRegistros(C_CONTAR)
    End Function


#End Region

#Region "Private Functions"

    Private Sub AtualizarParametros()

        _paramTitulo.Value = _titulo
        _paramDescricao.Value = _descricao
        _paramData_Inicio.Value = _data_inicio
        _paramData_Fim.Value = _data_fim
        _paramTelefone.Value = _telefone
        _paramTelefone1.Value = _telefone1
        _paramTelefone0800.Value = _telefone0800
        _paramLogradouro.Value = _logradouro
        _paramEndereco.Value = _endereco
        _paramEmail.Value = _email
        _paramSite.Value = _site

    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub PopularDados(ByVal reader As IDataReader)

        'popula propriedades da tabela links (criador, atualizador etc.)
        MyBase.PopularDados(reader)

        'popular propriedades
        Me.Id = reader("id")
        Me.Titulo = reader("titulo")
        Me.Descricao = reader("descricao")
        Me.Data_Inicio = reader("data_inicio")
        Me.Data_Fim = reader("data_fim")
        Me.Telefone = reader("telefone")
        Me.Telefone1 = reader("telefone1")
        Me.Telefone0800 = reader("telefone0800")
        Me.Logradouro = reader("logradouro")
        Me.Endereco = reader("endereco")
        Me.Email = reader("email")
        Me.Site = reader("site")

    End Sub

    Public Function Valido() As Boolean

        'chama a funcao validar endereco site, com o parametro
        '  ValidadorWebSite.Valido(Me.Link)

    End Function

    Public Sub Inserir()

        ' prepara parametros
        AtualizarParametros()

        ' executa comando no db
        Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramTitulo, _paramDescricao, _paramData_Inicio, _paramData_Fim, _paramTelefone, _paramTelefone1, _paramTelefone0800, _paramLogradouro, _paramEndereco, _paramEmail, _paramSite)

        If (ret.Read()) Then
            PopularDados(ret)
        End If

        'fecha reader
        ret.Close()

    End Sub

    Public Sub Alterar()

        ' prepara parametros
        _paramId.Value = Me._id
        AtualizarParametros()

        ' executa comando no db
        SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramDescricao, _paramData_Inicio, _paramData_Fim, _paramTelefone, _paramTelefone1, _paramTelefone0800, _paramLogradouro, _paramEndereco, _paramEmail, _paramSite)

    End Sub

    Public Shared Function Reprovado(ByVal id As Integer, ByVal status As String) As Object

        'Chamada para verificacao de perfil
        '    PermissaoGlobal.VerificarPermissao("link", "excluir")

        Dim ret As New CadAgenda
        Dim param As New SqlParameter("@id", SqlDbType.Int)
        Dim ystatus As New SqlParameter("@status", SqlDbType.VarChar)

        ' prepara parametro
        param.Value = id
        ystatus.Value = status
        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_STATUS, param, ystatus)

    End Function

    Public Shared Function Aprovado(ByVal id As Integer, ByVal status As String) As Object

        'Chamada para verificacao de perfil
        '    PermissaoGlobal.VerificarPermissao("link", "excluir")

        Dim ret As New CadAgenda
        Dim param As New SqlParameter("@id", SqlDbType.Int)
        Dim ystatus As New SqlParameter("@status", SqlDbType.VarChar)

        ' prepara parametro
        param.Value = id
        ystatus.Value = status

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_STATUS, param, ystatus)

    End Function

    Public Sub Excluir()

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

    Public Property Data_Inicio() As Date
        Get
            Return _data_inicio
        End Get
        Set(ByVal Value As DateTime)
            _data_inicio = Value
        End Set
    End Property

    Public Property Data_Fim() As Date
        Get
            Return _data_fim
        End Get
        Set(ByVal Value As DateTime)
            _data_fim = Value
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

    Public Property Telefone() As String
        Get
            Return _telefone
        End Get
        Set(ByVal Value As String)
            _telefone = Value
        End Set
    End Property

    Public Property Telefone1() As String
        Get
            Return _telefone1
        End Get
        Set(ByVal Value As String)
            _telefone1 = Value
        End Set
    End Property

    Public Property Telefone0800() As String
        Get
            Return _telefone0800
        End Get
        Set(ByVal Value As String)
            _telefone0800 = Value
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

    Public Property Endereco() As String
        Get
            Return _endereco
        End Get
        Set(ByVal Value As String)
            _endereco = Value
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

    Public Property Site() As String
        Get
            Return _site
        End Get
        Set(ByVal Value As String)
            _site = Value
        End Set
    End Property

#End Region

End Class
