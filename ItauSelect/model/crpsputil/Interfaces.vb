'//////////////////////////////////////////////////////////////////////////////
'//
'// Este arquivo contem as definicoes de interfaces utilizadas na DLL
'// CRPSP.Util.dll.
'//
'// Data de Criacao : 23-04-2004
'// 
'//////////////////////////////////////////////////////////////////////////////

'Interface para classes tipo 'entity' que 
'contem operacoes de persistencia no banco de dados
Public Interface IEntidade

  Sub PopularDados(ByVal reader As IDataReader)

End Interface

'Interface para classes tipo 'colecao de entidade', ou seja,
'listas especializadas contendo objetos 'entity'
Public Interface IColecaoEntidade

  Sub Add(ByVal item As IEntidade)
  Function CriarEntidade() As IEntidade

End Interface


