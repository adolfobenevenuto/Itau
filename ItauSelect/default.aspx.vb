Imports CRPSP.Util
Imports InformativoCRP

Partial Public Class _default
  Inherits System.Web.UI.Page
  Private _usuario As New Usuario
  Private _RodasOnline As New RodasOnline

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'If (Not IsPostBack) Then

    '  LblMsg.Visible = False

    'End If

    'BtnEntrar.Attributes.Add("onclick", "document.body.style.cursor = 'wait'; this.value='Aguarde, Enviando...'; this.disabled = true; " & Me.GetPostBackEventReference(BtnEntrar, String.Empty) & ";")


    ''If DRpGrupo1.SelectedItem.Value = "Não irei participar neste horário" Then


    ''  LblRoda1.Visible = False
    ''Else



   
  End Sub


  'Protected Sub BtnEntrar__Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEntrar.Click

  '  Response.Redirect("trabalhos/proposta.aspx")

  '  ''valida página
  '  'If Page.IsValid Then

  '  '  ''declara variavel cpf
  '  '  Dim xconsultarCFP, xconsultarEmail As String

  '  '  ''passa valor do cpf
  '  '  xconsultarCFP = TxtCPF.Text
  '  '  xconsultarEmail = TxtEmail.Text

  '  '  'testa CPF já foi cadastrado
  '  '  Try

  '  '    'consulta cpf
  '  '    _usuario = Usuario.ConsultarCPFCadastrado(xconsultarCFP, xconsultarEmail)

  '  '  Catch ex As Exception

  '  '    'cpf já cadastrado, msg de erro
  '  '    'LblCpf.Text = "CPF ou E-mail já cadastrado"
  '  '    Response.Redirect("CPF.htm")

  '  '  End Try

  '  '  'cria usuário 
  '  '  Dim Usu As New Usuario


  '  '  Usu.Crp = TxtCrp.Text
  '  '  Usu.Cpf = TxtCPF.Text
  '  '  Usu.Nome = TxtNome.Text
  '  '  Usu.Logon = TxtEmail.Text
  '  '  'TxtEmail.Text.ToUpper
  '  '  Usu.Email = TxtEmail.Text
  '  '  Usu.Senha = TxtSenha.Text
  '  '  Usu.Cidade = DrpCidade.SelectedItem.Value
  '  '  Usu.Telefone = TxtCelular.Text
  '  '  Usu.Comercial = "" 'TxtCelular.Text 'TxtComercial.Text.ToUpper
  '  '  Usu.Celular = "" 'TxtCelular.Text 'TxtCelular.Text.ToUpper
  '  '  Usu.Instituicao = TxtInstituicao.Text.ToUpper
  '  '  Usu.Possui_neces = "" 'IIf(RdoBtnDeficienciaNao.Checked = True, "NAO".ToUpper, "Sim".ToUpper)
  '  '  Usu.Baixa_visao = "" 'IIf(ChkBaixaVisao.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Cegueira = "" 'IIf(ChkCegueira.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Surdez = "" 'IIf(ChkSurdez.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Defic_fisica = "" 'IIf(ChkDeficienciaFisica.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Defic_intelectual = "" 'IIf(ChkDeficienciaIntelectual.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Outra = "" 'IIf(ChkOutradeficiencia.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Outral_qual = "" 'TxtQualDeficiencia.Text.ToUpper
  '  '  Usu.Neces_atend = "" 'IIf(RdoBtnRecursoNao.Checked = True, "NAO".ToUpper, "Sim".ToUpper)
  '  '  Usu.Braille = "" 'IIf(ChkBraille.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Guia = "" 'IIf(ChkGuia.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Libras = "" 'IIf(ChkLibras.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Guia_inter = "" 'IIf(ChkGuiaInter.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Outro_meces = "" 'IIf(ChkOutroRecurso.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Qual_atend = "" 'IIf(ChkBaixaVisao.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
  '  '  Usu.Congresso = "II Mostra de Práticas de Psicologia na Pandemia" 'xevento 'DropEvento.Text


  '  '  '  If (novo) Then

  '  '  'chama o metodo inserir
  '  '  Usu.InserirParticipante()

  '  '  'Autentica usuario e grava cookie de autenticacao
  '  '  Dim usu_ As Usuario = Usuario.Autenticar(TxtEmail.Text, TxtSenha.Text)

  '  '  If (usu_.Autenticado) Then

  '  '    'Grava usuario na session
  '  '    SessaoInformativo.UsuarioCorrente = usu_

  '  '    'Grava cookie de autenticacao e redireciona usuario
  '  '    FormsAuthentication.RedirectFromLoginPage(usu_.Logon, False)

  '  '    'redireciona para página com o menu da esquerda
  '  '    Response.Redirect("trabalhos/")



  '  '    'msg de sucesso
  '  '    '  LblMsg.Visible = True
  '  '    ' LblMsg.Text = "Sua inscrição como participante autora para o evento foi realizada com sucesso!"

  '  '    '      NavegadorInformativo.ExibirMensagem("Inscrição realizada com sucesso.", _
  '  '    '       "Sua inscrição como participante para o evento foi realizada com sucesso.", _
  '  '    '      "default.aspx")

  '  '    ' Else

  '  '    ''mostra msg de erro
  '  '    'Response.Redirect("erro.htm")

  '  '    'End If
  '  '  End If

  '  'Else

  '  '  ''msg de cpf inválido
  '  '  ' LblMsg.Visible = True
  '  '  '  Me.LblMsg.Text = "Preencha corretamente todos os campos de cadastro!"
  '  '  '  TxtCPF.TabIndex = 1
  '  '  Response.Redirect("CPF.htm")

  '  'End If

  'End Sub



  'Private Sub cvCPF_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvCPF.ServerValidate
  '  args.IsValid = VerificaCPF(Me.TxtCPF.Text.Trim)
  'End Sub

#Region "Verifica CPF"
  Public Function VerificaCPF(ByVal strCPFCliente As String) As Boolean

    '--Declaração das Variáveis
    Dim strCPFOriginal As String = strCPFCliente.Replace(".", "").Replace("-", "")
    Dim strCPF As String = Mid(strCPFOriginal, 1, 9)
    Dim strCPFTemp As String
    Dim intSoma As Integer
    Dim intResto As Integer
    Dim strDigito As String
    Dim intMultiplicador As Integer = 10
    Const constIntMultiplicador As Integer = 11
    Dim i As Integer
    '--------------------------

    For i = 0 To strCPF.ToString.Length - 1
      intSoma += CInt(strCPF.ToString.Chars(i).ToString) * intMultiplicador
      intMultiplicador -= 1
    Next

    If (intSoma Mod constIntMultiplicador) < 2 Then
      intResto = 0
    Else
      intResto = constIntMultiplicador - (intSoma Mod constIntMultiplicador)
    End If

    strDigito = intResto
    intSoma = 0

    strCPFTemp = strCPF & strDigito
    intMultiplicador = 11

    For i = 0 To strCPFTemp.Length - 1
      intSoma += CInt(strCPFTemp.Chars(i).ToString) * intMultiplicador
      intMultiplicador -= 1
    Next

    If (intSoma Mod constIntMultiplicador) < 2 Then
      intResto = 0
    Else
      intResto = constIntMultiplicador - (intSoma Mod constIntMultiplicador)
    End If

    strDigito &= intResto

    If strDigito = Mid(strCPFOriginal, 10, strCPFOriginal.Length) Then
      Return True
    Else
      Return False
    End If

  End Function

#End Region

#Region "Propriedades"
  Public Property novo() As Boolean
    Get
      If (ViewState("_novo") Is Nothing) Then
        ViewState("_novo") = True
      End If
      Return Convert.ToBoolean(ViewState("_novo"))
    End Get
    Set(ByVal Value As Boolean)
      ViewState("_novo") = Value
    End Set
  End Property

  Public Property CongID() As Integer
    Get
      Return Convert.ToInt32(ViewState("_id"))
    End Get
    Set(ByVal Value As Integer)
      ViewState("_id") = Value
    End Set
  End Property
#End Region


  'Private Sub BtnEntrarLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEntrarLogin.Click

  '  'If TxtEmail.Text = "eventos02@crpsp.org.br" Then

  '  If TxtEmailLogin.Text = "" Then
  '    LblMsg.Visible = True
  '    LblMsg.Text = "Preencha o campo E-mail!"
  '  Else
  '    If TxtSenhaLogin.Text = "" Then
  '      LblMsg.Visible = True
  '      LblMsg.Text = "Preencha o campo Senha!"

  '    Else

  '      'Autentica usuario e grava cookie de autenticacao
  '      Dim usu As Usuario = Usuario.Autenticar(TxtEmailLogin.Text, TxtSenhaLogin.Text)

  '      If (usu.Autenticado) Then

  '        'Grava usuario na session
  '        SessaoInformativo.UsuarioCorrente = usu

  '        'Grava cookie de autenticacao e redireciona usuario
  '        FormsAuthentication.RedirectFromLoginPage(usu.Logon, False)

  '        'redireciona para página com o menu da esquerda
  '        Response.Redirect("trabalhos/")

  '      Else

  '        LblMsg.Visible = True
  '        LblMsg.Text = "Usuário ou senha inválidos!"
  '        ' 'exibe mensagem de erro
  '        ' NavegadorInformativo.ExibirMensagem("Atenção!", _
  '        ' "Usuário ou senha inválidos", _
  '        '"default.aspx")

  '      End If

  '      'Else

  '      ''exibe mensagem de erro
  '      'Response.Redirect("default.aspx")

  '      '    End If


  '    End If
  '  End If

  'End Sub

  'Private Sub BtnInscrever_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInscrever.Click

  '  System.Threading.Thread.Sleep(5000)

  '  'valida página
  '  If TxtCpfInscricao.Text <> "" Then

  '    ''declara variavel cpf
  '    Dim xconsultarCFP, xconsultarEmail As String

  '    ''passa valor do cpf
  '    xconsultarCFP = TxtCpfInscricao.Text
  '    xconsultarEmail = TxtEmailInscricao.Text

  '    'testa CPF já foi cadastrado
  '    Try

  '      'consulta cpf
  '      _RodasOnline = RodasOnline.ConsultarCPFCadastrado(xconsultarCFP, xconsultarEmail)

  '    Catch ex As Exception

  '      'cpf já cadastrado, msg de erro
  '      'LblCpf.Text = "CPF ou E-mail já cadastrado"
  '      Response.Redirect("CPF.htm")

  '    End Try

  '    'cria usuário 
  '    Dim RodOn As New RodasOnline


  '    RodOn.Nome = TxtNomeInscricao.Text
  '    RodOn.Cpf = TxtCpfInscricao.Text
  '    RodOn.Profissao = DrpProfissao.SelectedItem.Value
  '    RodOn.Email = TxtEmailInscricao.Text
  '    RodOn.Celular = TxtCelularInscricao.Text 'TxtEmail.Text.ToUpper
  '    RodOn.Roda1 = DRpGrupo1.SelectedItem.Value
  '    RodOn.Roda2 = DRpGrupo2.SelectedItem.Value
  '    RodOn.Roda3 = DRpGrupo3.SelectedItem.Value
  '    RodOn.Roda4 = DRpGrupo4.SelectedItem.Value
  '    RodOn.Roda5 = DRpGrupo5.SelectedItem.Value
  '    RodOn.Libras = DrpLibras.SelectedItem.Value

  '    'Usu.Braille = "" 'IIf(ChkBraille.Checked = True, "Sim".ToUpper, "NAO".ToUpper)


  '    '  If (novo) Then

  '    'chama o metodo inserir
  '    RodOn.Inserir()

  '    'msg de sucesso
  '    LblMsg.Visible = True
  '    LblMsg.Text = "Sua inscrição como participante foi realizada com sucesso! Um email com informações de acesso ao Zoom será encaminhado, fique atento a sua pasta SPAM!"

  '    '      NavegadorInformativo.ExibirMensagem("Inscrição realizada com sucesso.", _
  '    '       "Sua inscrição como participante para o evento foi realizada com sucesso.", _
  '    '      "default.aspx")

  '    ' Else

  '    ''mostra msg de erro
  '    'Response.Redirect("erro.htm")

  '    'End If
  '  Else

  '    ''msg de cpf inválido
  '    LblMsg.Visible = True
  '    Me.LblMsg.Text = "CPF inválido!"
  '    TxtCpfInscricao.TabIndex = 1

  '  End If

  'End Sub

End Class