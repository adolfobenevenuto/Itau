Public Class Operadora
    Inherits BaseEntidade

#Region "Member Variables"

    ' constantes para SQL
    Private Shared ReadOnly C_DELETE As String = "update tbl_plano_saude_operadora set excluido = 1 where id = @id"
    Private Shared ReadOnly C_DELETE_TODOS As String = "update tbl_plano_saude_operadora set excluido = 1 where id_usu = @id_usu"
    Private Shared ReadOnly C_UPDATE As String = "update tbl_plano_saude_operadora set nome_oper = @nome_oper, modalidade = @modalidade,ins_gestao = @ins_gestao,ins_promocao = @ins_promocao,ins_prevencao = @ins_prevencao,ins_assistencia = @ins_assistencia,ins_reabilitacao = @ins_reabilitacao,ar_clinica = @ar_clinica,ar_individual = @ar_individual,ar_grupal = @ar_grupal,ar_rh = @ar_rh,ar_psicopedagogia = @ar_psicopedagogia,ar_hospitalar = @ar_hospitalar, " + _
                                                 " ar_educativo = @ar_educativo,ar_outros = @ar_outros,publ_crianca = @publ_crianca,publ_adolescente = @publ_adolescente,publ_adulto = @publ_adulto,publ_casal = @publ_casal,publ_familia = @publ_familia,publ_funcionario = @publ_funcionario,publ_outros = @publ_outros, dt_atualizacao = getdate() where id = @id"
    Private Shared ReadOnly C_SELECT_ID As String = "select id as 'Id', nome_oper as 'Nome' from tbl_plano_saude_operadora where id_usu = {0} and excluido = 0"
    Private Shared ReadOnly C_SELECT_OPERADORA As String = "select * from tbl_plano_saude_operadora where id = @id"
    Private Shared ReadOnly C_INSERT As String = "insert into tbl_plano_saude_operadora (id_usu, nome_oper, modalidade,ins_gestao,ins_promocao,ins_prevencao,ins_assistencia,ins_reabilitacao,ar_clinica,ar_individual,ar_grupal,ar_rh,ar_psicopedagogia,ar_hospitalar,ar_educativo,ar_outros,publ_crianca,publ_adolescente,publ_adulto,publ_casal,publ_familia,publ_funcionario,publ_outros,excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
                                                 "values(@id_usu, @nome_oper, @modalidade, @ins_gestao,@ins_promocao,@ins_prevencao,@ins_assistencia,@ins_reabilitacao,@ar_clinica,@ar_individual,@ar_grupal,@ar_rh,@ar_psicopedagogia,@ar_hospitalar,@ar_educativo,@ar_outros,@publ_crianca,@publ_adolescente,@publ_adulto,@publ_casal,@publ_familia,@publ_funcionario,@publ_outros,0,1,getdate(),1,getdate());" + _
                                                 "select * from tbl_plano_saude_operadora where id = @@identity"

    ' parametros
    Private _paramId As New SqlParameter("@id", SqlDbType.Int)
    Private _paramIdUsu As New SqlParameter("@id_usu", SqlDbType.Int)
    Private _paramNomeOper As New SqlParameter("@nome_oper", SqlDbType.VarChar)
    Private _paramModalidade As New SqlParameter("@modalidade", SqlDbType.VarChar)
    Private _paramInsGestao As New SqlParameter("@ins_gestao", SqlDbType.VarChar)
    Private _paramInsPromocao As New SqlParameter("@ins_promocao", SqlDbType.VarChar)
    Private _paramInsPrevencao As New SqlParameter("@ins_prevencao", SqlDbType.VarChar)
    Private _paramInsAssistencia As New SqlParameter("@ins_assistencia", SqlDbType.VarChar)
    Private _paramInsReabilitacao As New SqlParameter("@ins_reabilitacao", SqlDbType.VarChar)
    Private _paramArClinica As New SqlParameter("@ar_clinica", SqlDbType.VarChar)
    Private _paramArIndividual As New SqlParameter("@ar_individual", SqlDbType.VarChar)
    Private _paramArGrupal As New SqlParameter("@ar_grupal", SqlDbType.VarChar)
    Private _paramArRh As New SqlParameter("@ar_rh", SqlDbType.VarChar)
    Private _paramArPsicopedagogia As New SqlParameter("@ar_psicopedagogia", SqlDbType.VarChar)
    Private _paramArHospitalar As New SqlParameter("@ar_hospitalar", SqlDbType.VarChar)
    Private _paramArEducativo As New SqlParameter("@ar_educativo", SqlDbType.VarChar)
    Private _paramArOutros As New SqlParameter("@ar_outros", SqlDbType.VarChar)
    Private _paramPublCrianca As New SqlParameter("@publ_crianca", SqlDbType.VarChar)
    Private _paramPublAdolescente As New SqlParameter("@publ_adolescente", SqlDbType.VarChar)
    Private _paramPublAdultos As New SqlParameter("@publ_adulto", SqlDbType.VarChar)
    Private _paramPublCasal As New SqlParameter("@publ_casal", SqlDbType.VarChar)
    Private _paramPublFamilia As New SqlParameter("@publ_familia", SqlDbType.VarChar)
    Private _paramPublFuncionario As New SqlParameter("@publ_funcionario", SqlDbType.VarChar)
    Private _paramPublOutros As New SqlParameter("@publ_outros", SqlDbType.VarChar)


    ' propriedades
    Private _id As Integer
    Private _id_usu As Integer
    Private _nome_oper As String
    Private _modalidade As String
    Private _ins_gestao As String
    Private _ins_promocao As String
    Private _ins_prevencao As String
    Private _ins_assistencia As String
    Private _ins_reabilitacao As String
    Private _ar_clinica As String
    Private _ar_individual As String
    Private _ar_grupal As String
    Private _ar_rh As String
    Private _ar_psicopedagogia As String
    Private _ar_hospitalar As String
    Private _ar_educativo As String
    Private _ar_outros As String
    Private _publ_crianca As String
    Private _publ_adolescente As String
    Private _publ_adulto As String
    Private _publ_casal As String
    Private _publ_familia As String
    Private _publ_funcionario As String
    Private _publ_outros As String


