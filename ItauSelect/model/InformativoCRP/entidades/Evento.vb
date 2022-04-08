Imports System.Globalization

#Region "Classe Evento"
Public Class Evento
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_ecrp as 'Id', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_crp where Excluido = 0 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_evento_crp where id_ecrp = @id_ecrp"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_evento_crp (titulo,tema,dt_inicio,dt_fim,telefone,fax,end_logradouro,end_numero,end_complemento,end_bairro,end_cep,end_cidade,end_estado,email,site,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                                 "values(@titulo,@tema,@dt_inicio,@dt_fim,@telefone,@fax,@end_logradouro,@end_numero,@end_complemento,@end_bairro,@end_cep,@end_cidade,@end_estado,@email,@site,@oculto,0,1,getdate(),1,getdate());" + _
                                                 "select * from tbl_evento_crp where id_ecrp = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_evento_crp set excluido = 1 where id_ecrp = @id_ecrp"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_evento_crp set titulo = @titulo, tema = @tema, dt_inicio = @dt_inicio, dt_fim = @dt_fim, telefone = @telefone, fax = @fax, end_logradouro = @end_logradouro, end_numero = @end_numero, end_complemento = @end_complemento, end_bairro = @end_bairro, end_cep = @end_cep, end_cidade = @end_cidade, end_estado = @end_estado, email = @email, site = @site, oculto = @oculto where id_ecrp = @id_ecrp"

  ' parametros
  Private _paramId As New SqlParameter("@id_ecrp", SqlDbType.Int)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramTema As New SqlParameter("@tema", SqlDbType.VarChar)
  Private _paramDataInicio As New SqlParameter("@dt_inicio", SqlDbType.DateTime)
  Private _paramDataFim As New SqlParameter("@dt_fim", SqlDbType.DateTime)
  Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
  Private _paramFax As New SqlParameter("@fax", SqlDbType.VarChar)
  Private _paramEndLogradouro As New SqlParameter("@end_logradouro", SqlDbType.VarChar)
  Private _paramEndNumero As New SqlParameter("@end_numero", SqlDbType.Int)
  Private _paramEndComplemento As New SqlParameter("@end_complemento", SqlDbType.VarChar)
  Private _paramEndBairro As New SqlParameter("@end_bairro", SqlDbType.VarChar)
  Private _paramEndCep As New SqlParameter("@end_cep", SqlDbType.Char)
  Private _paramEndCidade As New SqlParameter("@end_cidade", SqlDbType.VarChar)
  Private _paramEndEstado As New SqlParameter("@end_estado", SqlDbType.Char)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramSite As New SqlParameter("@site", SqlDbType.VarChar)
  Private _paramOculto As New SqlParameter("@oculto", SqlDbType.Bit)

  ' propriedades
  Private _id As Integer = 0
  Private _titulo As String = ""
  Private _tema As String = ""
  Private _dt_inicio As Date = Date.Now
  Private _dt_fim As Date = Date.Now
  Private _telefone As String = ""
  Private _fax As String = ""
  Private _end_logradouro As String = ""
  Private _end_numero As Integer = 0
  Private _end_complemento As String = ""
  Private _end_bairro As String = ""
  Private _end_cep As Char = ""
  Private _end_cidade As String = ""
  Private _end_estado As Char = ""
  Private _email As String = ""
  Private _site As String = ""
  Private _oculto As Boolean = False

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Evento
    Dim param As New SqlParameter("@id_ecrp", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Evento não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, ""))

  End Function

  Public Shared Function ListarMes(ByVal mes As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, "and datepart(mm, dt_inicio) = " + mes.ToString))

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramTitulo.Value = _titulo
    _paramTema.Value = _tema
    _paramDataInicio.Value = _dt_inicio
    _paramDataFim.Value = _dt_fim
    _paramTelefone.Value = _telefone
    _paramFax.Value = _fax
    _paramEndLogradouro.Value = _end_logradouro
    _paramEndNumero.Value = _end_numero
    _paramEndComplemento.Value = _end_complemento
    _paramEndBairro.Value = _end_bairro
    _paramEndCep.Value = _end_cep
    _paramEndCidade.Value = _end_cidade
    _paramEndEstado.Value = _end_estado
    _paramEmail.Value = _email
    _paramSite.Value = _site
    _paramOculto.Value = _oculto

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id_ecrp")
    Me.Titulo = Convert.ToString(reader("titulo"))
    Me.Tema = Convert.ToString(reader("tema"))
    Me.DataInicio = reader("dt_inicio")
    Me.DataFim = reader("dt_fim")
    Me.Telefone = Convert.ToString(reader("telefone"))
    Me.Fax = Convert.ToString(reader("fax"))
    Me.EndLogradouro = Convert.ToString(reader("end_logradouro"))
    Me.EndNumero = reader("end_numero")
    Me.EndComplemento = Convert.ToString(reader("end_complemento"))
    Me.EndBairro = Convert.ToString(reader("end_bairro"))
    Me.EndCep = Convert.ToString(reader("end_cep"))
    Me.EndCidade = Convert.ToString(reader("end_cidade"))
    Me.EndEstado = Convert.ToString(reader("end_estado"))
    Me.Email = Convert.ToString(reader("email"))
    Me.Site = Convert.ToString(reader("site"))
    'Me.Oculto = Convert.ToBoolean(reader("oculto"))

  End Sub

  Public Function Valido() As Boolean

    'chama a funcao validar endereco site, com o parametro
    ValidadorWebSite.Valido(Me.Site)

  End Function

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("Evento", "inserir")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("Evento", "alterar")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("Evento", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property

  Public Property Titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property

  Public Property Tema() As String
    Get
      Return _tema
    End Get
    Set(ByVal Value As String)
      _tema = Value
    End Set
  End Property

  Public Property DataInicio() As Date
    Get
      Return _dt_inicio
    End Get
    Set(ByVal Value As Date)
      _dt_inicio = Value
    End Set
  End Property

  Public Property DataFim() As Date
    Get
      Return _dt_fim
    End Get
    Set(ByVal Value As Date)
      _dt_fim = Value
    End Set
  End Property
  Public Property Telefone() As String
    Get
      Return _telefone
    End Get
    Set(ByVal Value As String)
      _telefone = Value
    End Set
  End Property

  Public Property Fax() As String
    Get
      Return _fax
    End Get
    Set(ByVal Value As String)
      _fax = Value
    End Set
  End Property

  Public Property EndLogradouro() As String
    Get
      Return _end_logradouro
    End Get
    Set(ByVal Value As String)
      _end_logradouro = Value
    End Set
  End Property
  Public Property EndNumero() As Integer
    Get
      Return _end_numero
    End Get
    Set(ByVal Value As Integer)
      _end_numero = Value
    End Set
  End Property

  Public Property EndComplemento() As String
    Get
      Return _end_complemento
    End Get
    Set(ByVal Value As String)
      _end_complemento = Value
    End Set
  End Property

  Public Property EndBairro() As String
    Get
      Return _end_bairro
    End Get
    Set(ByVal Value As String)
      _end_bairro = Value
    End Set
  End Property
  Public Property EndCep() As Char
    Get
      Return _end_cep
    End Get
    Set(ByVal Value As Char)
      _end_cep = Value
    End Set
  End Property
  Public Property EndCidade() As String
    Get
      Return _end_cidade
    End Get
    Set(ByVal Value As String)
      _end_cidade = Value
    End Set
  End Property
  Public Property EndEstado() As Char
    Get
      Return _end_estado
    End Get
    Set(ByVal Value As Char)
      _end_estado = Value
    End Set
  End Property
  Public Property Email() As String
    Get
      Return _email
    End Get
    Set(ByVal Value As String)
      _email = Value
    End Set
  End Property
  Public Property Site() As String
    Get
      Return _site
    End Get
    Set(ByVal Value As String)
      _site = Value
    End Set
  End Property

  Public Property Oculto() As Boolean
    Get
      Return _oculto
    End Get
    Set(ByVal Value As Boolean)
      _oculto = Value
    End Set
  End Property

#End Region

End Class

#End Region

#Region "Evento Comissao"

Public Class EventoComissao
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_evc as 'Id', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_comissao where Excluido = 0 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_evento_comissao where id_evc = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_evento_comissao (titulo,tema,dt_inicio,dt_fim,telefone,fax,informacoes,end_logradouro,end_numero,end_complemento,end_bairro,end_cep,end_cidade,end_estado,email,site,oculto,privado,status,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@titulo,@tema,@dt_inicio,@dt_fim,@telefone,@fax,@informacoes,@end_logradouro,@end_numero,@end_complemento,@end_bairro,@end_cep,@end_cidade,@end_estado,@email,@site,@oculto,0,0,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_evento_comissao where id_evc = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_evento_comissao set excluido = 1 where id_evc = @id_evc"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_evento_comissao set titulo = @titulo, tema = @tema, dt_inicio = @dt_inicio, dt_fim = @dt_fim, telefone = @telefone, fax = @fax, informacoes = @informacoes, end_logradouro = @end_logradouro, end_numero = @end_numero, end_complemento = @end_complemento, end_bairro = @end_bairro, end_cep = @end_cep, end_cidade = @end_cidade, end_estado = @end_estado, email = @email, site = @site, oculto = @oculto where id_evc = @id_evc"

  ' parametros
  Private _paramId As New SqlParameter("@id_evc", SqlDbType.Int)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramTema As New SqlParameter("@tema", SqlDbType.VarChar)
  Private _paramDataInicio As New SqlParameter("@dt_inicio", SqlDbType.DateTime)
  Private _paramDataFim As New SqlParameter("@dt_fim", SqlDbType.DateTime)
  Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
  Private _paramFax As New SqlParameter("@fax", SqlDbType.VarChar)
  Private _paramInformacoes As New SqlParameter("@informacoes", SqlDbType.VarChar)
  Private _paramEndLogradouro As New SqlParameter("@end_logradouro", SqlDbType.VarChar)
  Private _paramEndNumero As New SqlParameter("@end_numero", SqlDbType.Int)
  Private _paramEndComplemento As New SqlParameter("@end_complemento", SqlDbType.VarChar)
  Private _paramEndBairro As New SqlParameter("@end_bairro", SqlDbType.VarChar)
  Private _paramEndCep As New SqlParameter("@end_cep", SqlDbType.VarChar)
  Private _paramEndCidade As New SqlParameter("@end_cidade", SqlDbType.VarChar)
  Private _paramEndEstado As New SqlParameter("@end_estado", SqlDbType.Char)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramSite As New SqlParameter("@site", SqlDbType.VarChar)
  Private _paramOculto As New SqlParameter("@oculto", SqlDbType.Bit)

  ' propriedades
  Private _id As Integer = 0
  Private _titulo As String = ""
  Private _tema As String = ""
  Private _dt_inicio As Date = Date.Now
  Private _dt_fim As Date = Date.Now
  Private _telefone As String = ""
  Private _fax As String = ""
  Private _informacoes As String = ""
  Private _end_logradouro As String = ""
  Private _end_numero As Integer = 0
  Private _end_complemento As String = ""
  Private _end_bairro As String = ""
  Private _end_cep As String = ""
  Private _end_cidade As String = ""
  Private _end_estado As Char = ""
  Private _email As String = ""
  Private _site As String = ""
  Private _oculto As Boolean = False

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New EventoComissao
    Dim param As New SqlParameter("@id", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Evento não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, ""))

  End Function

  Public Shared Function ListarMes(ByVal mes As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, "and datepart(mm, dt_inicio) = " + mes.ToString))

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramTitulo.Value = _titulo
    _paramTema.Value = _tema
    _paramDataInicio.Value = _dt_inicio
    _paramDataFim.Value = _dt_fim
    _paramTelefone.Value = _telefone
    _paramFax.Value = _fax
    _paramInformacoes.Value = _informacoes
    _paramEndLogradouro.Value = _end_logradouro
    _paramEndNumero.Value = IIf(_end_numero <= 0, Nothing, _end_numero)
    _paramEndComplemento.Value = _end_complemento
    _paramEndBairro.Value = _end_bairro
    _paramEndCep.Value = _end_cep
    _paramEndCidade.Value = _end_cidade
    _paramEndEstado.Value = _end_estado
    _paramEmail.Value = _email
    _paramSite.Value = _site
    _paramOculto.Value = _oculto

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id_esub")
    Me.Titulo = Convert.ToString(reader("titulo"))
    Me.Tema = Convert.ToString(reader("tema"))
    Me.DataInicio = reader("dt_inicio")
    Me.DataFim = reader("dt_fim")
    Me.Telefone = Convert.ToString(reader("telefone"))
    Me.Fax = Convert.ToString(reader("fax"))
    Me.Informacoes = Convert.ToString(reader("informacoes"))
    Me.EndLogradouro = Convert.ToString(reader("end_logradouro"))
    Me.EndNumero = CRPUtil.SafeToInt32(reader("end_numero"), 0)
    Me.EndComplemento = Convert.ToString(reader("end_complemento"))
    Me.EndBairro = Convert.ToString(reader("end_bairro"))
    Me.EndCep = Convert.ToString(reader("end_cep"))
    Me.EndCidade = Convert.ToString(reader("end_cidade"))
    Me.EndEstado = Convert.ToString(reader("end_estado"))
    Me.Email = Convert.ToString(reader("email"))
    Me.Site = Convert.ToString(reader("site"))
    Me.Oculto = Convert.ToBoolean(reader("oculto"))

  End Sub

  Public Function Valido() As Boolean

    'chama a funcao validar endereco site, com o parametro
    ValidadorWebSite.Valido(Me.Site)

  End Function

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("EventoComissao", "inserir")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramInformacoes, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("EventoComissao", "alterar")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramInformacoes, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("EventoComissao", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property

  Public Property Titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property

  Public Property Tema() As String
    Get
      Return _tema
    End Get
    Set(ByVal Value As String)
      _tema = Value
    End Set
  End Property

  Public Property DataInicio() As Date
    Get
      Return _dt_inicio
    End Get
    Set(ByVal Value As Date)
      _dt_inicio = Value
    End Set
  End Property

  Public Property DataFim() As Date
    Get
      Return _dt_fim
    End Get
    Set(ByVal Value As Date)
      _dt_fim = Value
    End Set
  End Property
  Public Property Telefone() As String
    Get
      Return _telefone
    End Get
    Set(ByVal Value As String)
      _telefone = Value
    End Set
  End Property

  Public Property Fax() As String
    Get
      Return _fax
    End Get
    Set(ByVal Value As String)
      _fax = Value
    End Set
  End Property
  Public Property Informacoes() As String
    Get
      Return _informacoes
    End Get
    Set(ByVal Value As String)
      _informacoes = Value
    End Set
  End Property
  Public Property EndLogradouro() As String
    Get
      Return _end_logradouro
    End Get
    Set(ByVal Value As String)
      _end_logradouro = Value
    End Set
  End Property
  Public Property EndNumero() As Integer
    Get
      Return _end_numero
    End Get
    Set(ByVal Value As Integer)
      _end_numero = Value
    End Set
  End Property

  Public Property EndComplemento() As String
    Get
      Return _end_complemento
    End Get
    Set(ByVal Value As String)
      _end_complemento = Value
    End Set
  End Property

  Public Property EndBairro() As String
    Get
      Return _end_bairro
    End Get
    Set(ByVal Value As String)
      _end_bairro = Value
    End Set
  End Property
  Public Property EndCep() As String
    Get
      Return _end_cep
    End Get
    Set(ByVal Value As String)
      _end_cep = Value
    End Set
  End Property
  Public Property EndCidade() As String
    Get
      Return _end_cidade
    End Get
    Set(ByVal Value As String)
      _end_cidade = Value
    End Set
  End Property
  Public Property EndEstado() As Char
    Get
      Return _end_estado
    End Get
    Set(ByVal Value As Char)
      _end_estado = Value
    End Set
  End Property
  Public Property Email() As String
    Get
      Return _email
    End Get
    Set(ByVal Value As String)
      _email = Value
    End Set
  End Property
  Public Property Site() As String
    Get
      Return _site
    End Get
    Set(ByVal Value As String)
      _site = Value
    End Set
  End Property

  Public Property Oculto() As Boolean
    Get
      Return _oculto
    End Get
    Set(ByVal Value As Boolean)
      _oculto = Value
    End Set
  End Property

#End Region

End Class

Public NotInheritable Class CRPUtil

  Public Shared Function SafeToInt32(ByVal val As Object, ByVal defVal As Integer) As Integer

    Try

      Return Convert.ToInt32(val)

    Catch ex As Exception

      Return defVal

    End Try

  End Function

End Class

#End Region

#Region "Evento Subsede"

Public Class EventoSubsede
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_ASSIS As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 17 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_BAURU As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 18 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_CAMPINAS As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 19 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_GRANDEABC As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 20 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_RIBEIRAO As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 21 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_SANTOS As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 22 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_SAOJOSE As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 23 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_LIST_TAUBATE As String = "select id as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 and id_subsede = 24 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_evento_subsede where id = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_evento_subsede (id_subsede, titulo,tema,dt_inicio,dt_fim,telefone,fax,informacoes,end_logradouro,end_numero,end_complemento,end_bairro,end_cep,end_cidade,end_estado,email,site,oculto,privado,status,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@id_subsede, @titulo,@tema,@dt_inicio,@dt_fim,@telefone,@fax,@informacoes,@end_logradouro,@end_numero,@end_complemento,@end_bairro,@end_cep,@end_cidade,@end_estado,@email,@site,@oculto,0,0,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_evento_subsede where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_evento_subsede set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_evento_subsede set titulo = @titulo, tema = @tema, dt_inicio = @dt_inicio, dt_fim = @dt_fim, telefone = @telefone, fax = @fax, informacoes = @informacoes, end_logradouro = @end_logradouro, end_numero = @end_numero, end_complemento = @end_complemento, end_bairro = @end_bairro, end_cep = @end_cep, end_cidade = @end_cidade, end_estado = @end_estado, email = @email, site = @site, oculto = @oculto where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramIdSubsede As New SqlParameter("@id_subsede", SqlDbType.Int)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramTema As New SqlParameter("@tema", SqlDbType.VarChar)
  Private _paramDataInicio As New SqlParameter("@dt_inicio", SqlDbType.DateTime)
  Private _paramDataFim As New SqlParameter("@dt_fim", SqlDbType.DateTime)
  Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
  Private _paramFax As New SqlParameter("@fax", SqlDbType.VarChar)
  Private _paramInformacoes As New SqlParameter("@informacoes", SqlDbType.VarChar)
  Private _paramEndLogradouro As New SqlParameter("@end_logradouro", SqlDbType.VarChar)
  Private _paramEndNumero As New SqlParameter("@end_numero", SqlDbType.Int)
  Private _paramEndComplemento As New SqlParameter("@end_complemento", SqlDbType.VarChar)
  Private _paramEndBairro As New SqlParameter("@end_bairro", SqlDbType.VarChar)
  Private _paramEndCep As New SqlParameter("@end_cep", SqlDbType.VarChar)
  Private _paramEndCidade As New SqlParameter("@end_cidade", SqlDbType.VarChar)
  Private _paramEndEstado As New SqlParameter("@end_estado", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramSite As New SqlParameter("@site", SqlDbType.VarChar)
  Private _paramOculto As New SqlParameter("@oculto", SqlDbType.Bit)

  ' propriedades
  Private _id As Integer = 0
  Private _id_subsede As Integer = 0
  Private _titulo As String = ""
  Private _tema As String = ""
  Private _dt_inicio As Date = Date.Now
  Private _dt_fim As Date = Date.Now
  Private _telefone As String = ""
  Private _fax As String = ""
  Private _informacoes As String = ""
  Private _end_logradouro As String = ""
  Private _end_numero As Integer = 0
  Private _end_complemento As String = ""
  Private _end_bairro As String = ""
  Private _end_cep As String = ""
  Private _end_cidade As String = ""
  Private _end_estado As String = ""
  Private _email As String = ""
  Private _site As String = ""
  Private _oculto As Boolean = False

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New EventoSubsede
    Dim param As New SqlParameter("@id", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Evento não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    If Usuario.UsuarioCorrente.Logon = "Assis" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_ASSIS, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "Bauru" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BAURU, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "Campinas" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_CAMPINAS, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "Abc" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_GRANDEABC, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "Ribeirao" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_RIBEIRAO, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "Santos" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_SANTOS, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "SaoJose" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_SAOJOSE, ""))

    ElseIf Usuario.UsuarioCorrente.Logon = "Paraiba" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TAUBATE, ""))

    Else

      'retorna lista
      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, ""))

    End If

  End Function

  Public Shared Function ListarMes(ByVal mes As Integer) As IList

    If Usuario.UsuarioCorrente.Logon = "Assis" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_ASSIS, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "Bauru" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_BAURU, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "Campinas" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_CAMPINAS, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "Abc" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_GRANDEABC, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "Ribeirao" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_RIBEIRAO, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "Santos" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_SANTOS, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "SaoJose" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_SAOJOSE, "and datepart(mm, dt_inicio) = " + mes.ToString))

    ElseIf Usuario.UsuarioCorrente.Logon = "Paraiba" Then

      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_TAUBATE, "and datepart(mm, dt_inicio) = " + mes.ToString))

    Else

      'retorna lista
      Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, "and datepart(mm, dt_inicio) = " + mes.ToString))


    End If


  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramIdSubsede.Value = _id_subsede
    _paramTitulo.Value = _titulo
    _paramTema.Value = _tema
    _paramDataInicio.Value = _dt_inicio
    _paramDataFim.Value = _dt_fim
    _paramTelefone.Value = _telefone
    _paramFax.Value = _fax
    _paramInformacoes.Value = _informacoes
    _paramEndLogradouro.Value = _end_logradouro
    _paramEndNumero.Value = IIf(_end_numero <= 0, Nothing, _end_numero)
    _paramEndComplemento.Value = _end_complemento
    _paramEndBairro.Value = _end_bairro
    _paramEndCep.Value = _end_cep
    _paramEndCidade.Value = _end_cidade
    _paramEndEstado.Value = _end_estado
    _paramEmail.Value = _email
    _paramSite.Value = _site
    _paramOculto.Value = _oculto

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.Id_Subsede = reader("id_subsede")
    Me.Titulo = Convert.ToString(reader("titulo"))
    Me.Tema = Convert.ToString(reader("tema"))
    Me.DataInicio = reader("dt_inicio")
    Me.DataFim = reader("dt_fim")
    Me.Telefone = Convert.ToString(reader("telefone"))
    Me.Fax = Convert.ToString(reader("fax"))
    Me.Informacoes = Convert.ToString(reader("informacoes"))
    Me.EndLogradouro = Convert.ToString(reader("end_logradouro"))
    Me.EndNumero = CRPUtil.SafeToInt32(reader("end_numero"), 0)
    Me.EndComplemento = Convert.ToString(reader("end_complemento"))
    Me.EndBairro = Convert.ToString(reader("end_bairro"))
    Me.EndCep = Convert.ToString(reader("end_cep"))
    Me.EndCidade = Convert.ToString(reader("end_cidade"))
    Me.EndEstado = Convert.ToString(reader("end_estado"))
    Me.Email = Convert.ToString(reader("email"))
    Me.Site = Convert.ToString(reader("site"))
    Me.Oculto = Convert.ToBoolean(reader("oculto"))

  End Sub

  Public Function Valido() As Boolean

    'chama a funcao validar endereco site, com o parametro
    ValidadorWebSite.Valido(Me.Site)

  End Function

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("EventoComissao", "inserir")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramIdSubsede, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramInformacoes, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("EventoComissao", "alterar")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramInformacoes, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("EventoComissao", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property
  Public Property Id_Subsede() As Integer
    Get
      Return _id_subsede
    End Get
    Set(ByVal Value As Integer)
      _id_subsede = Value
    End Set
  End Property

  Public Property Titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property

  Public Property Tema() As String
    Get
      Return _tema
    End Get
    Set(ByVal Value As String)
      _tema = Value
    End Set
  End Property

  Public Property DataInicio() As Date
    Get
      Return _dt_inicio
    End Get
    Set(ByVal Value As Date)
      _dt_inicio = Value
    End Set
  End Property

  Public Property DataFim() As Date
    Get
      Return _dt_fim
    End Get
    Set(ByVal Value As Date)
      _dt_fim = Value
    End Set
  End Property
  Public Property Telefone() As String
    Get
      Return _telefone
    End Get
    Set(ByVal Value As String)
      _telefone = Value
    End Set
  End Property

  Public Property Fax() As String
    Get
      Return _fax
    End Get
    Set(ByVal Value As String)
      _fax = Value
    End Set
  End Property
  Public Property Informacoes() As String
    Get
      Return _informacoes
    End Get
    Set(ByVal Value As String)
      _informacoes = Value
    End Set
  End Property
  Public Property EndLogradouro() As String
    Get
      Return _end_logradouro
    End Get
    Set(ByVal Value As String)
      _end_logradouro = Value
    End Set
  End Property
  Public Property EndNumero() As Integer
    Get
      Return _end_numero
    End Get
    Set(ByVal Value As Integer)
      _end_numero = Value
    End Set
  End Property

  Public Property EndComplemento() As String
    Get
      Return _end_complemento
    End Get
    Set(ByVal Value As String)
      _end_complemento = Value
    End Set
  End Property

  Public Property EndBairro() As String
    Get
      Return _end_bairro
    End Get
    Set(ByVal Value As String)
      _end_bairro = Value
    End Set
  End Property
  Public Property EndCep() As String
    Get
      Return _end_cep
    End Get
    Set(ByVal Value As String)
      _end_cep = Value
    End Set
  End Property
  Public Property EndCidade() As String
    Get
      Return _end_cidade
    End Get
    Set(ByVal Value As String)
      _end_cidade = Value
    End Set
  End Property
  Public Property EndEstado() As String
    Get
      Return _end_estado
    End Get
    Set(ByVal Value As String)
      _end_estado = Value
    End Set
  End Property
  Public Property Email() As String
    Get
      Return _email
    End Get
    Set(ByVal Value As String)
      _email = Value
    End Set
  End Property
  Public Property Site() As String
    Get
      Return _site
    End Get
    Set(ByVal Value As String)
      _site = Value
    End Set
  End Property

  Public Property Oculto() As Boolean
    Get
      Return _oculto
    End Get
    Set(ByVal Value As Boolean)
      _oculto = Value
    End Set
  End Property
#End Region

End Class
#End Region


#Region "Evento Subsede Now"

Public Class EventoSubsedeNow
  Inherits BaseEntidade

  Private _comissao As Comissao

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id_esub as 'Id', id_subsede as 'IdSubsede', titulo as 'Titulo', tema as 'Tema', dt_inicio as 'DataInicio', dt_fim as 'DataFim', telefone as 'Telefone',fax as 'Fax', informacoes as 'Informacoes', end_logradouro as 'EndLogradouro', end_numero as 'EndNumero', end_complemento as 'EndComplemento', end_bairro as 'Endbairro', end_cep as 'EndCep', end_cidade as 'EndCidade', end_estado as 'EndEstado', email as 'Email', site as 'Site' from tbl_evento_subsede where Excluido = 0 {0} order by dt_inicio"
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_evento_subsede where id_esub = @id"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_evento_subsede (id_subsede, titulo,tema,dt_inicio,dt_fim,telefone,fax,informacoes,end_logradouro,end_numero,end_complemento,end_bairro,end_cep,end_cidade,end_estado,email,site,oculto,privado,status,excluido,criador,dt_criacao,atualizador,dt_atualizacao) " + _
                                               "values(@id_subsede, @titulo,@tema,@dt_inicio,@dt_fim,@telefone,@fax,@informacoes,@end_logradouro,@end_numero,@end_complemento,@end_bairro,@end_cep,@end_cidade,@end_estado,@email,@site,@oculto,0,0,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_evento_subsede where id_esub = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_evento_subsede set excluido = 1 where id_esub = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_evento_subsede set titulo = @titulo, tema = @tema, dt_inicio = @dt_inicio, dt_fim = @dt_fim, telefone = @telefone, fax = @fax, informacoes = @informacoes, end_logradouro = @end_logradouro, end_numero = @end_numero, end_complemento = @end_complemento, end_bairro = @end_bairro, end_cep = @end_cep, end_cidade = @end_cidade, end_estado = @end_estado, email = @email, site = @site, oculto = @oculto where id_esub = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramIdSubsede As New SqlParameter("@id_subsede", SqlDbType.Int)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramTema As New SqlParameter("@tema", SqlDbType.VarChar)
  Private _paramDataInicio As New SqlParameter("@dt_inicio", SqlDbType.DateTime)
  Private _paramDataFim As New SqlParameter("@dt_fim", SqlDbType.DateTime)
  Private _paramTelefone As New SqlParameter("@telefone", SqlDbType.VarChar)
  Private _paramFax As New SqlParameter("@fax", SqlDbType.VarChar)
  Private _paramInformacoes As New SqlParameter("@informacoes", SqlDbType.VarChar)
  Private _paramEndLogradouro As New SqlParameter("@end_logradouro", SqlDbType.VarChar)
  Private _paramEndNumero As New SqlParameter("@end_numero", SqlDbType.Int)
  Private _paramEndComplemento As New SqlParameter("@end_complemento", SqlDbType.VarChar)
  Private _paramEndBairro As New SqlParameter("@end_bairro", SqlDbType.VarChar)
  Private _paramEndCep As New SqlParameter("@end_cep", SqlDbType.VarChar)
  Private _paramEndCidade As New SqlParameter("@end_cidade", SqlDbType.VarChar)
  Private _paramEndEstado As New SqlParameter("@end_estado", SqlDbType.Char)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramSite As New SqlParameter("@site", SqlDbType.VarChar)
  Private _paramOculto As New SqlParameter("@oculto", SqlDbType.Bit)

  ' propriedades
  Private _id As Integer = 0
  Private _id_subsede As Integer = 0
  Private _titulo As String = ""
  Private _tema As String = ""
  Private _dt_inicio As Date = Date.Now
  Private _dt_fim As Date = Date.Now
  Private _telefone As String = ""
  Private _fax As String = ""
  Private _informacoes As String = ""
  Private _end_logradouro As String = ""
  Private _end_numero As Integer = 0
  Private _end_complemento As String = ""
  Private _end_bairro As String = ""
  Private _end_cep As String = ""
  Private _end_cidade As String = ""
  Private _end_estado As Char = ""
  Private _email As String = ""
  Private _site As String = ""
  Private _oculto As Boolean = False

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id_esub As Integer) As Object

    Dim ret As New EventoSubsede
    Dim param As New SqlParameter("@id", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_esub

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Evento não encotrado.")

  End Function

  Public Shared Function Listar() As IList

    Dim IdCom As Integer
    IdCom = Comissao.ComissaoCorrente.Id


    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, "and id_subsede = " + IdCom.ToString))

  End Function
  Public Shared Function ListarTodos() As IList

    Dim IdCom As Integer
    IdCom = Comissao.ComissaoCorrente.Id


    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, ""))

  End Function

  Public Shared Function ListarMes(ByVal mes As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST, "and datepart(mm, dt_inicio) = " + mes.ToString))

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramId.Value = _id
    _paramIdSubsede.Value = _id_subsede
    _paramTitulo.Value = _titulo
    _paramTema.Value = _tema
    _paramDataInicio.Value = _dt_inicio
    _paramDataFim.Value = _dt_fim
    _paramTelefone.Value = _telefone
    _paramFax.Value = _fax
    _paramInformacoes.Value = _informacoes
    _paramEndLogradouro.Value = _end_logradouro
    _paramEndNumero.Value = IIf(_end_numero <= 0, Nothing, _end_numero)
    _paramEndComplemento.Value = _end_complemento
    _paramEndBairro.Value = _end_bairro
    _paramEndCep.Value = _end_cep
    _paramEndCidade.Value = _end_cidade
    _paramEndEstado.Value = _end_estado
    _paramEmail.Value = _email
    _paramSite.Value = _site
    _paramOculto.Value = _oculto

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id_esub")
    Me.Id_Subsede = reader("id_subsede")
    Me.Titulo = Convert.ToString(reader("titulo"))
    Me.Tema = Convert.ToString(reader("tema"))
    Me.DataInicio = reader("dt_inicio")
    Me.DataFim = reader("dt_fim")
    Me.Telefone = Convert.ToString(reader("telefone"))
    Me.Fax = Convert.ToString(reader("fax"))
    Me.Informacoes = Convert.ToString(reader("informacoes"))
    Me.EndLogradouro = Convert.ToString(reader("end_logradouro"))
    Me.EndNumero = CRPUtil.SafeToInt32(reader("end_numero"), 0)
    Me.EndComplemento = Convert.ToString(reader("end_complemento"))
    Me.EndBairro = Convert.ToString(reader("end_bairro"))
    Me.EndCep = Convert.ToString(reader("end_cep"))
    Me.EndCidade = Convert.ToString(reader("end_cidade"))
    Me.EndEstado = Convert.ToString(reader("end_estado"))
    Me.Email = Convert.ToString(reader("email"))
    Me.Site = Convert.ToString(reader("site"))
    Me.Oculto = Convert.ToBoolean(reader("oculto"))

  End Sub

  Public Function Valido() As Boolean

    'chama a funcao validar endereco site, com o parametro
    ValidadorWebSite.Valido(Me.Site)

  End Function

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("EventoSubsede", "inserir")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramId, _paramIdSubsede, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramInformacoes, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("EventoSubsede", "alterar")

    ' valida link
    ValidadorWebSite.Validar(_site)

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramTitulo, _paramTema, _paramDataInicio, _paramDataFim, _paramTelefone, _paramFax, _paramInformacoes, _paramEndLogradouro, _paramEndNumero, _paramEndComplemento, _paramEndBairro, _paramEndCep, _paramEndCidade, _paramEndEstado, _paramEmail, _paramSite, _paramOculto)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("EventoSubsede", "excluir")

    ' prepara parametro
    _paramId.Value = Me._id

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId)

  End Sub

