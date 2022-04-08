'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem a classe que representa relacionamento entre funcoes 
'// do sistema e perfis de acesso.
'//
'// Data de Criacao : 18-06-2004
'// Criador : 
'//////////////////////////////////////////////////////////////////////////////

'Classe que representa relacionamento entre funcoes do sistema e
'perfis de acesso.
Public NotInheritable Class FuncaoPerfil

#Region "Variaveis membro"

  'Propriedades
  Private _funcao As FuncaoSistema
  Private _perfil As PerfilUsuario
  Private _somenteCriador As Boolean

#End Region

#Region "Construtor"

  Friend Sub New(ByVal funcao As FuncaoSistema, _
                 ByVal perfil As PerfilUsuario, _
                 ByVal somenteCriador As Boolean)

    'inicia propriedades
    _funcao = funcao
    _perfil = perfil
    _somenteCriador = somenteCriador

  End Sub

#End Region

#Region "Propriedades"

  Public ReadOnly Property Funcao() As FuncaoSistema
    Get
      Return _funcao
    End Get
  End Property

  Public ReadOnly Property Perfil() As PerfilUsuario
    Get
      Return _perfil
    End Get
  End Property

  Public Property SomenteCriador() As Boolean
    Get
      Return _somenteCriador
    End Get
    Set(ByVal Value As Boolean)
      _somenteCriador = Value
    End Set
  End Property

#End Region

End Class