#End Region

#Region "Static Methods"

    Public Shared Function ListarOperadora(ByVal id_usu As Integer) As IList

        Dim sql As String
        sql = id_usu

        'Monta consulta sql
        sql = String.Format(C_SELECT_ID, sql)

        'retorna lista
        Return ListaHelper.ListarRegistros(sql)

    End Function


    Public Shared Function ConsultarOperId(ByVal id As String) As Object

        Dim ret As New Operadora
        Dim param As New SqlParameter("@id", SqlDbType.Int)

        ' prepara parametro
        param.Value = id


        ' executa comando no db
        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_SELECT_OPERADORA, param)

        ' verifica se encontrou o registro
        If (reader.Read()) Then

            ret.PopularDados(reader)
            Return ret

        Else
            ' retorna novo objeto
            Throw New Exception("ID não encontrado.")

        End If


    End Function
#End Region

#Region "Private Functions"

    Private Sub AtualizarParametros()

        _paramIdUsu.Value = _id_usu
        _paramNomeOper.Value = _nome_oper
        _paramModalidade.Value = _modalidade
        _paramInsGestao.Value = _ins_gestao
        _paramInsPromocao.Value = _ins_promocao
        _paramInsPrevencao.Value = _ins_prevencao
        _paramInsAssistencia.Value = _ins_assistencia
        _paramInsReabilitacao.Value = _ins_reabilitacao
        _paramArClinica.Value = _ar_clinica
        _paramArIndividual.Value = _ar_individual
        _paramArGrupal.Value = _ar_grupal
        _paramArRh.Value = _ar_rh
        _paramArPsicopedagogia.Value = _ar_psicopedagogia
        _paramArHospitalar.Value = _ar_hospitalar
        _paramArEducativo.Value = _ar_educativo
        _paramArOutros.Value = _ar_outros
        _paramPublCrianca.Value = _publ_crianca
        _paramPublAdolescente.Value = _publ_adolescente
        _paramPublAdultos.Value = _publ_adulto
        _paramPublCasal.Value = _publ_casal
        _paramPublFamilia.Value = _publ_familia
        _paramPublFuncionario.Value = _publ_funcionario
        _paramPublOutros.Value = _publ_outros

    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub PopularDados(ByVal reader As IDataReader)

        'popula propriedades da tabela links (criador, atualizador etc.)
        MyBase.PopularDados(reader)

        'popular proiedades
        Me.Id = reader("id")
        Me.IdUsu = reader("id_usu")
        Me.NomeOper = reader("nome_oper")
        Me.Modalidade = reader("modalidade")
        Me.InsGestao = reader("ins_gestao")
        Me.InsPromocao = reader("ins_promocao")
        Me.InsPrevencao = reader("ins_prevencao")
        Me.InsAssistencia = reader("ins_assistencia")
        Me.InsReabilitacao = reader("ins_reabilitacao")
        Me.ArClinica = reader("ar_clinica")
        Me.ArIndividual = reader("ar_individual")
        Me.ArGrupal = reader("ar_grupal")
        Me.ArRh = reader("ar_rh")
        Me.ArPsicopedagogia = reader("ar_psicopedagogia")
        Me.ArHospitalar = reader("ar_hospitalar")
        Me.ArEducativo = reader("ar_educativo")
        Me.ArOutros = reader("ar_outros")
        Me.PublCrianca = reader("publ_crianca")
        Me.PublAdolescente = reader("publ_adolescente")
        Me.PublAdulto = reader("publ_adulto")
        Me.PublCasal = reader("publ_casal")
        Me.PublFamilia = reader("publ_familia")
        Me.PublFuncionario = reader("publ_funcionario")
        Me.PublOutros = reader("publ_outros")

    End Sub

    Public Sub Inserir(ByVal id_usu As Integer)

        ' prepara parametros
        AtualizarParametros()
        _paramIdUsu.Value = id_usu

        ' executa comando no db
        Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramIdUsu, _paramNomeOper, _paramModalidade, _paramInsGestao, _paramInsPromocao, _paramInsPrevencao, _paramInsAssistencia, _paramInsReabilitacao, _paramArClinica, _paramArIndividual, _paramArGrupal, _paramArRh, _paramArPsicopedagogia, _paramArHospitalar, _paramArEducativo, _paramArOutros, _paramPublCrianca, _paramPublAdolescente, _paramPublAdultos, _paramPublCasal, _paramPublFamilia, _paramPublFuncionario, _paramPublOutros)

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
        SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramNomeOper, _paramModalidade, _paramInsGestao, _paramInsPromocao, _paramInsPrevencao, _paramInsAssistencia, _paramInsReabilitacao, _paramArClinica, _paramArIndividual, _paramArGrupal, _paramArRh, _paramArPsicopedagogia, _paramArHospitalar, _paramArEducativo, _paramArOutros, _paramPublCrianca, _paramPublAdolescente, _paramPublAdultos, _paramPublCasal, _paramPublFamilia, _paramPublFuncionario, _paramPublOutros)

    End Sub
    Public Sub ExcluirTodos(ByVal xidusu As Integer)

        'Chamada para verificacao de perfil
        '        PermissaoGlobal.VerificarPermissao("Boletins", "excluir")

        Dim param As New SqlParameter("@id_usu", SqlDbType.Int)

        ' prepara parametro
        param.Value = xidusu

        ' executa comando no db
        SqlHelper.ExecuteNonQuery(C_DELETE_TODOS, param)

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
    Public Property IdUsu() As Integer
        Get
            Return _id_usu
        End Get
        Set(ByVal Value As Integer)
            _id_usu = Value
        End Set
    End Property

    Public Property NomeOper() As String
        Get
            Return _nome_oper
        End Get
        Set(ByVal Value As String)
            _nome_oper = Value
        End Set
    End Property
    Public Property Modalidade() As String
        Get
            Return _modalidade
        End Get
        Set(ByVal Value As String)
            _modalidade = Value
        End Set
    End Property

    Public Property InsGestao() As String
        Get
            Return _ins_gestao
        End Get
        Set(ByVal Value As String)
            _ins_gestao = Value
        End Set
    End Property
    Public Property InsPromocao() As String
        Get
            Return _ins_promocao
        End Get
        Set(ByVal Value As String)
            _ins_promocao = Value
        End Set
    End Property
    Public Property InsPrevencao() As String
        Get
            Return _ins_prevencao
        End Get
        Set(ByVal Value As String)
            _ins_prevencao = Value
        End Set
    End Property
    Public Property InsAssistencia() As String
        Get
            Return _ins_assistencia
        End Get
        Set(ByVal Value As String)
            _ins_assistencia = Value
        End Set
    End Property
    Public Property InsReabilitacao() As String
        Get
            Return _ins_reabilitacao
        End Get
        Set(ByVal Value As String)
            _ins_reabilitacao = Value
        End Set
    End Property
    Public Property ArClinica() As String
        Get
            Return _ar_clinica
        End Get
        Set(ByVal Value As String)
            _ar_clinica = Value
        End Set
    End Property
    Public Property ArIndividual() As String
        Get
            Return _ar_individual
        End Get
        Set(ByVal Value As String)
            _ar_individual = Value
        End Set
    End Property
    Public Property ArGrupal() As String
        Get
            Return _ar_grupal
        End Get
        Set(ByVal Value As String)
            _ar_grupal = Value
        End Set
    End Property
    Public Property ArRh() As String
        Get
            Return _ar_rh
        End Get
        Set(ByVal Value As String)
            _ar_rh = Value
        End Set
    End Property
    Public Property ArPsicopedagogia() As String
        Get
            Return _ar_psicopedagogia
        End Get
        Set(ByVal Value As String)
            _ar_psicopedagogia = Value
        End Set
    End Property
    Public Property ArHospitalar() As String
        Get
            Return _ar_hospitalar
        End Get
        Set(ByVal Value As String)
            _ar_hospitalar = Value
        End Set
    End Property
    Public Property ArEducativo() As String
        Get
            Return _ar_educativo
        End Get
        Set(ByVal Value As String)
            _ar_educativo = Value
        End Set
    End Property
    Public Property ArOutros() As String
        Get
            Return _ar_outros
        End Get
        Set(ByVal Value As String)
            _ar_outros = Value
        End Set
    End Property
    Public Property PublCrianca() As String
        Get
            Return _publ_crianca

        End Get
        Set(ByVal Value As String)
            _publ_crianca = Value
        End Set
    End Property
    Public Property PublAdolescente() As String
        Get
            Return _publ_adolescente

        End Get
        Set(ByVal Value As String)
            _publ_adolescente = Value
        End Set
    End Property
    Public Property PublAdulto() As String
        Get
            Return _publ_adulto

        End Get
        Set(ByVal Value As String)
            _publ_adulto = Value
        End Set
    End Property
    Public Property PublCasal() As String
        Get
            Return _publ_casal

        End Get
        Set(ByVal Value As String)
            _publ_casal = Value
        End Set
    End Property
    Public Property PublFamilia() As String
        Get
            Return _publ_familia

        End Get
        Set(ByVal Value As String)
            _publ_familia = Value
        End Set
    End Property
    Public Property PublFuncionario() As String
        Get
            Return _publ_funcionario

        End Get
        Set(ByVal Value As String)
            _publ_funcionario = Value
        End Set
    End Property
    Public Property PublOutros() As String
        Get
            Return _publ_outros

        End Get
        Set(ByVal Value As String)
            _publ_outros = Value
        End Set
    End Property

#End Region

End Class
