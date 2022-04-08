'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem a implementacao da classe PermissaoGlobal
'// para gerenciamento das permissoes de usuarios no sistema em um contexto
'// Global
'//
'// Data de Criacao : 21-06-2004
'//////////////////////////////////////////////////////////////////////////////

Public NotInheritable Class PermissaoTexto
  Inherits BasePermissao

  Private Shared Function ListarPerfis() As Integer()

    Dim sql As New String("select id_perf from tbl_artigo_perfil where id_usu = " & _
                          Usuario.UsuarioCorrente.Id.ToString() & " and id_art = " & _
                          1)

    Return BasePermissao.MontaPerfis("id_perf", sql, Nothing)

  End Function

  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal idUsuario As String) As Boolean

    Return GerenciadorPermissao.Permitido(classe, operacao, ListarPerfis())

  End Function

  Public Shared Function Permitido(ByVal classe As String, _
                                   ByVal operacao As String, _
                                   ByVal idUsuario As String, _
                                   ByVal idCriador As String) As Boolean

    Return GerenciadorPermissao.Permitido(classe, operacao, ListarPerfis(), idCriador)

  End Function

  Public Shared Function VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal idUsuario As String) As Boolean

    GerenciadorPermissao.VerificarPermissao(classe, operacao, ListarPerfis())

  End Function

  Public Shared Function VerificarPermissao(ByVal classe As String, _
                                            ByVal operacao As String, _
                                            ByVal idUsuario As String, _
                                            ByVal idCriador As String) As Boolean

    GerenciadorPermissao.VerificarPermissao(classe, operacao, ListarPerfis(), idCriador)

  End Function

End Class

