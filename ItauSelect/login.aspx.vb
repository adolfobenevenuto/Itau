Imports InformativoCRP
Imports CRPSP.Util

Partial Public Class login
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Private Sub BtnEntrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEntrar.Click


    'Autentica usuario e grava cookie de autenticacao
    Dim usu As Usuario = Usuario.Autenticar(TxtEmail.Text, TxtSenha.Text)

    If (usu.Autenticado) Then

      'Grava usuario na session
      SessaoInformativo.UsuarioCorrente = usu

      'Grava cookie de autenticacao e redireciona usuario
      FormsAuthentication.RedirectFromLoginPage(usu.Logon, False)

      'redireciona para página com o menu da esquerda
      Response.Redirect("trabalhos/")

    Else

      'exibe mensagem de erro
      NavegadorInformativo.ExibirMensagem("Atenção!", _
        "Usuário ou senha inválidos", _
        "login.aspx")

    End If

  End Sub

End Class