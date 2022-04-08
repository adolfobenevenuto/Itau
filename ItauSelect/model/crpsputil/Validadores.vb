'//////////////////////////////////////////////////////////////////////////////
'//
'// Este arquivo contem classes de apoio para utilizacao no sistema
'// Informativo CRP SP.
'//
'// Data de Criacao : 23-04-2004
'// 
'//////////////////////////////////////////////////////////////////////////////

'Imports
Imports System.Text.RegularExpressions
Imports System.Reflection

'Classe para validacao de enderecos de E-Mail. 
'Apesar de ter funcionalidade redundante (pois ja existem validadores 
'prontos na camada visual), eh necessaria pois cada objeto deve garantir
'que seus dados de e-mail estejam validos
Public NotInheritable Class ValidadorEMail

#Region "Validacao"

  'Verifica se um endereco de e-mail eh valido.
  'Se o endereco for valido, retorna true, senao
  'retorna false
  Public Shared Function Valido(ByVal endereco As String) As Boolean

    'testa validade do endereco de e-mail
    Return Regex.IsMatch(endereco, "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")

  End Function

  'Verifica se um endereco de e-mail eh valido e caso
  'nao seja, dispara um erro
  Public Shared Sub Validar(ByVal endereco As String)

    'dispara erro se o e-mail nao for valido
    If (Not Valido(endereco)) Then
      Throw New Exception("O endereço de E-Mail informado não é válido.")
    End If

  End Sub

#End Region

End Class


'Classe para validacao de enderecos de web sites. 
'Apesar de ter funcionalidade redundante (pois ja existem validadores 
'prontos na camada visual), eh necessaria pois cada objeto deve garantir
'que seus enderecos de web site estejam validos
Public NotInheritable Class ValidadorWebSite

#Region "Validacao"

  'Verifica se um endereco de web site eh valido.
  'Se o endereco for valido, retorna true, senao
  'retorna false
  Public Shared Function Valido(ByVal endereco As String) As Boolean

    'testa validade do endereco de web sites
    Return Regex.IsMatch(endereco, "http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?") Or Regex.IsMatch(endereco, "https://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")

  End Function

  'Verifica se um endereco de web sites eh valido e caso
  'nao seja, dispara um erro
  Public Shared Sub Validar(ByVal endereco As String)

    'dispara erro se o web site nao for valido
    If (Not Valido(endereco)) Then
      Throw New Exception("O Web Site informado não é válido.")
    End If

  End Sub

#End Region

End Class