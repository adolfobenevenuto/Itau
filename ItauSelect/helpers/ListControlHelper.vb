'Classe com metodos auxiliares para facilitar a utilizacao de
'combos e listboxes
Public NotInheritable Class ListControlHelper

#Region "Static Methods"

  Private Shared Sub SelectItem(ByVal list As ListControl, ByVal item As ListItem, ByVal singleSelection As Boolean)

    If (item Is Nothing) Then
      list.SelectedIndex = -1
      Return
    End If

    item.Selected = True

    If singleSelection Then
      list.SelectedIndex = list.Items.IndexOf(item)
    End If

  End Sub

  Public Shared Sub SelectListValue(ByVal list As ListControl, ByVal val As String, ByVal singleSelection As Boolean)

    Dim item1 As ListItem = list.Items.FindByValue(val)

    SelectItem(list, item1, singleSelection)

  End Sub

  Public Shared Sub SelectListValue(ByVal list As ListControl, ByVal val As String)

    SelectListValue(list, val, True)

  End Sub

  Public Shared Sub SelectListValue(ByVal list As ListControl, ByVal val As Integer)

    SelectListValue(list, val.ToString(), True)

  End Sub

  Public Shared Sub SelectListValues(ByVal list As ListControl, ByVal values As Integer())

    Dim num1 As Integer = 0

    If (values Is Nothing) Then
      Return
    End If

    Do While (num1 < values.Length)
      SelectListValue(list, values(num1).ToString, False)
      num1 = (num1 + 1)
    Loop

  End Sub

  Public Shared Function GetSelectedValueInt32(ByVal list As ListControl, ByVal defVal As Integer) As Integer

    Dim num1 As Integer

    Try

      Return Convert.ToInt32(list.SelectedItem.Value)

    Catch ex As Exception

      Return defVal

    End Try

    Return num1

  End Function

  Public Shared Function GetSelectedValueInt32(ByVal list As ListControl) As Integer

    Return GetSelectedValueInt32(list, 0)

  End Function

  Public Shared Function ContainsValue(ByVal list As ListControl, ByVal value As String) As Boolean

    Return (Not list.Items.FindByValue(value) Is Nothing)

  End Function


#End Region

End Class
