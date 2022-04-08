'//////////////////////////////////////////////////////////////////////////////
'//
'// Este arquivo contem as definicoes de interfaces utilizadas no sistema
'// Informativo CRP SP.
'//
'// Data de Criacao : 19-07-2004
'// 
'//////////////////////////////////////////////////////////////////////////////

'Interface para pesquisa de objetos no estilo WEB SEARCH
Public Interface IPesquisa

  Function Pesquisar() As ColecaoResultadoPesquisa

  Property TextoProcurado() As String
  Property TipoPesquisa() As TipoPesquisa

End Interface
