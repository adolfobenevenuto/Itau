'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem a implementacao da classe PermissaoGlobal
'// para gerenciamento das permissoes de usuarios no sistema em um contexto
'// Global
'//
'// Data de Criacao : 21-06-2004
'//////////////////////////////////////////////////////////////////////////////

Public NotInheritable Class PermissaoForum

  Private Shared Function ListarPerfis(ByVal idUsuario As Integer) As Integer()

        Dim sql As New String("select id_perf from tbl_2015_eventos_perfil where id_usu = " & idUsuario.ToString())
    Dim reader As SqlDataReader
    Dim ret As New ArrayList

    'Popula funcoes
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(sql)

      While reader.Read()

        'Adiciona funcao
        ret.Add(reader("id_perf"))

      End While

      'Fecha reader
      reader.Close()

      Dim perfs(ret.Count) As Integer

      ret.CopyTo(perfs)

      Return perfs

    Catch ex As Exception

      If (Not reader Is Nothing) Then
        If (Not reader.IsClosed) Then
          reader.Close()
        End If
      End If

      Throw ex

    End Try

  End Function

  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal idUsuario As String) As Boolean

    Return GerenciadorPermissao.Permitido(classe, operacao, ListarPerfis(idUsuario))

  End Function

  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal idUsuario As String, _
                                   ByVal idCriador As String) As Boolean

    Return GerenciadorPermissao.Permitido(classe, operacao, ListarPerfis(idUsuario), idCriador)

  End Function

  Public Shared Function VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal idUsuario As String) As Boolean

    GerenciadorPermissao.VerificarPermissao(classe, operacao, ListarPerfis(idUsuario))

  End Function

  Public Shared Function VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal idUsuario As String, _
                                            ByVal idCriador As String) As Boolean

    GerenciadorPermissao.VerificarPermissao(classe, operacao, ListarPerfis(idUsuario), idCriador)

  End Function

End Class

