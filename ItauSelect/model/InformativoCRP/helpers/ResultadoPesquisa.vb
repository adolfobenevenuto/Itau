Imports System.Text.RegularExpressions

'Classe que representa um item no resultado de uma pesquisa
'realizada por um objeto de pesquisa
Public Class ResultadoPesquisa

#Region "Variaveis Membro"

  Private _id As Integer = 0
  Private _titulo As String = ""
  Private _fragmento As String = ""

#End Region

#Region "Construtor"

  Public Sub New(ByVal id As Integer, _
                 ByVal titulo As String, _
                 ByVal fragmento As String)

    _id = id
    _titulo = titulo
    _fragmento = fragmento

  End Sub


#End Region

#Region "Propriedades"

  Public ReadOnly Property Id() As Integer
    Get
      Return _id
    End Get
  End Property

  Public ReadOnly Property Titulo() As String
    Get
      Return _titulo
    End Get
  End Property

  Public ReadOnly Property Fragmento() As String
    Get
      Return _fragmento
    End Get
  End Property

#End Region

End Class


'Colecao de resultados de pesquisa
Public Class ColecaoResultadoPesquisa
  Inherits CollectionBase

#Region "Metodos publicos"

  Public Sub Add(ByVal item As ResultadoPesquisa)
    InnerList.Add(item)
  End Sub

  Default Public Overridable ReadOnly Property Item(ByVal indice As Integer) As ResultadoPesquisa
    Get
      Return CType(InnerList.Item(indice), ResultadoPesquisa)
    End Get
  End Property

#End Region

End Class
