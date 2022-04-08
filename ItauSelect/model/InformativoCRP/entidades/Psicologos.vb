
Public Class Psicologos
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select crp as 'Crp', nome as 'Nome', especialidade1 as 'Especialidade1', especialidade2 as 'Especialidade2' from tbl_psicologos order by nome"
  Private Shared ReadOnly C_GET_LIST_BUSCAR_CRP As String = "select crp as 'Crp', nome as 'Nome', especialidade1 as 'Especialidade1', especialidade2 as 'Especialidade2' from tbl_psicologos where crp = {0} order by nome"
  Private Shared ReadOnly C_GET_LIST_BUSCAR_NOMEINICIO As String = "select crp as 'Crp', nome as 'Nome', especialidade1 as 'Especialidade1', especialidade2 as 'Especialidade2' from tbl_psicologos where nome like {0} order by nome"
  Private Shared ReadOnly C_GET_LIST_BUSCAR_NOME As String = "select crp as 'Crp', nome as 'Nome', especialidade1 as 'Especialidade1', especialidade2 as 'Especialidade2' from tbl_psicologos where  nome = {0} order by nome"
  Private Shared ReadOnly C_GET_LIST_BUSCAR_NOMEQUALQUERPARTE As String = "select crp as 'Crp', nome as 'Nome', especialidade1 as 'Especialidade1', especialidade2 as 'Especialidade2' from tbl_psicologos where nome like {0} order by nome"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_psicologos where crp = @crp"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_psicologos (crp, nome, especialidade1,especialidade2) " + _
                                               "values(@crp, @nome, @especialidade1, @especialidade2);" + _
                                               "select * from tbl_psicologos where crp = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_psicologos set excluido = 1 where crp = @crp"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_link set crp = @crp, nome = @nome, especialidade1 = @especialidade1, especialidade2 = @especialidade2 where crp = @crp"

  ' parametros
  Private _paramCrp As New SqlParameter("@crp", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramEspecialidade1 As New SqlParameter("@especialidade1", SqlDbType.VarChar)
  Private _paramEspecialidade2 As New SqlParameter("@especialidade2", SqlDbType.VarChar)

  ' propriedades
  Private _crp As Integer
  Private _nome As String
  Private _especialidade1 As String
  Private _especialidade2 As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal crp As Integer) As Object

    Dim ret As New Psicologos
    Dim param As New SqlParameter("@crp", SqlDbType.Int)

    ' prepara parametro
    param.Value = crp

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Profissional não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function


  Public Shared Function ListarCRP(ByVal crp As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BUSCAR_CRP, crp))


  End Function

  Public Shared Function ListarNomeInicio(ByVal nome As String) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BUSCAR_NOMEINICIO, nome))

  End Function

  Public Shared Function ListarNome(ByVal nome As String) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BUSCAR_NOME, nome))

  End Function

  Public Shared Function ListarNomeQualquerParte(ByVal nome As String) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BUSCAR_NOMEQUALQUERPARTE, nome))

  End Function


#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramCrp.Value = _crp
    _paramNome.Value = _nome
    _paramEspecialidade1.Value = _especialidade1
    _paramEspecialidade2.Value = _especialidade2

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.CRP = reader("CRP")
    Me.Nome = reader("nome")
    Me.Especialidade1 = reader("Especialidade1")
    Me.Especialidade2 = reader("Especialidade2")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramCrp, _paramNome, _paramEspecialidade1, _paramEspecialidade2)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' prepara parametros
    _paramCrp.Value = Me._crp
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramCrp, _paramNome, _paramEspecialidade1, _paramEspecialidade2)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "excluir")

    ' prepara parametro
    _paramCrp.Value = Me._crp

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramCrp)

  End Sub

#End Region

#Region "Public Properties"

  Public Property CRP() As Integer
    Get
      Return _crp
    End Get
    Set(ByVal Value As Integer)
      _crp = Value
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

  Public Property Especialidade1() As String
    Get
      Return _especialidade1
    End Get
    Set(ByVal Value As String)
      _especialidade1 = Value
    End Set
  End Property

  Public Property Especialidade2() As String
    Get
      Return _especialidade2
    End Get
    Set(ByVal Value As String)
      _especialidade2 = Value
    End Set
  End Property

#End Region

End Class
