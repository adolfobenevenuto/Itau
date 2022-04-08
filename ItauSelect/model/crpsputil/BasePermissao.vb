'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem a implementacao da classe PermissaoGlobal
'// para gerenciamento das permissoes de usuarios no sistema em um contexto
'// Global
'//
'// Data de Criacao : 21-06-2004
'//////////////////////////////////////////////////////////////////////////////

Public MustInherit Class BasePermissao

  Protected Shared Function MontaPerfis(ByVal campo As String, _
                                        ByVal sql As String, _
                                        ByVal ParamArray params() As SqlParameter) As Integer()

    Dim reader As SqlDataReader
    Dim ret As New ArrayList

    'Popula funcoes
    Try

      'Abre reader
      reader = SqlHelper.ExecuteReader(sql, params)

      While reader.Read()

        'Adiciona funcao
        ret.Add(reader(campo))

      End While

      'Fecha reader
      reader.Close()

      Dim perfs(ret.Count - 1) As Integer

      ret.CopyTo(perfs)

      Return perfs

    Catch ex As Exception

      If (Not reader Is Nothing) Then
        If (Not reader.IsClosed) Then
          reader.Close()
        End If
      End If

      Throw ex

    End Try

  End Function


End Class
