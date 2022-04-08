Imports System.Text.RegularExpressions

'Base para classes de pesquisa
Public MustInherit Class BasePesquisa
  Implements IPesquisa

#Region "Variaveis Membro"

  Private _texto As String = ""
  Private _tipo As TipoPesquisa = TipoPesquisa.QualquerPalavra

#End Region

#Region "Metodos helper"

  Protected Sub PopularReader(ByVal colecao As ColecaoResultadoPesquisa, _
                              ByVal reader As IDataReader)

    'Deleta items
    colecao.Clear()

    'Loop pelo reader
    While (reader.Read())

      Dim item As ResultadoPesquisa = MontaResultado(reader)
      colecao.Add(item)

    End While

  End Sub

  Protected Function ExtrairFragmento(ByVal conteudo As String, _
                                      ByVal tamanho As Integer) As String

    Dim palavras() As String = Me.TextoProcurado.Split(" ")
    Dim palavra As String
    Dim match As Match

    'Se o fragmento eh menor do que o tamanho desejado,
    'retorna todo o conteudo
    If (conteudo.Length <= tamanho) Then
      Return conteudo
    End If

    'Verifica tipo de pesquisa
    If (Me.TipoPesquisa = TipoPesquisa.FraseExata) Then

      'Procura substring
      match = Regex.Match(conteudo, Me.TextoProcurado, RegexOptions.IgnoreCase)

      If (match.Success) Then
        If (match.Index >= CInt(tamanho / 2)) Then
          Return conteudo.Substring(match.Index - CInt(tamanho / 2), tamanho)
        Else
          Return conteudo.Substring(0, tamanho)
        End If
      End If

    Else

      'Procura qualquer uma das palavras e retorna
      For Each palavra In palavras
        match = Regex.Match(conteudo, palavra, RegexOptions.IgnoreCase)
        If (match.Success) Then
          If (match.Index >= CInt(tamanho / 2)) Then
            Return conteudo.Substring(match.Index - CInt(tamanho / 2), tamanho)
          Else
            Return conteudo.Substring(0, tamanho)
          End If
        End If
      Next

    End If

    Return conteudo.Substring(0, tamanho)

  End Function

  Protected Function MontarClausulaWhere(ByVal campo As String) As String

    Dim palavras() As String

    'Verifica consulta nula
    If (Me.TextoProcurado = "") Then
      Return " (1=1) "
    End If

    'Monta clausula where
    Select Case Me.TipoPesquisa

      Case TipoPesquisa.FraseExata

        Return " (" + campo + " like @frase) "

      Case TipoPesquisa.QualquerPalavra

        palavras = Me.TextoProcurado.Split(" ")

        Return " (" + campo + " like @" + String.Join(" or " + campo + " like @", palavras) + ") "

      Case TipoPesquisa.TodasAsPalavras

        palavras = Me.TextoProcurado.Split(" ")

        Return " (" + campo + " like @" + String.Join(" and " + campo + " like @", palavras) + ") "

    End Select

  End Function

  Protected Function MontarParametros() As SqlParameter()

    Dim ret As New ArrayList
    Dim palavras() As String = Me.TextoProcurado.Split(" ")
    Dim palavra As String

    If (TipoPesquisa = TipoPesquisa.FraseExata) Then

      'Adiciona parametro frase
      Dim p As New SqlParameter("@frase", SqlDbType.VarChar)
      p.Value = "%" + Me.TextoProcurado + "%"
      ret.Add(p)

    Else

      'Adiciona parametros
      For Each palavra In palavras
        Dim p As New SqlParameter("@" + palavra, SqlDbType.VarChar)
        p.Value = "%" + palavra + "%"
        ret.Add(p)
      Next

    End If

    'Retorno
    If (ret.Count = 0) Then
      Return Nothing
    End If

    Return CType(ret.ToArray(GetType(SqlParameter)), SqlParameter())

  End Function

  Protected Function PesquisarSQL(ByVal sql As String, _
                                  ByVal ParamArray params() As SqlParameter) As ColecaoResultadoPesquisa

    'Abre reader
    Dim reader As SqlDataReader

    reader = SqlHelper.ExecuteReader(sql, params)

    'Monta colecao de resultados
    Try

      Dim ret As New ColecaoResultadoPesquisa

      PopularReader(ret, reader)

      Return ret

    Catch ex As Exception

      Throw ex

    Finally

      reader.Close()

    End Try

  End Function


#End Region

#Region "Metodos abstratos"

  Public MustOverride Function Pesquisar() As ColecaoResultadoPesquisa Implements IPesquisa.Pesquisar

  Protected MustOverride Function MontaResultado(ByVal record As IDataRecord) As ResultadoPesquisa

#End Region

#Region "Propriedades"

  Public Property TextoProcurado() As String Implements IPesquisa.TextoProcurado
    Get
      Return _texto
    End Get
    Set(ByVal Value As String)
      _texto = Value
    End Set
  End Property
  Public Property TipoPesquisa() As TipoPesquisa Implements IPesquisa.TipoPesquisa
    Get
      Return _tipo
    End Get
    Set(ByVal Value As TipoPesquisa)
      _tipo = Value
    End Set
  End Property

#End Region

End Class
