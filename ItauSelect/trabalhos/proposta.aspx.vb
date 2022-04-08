Imports InformativoCRP
Imports CRPSP.Util
Imports System
Imports System.Text.RegularExpressions

Partial Public Class proposta
  Inherits System.Web.UI.Page

  Dim _PropostaTese As New PropostaTese

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '   Response.Redirect("https://cnp.cfp.org.br/sistema/11/login")

    'txtComment.Attributes.Add("onkeydown", "return getText(this, event);")
    'txtComment.Attributes.Add("onkeyup", "setText(this);")

    Dim texto As String
    texto = TxtResumo.Text
    ' Dim textoVazio As String = ""
    Dim quant As Long = WordCount(texto)
    ' Dim quantVazio As Long = WordCount(textoVazio)
    Console.WriteLine("Com palavras " & quant.ToString())
    LblQuantidadePalavras.Text = quant.ToString()
    '   Console.WriteLine("Vazio " & quantVazio.ToString())


  End Sub

  Public Function Main()

    Dim texto As String
    texto = TxtResumo.Text
    ' Dim textoVazio As String = ""
    Dim quant As Long = WordCount(texto)
    ' Dim quantVazio As Long = WordCount(textoVazio)
    Console.WriteLine("Com palavras " & quant.ToString())
    LblQuantidadePalavras.Text = quant.ToString()
    '   Console.WriteLine("Vazio " & quantVazio.ToString())
  End Function

  Private Shared Function WordCount(ByVal strInput As String) As Long
    Dim intCount As Long = 0

    For i As Integer = 1 To strInput.Length - 1

      If Char.IsWhiteSpace(strInput(i - 1)) = True Then

        If Char.IsLetterOrDigit(strInput(i)) = True OrElse Char.IsPunctuation(strInput(i)) Then
          intCount += 1
        End If
      End If
    Next

    If strInput.Length > 2 Then
      intCount += 1
    End If

    Return intCount
  End Function


  Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click

      If TxtResumo.Text = "" Then
        LblMsg.Visible = True
      LblMsg.Text = "Preencha o campo resumo!"

      Else
      If LblQuantidadePalavras.Text < 76 Then
        LblMsg.Visible = False

        'cria usuário 
        Dim ProTes As New PropostaTese


        ' Trab.Id_Trab = TxtCrp.Text
        ProTes.id_usu = Usuario.UsuarioCorrente.Id
        ProTes.evento = DrpEvento.SelectedItem.Value
        ProTes.regiao = DrpRegiao.SelectedItem.Value
        ProTes.eixo = DrpEixo.SelectedItem.Value
        ProTes.ambito = DrpAmbito.SelectedItem.Value
        ProTes.palavra1 = DrpPalavra1.SelectedItem.Value
        ProTes.palavra2 = DrpPalavra2.SelectedItem.Value
        ProTes.palavra3 = DrpPalavra3.SelectedItem.Value
        ProTes.proposta = TxtResumo.Text
        ProTes.Status = "PENDENTE"

        'chama o metodo inserir
        ProTes.Inserir()

        'msg de sucesso
        LblMsg.Visible = True
        LblMsg.Text = "Proposta encaminhada com sucesso."
        'NavegadorInformativo.ExibirMensagem("Inscrição realizada com sucesso.", _
        ' "Sua inscrição como participante para o evento foi realizada com sucesso.", _
        '"inscricoes.aspx")

      Else

        'msg de sucesso
        LblMsg.Visible = True
        LblMsg.Text = "Máximo de 75 palavras - Proposta não enviada!"

      End If 'Else


      'Try

      '_PropostaTese = TrabalhosMostra.ConsultarAutorCountComunicacao(Usuario.UsuarioCorrente.Id)


      '  If _trabalhosmostra.total >= 1 Then

      '    ' LblMsg.Visible = True
      '    '  LblMsg.Text = "Apenas uma comunicação oral por autor/a!"
      '    BtnEnviar.Enabled = False
      '    BtnEnviar.Text = "Você já enviou este trabalho"

      '  End If
      'Catch ex As Exception

      'End Try

      ''mostra msg de erro
      'Response.Redirect("erro.htm")

      'End If
      'Else

      ''msg de cpf inválido
      'LblCpf.Visible = True
      'Me.LblCpf.Text = "CPF inválido!"
      'TxtCPF.TabIndex = 1

      'End If

    End If

  End Sub
End Class