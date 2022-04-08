Imports System.Web.Mail
Imports System.Web.Security
Imports InformativoCRP
Imports CRPSP.Util

Partial Public Class _default1
  Inherits System.Web.UI.Page
  Private _usuario As Usuario

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ' verifica se eh primaira vez
    If (Not IsPostBack) Then

      ' carrega grid
      CarregaGrid()

      'grid de exportação
      '  CarregaGridExportarExcel()

    End If

    'apaga msg top da tela
    LblResultado.Visible = False

  End Sub

  Private Function CarregaGrid()

    ' carrega data grid
    GrdInscritos.DataSource = Usuario.Listar()
    GrdInscritos.DataBind()

  End Function
  Private Function CarregaGridExportarExcel()

    ' carrega data grid
    GrdExportExcel.DataSource = Usuario.Listar()
    GrdExportExcel.DataBind()

  End Function
  'Protected Sub ImgBtnSalvar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnSalvar.Click

  '  'insere participante
  '  Dim Usu As New Usuario

  '  Usu.Id = LblId.Text
  '  Usu.Crp = TxtCrp.Text.ToUpper
  '  Usu.Cpf = TxtCPF.Text.ToUpper
  '  Usu.Nome = TxtNomeCompleto.Text.ToUpper
  '  Usu.Email = TxtEmail.Text.ToUpper
  '  Usu.Cidade = TxtCidade.Text.ToUpper
  '  Usu.Telefone = TxtResidencial.Text.ToUpper
  '  Usu.Comercial = TxtComercial.Text.ToUpper
  '  Usu.Celular = TxtCelular.Text.ToUpper
  '  Usu.Titulacao = DrpTitulacao.SelectedItem.Value.ToUpper
  '  Usu.Instituicao = TxtInstituicao.Text.ToUpper


  '  ' se for novo item, insere

  '  If (Novo) Then

  '    Usu.Inserir()

  '    'msg de sucesso
  '    LblResultado.Visible = True
  '    LblResultado.Text = "Inserção realizada com sucesso!"

  '  Else

  '    Usu.Id = UsuId
  '    Usu.Alterar()

  '    'msg de sucesso
  '    LblResultado.Visible = True
  '    LblResultado.Text = "Alteração realizada com sucesso!"

  '  End If

  '  ' atualiza grid
  '  CarregaGrid()

  '  'limpar tela
  '  LimparTela()

  'End Sub

  Private Sub GrdInscritos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrdInscritos.PageIndexChanged
    GrdInscritos.CurrentPageIndex = e.NewPageIndex
    CarregaGrid()
  End Sub

  Private Sub GrdInscritos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdInscritos.SelectedIndexChanged
    Dim id As Integer = CType(GrdInscritos.Items(GrdInscritos.SelectedIndex).Cells(0).Text, Integer)
    Consultar(id)
  End Sub

  Private Sub AtualizaControles(ByVal id As Integer, ByVal crp As String, ByVal cpf As String, ByVal nome As String, ByVal logon As String, ByVal email As String, ByVal senha As String, ByVal cidade As String, ByVal telefone As String, ByVal comercial As String, ByVal celular As String, ByVal instituicao As String, ByVal possui_neces As String, ByVal baixa_visao As String, ByVal cegueira As String, ByVal surdez As String, ByVal defic_fisica As String, ByVal defic_intelectual As String, ByVal outra As String, ByVal outral_qual As String, ByVal neces_atend As String, ByVal braille As String, ByVal guia As String, ByVal libras As String, ByVal guia_inter As String, ByVal outro_meces As String, ByVal qual_atend As String, ByVal congresso As String)

    LblId.Text = id
    TxtCrp.Text = crp
    TxtCPF.Text = cpf
    TxtNomeCompleto.Text = nome
    TxtEmail.Text = email
    TxtCidade.Text = cidade
    TxtResidencial.Text = telefone
    TxtComercial.Text = comercial
    TxtCelular.Text = celular
    TxtInstituicao.Text = instituicao
    LblDeficiencia.Text = possui_neces
    LblBaixaVisao.Text = baixa_visao
    LblCegueira.Text = cegueira
    LblSurdez.Text = surdez
    LblDeficienciaFisica.Text = defic_fisica
    LblDeficienciaIntelectual.Text = defic_intelectual
    LblOutra.Text = outra
    LblQualOutra.Text = outral_qual
    LblRecurso.Text = neces_atend
    LblBraille.Text = braille
    LblGuia.Text = guia
    LblLibras.Text = libras
    LblGuiaInter.Text = guia_inter
    LblOutro.Text = outro_meces
    LblQualOutro.Text = qual_atend
    LblSenha.Text = senha
    LblCongresso.Text = congresso


  End Sub

  Private Sub Consultar(ByVal id As Integer)

    ' consulta objeto Participante
    Dim Usu As Usuario = Usuario.Consultar(id)

    ' atualiza controles
    AtualizaControles(Usu.Id, Usu.Crp, Usu.Cpf, Usu.Nome, Usu.Logon, Usu.Email, Usu.Senha, Usu.Cidade, Usu.Telefone, Usu.Comercial, Usu.Celular, Usu.Instituicao, Usu.Possui_neces, Usu.Baixa_visao, Usu.Cegueira, Usu.Surdez, Usu.Defic_fisica, Usu.Defic_intelectual, Usu.Outra, Usu.Outral_qual, Usu.Neces_atend, Usu.Braille, Usu.Guia, Usu.Libras, Usu.Guia_inter, Usu.Outro_meces, Usu.Qual_atend, Usu.Congresso)

    ' marca como registro existente
    Novo = False
    UsuId = id

  End Sub

  'Private Sub ImgBtnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnNovo.Click

  '  LimparTela()

  'End Sub

  'Private Sub ImgBtnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnExcluir.Click

  '  Dim Usu As New Usuario

  '  Usu.Id = UsuId

  '  'chama a funcao excluir
  '  Usu.Excluir()

  '  'carregar grid
  '  CarregaGrid()

  '  'limpar tela
  '  LimparTela()

  '  'msg de sucesso
  '  LblResultado.Visible = True
  '  LblResultado.Text = "Exclusão realizada com sucesso!"

  'End Sub

  Private Sub LimparTela()
    AtualizaControles(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
    Novo = True
  End Sub

#Region "Propriedaes"

  Public Property Novo() As Boolean
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

  Public Property UsuId() As Integer
    Get

      Return Convert.ToInt32(ViewState("_id"))

    End Get
    Set(ByVal Value As Integer)

      ViewState("_id") = Value

    End Set
  End Property

#End Region

  Sub exportarExcel(ByVal grid As DataGrid)

    ' O limite de linhas do Excel é  65536
    If grid.Items.Count.ToString + 1 < 65536 Then

      Dim g As New Guid

      grid.AllowPaging = False
      CarregaGridExportarExcel()

      Dim oResponse As System.Web.HttpResponse _
      = System.Web.HttpContext.Current.Response
      oResponse.ContentType = "application/vnd.ms-excel"

      Dim stringWrite As New System.IO.StringWriter
      Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
      Dim htmlForm As New HtmlForm

      oResponse.AddHeader("Content-Disposition", _
      "attachment; filename=Relatorio" + g.NewGuid.ToString + ".xls")

      Controls.Add(htmlForm)
      htmlForm.Controls.Add(grid)
      htmlForm.RenderControl(htmlWrite)
      oResponse.Write(stringWrite.ToString)
      oResponse.End()
      grid.AllowPaging = True
      grid.DataBind()

      'HttpContext.Current.Response.Clear()
      'HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
      'HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" & saveAsFile & ".xls")
      '' Remover caracteres do header - Content-Type
      'HttpContext.Current.Response.Charset = ""
      '' desabilita o  view state.
      'grid.EnableViewState = False
      'Dim tw As New System.IO.StringWriter()
      'Dim hw As New System.Web.UI.HtmlTextWriter(tw)
      'grid.RenderControl(hw)
      '' Escrever o html no navegador
      'HttpContext.Current.Response.Write(tw.ToString())
      '' termina o response
      'HttpContext.Current.Response.End()
    Else
      HttpContext.Current.Response.Write("Muitas linhas para exportar para o Exel !!!")
    End If

  End Sub

End Class