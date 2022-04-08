Imports System.Text.RegularExpressions

Public NotInheritable Class WebUtil

  Public Shared Function SafeToInt32(ByVal val As Object, ByVal defVal As Integer) As Integer

    Try

      Return Convert.ToInt32(val)

    Catch ex As Exception

      Return defVal

    End Try

  End Function

  Public Shared Function GetSafeParamString(ByVal paramName As String) As String

    Dim param As String
    param = Convert.ToString(HttpContext.Current.Request.Params.Item(paramName))
    Return HttpContext.Current.Server.UrlDecode(param)

  End Function

  Public Shared Function GetSafeParamInt32(ByVal paramName As String) As Integer

    Dim param As Integer
    Return Convert.ToInt32(HttpContext.Current.Request.Params.Item(paramName))

  End Function

  Public Shared Function DecorateSearchText(ByVal source As String, _
                                            ByVal searchedText As String, _
                                            ByVal prefix As String, _
                                            ByVal suffix As String) As String

    Dim ret As String = IIf(source Is Nothing, "", source)
    Dim words() As String = searchedText.Split(" ")
    Dim word As String
    Dim dec As New Decorator

    dec.Prefix = prefix
    dec.Suffix = suffix

    For Each word In words

      'Replace parameters
      ret = Regex.Replace(ret, Regex.Escape(word), dec.Evaluator, RegexOptions.IgnoreCase)

    Next

    Return ret

  End Function

  Public Shared Function FormatHtmlText(ByVal text As String)

    Return text.Replace(vbCrLf, "<br />").Replace(" ", "&nbsp;")

  End Function

#Region "Classes internas"

  Private Class Decorator

    Private _prefix As String
    Private _suffix As String
    Private _evaluator As MatchEvaluator

    Public Sub New()

      _evaluator = New MatchEvaluator(AddressOf Me.ReplaceMatch)

    End Sub

    Private Function ReplaceMatch(ByVal match As Match) As String

      Return _prefix + match.Value + _suffix

    End Function

    Public Property Prefix() As String
      Get
        Return _prefix
      End Get
      Set(ByVal Value As String)
        _prefix = Value
      End Set
    End Property

    Public Property Suffix() As String
      Get
        Return _suffix
      End Get
      Set(ByVal Value As String)
        _suffix = Value
      End Set
    End Property

    Public ReadOnly Property Evaluator() As MatchEvaluator
      Get
        Return _evaluator
      End Get
    End Property

  End Class

#End Region

End Class


