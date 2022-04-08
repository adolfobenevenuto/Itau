Imports CRPSP.Util
Imports InformativoCRP

Partial Public Class sair
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    'limpa usuario da session
    SessaoInformativo.LimparSessao()

    FormsAuthentication.SignOut()

    Response.Redirect("http://www.crpsp.org.br/cnp/")


  End Sub

End Class