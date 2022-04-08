Public Class CadPonto
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', data as 'Data', matricula as 'Matricula', senha as 'Senha', observacao as 'observacao' from tbl_horas order by data desc"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_horas where id = @id"
  Private Shared ReadOnly C_INSERT As String = "Insert Into tbl_horas " + _
                                                "(data, matricula, senha, observacao) " + _
                                                "values " + _
                                                "(getdate(),@matricula,@senha,@observacao)"
  Private Shared ReadOnly C_DELETE As String = ""
  Private Shared ReadOnly C_UPDATE As String = ""

  ' parametros
  Private Shared ReadOnly _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private Shared ReadOnly _paramData As New SqlParameter("@data", SqlDbType.DateTime)
  Private Shared ReadOnly _paramMatricula As New SqlParameter("@matricula", SqlDbType.Int)
  Private Shared ReadOnly _paramSenha As New SqlParameter("@senha", SqlDbType.VarChar)
  Private Shared ReadOnly _paramObservacao As New SqlParameter("@observacao", SqlDbType.NVarChar)

  ' propriedades
  Private _id As Integer
  Private _data As Date = Date.MinValue
  Private _matricula As Integer
  Private _senha As String
  Private _observacao As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As CadPonto

    Dim ret As New CadPonto

    'prepara parametro
    _paramId.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, _paramId)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.CarregarReader(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Cadastro não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'Executa comando no db
    Dim reader As IDataReader

    reader = SqlHelper.ExecuteReader(C_GET_LIST)

    Dim val As IEnumerator = CType(reader, IEnumerable).GetEnumerator()
    Dim ret As New ArrayList

    If (Not val Is Nothing) Then
      While (val.MoveNext())
        ret.Add(val.Current)
      End While
    End If

    'retorna lista
    Return ret

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = id
    _paramData.Value = data
    _paramMatricula.Value = matricula
    _paramSenha.Value = senha
    _paramObservacao.Value = observacao

  End Sub

  Private Sub CarregarReader(ByVal reader As SqlDataReader)
    Me.id = reader("id")
    Me.data = reader("data")
    Me.matricula = reader("matricula")
    Me.senha = reader("senha")
    Me.observacao = reader("observacao")
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    'MyBase.PopularDados(reader)

    'popular proiedades
    Me.id = reader("id")
    Me.data = reader("data")
    Me.matricula = reader("matricula")
    Me.senha = reader("senha")
    Me.observacao = reader("observacao")


  End Sub

  Public Sub Inserir()

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_INSERT, _paramData, _paramMatricula, _paramSenha, _paramObservacao)

  End Sub

  Public Sub Alterar()

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramData, _paramMatricula, _paramSenha, _paramObservacao)

  End Sub

  Public Sub Excluir()

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property
  Public Property data() As Date
    Get
      Return _data
    End Get
    Set(ByVal Value As DateTime)
      _data = Value
    End Set
  End Property
  Public Property matricula() As Integer
    Get
      Return _matricula
    End Get
    Set(ByVal Value As Integer)
      _matricula = Value
    End Set
  End Property
  Public Property senha() As String
    Get
      Return _senha
    End Get
    Set(ByVal Value As String)
      _senha = Value
    End Set
  End Property
  Public Property observacao() As String
    Get
      Return _observacao
    End Get
    Set(ByVal Value As String)
      _observacao = Value
    End Set
  End Property

#End Region
End Class
