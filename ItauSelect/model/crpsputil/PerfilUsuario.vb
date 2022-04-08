'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem classes relacionadas aos perfis de 
'// usuarios do sistema.
'//
'// Data de Criacao : 23-04-2004
'// Criador : 
'//////////////////////////////////////////////////////////////////////////////

'Classe que representa perfis de usuarios do sistema.
Public Class PerfilUsuario

#Region "Variaveis membro"

  'Propriedades
  Private _id As Integer = 0
  Private _idContexto As Integer = 0
  Private _nome As New String("")
  Private _descricao As New String("")

#End Region

#Region "Construtor"

  Friend Sub New(ByVal id As Integer, _
                 ByVal idContexto As Integer, _
                 ByVal nome As String, _
                 ByVal descricao As String)

    'inicia propriedades
    _id = id
    _idContexto = idContexto
    _nome = nome
    _descricao = descricao

  End Sub

#End Region

#Region "Lista de objetos funcaoperfil"

  'Retorna lista de funcoes para o comando informado
  Public Function ListarFuncoes() As ArrayList

    Dim C_SQL As String = "select " & _
                            "f.*,pf.somente_criador " & _
                          "from " & _
                            "tbl_eventos_funcao_sistema f inner join " & _
                            "tbl_eventos_funcao_perfil pf on pf.id_fnc = f.id_fnc " & _
                          "where id_perf = " & Me.Id.ToString()
    Dim reader As SqlDataReader
    Dim ret As New ArrayList

    'Popula funcoes
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(C_SQL)

      While reader.Read()

        'Cria objeto funcaosistema
        Dim f As New FuncaoSistema(Convert.ToInt32(reader("id_fnc")), _
                                   Convert.ToInt32(reader("contexto")), _
                                   Convert.ToString(reader("classe")), _
                                   Convert.ToString(reader("operacao")), _
                                   Convert.ToString(reader("nome")), _
                                   Convert.ToString(reader("descricao")))

        'Cria perfilfuncao
        Dim fp As New FuncaoPerfil(f, Me, Convert.ToBoolean(reader("somente_criador")))

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

  Public ReadOnly Property Id() As Integer
    Get
      Return _id
    End Get
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

#End Region

End Class
