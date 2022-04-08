'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem a implementacao da classe PermissaoGlobal
'// para gerenciamento das permissoes de usuarios no sistema em um contexto
'// Global
'//
'// Data de Criacao : 21-06-2004
'//////////////////////////////////////////////////////////////////////////////

Public NotInheritable Class PermissaoGlobal
  Inherits BasePermissao

  Private Shared Function ListarPerfis() As Integer()

        Dim sql As New String("select id_perf from tbl_2015_eventos_perfil where id_usu = " & _
                          Usuario.UsuarioCorrente.Id)

    Return BasePermissao.MontaPerfis("id_perf", sql, Nothing)

  End Function

  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String) As Boolean

    Return GerenciadorPermissao.Permitido(classe, operacao, ListarPerfis())

  End Function

  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal idCriador As String) As Boolean

    Return GerenciadorPermissao.Permitido(classe, operacao, ListarPerfis(), idCriador)

  End Function

  Public Shared Sub VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String)

    GerenciadorPermissao.VerificarPermissao(classe, operacao, ListarPerfis())

  End Sub

  Public Shared Sub VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal idCriador As String)

    GerenciadorPermissao.VerificarPermissao(classe, operacao, ListarPerfis(), idCriador)

  End Sub

End Class

