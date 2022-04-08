Imports System.Web.Mail

'Envia e-mails usando as classes de email do .net
Public NotInheritable Class EnviaEmail

  Public Shared Function Enviar()

    Dim msg As New MailMessage

    'cria mensagem de e-mail
    'msg.BodyFormat = MailFormat.Html
    'msg.From = "cadastro@bancosocialpsi.org.br"
    'msg.Subject = txtAssunto.Text
    'msg.Priority = MailPriority.High
    'msg.To = r(_campoEmail)
    'msg.Body = SubstituirCampos(_html, r)

    'envia e-mail
    'SmtpMail.Send(msg)

  End Function

End Class
