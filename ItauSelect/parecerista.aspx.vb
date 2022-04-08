Imports CRPSP.Util
Imports InformativoCRP

Partial Public Class parecerista
  Inherits System.Web.UI.Page
  Private _usuario As New Usuario

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Protected Sub btnentrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnentrar.Click
    'If TxtEmail.Text = "eventos02@crpsp.org.br" Then

    If TxtEmailLogin.Text = "" Then
      LblMsg.Visible = True
      LblMsg.Text = "Preencha o campo E-mail!"
    Else
      If TxtSenhaLogin.Text = "" Then
        LblMsg.Visible = True
        LblMsg.Text = "Preencha o campo Senha!"

      Else

        'Autentica usuario e grava cookie de autenticacao
        Dim usu As Usuario = Usuario.Autenticar(TxtEmailLogin.Text, TxtSenhaLogin.Text)

        If (usu.Autenticado) Then

          'Grava usuario na session
          SessaoInformativo.UsuarioCorrente = usu

          'Grava cookie de autenticacao e redireciona usuario
          FormsAuthentication.RedirectFromLoginPage(usu.Logon, False)

          'redireciona para página com o menu da esquerda
          Response.Redirect("parecerista/")

        Else

          LblMsg.Visible = True
          LblMsg.Text = "Usuário ou senha inválidos!"
          ' 'exibe mensagem de erro
          ' NavegadorInformativo.ExibirMensagem("Atenção!", _
          ' "Usuário ou senha inválidos", _
          '"default.aspx")

        End If

        'Else

        ''exibe mensagem de erro
        'Response.Redirect("default.aspx")

        '    End If


      End If
    End If
  End Sub
End Class