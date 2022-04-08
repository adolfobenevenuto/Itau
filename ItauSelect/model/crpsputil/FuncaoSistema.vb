'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem classes relacionadas as funcoes do sistema. Estas
'// funcoes sao operacoes do sistema para as quais sera possivel configurar
'// as permissoes de execucao dinamicamente
'//
'//////////////////////////////////////////////////////////////////////////////

'Classe que representa funcoes do sistema.
Public NotInheritable Class FuncaoSistema

#Region "Variaveis membro"

  'Propriedades
  Private _id As Integer = 0
  Private _idContexto As Integer = 0
  Private _nome As New String("")
  Private _descricao As New String("")
  Private _classe As New String("")
  Private _operacao As New String("")

#End Region

#Region "Construtor"

  Friend Sub New(ByVal id As Integer, _
                 ByVal idContexto As Integer, _
                 ByVal nome As String, _
                 ByVal descricao As String, _
                 ByVal classe As String, _
                 ByVal operacao As String)

    'inicia propriedades
    _id = id
    _idContexto = idContexto
    _nome = nome
    _descricao = descricao
    _classe = classe
    _operacao = operacao

  End Sub

#End Region

#Region "Lista de objetos funcaoperfil"

  'Retorna lista de perfis para o comando informado
  Private Function ListarPerfis(ByVal sql As String) As ArrayList

    Dim C_SQL As String = "select " & _
                            "p.*,pf.somente_criador " & _
                          "from " & _
                            "tbl_eventos_perfil_acesso p inner join " & _
                            "tbl_eventos_funcao_perfil pf on pf.id_perf = f.id_perf " & _
                          "where pf.id_fnc = " & Me.Id.ToString()
    Dim reader As SqlDataReader
    Dim ret As New ArrayList

    'Popula funcoes
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(C_SQL)

      While reader.Read()

        'Cria objeto perfilusuario
        Dim p As New PerfilUsuario(Convert.ToInt32(reader("id_perf")), _
                                   Convert.ToInt32(reader("contexto")), _
                                   Convert.ToString(reader("nome")), _
                                   Convert.ToString(reader("descricao")))

        'Cria perfilfuncao
        Dim fp As New FuncaoPerfil(Me, p, Convert.ToBoolean(reader("somente_criador")))

        'Adiciona funcao
        ret.Add(fp)

      End While

      'Fecha reader
      reader.Close()

      Return ret

    Catch ex As Exception

      If (Not reader Is Nothing) Then
        If (Not reader.IsClosed) Then
          reader.Close()
        End If
      End If

      Throw ex

    End Try

  End Function

#End Region

#Region "Propriedades"

  Friend Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property

  Friend Property IdContexto() As Integer
    Get
      Return _idContexto
    End Get
    Set(ByVal Value As Integer)
      _idContexto = Value
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

  Public Property Descricao() As String
    Get
      Return _descricao
    End Get
    Set(ByVal Value As String)
      _descricao = Value
    End Set
  End Property

  Public Property Classe() As String
    Get
      Return _classe
    End Get
    Set(ByVal Value As String)
      _classe = Value
    End Set
  End Property

  Public Property Operacao() As String
    Get
      Return _operacao
    End Get
    Set(ByVal Value As String)
      _operacao = Value
    End Set
  End Property

#End Region

End Class
