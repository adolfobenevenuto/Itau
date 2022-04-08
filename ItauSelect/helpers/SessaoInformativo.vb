Imports InformativoCRP
Imports CRPSP.Util

Public NotInheritable Class SessaoInformativo

  Public Shared Sub LimparSessao()

    ComissaoCorrente = New Comissao

    UsuarioCorrente = New Usuario

    MensagemTitulo = ""
    MensagemComplemento = ""
    MensagemURLRetorno = ""
    MostraMenu = False

  End Sub

    Public Shared Property ComissaoCorrente() As Comissao
        Get

      If (HttpContext.Current.Session) Is Nothing Then

        Return Nothing

      End If

      If (HttpContext.Current.Session("_comissaoCorrente") Is Nothing) Then
        HttpContext.Current.Session("_comissaoCorrente") = Nothing
      End If

      Return CType(HttpContext.Current.Session("_comissaoCorrente"), Comissao)

        End Get
        Set(ByVal Value As Comissao)

            HttpContext.Current.Session("_comissaoCorrente") = Value
            Comissao.ComissaoCorrente = Value

        End Set
    End Property

    Public Shared Property UsuarioCorrente() As Usuario
        Get

      If (HttpContext.Current.Session) Is Nothing Then

        Return Nothing

      End If

      If (HttpContext.Current.Session("_usuarioCorrente") Is Nothing) Then
        HttpContext.Current.Session("_usuarioCorrente") = Nothing
      End If

      Return CType(HttpContext.Current.Session("_usuarioCorrente"), Usuario)


    End Get
        Set(ByVal Value As Usuario)

            HttpContext.Current.Session("_usuarioCorrente") = Value
            Usuario.UsuarioCorrente = Value

        End Set
    End Property

    Public Shared Property MensagemTitulo() As String
        Get

            If (HttpContext.Current.Session("_mensagemTitulo") Is Nothing) Then
                HttpContext.Current.Session("_mensagemTitulo") = ""
            End If

            Return CType(HttpContext.Current.Session("_mensagemTitulo"), String)

        End Get
        Set(ByVal Value As String)

            HttpContext.Current.Session("_mensagemTitulo") = Value

        End Set
    End Property

    Public Shared Property MensagemComplemento() As String
        Get

            If (HttpContext.Current.Session("_mensagemComplemento") Is Nothing) Then
                HttpContext.Current.Session("_mensagemComplemento") = ""
            End If

            Return CType(HttpContext.Current.Session("_mensagemComplemento"), String)

        End Get
        Set(ByVal Value As String)

            HttpContext.Current.Session("_mensagemComplemento") = Value

        End Set
    End Property

    Public Shared Property MensagemURLRetorno() As String
        Get

            If (HttpContext.Current.Session("_mensagemURLRetorno") Is Nothing) Then
                HttpContext.Current.Session("_mensagemURLRetorno") = ""
            End If

            Return CType(HttpContext.Current.Session("_mensagemURLRetorno"), String)

        End Get
        Set(ByVal Value As String)

            HttpContext.Current.Session("_mensagemURLRetorno") = Value

        End Set
    End Property
    Public Shared Property MostraMenu() As Boolean
        Get

            If (HttpContext.Current.Session("_mostraMenu") Is Nothing) Then
                HttpContext.Current.Session("_mostraMenu") = False
            End If

            Return CType(HttpContext.Current.Session("_mostraMenu"), Boolean)

        End Get
        Set(ByVal Value As Boolean)

            HttpContext.Current.Session("_mostraMenu") = Value

        End Set
    End Property

End Class
