Partial Public Class trabalhos
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Protected Sub BtnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click

    'cria objeto com dados do e-mail 
    Dim objEmail As New System.Net.Mail.MailMessage()

    'remetente do e-mail 
    objEmail.From = New System.Net.Mail.MailAddress("site@crpsp.org.br")

    'destinatários do e-mail 
    'objEmail.To.Add("webmaster@crpsp.org.br")
    objEmail.To.Add("comunicacao02@crpsp.org.br")

    'enviar cópia para 
    'objEmail.To.Add("Nome <email@dominio.com.br>")
    'enviar cópia oculta para 
    'objEmail.Bcc.Add("Nome <email@dominio.com.br>")

    'prioridade do e-mail 
    objEmail.Priority = System.Net.Mail.MailPriority.Normal

    'formato do e-mail HTML (caso não queira HTML alocar valor false) 
    objEmail.IsBodyHtml = True

    'título do e-mail 
    objEmail.Subject = "INSCRIÇÃO DE TRABALHO - EVENTO "

    'corpo do e-mail 
    objEmail.Body = "Nome: " + TxtNome.Text + "<br><br> CPF: " + Txtcpf.Text + "<br /><br />Telefone: " + Txttelefone.Text + "<br><br>E-mail: " + TxtEmail.Text + "<br><br> Mensagem: " + TxtMsg.Text

    ' Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
    objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
    objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

    'cria objeto com os dados do SMTP 
    Dim objSmtp As New System.Net.Mail.SmtpClient

    'alocamos o endereço do host para enviar os e-mails, localhost(recomendado) ou smtp2.locaweb.com.br 
    objSmtp.Host = "smtp2.locaweb.com.br"

    'enviamos o e-mail através do método .Send() 
    Try
      objSmtp.Send(objEmail)

      '  Response.Write("E-mail enviado com sucesso !")

    Catch ex As Exception

      'msg de sucesso
      NavegadorInformativo.ExibirMensagem("PSI Site do CRPSP - ERRO!", _
         "Sua mensagem NÃO foi encaminhaminhada. Erro: " & ex.Message, _
         "faleconosco.aspx")

      'Response.Write("Ocorreram problemas no envio do e-mail. Error = " & ex.Message)

    End Try

    'msg de sucesso
    NavegadorInformativo.ExibirMensagem("Mensagem encaminhada com sucesso!", _
       "Sua mensagem foi encaminhada com sucesso!", _
       "faleconosco.aspx")

    'excluímos o objeto de e-mail da memória 
    objEmail.Dispose()

  End Sub

End Class