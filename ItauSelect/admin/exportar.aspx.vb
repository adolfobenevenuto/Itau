Imports InformativoCRP
Imports CRPSP.Util

Partial Public Class exportar
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'CARREGAR GRID
    CarregaGridExportarExcel()

  End Sub

  Private Function CarregaGridExportarExcel()

    ' carrega data grid
    GrdExportExcel.DataSource = Usuario.Listar()
    GrdExportExcel.DataBind()

  End Function

  Sub exportarExcel(ByVal grid As DataGrid)

    ' O limite de linhas do Excel é  65536
    If grid.Items.Count.ToString + 1 < 65536 Then

      Dim g As New Guid

      grid.AllowPaging = False
      CarregaGridExportarExcel()

      Dim oResponse As System.Web.HttpResponse _
      = System.Web.HttpContext.Current.Response
      oResponse.ContentType = "application/vnd.ms-excel"

      'objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

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

  Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    exportarExcel(GrdExportExcel)
  End Sub
End Class