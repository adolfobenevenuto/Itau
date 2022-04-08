Imports InformativoCRP
Imports CRPSP.Util

Partial Public Class _default2__
  Inherits System.Web.UI.Page
  Dim _trabalhosmostra As New TrabalhosMostra

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ' Response.Redirect("https://cnp.cfp.org.br/sistema/11/login")

    '  If (Not IsPostBack) Then

    '    LblMsg.Visible = False

    '    TxtResumo.Attributes.Add("maxlength", "1500")

    '  End If

    '  Try

    LblUser.Text = Usuario.UsuarioCorrente.Nome

    If Usuario.UsuarioCorrente.Id = 0 Then
      Response.Redirect("../erro.htm")
    End If
    '    _trabalhosmostra = TrabalhosMostra.ConsultarAutorCountComunicacao(Usuario.UsuarioCorrente.Id)


    '    If _trabalhosmostra.total >= 2 Then

    '      LblMsg.Visible = True
    '      LblMsg.Text = "Inscrições encerradas, apenas duas comunicações orais por autor/a!"
    '      BtnEnviar.Enabled = False
    '      BtnEnviar.Text = "Não é possível enviar uma comunicação oral"

    '    End If
    '  Catch ex As Exception

    '  End Try


    '  LblNome.Text = Usuario.UsuarioCorrente.Nome
    '  LblEmail.Text = Usuario.UsuarioCorrente.Email
    '  LblInstituicao.Text = Usuario.UsuarioCorrente.Instituicao

    '  If Usuario.UsuarioCorrente.Id = 0 Then
    '    Response.Redirect("http://www.crpsp.org.br/cnp/sair.aspx")
    '  End If

    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click
    '  'valida página
    '  ' If Page.IsValid Then

    '  ''declara variavel cpf
    '  'Dim xconsultarCFP, xconsultarEmail As String

    '  ''passa valor do cpf
    '  'xconsultarCFP = TxtCPF.Text
    '  'xconsultarEmail = TxtEmail.Text

    '  ''testa CPF já foi cadastrado
    '  'Try

    '  '  'consulta cpf
    '  '  _usuario = Usuario.ConsultarCPFCadastrado(xconsultarCFP, xconsultarEmail)

    '  'Catch ex As Exception

    '  '  'cpf já cadastrado, msg de erro
    '  '  ' LblCpf.Text = "CPF ou E-mail já cadastrado"
    '  '  Response.Redirect("CPF.htm")

    '  'End Try

    '  'cria usuário 
    '  Dim Trab As New TrabalhosMostra


    '  ' Trab.Id_Trab = TxtCrp.Text
    '  Trab.id_usu = Usuario.UsuarioCorrente.Id
    '  Trab.Nome = LblNome.Text 'Usuario.UsuarioCorrente.Nome
    '  Trab.Logon = LblEmail.Text 'Usuario.UsuarioCorrente.Logon
    '  Trab.Instituicao = LblInstituicao.Text 'Usuario.UsuarioCorrente.Instituicao
    '  Trab.Titulo = TxtTitulo.Text
    '  Trab.eixo = DrpEixo.SelectedItem.Value
    '  Trab.Categoria = "COMUNICAÇÃO ORAL"
    '  Trab.Resumo = TxtResumo.Text
    '  Trab.Status = "ENVIADO"
    '  Trab.Id_Par = 1
    '  Trab.Linkvideo = ""
    '  Trab.Linkyoutube = ""
    '  Trab.Linkarquivo = ""
    '  Trab.Obs = ""
    '  Trab.Outros1 = TxtOutroAutor1.Text
    '  Trab.Emailoutros1 = TxtEmailOutroAutor1.Text
    '  Trab.Outros2 = TxtOutroAutor2.Text
    '  Trab.Emailoutros2 = TxtEmailOutroAutor2.Text
    '  Trab.Outros3 = TxtOutroAutor3.Text
    '  Trab.Emailoutros3 = TxtEmailOutroAutor3.Text
    '  Trab.Outros4 = TxtOutroAutor4.Text
    '  Trab.Emailoutros4 = TxtEmailOutroAutor4.Text
    '  Trab.Area = ""
    '  Trab.Processo = ""
    '  Trab.Classificacao = ""
    '  Trab.Comentario = ""

    '  'chama o metodo inserir
    '  Trab.Inserir()

    '  'msg de sucesso
    '  LblMsg.Visible = True
    '  LblMsg.Text = "Trabalho encaminhado com sucesso."
    '  'NavegadorInformativo.ExibirMensagem("Inscrição realizada com sucesso.", _
    '  ' "Sua inscrição como participante para o evento foi realizada com sucesso.", _
    '  '"inscricoes.aspx")

    '  'Else


    '  Try

    '    _trabalhosmostra = TrabalhosMostra.ConsultarAutorCountComunicacao(Usuario.UsuarioCorrente.Id)


    '    If _trabalhosmostra.total >= 1 Then

    '      ' LblMsg.Visible = True
    '      '  LblMsg.Text = "Apenas uma comunicação oral por autor/a!"
    '      BtnEnviar.Enabled = False
    '      BtnEnviar.Text = "Você já enviou uma comunicação oral"

    '    End If
    '  Catch ex As Exception

    '  End Try

    '  ''mostra msg de erro
    '  'Response.Redirect("erro.htm")

    '  'End If
    '  'Else

    '  ''msg de cpf inválido
    '  'LblCpf.Visible = True
    '  'Me.LblCpf.Text = "CPF inválido!"
    '  'TxtCPF.TabIndex = 1

    '  'End If
  End Sub
End Class