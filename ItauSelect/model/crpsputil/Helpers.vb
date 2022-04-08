'//////////////////////////////////////////////////////////////////////////////
'//
'// Este arquivo contem classes de apoio para utilizacao no sistema
'// Informativo CRP SP.
'//
'// Data de Criacao : 23-04-2004
'// 
'//////////////////////////////////////////////////////////////////////////////

'Imports
Imports System.Reflection

'Classe para popular listas a partir de dados
'provenientes de diversas fontes
Public NotInheritable Class ListaHelper

  'Cria um ArrayList contendo objetos DbDataRecord
  'a partir de uma consulta SQL. 
  'ATEN플O !!! Pode se tornar lento em caso de muitos registros
  Public Shared Function ListarRegistros(ByVal comandoSQL As String) As IList

    'executa consulta
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.Text, _
                                                          comandoSQL)
    Try

      'chama overload
      Dim ret As IList = ListarRegistros(reader)

      Return ret

    Catch ex As Exception
      Throw ex
    Finally
      reader.Close()
    End Try


  End Function

  'Cria um ArrayList contendo objetos DbDataRecord
  'a partir dos dados de um DataReader. 
  'ATEN플O !!! Pode se tornar lento em caso de muitos registros
  Public Shared Function ListarRegistros(ByVal reader As IDataReader) As IList

    'cria enumerador
    Dim val As IEnumerator = CType(reader, IEnumerable).GetEnumerator()

    'cria ArrayList que sera retornado
    Dim ret As New ArrayList

    'testa de o enumerador esta nulo
    If (Not val Is Nothing) Then

      'loop pelo reader para popular o ArrayList
      While (val.MoveNext())
        ret.Add(val.Current)
      End While

    End If

    'retorno da funcao (nunca retorna nulo)
    Return ret

  End Function

End Class

'Classe para popular colecoes a partir de dados
'provenientes de diversas fontes
Public NotInheritable Class ColecaoHelper

  'Popula uma colecao especializada de objetos que
  'implementem a interface IEntidade a partir de uma consulta SQL.
  'A colecao a ser populada deve implementar a interface IColecaoEntidade
  'ATEN플O !!! A performance deste metodo depende totalmente da implementacao
  'do metodo PopularDados do objeto que implementa a interface IEntidade,
  'porem, tomando uma implementacao basica como exemplo, este metodo eh muito 
  'mais rapido do que o metodo ListaRegistros (pois nao usamos IEnumerator...)
  Public Shared Function PopularColecaoEntidade(ByVal comandoSQL As String, _
                                               ByVal colecao As IColecaoEntidade, _
                                               ByVal excluiItens As Boolean, _
                                               ByVal ParamArray parameters() As SqlParameter) As IColecaoEntidade

    'executa consulta
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(comandoSQL, parameters)
    Try

      'chama overload
      Return PopularColecaoEntidade(reader, colecao, excluiItens)

    Catch ex As Exception
      Throw ex
    Finally
      reader.Close()
    End Try

  End Function

  'Popula uma colecao especializada de objetos que
  'implementem a interface IEntidade a partir de um datareader.
  'A colecao a ser populada deve implementar a interface IColecaoEntidade
  'ATEN플O !!! A performance deste metodo depende totalmente da implementacao
  'do metodo PopularDados do objeto que implementa a interface IEntidade,
  'porem, tomando uma implementacao basica como exemplo, este metodo eh muito 
  'mais rapido do que o metodo ListaRegistros (pois nao usamos IEnumerator...)
  Public Shared Function PopularColecaoEntidade(ByVal reader As IDataReader, _
                                          ByVal colecao As IColecaoEntidade, _
                                          ByVal excluiItens As Boolean) As IColecaoEntidade

    'verifica se a colecao recebida eh nula
    If (colecao Is Nothing) Then Return Nothing

    'verifica se devemos limpar a colecao atual
    If (excluiItens) Then
      Dim mi As MethodInfo
      Try
        mi = CType(colecao, Object).GetType().GetMethod("Clear")
      Catch amex As AmbiguousMatchException
      Catch ex As Exception
        Throw ex
      End Try

      If (Not mi Is Nothing) Then
        mi.Invoke(colecao, Nothing)
      End If
    End If

    'loop pelo reader para popular o ArrayList
    While (reader.Read())

      'cria novo objeto
      Dim novo As IEntidade = colecao.CriarEntidade()

      'popula dados do objeto com os dados do recordset
      novo.PopularDados(reader)

      'adiciona novo objeto a colecao
      colecao.Add(novo)

    End While

    Return colecao

  End Function

End Class
