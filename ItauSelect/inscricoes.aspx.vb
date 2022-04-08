Imports CRPSP.Util
Imports InformativoCRP

Partial Public Class inscricoes
  Inherits System.Web.UI.Page
  Private _usuario As Usuario
  Dim xevento As String
  Dim xlimite As Integer


  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ''verifica evento cadastrado
    ''  Try

    'verifica o evento
    VerEvento()

    RdoBtnEncEstudante17.Checked = False
    RdoBtnEncEstudante17.Enabled = False
    RdoBtnEncEstudante17.Text = "1/7 - Encontros com Estudantes às 17h - <font color=red><strong> Atividade já realizada!</strong></font>"


    _usuario = Usuario.ConsultarCongressoRodolfo(xevento)

    If _usuario.Totalinscritos >= xlimite Then


 


      If xevento = "2/7 - Encontros com Professoras/es-Supervisoras/es às 17h" Then
        RdoBtnEncProfessores17.Checked = False
        RdoBtnEncProfessores17.Enabled = False
        RdoBtnEncProfessores17.Text = "2/7 - Encontros com Professoras/es-Supervisoras/es às 17h - <font color=red><strong> Atividade já realizada!</strong></font>"
      End If


      '    Response.Redirect("esgotadas.aspx")

    Else

      'DropEvento.Visible = True
      BtnEnviar.Visible = True


    End If


    ''    Catch ex As Exception

    ''  'cpf já cadastrado, msg de erro
    ''  ' LblCpf.Text = "CPF ou E-mail já cadastrado"
    ''  Response.Redirect("CPF.htm")

    ''End Try


  End Sub

    Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click

        'valida página
        ' If Page.IsValid Then

        ''declara variavel cpf
        'Dim xconsultarCFP, xconsultarEmail As String

        ''passa valor do cpf
        'xconsultarCFP = TxtCPF.Text
        'xconsultarEmail = TxtEmail.Text

        ''testa CPF já foi cadastrado
        'Try

        '  'consulta cpf
        '  _usuario = Usuario.ConsultarCPFCadastrado(xconsultarCFP, xconsultarEmail)

        'Catch ex As Exception

        '  'cpf já cadastrado, msg de erro
        '  ' LblCpf.Text = "CPF ou E-mail já cadastrado"
        '  Response.Redirect("CPF.htm")

        'End Try

        'cria usuário 
        Dim Usu As New Usuario


        Usu.Crp = TxtCrp.Text.ToUpper
        Usu.Cpf = TxtCPF.Text.ToUpper
        Usu.Nome = TxtNomeCompleto.Text.ToUpper
        Usu.Logon = "NÃO SELECIONAADO"
        'TxtEmail.Text.ToUpper
        Usu.Email = TxtEmail.Text.ToUpper
        Usu.Senha = "No Have".ToUpper
        Usu.Cidade = TxtCidade.Text.ToUpper
        Usu.Telefone = TxtResidencial.Text.ToUpper
        Usu.Comercial = TxtComercial.Text.ToUpper
        Usu.Celular = TxtCelular.Text.ToUpper
        Usu.Instituicao = TxtInstituicao.Text.ToUpper
        Usu.Possui_neces = IIf(RdoBtnDeficienciaNao.Checked = True, "NAO".ToUpper, "Sim".ToUpper)
        Usu.Baixa_visao = IIf(ChkBaixaVisao.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Cegueira = IIf(ChkCegueira.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Surdez = IIf(ChkSurdez.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Defic_fisica = IIf(ChkDeficienciaFisica.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Defic_intelectual = IIf(ChkDeficienciaIntelectual.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Outra = IIf(ChkOutradeficiencia.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Outral_qual = TxtQualDeficiencia.Text.ToUpper
        Usu.Neces_atend = IIf(RdoBtnRecursoNao.Checked = True, "NAO".ToUpper, "Sim".ToUpper)
        Usu.Braille = IIf(ChkBraille.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Guia = IIf(ChkGuia.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Libras = IIf(ChkLibras.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Guia_inter = IIf(ChkGuiaInter.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Outro_meces = IIf(ChkOutroRecurso.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
        Usu.Qual_atend = IIf(ChkBaixaVisao.Checked = True, "Sim".ToUpper, "NAO".ToUpper)
    Usu.Congresso = xevento 'DropEvento.Text


        If (novo) Then

            'chama o metodo inserir
            Usu.InserirParticipante()

            'msg de sucesso
            NavegadorInformativo.ExibirMensagem("Inscrição realizada com sucesso.", _
              "Sua inscrição como participante para o evento foi realizada com sucesso.", _
              "inscricoes.aspx")

        Else

            'mostra msg de erro
            Response.Redirect("erro.htm")

        End If
        'Else

        ''msg de cpf inválido
        'LblCpf.Visible = True
        'Me.LblCpf.Text = "CPF inválido!"
        'TxtCPF.TabIndex = 1

        'End If

  End Sub

  Public Function VerEvento()

    If RdoBtnEncEstudante17.Checked = True Then
      xevento = "1/7 - Encontros com Estudantes às 17h"
      xlimite = 40
      LblTexto.Text = "Registro da/o Aluna/o (obrigatório)"
    End If

    If RdoBtnEncProfessores17.Checked = True Then
      xevento = "2/7 - Encontros com Professoras/es-Supervisoras/es às 17h"
      xlimite = 40
      LblTexto.Text = "Número do CRP (obrigatório)"
    End If
 
  End Function

  Private Sub cvCPF_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvCPF.ServerValidate
    args.IsValid = VerificaCPF(Me.TxtCPF.Text.Trim)
  End Sub

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


End Class