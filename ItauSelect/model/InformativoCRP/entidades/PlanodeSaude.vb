Public Class PlanodeSaude
    Inherits BaseEntidade

#Region "Member Variables"

    ' constantes para SQL
    Private Shared ReadOnly C_GET_DATA_EMAIL As String = "select * from tbl_plano_saude where email = @email"
    Private Shared ReadOnly C_DELETE As String = "update tbl_plano_saude set excluido = 1 where id = @id"
    Private Shared ReadOnly C_UPDATE As String = "update tbl_plano_saude set nome = @nome,crp = @crp,responsavel = @responsavel,crp_responsavel = @crp_responsavel,endereco = @endereco,bairro = @bairro,cidade = @cidade,estado = @estado,cep = @cep,telefone = @telefone,cnes = @cnes,email = @email where id = @id"
    Private Shared ReadOnly C_SELECT_ID As String = "select * from tbl_plano_saude where id = @id"
    Private Shared ReadOnly C_INSERT As String = "insert into tbl_plano_saude (nome, crp, responsavel, crp_responsavel, endereco, bairro, cidade, estado, cep, telefone, cnes, email,senha, excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
                                                 "values(@nome, @crp, @responsavel,@crp_responsavel, @endereco, @bairro,@cidade,@estado,@cep,@telefone,@cnes,@email,@senha,0,1,getdate(),1,getdate());" + _
                                                 "select * from tbl_plano_saude where id = @@identity"


    ' parametros
    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
    Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
    Private _paramCrp As New SqlParameter("@crp", SqlDbType.VarChar)
    Private _paramResponsavel As New SqlParameter("@responsavel", SqlDbType.VarChar)
    Private _paramCrp_Responsavel As New SqlParameter("@crp_responsavel", SqlDbType.VarChar)
    Private _paramEndereco As New SqlParameter("@endereco", SqlDbType.VarChar)
    Private _paramBairro As New SqlParameter("@bairro", SqlDbType.VarChar)
    Private _paramCidade As New SqlParameter("@cidade", SqlDbType.VarChar)
    Private _paramEstado As New SqlParameter("@estado", SqlDbType.VarChar)
    Private _paramCep As New SqlParameter("@cep", SqlDbType.VarChar)
    Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
    Private _paramCnes As New SqlParameter("@cnes", SqlDbType.VarChar)
    Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
    Private _paramSenha As New SqlParameter("@senha", SqlDbType.VarChar)

    ' propriedades
    Private _id As Integer
    Private _nome As String
    Private _crp As String
    Private _responsavel As String
    Private _crp_responsavel As String
    Private _endereco As String
    Private _bairro As String
    Private _cidade As String
    Private _estado As String
    Private _cep As String
    Private _telefone As String
    Private _cnes As String
    Private _email As String
    Private _senha As String



#End Region

#Region "Static Methods"

    Public Shared Function ConsultarCadastrado(ByVal email As String) As Object

        Dim ret As New PlanodeSaude
        Dim param As New SqlParameter("@email", SqlDbType.VarChar)

        ' prepara parametro
        param.Value = email

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_EMAIL, param)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ret.PopularDados(reader)
            Return ret

        Else
            ' retorna novo objeto
            Throw New Exception("Usuario não encontrado.")

        End If

    End Function
    Public Shared Function ConsultarRepetido(ByVal email As String) As Object

        Dim ret As New PlanodeSaude
        Dim param As New SqlParameter("@email", SqlDbType.VarChar)

        ' prepara parametro
        param.Value = email

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_EMAIL, param)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ' retorna novo objeto
            Throw New Exception("Usuario não encontrado.")

        End If

    End Function
    Public Shared Function ConsultarId(ByVal id As Integer) As Object

        Dim ret As New PlanodeSaude
        Dim param As New SqlParameter("@id", SqlDbType.Int)

        ' prepara parametro
        param.Value = id

        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_SELECT_ID, param)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ret.PopularDados(reader)
            Return ret

        End If

        ' retorna novo objeto
        Throw New Exception("Cadastro não encontrado.")

    End Function

#End Region

#Region "Private Functions"

    Private Sub AtualizarParametros()

        _paramNome.Value = _nome
        _paramCrp.Value = _crp
        _paramResponsavel.Value = _responsavel
        _paramCrp_Responsavel.Value = _crp_responsavel
        _paramEndereco.Value = _endereco
        _paramBairro.Value = _bairro
        _paramCidade.Value = _cidade
        _paramEstado.Value = _estado
        _paramCep.Value = _cep
        _paramTelefone.Value = _telefone
        _paramCnes.Value = _cnes
        _paramEmail.Value = _email
        _paramSenha.Value = _senha
    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub PopularDados(ByVal reader As IDataReader)

        'popula propriedades da tabela links (criador, atualizador etc.)
        MyBase.PopularDados(reader)

        'popular proiedades
        Me.Id = reader("id")
        Me.Nome = reader("nome")
        Me.Crp = reader("crp")
        Me.Responsavel = reader("responsavel")
        Me.Crp_Responsavel = reader("crp_responsavel")
        Me.Endereco = reader("endereco")
        Me.Bairro = reader("bairro")
        Me.Cidade = reader("cidade")
        Me.Estado = reader("estado")
        Me.Cep = reader("cep")
        Me.Telefone = reader("telefone")
        Me.Cnes = reader("cnes")
        Me.Email = reader("email")
        Me.Senha = reader("senha")

    End Sub

    Public Sub Inserir()

        ' prepara parametros
        AtualizarParametros()

        ' executa comando no db
        Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramNome, _paramCrp, _paramResponsavel, _paramCrp_Responsavel, _paramEndereco, _paramBairro, _paramCidade, _paramEstado, _paramCep, _paramTelefone, _paramCnes, _paramEmail, _paramSenha)

        If (ret.Read()) Then
            PopularDados(ret)
        End If

        'fecha reader
        ret.Close()

    End Sub

    Public Sub Alterar(ByVal id As Integer)

        ' prepara parametros
        _paramId.Value = id
        AtualizarParametros()

        ' executa comando no db
        SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNome, _paramCrp, _paramResponsavel, _paramCrp_Responsavel, _paramEndereco, _paramBairro, _paramCidade, _paramEstado, _paramCep, _paramTelefone, _paramCnes, _paramEmail)

    End Sub

    Public Sub Excluir(ByVal xid As Integer)

        'Chamada para verificacao de perfil
        '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

        Dim param As New SqlParameter("@id", SqlDbType.Int)

        ' prepara parametro
        param.Value = xid

        ' executa comando no db
        SqlHelper.ExecuteNonQuery(C_DELETE, param)

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
    Public Property Crp() As String
        Get
            Return _crp
        End Get
        Set(ByVal Value As String)
            _crp = Value
        End Set
    End Property

    Public Property Responsavel() As String
        Get
            Return _responsavel
        End Get
        Set(ByVal Value As String)
            _responsavel = Value
        End Set
    End Property
    Public Property Crp_Responsavel() As String
        Get
            Return _crp_responsavel
        End Get
        Set(ByVal Value As String)
            _crp_responsavel = Value
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
    Public Property Telefone() As String
        Get
            Return _telefone
        End Get
        Set(ByVal Value As String)
            _telefone = Value
        End Set
    End Property
    Public Property Cnes() As String
        Get
            Return _cnes
        End Get
        Set(ByVal Value As String)
            _cnes = Value
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
    Public Property Senha() As String
        Get
            Return _senha
        End Get
        Set(ByVal Value As String)
            _senha = Value
        End Set
    End Property
#End Region

End Class
