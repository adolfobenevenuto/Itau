'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem a implementacao da classe GerenciadorPermissao, 
'// que gerencia os perfis de acesso ao sistema, funcoes do sistema
'// e o relacionamento entre perfis e funcoes.
'//
'// Data de Criacao : 21-06-2004
'//////////////////////////////////////////////////////////////////////////////
Imports System.Security

'Classe gerenciamento de permissoes. Disponibiliza informacoes
'sobre perfis de acesso, funcoes do sistema e o relacionamento entre
'perfis e funcoes
Public NotInheritable Class GerenciadorPermissao

#Region "Variaveis memnbro"

  'Dados sobre funcoes, perfis e relacionamento entre funcoes e perfis
  Private _ds As DataSet

#End Region

#Region "Metodos privados"

  'Dispara erro de acesso negado
  Private Shared Sub NegarPermissao()
    Throw New GerenciadorPermissaoException("Você não tem permissão para executar a operação solicitada.")
  End Sub

  'Retorna lista de funcoes para o comando informado
  Private Shared Function ListarFuncoes(ByVal sql As String) As ArrayList

    Dim reader As SqlDataReader
    Dim ret As New ArrayList

    'Popula funcoes
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(sql)

      While reader.Read()

        'Cria objeto funcaosistema
        Dim f As New FuncaoSistema(Convert.ToInt32(reader("id_fnc")), _
                                   Convert.ToInt32(reader("contexto")), _
                                   Convert.ToString(reader("classe")), _
                                   Convert.ToString(reader("operacao")), _
                                   Convert.ToString(reader("nome")), _
                                   Convert.ToString(reader("descricao")))

        'Adiciona funcao
        ret.Add(f)

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

  'Retorna lista de perfis para o comando informado
  Private Shared Function ListarPerfis(ByVal sql As String) As ArrayList

    Dim reader As SqlDataReader
    Dim ret As New ArrayList

    'Popula perfis
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(sql)

      While reader.Read()

        'Cria objeto perfilusuario
        Dim p As New PerfilUsuario(Convert.ToInt32(reader("id_perf")), _
                                   Convert.ToInt32(reader("contexto")), _
                                   Convert.ToString(reader("nome")), _
                                   Convert.ToString(reader("descricao")))

        'Adiciona perfil
        ret.Add(p)

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

#Region "Metodos publicos"

  'Retorna lista de funcoes para o contexto informado
  Public Shared Function ListarFuncoesContexto(ByVal idContexto As Integer) As ArrayList

    Dim sql As New String("select * from tbl_eventos_funcao_sistema where contexto = " & idContexto.ToString())

    Return ListarFuncoes(sql)

  End Function

  'Retorna lista de perfis para o contexto informado
  Public Shared Function ListarPerfisContexto(ByVal idContexto As Integer) As ArrayList

    Dim sql As New String("select * from tbl_perfil_acesso where excluido = 0 and contexto = " & idContexto.ToString())

    Return ListarPerfis(sql)

  End Function

  'Verifica a permissao para execucao de uma operacao 
  'para os perfis informados
  Public Shared Function ConsultarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal perfis() As Integer) As TipoPermissao

    Dim ret As TipoPermissao = TipoPermissao.Nenhuma

    'Testa perfis nulos
    If (perfis Is Nothing) Then Return ret

    If (perfis.Length = 0) Then Return ret

    'Testa usuario nao autenticado
    If (Not Usuario.UsuarioCorrente.Autenticado) Then Return ret

    'Monta consulta
    Dim i As Integer
    Dim perfs(perfis.Length - 1) As String

    For i = 0 To perfis.Length - 1
      perfs(i) = perfis(i).ToString()
    Next

    Dim C_SQL As String = "select somente_criador from " & _
                          "tbl_eventos_funcao_perfil fp inner join " & _
                          "tbl_eventos_funcao_sistema f on f.id_fnc = fp.id_fnc " & _
                          "where f.classe = @classe and f.operacao = @operacao and " & _
                          "fp.id_perf in ({0}) " & _
                          "order by somente_criador"
    C_SQL = String.Format(C_SQL, String.Join(",", perfs))

    'Cria parametros e reader
    Dim reader As SqlDataReader
    Dim pclasse As New SqlParameter("@classe", classe)
    Dim poperacao As New SqlParameter("@operacao", operacao)

    'Popula funcoes
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(C_SQL, pclasse, poperacao)

      If (reader.Read()) Then
        ret = IIf(Convert.ToInt32(reader(0)) = 1, TipoPermissao.ExecutarCriador, TipoPermissao.Executar)
      End If

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

  'Verifica se um grupo de perfis tem acesso para executar
  'determinada operacao
  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal perfis() As Integer) As Boolean

    'Consulta permissao
    Dim tipo As TipoPermissao = ConsultarPermissao(classe, operacao, perfis)

    Return (tipo = TipoPermissao.Executar)

  End Function

  'Verifica se um grupo de perfis tem acesso para executar
  'determinada operacao dado o criador do objeto da classe
  'informada
  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal perfis() As Integer, _
                                   ByVal idCriador As Integer) As Boolean

    'Consulta permissao
    Dim tipo As TipoPermissao = ConsultarPermissao(classe, operacao, perfis)

    Return (tipo = TipoPermissao.Executar) Or _
           (tipo = TipoPermissao.ExecutarCriador And idCriador = Usuario.UsuarioCorrente.Id)

  End Function

  'Verifica se um grupo de perfis tem acesso para executar
  'determinada operacao e dispara erro caso nao tenha permissao
  Public Shared Sub VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal perfis() As Integer)

    If (Not Permitido(classe, operacao, perfis)) Then
      NegarPermissao()
    End If

  End Sub

  'Verifica se um grupo de perfis tem acesso para executar
  'determinada operacao dado o criador do objeto da classe
  'informada e dispara erro caso nao tenha permissao
  Public Shared Sub VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal perfis() As Integer, _
                                            ByVal idCriador As Integer)

    If (Not Permitido(classe, operacao, perfis, idCriador)) Then
      NegarPermissao()
    End If

  End Sub


#End Region

End Class

Public Class GerenciadorPermissaoException
  Inherits SecurityException

  Public Sub New(ByVal msg As String)
    MyBase.New(msg)
  End Sub

End Class

