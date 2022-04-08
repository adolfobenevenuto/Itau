Imports InformativoCRP
Imports CRPSP.Util

Partial Public Class _default4
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ' verifica se eh primaira vez
    If (Not IsPostBack) Then

      ' carrega grid
      CarregaGrid(0)

      'grid de exportação
      '  CarregaGridExportarExcel()

    End If


    ''LblNome.Text = Usuario.UsuarioCorrente.Nome
    ''LblEmail.Text = Usuario.UsuarioCorrente.Email
    ''LblInstituicao.Text = Usuario.UsuarioCorrente.Instituicao
    'If Usuario.UsuarioCorrente.Id = 0 Then
    '  Response.Redirect("http://www.crpsp.org.br/cnp/sair.aspx")
    'End If



  End Sub

  Private Function CarregaGrid(ByVal xid_usu As Integer)

    ' carrega data grid
    GrdInscritos.DataSource = PropostaTese.Listar 'Trabalhos(xid_usu)
    GrdInscritos.DataBind()

  End Function

  
End Class