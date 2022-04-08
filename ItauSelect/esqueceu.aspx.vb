Imports System.Web.Mail
Imports System.Web.Security
Imports CRPSP.Util
Imports InformativoCRP

Partial Public Class esqueceu
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click

    'consulta usuario
    Dim usu As Usuario
    Dim mail As New MailMessage
    Dim msg As String

    Try

      usu = Usuario.Consultar(TxtEmail.Text)

      If usu Is Nothing Then

        'mensagem de erro
        LblResultado.Text = "E-mail não cadastrado!"

      Else
        'verifica dados do usuario
        If (usu.Email.ToUpper() = TxtEmail.Text.ToUpper()) Then

          Try
            If usu.Senha = "123456" Then
              EnviarEmail123456(usu.Nome, usu.Email, usu.Senha)
            Else
              EnviarEmail(usu.Nome, usu.Email, usu.Senha)
            End If

            'mensagem ok
            LblResultado.Text = "Sua mensagem foi enviada com sucesso!"

          Catch ex As Exception

            Throw ex

            'mensagem de erro
            LblResultado.Text = "Um erro ocorreu e sua senha não foi enviada para seu E-Mail." + vbCrLf + "Favor contacte o administrador do sistema."

          End Try

        Else

          'mensagem de erro
          LblResultado.Text = "Os dados informados para envio de senha não conferem!"


        End If

      End If

    Catch ex As Exception

      'mensagem ok
      LblResultado.Text = "Sua mensagem foi enviada com sucesso!"
      'Response.Redirect("erro.htm")

    End Try

  End Sub

  Public Function EnviarEmail123456(ByVal xnome As String, ByVal xemail As String, ByVal xsenha As String)

    'cria objeto com dados do e-mail 
    Dim objEmail As New System.Net.Mail.MailMessage()

    'remetente do e-mail 
    objEmail.From = New System.Net.Mail.MailAddress("eventos03@crpsp.org.br")

    'destinatários do e-mail 
    'objEmail.To.Add("webmaster@crpsp.org.br")
    objEmail.To.Add(xemail) '"abep@abepsi.org.br")

    'enviar cópia para 
    'objEmail.To.Add("Nome <email@dominio.com.br>")
    'enviar cópia oculta para 
    objEmail.Bcc.Add("eventos03@crpsp.org.br")

    'prioridade do e-mail 
    objEmail.Priority = System.Net.Mail.MailPriority.Normal

    'formato do e-mail HTML (caso não queira HTML alocar valor false) 
    objEmail.IsBodyHtml = True

    'título do e-mail 
    objEmail.Subject = "PSI Site do CRP SP - Esqueceu senha!"

    'corpo do e-mail 
    objEmail.Body = "<HTML><HEAD><TITLE>E-mail CRP SP</TITLE></HEAD><BODY vLink=#ff0000 aLink=#ff0000 link=#ff0000 bgColor=#ffffff><table width=100% border=0 cellpadding=0 cellspacing=0>  <tr>    <td colspan=2></td>  </tr>  <tr>    <td colspan=2></td>  </tr>  <tr>    <td colspan=2><FONT face='Arial, Helvetica, sans-serif' size=2>&nbsp;</FONT>      <blockquote><p><font size=2 face=Arial, Helvetica, sans-serif><B>Prezado(a) " + xnome + ",</B></font></p><p align=justify><FONT face='Arial, Helvetica, sans-serif' size=2>Sua senha provis&oacute;ria de acesso &eacute; <strong>" + xsenha + "</strong><br></FONT><FONT face='Arial, Helvetica, sans-serif' size=2><BR></FONT><em>Cordialmente,<BR>Webmaster CRP SP</em></p></blockquote></td>  </tr></table><br></BODY></HTML>"

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
      Response.Redirect("erro.htm")
      'NavegadorInformativo.ExibirMensagem("PSI Site da ABEP - ERRO!", _
      '  "Sua mensagem NÃO foi encaminhaminhada. Erro: " & ex.Message, _
      ' "contato.aspx")

      'Response.Write("Ocorreram problemas no envio do e-mail. Error = " & ex.Message)

    End Try

    'msg de sucesso
    NavegadorInformativo.ExibirMensagem("Mensagem encaminhada com sucesso!", _
       "Sua mensagem foi encaminhada com sucesso!", _
       "esqueceu.aspx")

    'excluímos o objeto de e-mail da memória 
    objEmail.Dispose()


  End Function

  Public Function EnviarEmail(ByVal xnome As String, ByVal xemail As String, ByVal xsenha As String)

    'cria objeto com dados do e-mail 
    Dim objEmail As New System.Net.Mail.MailMessage()

    'remetente do e-mail 
    objEmail.From = New System.Net.Mail.MailAddress("eventos03@crpsp.org.br")

    'destinatários do e-mail 
    'objEmail.To.Add("webmaster@crpsp.org.br")
    objEmail.To.Add(TxtEmail.Text) '"abep@abepsi.org.br")

    'enviar cópia para 
    'objEmail.To.Add("Nome <email@dominio.com.br>")
    'enviar cópia oculta para 
    objEmail.Bcc.Add(xemail)

    'prioridade do e-mail 
    objEmail.Priority = System.Net.Mail.MailPriority.Normal

    'formato do e-mail HTML (caso não queira HTML alocar valor false) 
    objEmail.IsBodyHtml = True

    'título do e-mail 
    objEmail.Subject = "PSI Site do CRP SP - Esqueceu senha!"

    'corpo do e-mail 
    objEmail.Body = "<HTML><HEAD><TITLE>E-mail CRP SP</TITLE></HEAD><BODY vLink=#ff0000 aLink=#ff0000 link=#ff0000 bgColor=#ffffff><table width=100% border=0 cellpadding=0 cellspacing=0>  <tr>    <td colspan=2></td>  </tr>  <tr>    <td colspan=2></td>  </tr>  <tr>    <td colspan=2><FONT face='Arial, Helvetica, sans-serif' size=2>&nbsp;</FONT>      <blockquote><p><font size=2 face=Arial, Helvetica, sans-serif><B>Prezado(a) " + xnome + ",</B></font></p><p align=justify><FONT face='Arial, Helvetica, sans-serif' size=2>Sua senha provis&oacute;ria de acesso &eacute; <strong>" + xsenha + "</strong><br></FONT><FONT face='Arial, Helvetica, sans-serif' size=2><BR></FONT><em>Cordialmente,<BR>Webmaster CRP SP</em></p></blockquote></td>  </tr></table><br></BODY></HTML>"

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
      NavegadorInformativo.ExibirMensagem("PSI Site do CRP SP - ERRO!", _
         "Sua mensagem NÃO foi encaminhaminhada. Erro: " & ex.Message, _
         "esqueceu.aspx")

      'Response.Write("Ocorreram problemas no envio do e-mail. Error = " & ex.Message)

    End Try

    'msg de sucesso
    NavegadorInformativo.ExibirMensagem("Mensagem encaminhada com sucesso!", _
       "Sua mensagem foi encaminhada com sucesso!", _
       "esqueceu.aspx")

    'excluímos o objeto de e-mail da memória 
    objEmail.Dispose()

  End Function


End Class