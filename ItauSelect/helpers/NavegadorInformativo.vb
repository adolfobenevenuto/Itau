Public NotInheritable Class NavegadorInformativo

  Public Shared Sub ExibirMensagem(ByVal titulo As String, _
                                   ByVal complemento As String, _
                                   ByVal retorno As String)

    'Atribui valores para variaveis de sessao
    SessaoInformativo.MensagemTitulo = titulo
    SessaoInformativo.MensagemComplemento = complemento
    SessaoInformativo.MensagemURLRetorno = retorno

    'Redireciona para pagina de mensagem
    Dim app As String
    app = HttpContext.Current.Request.ApplicationPath
    HttpContext.Current.Response.Redirect(app + "/fr_msg.aspx", True)

  End Sub

End Class
