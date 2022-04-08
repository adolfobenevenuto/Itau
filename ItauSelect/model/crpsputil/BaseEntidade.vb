'//////////////////////////////////////////////////////////////////////////////
'//
'// Este arquivo contem a implementacao da classe BaseEntidade, da qual
'// diversas classes no sistema poderao ser filhas.
'//
'// Data de Criacao : 23-04-2004
'// 
'//////////////////////////////////////////////////////////////////////////////

'Classe para representar entidades que contem informacoes de log como :
'Criador, data de criacao, atualizador e data de atualizacao
Public MustInherit Class BaseEntidade
  Implements IEntidade

#Region "Variaveis membro"

  'Propriedades
  Private _excluido As Boolean = False
  Private _criador As Integer = 0
  Private _atualizador As Integer = 0
  Private _dataCriacao As Date = Date.MinValue
  Private _dataAtualizacao As Date = Date.MinValue

  'Parametros para SQL
  Protected ReadOnly _paramCriador As New SqlParameter("@criador", System.Data.SqlDbType.Int)
  Protected ReadOnly _paramDataCriacao As New SqlParameter("@dt_criacao", System.Data.SqlDbType.DateTime)
  Protected ReadOnly _paramAtualizador As New SqlParameter("@atualizador", System.Data.SqlDbType.Int)
  Protected ReadOnly _paramDataAtualizacao As New SqlParameter("@dt_atualizacao", System.Data.SqlDbType.DateTime)
  Protected ReadOnly _paramExcluido As New SqlParameter("@excluido", System.Data.SqlDbType.Bit)

#End Region

#Region "Construtor"

  Sub New()

    _paramAtualizador.IsNullable = True
    _paramCriador.IsNullable = True

  End Sub

#End Region

#Region "Metodos protegidos"

  Protected Function CInt32(ByVal val As Object) As Integer

    Return CInt32(val, 0)

  End Function

  Protected Function CInt32(ByVal val As Object, ByVal defVal As Integer) As Integer

    Try
      Return Convert.ToInt32(val)
    Catch ex As Exception
      Return defVal
    End Try

  End Function

  Protected Sub AtualizarParametrosUsuario()

    'Coloca valor para atualizador e criador
    _paramCriador.Value = IIf(Usuario.UsuarioCorrente.Autenticado, _
                              Usuario.UsuarioCorrente.Id, _
                              Nothing)
    _paramAtualizador.Value = _paramCriador.Value

  End Sub

#End Region

#Region "Implementacao de IEntidade"

  'Popula dados do reader.
  'ATENCAO !!! Este metodo supoe que exista no datareader
  'campos chamados 'criador','dtcriacao','atualizador','dtatualizacao'
  'e 'excluido'
  'Pode ser criado futuramente uma estrutura mais elegante que permita
  'a cada subclasse definir qual nome de campo corresponde a cada propriedade.
  'Porem, por enquanto estes nomes estarao fixos e estamos confiando na 
  'padronizacao de nomes de campos...
  'Caso estes campos nao existam, um erro sera gerado !!!
  Public Overridable Sub PopularDados(ByVal reader As IDataReader) Implements IEntidade.PopularDados

    'atribui valor para as variaveis de acordo com o reader
    _excluido = Convert.ToBoolean(reader("excluido"))
    _criador = CInt32(reader("criador"))
    _atualizador = CInt32(reader("atualizador"))
    _dataCriacao = Convert.ToDateTime(reader("dt_criacao"))
    _dataAtualizacao = Convert.ToDateTime(reader("dt_atualizacao"))

  End Sub

#End Region

#Region "Consulta"

  'Consulta um objeto que implementa a interface IEntidade
  Protected Shared Function ConsultarEntidade(ByVal entidade As IEntidade, _
                                              ByVal contexto As SqlTransaction, _
                                              ByVal query As String, _
                                              ByVal ParamArray parameters() As SqlParameter) As IEntidade

    'declara reader
    Dim reader As SqlDataReader

    If (contexto Is Nothing) Then
      reader = SqlHelper.ExecuteReader(query, parameters)
    Else
      reader = SqlHelper.ExecuteReader(contexto, CommandType.Text, query, parameters)
    End If

    Try

      If (reader.Read()) Then

        'Popula dados
        entidade.PopularDados(reader)

      End If

      'retorna reader
      Return entidade

    Finally

      If (Not reader.IsClosed) Then
        reader.Close()
      End If

    End Try

  End Function

  'Consulta um objeto que implementa a interface IEntidade
  Protected Shared Function ConsultarEntidade(ByVal entidade As IEntidade, _
                                              ByVal query As String, _
                                              ByVal ParamArray parameters() As SqlParameter) As IEntidade

    'Chama overload
    Return ConsultarEntidade(entidade, Nothing, query, parameters)

  End Function

#End Region

#Region "Propriedades"

  Public ReadOnly Property Excluido() As Boolean
    Get
      Return _excluido
    End Get
  End Property

  Public ReadOnly Property IdCriador() As Integer
    Get
      Return _criador
    End Get
  End Property

  Public ReadOnly Property IdAtualizador() As Integer
    Get
      Return _atualizador
    End Get
  End Property

  Public ReadOnly Property DataCriacao() As Date
    Get
      Return _dataCriacao
    End Get
  End Property

  Public ReadOnly Property DataAtualizacao() As Date
    Get
      Return _dataAtualizacao
    End Get
  End Property

#End Region

End Class


'Classe base de colecao de entidades com metodos para populacao 
'automatica de objetos 
Public MustInherit Class BaseColecaoEntidade
  Inherits CollectionBase
  Implements IColecaoEntidade

#Region "Variaveis Membro"

  Private _excluidos As New ArrayList
  Private _adicionados As New ArrayList

#End Region

#Region "IColecaoEntidade"

  Public Overridable Sub Add(ByVal item As IEntidade) Implements IColecaoEntidade.Add
    InnerList.Add(item)
  End Sub

  Public MustOverride Function CriarEntidade() As IEntidade Implements IColecaoEntidade.CriarEntidade

#End Region

#Region "Eventos da colecao"

  Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)

    _adicionados.Add(value)

  End Sub

  Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)

    _excluidos.Add(value)

  End Sub

  Protected Overrides Sub OnClearComplete()

    _adicionados.Clear()
    _excluidos.Clear()

  End Sub

#End Region

#Region "Propriedades"

  Protected ReadOnly Property Excluidos() As ArrayList
    Get
      Return _excluidos
    End Get
  End Property

  Protected ReadOnly Property Adicionados() As ArrayList
    Get
      Return _adicionados
    End Get
  End Property

#End Region

End Class


