Public Class Relatorio
    Inherits BaseEntidade

#Region "Member Variables"

    ' constantes para SQL
    Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', titulo as 'Titulo', subtitulo as 'Subtitulo', resumo as 'Resumo', relatorio as 'Relatorio' from tbl_relatorio where Excluido = 0"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_relatorio where id = @id order by id"
    Private Shared ReadOnly C_INSERT As String = "insert into tbl_relatorio (titulo, subtitulo, resumo,relatorio,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@titulo,@subtitulo,@resumo,@relatorio,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_relatorio where id = @@identity"
    Private Shared ReadOnly C_DELETE As String = "update tbl_relatorio set excluido = 1 where id = @id"
    Private Shared ReadOnly C_UPDATE As String = "update tbl_relatorio set titulo = @titulo, subtitulo = @subtitulo, resumo = @resumo, relatorio = @relatorio, atualizador = 1, dt_atualizacao = getdate() where id = @id"

    ' parametros
    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
    Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
    Private _paramSubtitulo As New SqlParameter("@subtitulo", SqlDbType.VarChar)
    Private _paramResumo As New SqlParameter("@resumo", SqlDbType.VarChar)
    Private _paramRelatorio As New SqlParameter("@relatorio", SqlDbType.VarChar)

    ' propriedades
    Private _id As Integer
    Private _titulo As String
    Private _subtitulo As String
    Private _resumo As String
    Private _relatorio As String

#End Region

#Region "Static Methods"

    Public Shared Function Consultar(ByVal id As Integer) As Object

        Dim ret As New Relatorio
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
        Throw New Exception("Relatório não encotrado.")

    End Function

    Public Shared Function Listar() As IList

        'retorna lista
        Return ListaHelper.ListarRegistros(C_GET_LIST)

    End Function

#End Region

#Region "Private Functions"

    Private Sub AtualizarParametros()

        _paramTitulo.Value = _titulo
        _paramSubtitulo.Value = _subtitulo
        _paramResumo.Value = _resumo
        _paramRelatorio.Value = _relatorio

    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub PopularDados(ByVal reader As IDataReader)

        'popula propriedades da tabela links (criador, atualizador etc.)
        MyBase.PopularDados(reader)

        'popular proiedades
        Me.Id = reader("id")
        Me.Titulo = reader("titulo")
        Me.Subtitulo = reader("subtitulo")
        Me.Resumo = reader("resumo")
        Me.Relatorio = reader("relatorio")

    End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("relatorio", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramTitulo, _paramSubtitulo, _paramResumo, _paramRelatorio)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("relatorio", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramSubtitulo, _paramResumo, _paramRelatorio)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("relatorio", "excluir")

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

    Public Property Subtitulo() As String
        Get
            Return _subtitulo
        End Get
        Set(ByVal Value As String)
            _subtitulo = Value
        End Set
    End Property

    Public Property Resumo() As String
        Get
            Return _resumo
        End Get
        Set(ByVal Value As String)
            _resumo = Value
        End Set
    End Property


    Public Property Relatorio() As String
        Get
            Return _relatorio
        End Get
        Set(ByVal Value As String)
            _relatorio = Value
        End Set
    End Property

#End Region

End Class
