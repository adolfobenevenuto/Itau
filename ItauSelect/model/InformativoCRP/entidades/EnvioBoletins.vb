Public Class EnvioBoletins
    Inherits BaseEntidade

#Region "Member Variables"

    ' constantes para SQL
    Private Shared ReadOnly C_GET_CONSULT As String = " select * from tbl_informativo_msg ORDER BY dt_criacao DESC"
  Private Shared ReadOnly C_GET_CONSULT_ As String = " select * from tbl_informativo_msg order by id desc"

    Private Shared ReadOnly C_GET_LIST As String = "select * from tbl_informativo_envio where Excluido = 0 order by assunto"
    Private Shared ReadOnly C_INSERT_MSG As String = "insert into tbl_informativo_msg (assunto, resp_email, titulo, msg,status, excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
                                                       "values(@assunto, @resp_email, @titulo, @msg,@status,0,1,getdate(),1,getdate());" + _
                                                       "select * from tbl_informativo_msg where id = @@identity"
    Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_informativo_msg where id = @id"
    Private Shared ReadOnly C_DELETE As String = "update tbl_informativo_msg set status = 'Excluido' where id = @id"
    Private Shared ReadOnly C_UPDATE As String = "update tbl_informativo_envio set assunto = @assunto, resp_email = @resp_email, titulo = @titulo, msg = @msg where id = @id"

    ' parametros
    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
    Private _paramAssunto As New SqlParameter("@assunto", SqlDbType.VarChar)
    Private _paramResp_email As New SqlParameter("@resp_email", SqlDbType.VarChar)
    Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
    Private _paramMsg As New SqlParameter("@msg", SqlDbType.VarChar)
    Private _paramStatus As New SqlParameter("@status", SqlDbType.VarChar)

    ' propriedades
    Private _id As Integer
    Private _assunto As String
    Private _resp_email As String
    Private _titulo As String
    Private _msg As String
    Private _status As String

#End Region

#Region "Static Methods"

    Public Shared Function Consultar(ByVal id As Integer) As Object

        Dim ret As New EnvioBoletins
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
        Throw New Exception("Cadastro não encotrado.")

    End Function

    Public Shared Function Excluir(ByVal id As Integer) As Object

        Dim param As New SqlParameter("@id", SqlDbType.Int)
        ' prepara parametro
        param.Value = id

        ' executa comando no db
        SqlHelper.ExecuteNonQuery(C_DELETE, param)

    End Function

    Public Shared Function Listar() As IList

        'retorna lista
        Return ListaHelper.ListarRegistros(C_GET_LIST)

    End Function

    Public Shared Function ConsultarInformativos() As IList

        Dim sql As String

        sql = String.Format(C_GET_CONSULT)

        'retorna lista
        Return ListaHelper.ListarRegistros(sql)

    End Function

  Public Shared Function ConsultarInformativos_() As IList

    Dim sql As String

    sql = String.Format(C_GET_CONSULT_)

    'retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function


#End Region

#Region "Private Functions"

    Private Sub AtualizarParametros()

        _paramAssunto.Value = _assunto
        _paramResp_email.Value = _resp_email
        _paramTitulo.Value = _titulo
        _paramMsg.Value = _msg

    End Sub
    Private Sub AtualizarParametrosMsg()

        _paramAssunto.Value = _assunto
        _paramResp_email.Value = _resp_email
        _paramTitulo.Value = _titulo
        _paramMsg.Value = _msg
        _paramStatus.Value = _status

    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub PopularDados(ByVal reader As IDataReader)

        'popula propriedades da tabela links (criador, atualizador etc.)
        MyBase.PopularDados(reader)

        'popular proiedades
        Me.Id = reader("id")
        Me.Assunto = reader("assunto")
        Me.Resp_email = reader("resp_email")
        Me.Titulo = reader("titulo")
        Me.Msg = reader("msg")



    End Sub
    Public Sub InserirMsg()

        'prepara parametros 
        AtualizarParametrosMsg()

        ' executa comando no db
        Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT_MSG, _paramAssunto, _paramResp_email, _paramTitulo, _paramMsg, _paramStatus)

        If (ret.Read()) Then
            PopularDados(ret)
        End If

        'fecha reader
        ret.Close()
    End Sub
    Public Sub Alterar()

        'Chamada para verificacao de perfil
        '        PermissaoGlobal.VerificarPermissao("Boletins", "alterar")

        ' prepara parametros
        _paramId.Value = Me._id
        AtualizarParametros()

        ' executa comando no db
        SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramAssunto, _paramResp_email, _paramTitulo, _paramMsg)

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

    Public Property Assunto() As String
        Get
            Return _assunto
        End Get
        Set(ByVal Value As String)
            _assunto = Value
        End Set
    End Property

    Public Property Resp_email() As String
        Get
            Return _resp_email
        End Get
        Set(ByVal Value As String)
            _resp_email = Value
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

    Public Property Msg() As String
        Get
            Return _msg
        End Get
        Set(ByVal Value As String)
            _msg = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property
#End Region

End Class