#End Region

#Region "Public Properties"

  Public Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property
  Public Property Id_Subsede() As Integer
    Get
      Return _id_subsede
    End Get
    Set(ByVal Value As Integer)
      _id_subsede = Value
    End Set
  End Property

  Public Property Titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property

  Public Property Tema() As String
    Get
      Return _tema
    End Get
    Set(ByVal Value As String)
      _tema = Value
    End Set
  End Property

  Public Property DataInicio() As Date
    Get
      Return _dt_inicio
    End Get
    Set(ByVal Value As Date)
      _dt_inicio = Value
    End Set
  End Property

  Public Property DataFim() As Date
    Get
      Return _dt_fim
    End Get
    Set(ByVal Value As Date)
      _dt_fim = Value
    End Set
  End Property
  Public Property Telefone() As String
    Get
      Return _telefone
    End Get
    Set(ByVal Value As String)
      _telefone = Value
    End Set
  End Property

  Public Property Fax() As String
    Get
      Return _fax
    End Get
    Set(ByVal Value As String)
      _fax = Value
    End Set
  End Property
  Public Property Informacoes() As String
    Get
      Return _informacoes
    End Get
    Set(ByVal Value As String)
      _informacoes = Value
    End Set
  End Property
  Public Property EndLogradouro() As String
    Get
      Return _end_logradouro
    End Get
    Set(ByVal Value As String)
      _end_logradouro = Value
    End Set
  End Property
  Public Property EndNumero() As Integer
    Get
      Return _end_numero
    End Get
    Set(ByVal Value As Integer)
      _end_numero = Value
    End Set
  End Property

  Public Property EndComplemento() As String
    Get
      Return _end_complemento
    End Get
    Set(ByVal Value As String)
      _end_complemento = Value
    End Set
  End Property

  Public Property EndBairro() As String
    Get
      Return _end_bairro
    End Get
    Set(ByVal Value As String)
      _end_bairro = Value
    End Set
  End Property
  Public Property EndCep() As String
    Get
      Return _end_cep
    End Get
    Set(ByVal Value As String)
      _end_cep = Value
    End Set
  End Property
  Public Property EndCidade() As String
    Get
      Return _end_cidade
    End Get
    Set(ByVal Value As String)
      _end_cidade = Value
    End Set
  End Property
  Public Property EndEstado() As Char
    Get
      Return _end_estado
    End Get
    Set(ByVal Value As Char)
      _end_estado = Value
    End Set
  End Property
  Public Property Email() As String
    Get
      Return _email
    End Get
    Set(ByVal Value As String)
      _email = Value
    End Set
  End Property
  Public Property Site() As String
    Get
      Return _site
    End Get
    Set(ByVal Value As String)
      _site = Value
    End Set
  End Property

  Public Property Oculto() As Boolean
    Get
      Return _oculto
    End Get
    Set(ByVal Value As Boolean)
      _oculto = Value
    End Set
  End Property

#End Region

End Class

'Public NotInheritable Class CRPUtil

'  Public Shared Function SafeToInt32(ByVal val As Object, ByVal defVal As Integer) As Integer

'    Try

'      Return Convert.ToInt32(val)

'    Catch ex As Exception

'      Return defVal

'    End Try

'  End Function

'End Class

#End Region