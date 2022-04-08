Imports InformativoCRP
Imports CRPSP.Util

Partial Public Class _default3
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    'limpa usuario da session
    SessaoInformativo.LimparSessao()

    FormsAuthentication.SignOut()

    Response.Redirect("../default.aspx")

  End Sub


End Class