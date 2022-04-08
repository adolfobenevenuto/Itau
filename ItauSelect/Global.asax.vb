Imports System.Web
Imports System.Web.SessionState
Imports System.Security.Principal
Imports System.Web.Security
Imports InformativoCRP
Imports CRPSP.Util

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub


  Private Sub Application_AcquireRequestState(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.AcquireRequestState

    'Atualiza contexto de objetos de negocio
    If Not (SessaoInformativo.UsuarioCorrente Is Nothing) Then

      Usuario.UsuarioCorrente = SessaoInformativo.UsuarioCorrente

    End If

    If Not (SessaoInformativo.ComissaoCorrente Is Nothing) Then

      Comissao.ComissaoCorrente = SessaoInformativo.ComissaoCorrente

    End If

  End Sub

  Private Sub Global_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error

    'Verifica se o erro e de permissao
    Dim ex As Exception = Server.GetLastError()
    If (TypeOf ex Is GerenciadorPermissaoException) Then


      Dim url As String = String.Format("default.aspx?ReturnUrl={0}", _
        Server.UrlEncode(Request.Url.PathAndQuery))
      Response.Redirect(url)

    End If

  End Sub


End Class