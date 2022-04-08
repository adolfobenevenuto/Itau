Imports System.Web.Mail

'Status possiveis para Textos
Public Enum StatusTexto
  Pendente = 0
  Aprovado = 1
  Antigo = 2
  Reprovado = 3
End Enum

'Status possiveis para Comentarios de Textos
Public Enum StatusComentario
  Pendente = 0
  Aprovado = 1
  Reprovado = 3
End Enum

'Representa um texto a ser publicado em uma comissao para o qual podem
'ser adicionados comentarios por visitantes do site
Public Class Texto
  Inherits BaseEntidade

#Region "Variaveis membro"

  'Constantes para SQL
  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_texto where id_art = @id"

  Private Shared ReadOnly C_INSERT As String = "insert into tbl_texto (autor,email,titulo,resumo,texto," + _
                                               "receberemail,oculto,status,excluido,criador,dt_criacao," + _
                                               "atualizador,dt_atualizacao,id_com) values(@autor,@email,@titulo," + _
                                               "@resumo,@texto,0,@oculto,0,0,@criador,getdate(),@atualizador,getdate(),@id_com);" + _
                                               "select * from tbl_texto where id_art = @@identity"

  Private Shared ReadOnly C_DELETE As String = "update tbl_texto set excluido = 1, atualizador = @atualizador " + _
                                               "where id_art = @id"

  Private Shared ReadOnly C_UPDATE As String = "update tbl_texto set autor = @autor, email = @email, " + _
                                               "titulo = @titulo, resumo = @resumo, texto = @texto," + _
                                               "receberemail = 0, oculto = @oculto, status = @status, " + _
                                               "motivo_status = @motivo_status, atualizador = @atualizador, dt_atualizacao = getdate() " + _
                                               "where id_art = @id"

  'Parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramAutor As New SqlParameter("@autor", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramTitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramResumo As New SqlParameter("@resumo", SqlDbType.VarChar)
  Private _paramTexto As New SqlParameter("@texto", SqlDbType.Text)
  Private _paramOculto As New SqlParameter("@oculto", SqlDbType.Bit)
  Private _paramStatus As New SqlParameter("@status", SqlDbType.Int)
  Private _paramMotivoStatus As New SqlParameter("@motivo_status", SqlDbType.VarChar)
  Private _paramIdComissao As New SqlParameter("@id_com", SqlDbType.Int)

  'Propriedades
  Private _id As Integer = 0
  Private _autor As String = ""
  Private _email As String = ""
  Private _titulo As String = ""
  Private _resumo As String = ""
  Private _texto As String = ""
  Private _motivoStatus As String = ""
  Private _oculto As Boolean = False
  Private _status As StatusTexto = StatusTexto.Pendente
  Private _idComissao As Integer = Comissao.ComissaoCorrente.Id

#End Region

#Region "Funcao consultar"

  Public Shared Function Consultar(ByVal id As Integer) As Texto

    'Chama metodo da classe base
    Dim param As New SqlParameter("@id", SqlDbType.Int)
    param.Value = id

    Dim ret As Texto

    ret = CType(BaseEntidade.ConsultarEntidade(New Texto, C_GET_DATA, param), Texto)

    'Se o Texto for oculto e nao estamos conectados, retorna novo Texto
    If (ret.Oculto And Not Usuario.UsuarioCorrente.Autenticado) Then
      Return New Texto
    End If

    Return ret

  End Function

#End Region

#Region "Metodos privados"

  Private Sub AtualizarParametros()

    'Verifica email
    ValidadorEMail.Validar(_email)

    'Chama metodo para atualizar parametros de usuario
    MyBase.AtualizarParametrosUsuario()

    'Parametros especificos
    _paramId.Value = _id
    _paramAutor.Value = _autor
    _paramEmail.Value = _email
    _paramTitulo.Value = _titulo
    _paramResumo.Value = _resumo
    _paramTexto.Value = _texto
    _paramOculto.Value = Convert.ToInt32(_oculto)
    _paramStatus.Value = Convert.ToInt32(_status)
    _paramIdComissao.Value = _idComissao
    _paramMotivoStatus.Value = _motivoStatus

  End Sub

#End Region

#Region "Metodos internos"

  Friend Sub Inserir(ByVal contexto As SqlTransaction)

    'Verifica comissao corrente
    If (Comissao.ComissaoCorrente.Id = 0) Then
      Throw New ApplicationException("Comissão corrente não definida.")
    End If

    'Verifica se o texto eh oculto e o usuario nao eh 
    'membro da comissao
    Dim com As Comissao = Comissao.Consultar(Me.IdComissao)

    If (Me.Oculto) Then
      If (Not com.SouMembro()) Then
        Throw New ApplicationException("Somente membros da comissão podem incluir textos ocultos.")
      End If
    End If

    'Prepara parametros
    AtualizarParametros()

    'Executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(contexto, _
                                                       CommandType.Text, _
                                                       C_INSERT, _
                                                       _paramAutor, _
                                                       _paramEmail, _
                                                       _paramTitulo, _
                                                       _paramResumo, _
                                                       _paramTexto, _
                                                       _paramOculto, _
                                                       _paramStatus, _
                                                       _paramIdComissao, _
                                                       _paramCriador, _
                                                       _paramAtualizador)


    Try

      'Consulta dados
      If (ret.Read()) Then
        PopularDados(ret)
      End If

    Finally

      'Fecha reader
      If (Not ret.IsClosed) Then
        ret.Close()
      End If

    End Try

  End Sub

  Friend Sub Alterar(ByVal contexto As SqlTransaction)

    'Chamada para verificacao de perfil
    PermissaoComissao.VerificarPermissao("texto", "alterar")

    'Prepara parametros
    AtualizarParametros()

    'Executa comando no db
    SqlHelper.ExecuteNonQuery(contexto, _
                              CommandType.Text, _
                              C_UPDATE, _
                              _paramId, _
                              _paramAutor, _
                              _paramEmail, _
                              _paramTitulo, _
                              _paramResumo, _
                              _paramTexto, _
                              _paramOculto, _
                              _paramStatus, _
                              _paramAtualizador, _
                              _paramMotivoStatus)

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, contexto, C_GET_DATA, _paramId)

    'Envia email para autor informando o motivo do status
    Dim msgBody As String
    Dim msgFrom As String = "webmaster@crpsp.org.br"
    SmtpMail.SmtpServer = "smtp2.locaweb.com.br"

    If (Me.Status = StatusTexto.Aprovado) Then

      msgBody = "O seu texto '" + Me.Titulo + "' foi aprovado e está " + _
        "disponível em nosso site !"

      SmtpMail.Send(msgFrom, Me.Email, "Texto aprovado", msgBody)

    ElseIf (Me.Status = StatusTexto.Reprovado) Then

      msgBody = "O seu texto '" + Me.Titulo + "' não foi aprovado para " + _
        "publicação em nosso site." + vbCrLf + vbCrLf + _
        "Motivo da reprovação :" + vbCrLf + _
        Me.MotivoStatus

      SmtpMail.Send(msgFrom, Me.Email, "Texto reprovado", msgBody)

    End If

  End Sub

  Friend Sub Excluir(ByVal contexto As SqlTransaction)

    'Chamada para verificacao de perfil
    PermissaoComissao.VerificarPermissao("texto", "excluir")

    'Prepara parametro
    _paramId.Value = Me._id

    'Executa comando no db
    SqlHelper.ExecuteNonQuery(contexto, CommandType.Text, C_DELETE, _paramId)

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, contexto, C_GET_DATA, _paramId)

  End Sub

#End Region

#Region "Metodos publicos"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'Popula propriedades da tabela texto (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id_art")
    Me.IdComissao = reader("id_com")
    Me.Autor = Convert.ToString(reader("autor"))
    Me.Email = Convert.ToString(reader("email"))
    Me.Titulo = Convert.ToString(reader("titulo"))
    Me.Resumo = Convert.ToString(reader("resumo"))
    Me.Texto = Convert.ToString(reader("texto"))
    Me.MotivoStatus = Convert.ToString(reader("motivo_status"))
    Me.Status = CType(Convert.ToInt32(reader("status")), StatusTexto)
    Me.Oculto = Convert.ToBoolean(reader("oculto"))

  End Sub

  Public Sub Inserir()

    '    SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf Inserir))

  End Sub

  Public Sub Alterar()

    '   SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf Alterar))

  End Sub

  Public Sub Excluir()

    '  SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf Excluir))

  End Sub

#End Region

#Region "Comentarios"

  Public Function ListarComentarios() As IList

    Return ComentarioTexto.Listar(Me.Id, StatusComentario.Aprovado)

  End Function

  Public Function ListarComentariosStatus(ByVal status As StatusComentario) As IList

    Return ComentarioTexto.Listar(Me.Id, status)

  End Function

  Public Function ConsultarComentario(ByVal idComentario As Integer) As ComentarioTexto

    Return ComentarioTexto.Consultar(Me.Id, idComentario)

  End Function

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

  Public Property IdComissao() As Integer
    Get
      Return _idComissao
    End Get
    Set(ByVal Value As Integer)
      _idComissao = Value
    End Set
  End Property

  Public Property Autor() As String
    Get
      Return _autor
    End Get
    Set(ByVal Value As String)
      _autor = Value
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

  Public Property Titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property

  Public Property Resumo() As String
    Get
      Return _resumo
    End Get
    Set(ByVal Value As String)
      _resumo = Value
    End Set
  End Property

  Public Property Texto() As String
    Get
      Return _texto
    End Get
    Set(ByVal Value As String)
      _texto = Value
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

  Public Property Status() As StatusTexto
    Get
      Return _status
    End Get
    Set(ByVal Value As StatusTexto)
      _status = Value
    End Set
  End Property

  Public Property MotivoStatus() As String
    Get
      Return _motivoStatus
    End Get
    Set(ByVal Value As String)
      _motivoStatus = Value
    End Set
  End Property

#End Region

End Class

'Representa um comentario efetuado para um determinado texto
Public Class ComentarioTexto
  Inherits BaseEntidade

#Region "Variaveis membro"

  'Constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "SELECT " + _
                                                    "id_coa AS 'Id', " + _
                                                    "id_art AS 'IdTexto', " + _
                                                    "autor AS 'Autor', " + _
                                                    "email AS 'Email', " + _
                                                    "texto AS 'Texto', " + _
                                                    "dt_criacao AS 'DataCriacao', " + _
                                                    "dt_atualizacao AS 'DataAtualizacao' " + _
                                                 "FROM tbl_comentario_texto " + _
                                                 "where {0} excluido = 0 " + _
                                                 "order by dt_criacao "

  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_comentario_texto " + _
                                                 "where id_art = @id_art and " + _
                                                 "id_coa = @id_coa and excluido = 0"

  Private Shared ReadOnly C_INSERT As String = "insert into tbl_comentario_texto " + _
                                               "(id_art, autor, email, texto, status, " + _
                                               " motivo_status, excluido, receberemail, criador, " + _
                                               " dt_criacao, atualizador, dt_atualizacao) " + _
                                               " values (@id_art, @autor, @email, @texto, 0, " + _
                                               " null, 0, 0, @criador, " + _
                                               " getdate(), @atualizador, getdate());" + _
                                               "select * from tbl_comentario_texto " + _
                                               "where id_art = @id_art and " + _
                                               "id_coa = @@identity"

  Private Shared ReadOnly C_DELETE As String = "update tbl_comentario_texto " + _
                                               "set excluido = 1, " + _
                                               "atualizador = @atualizador, " + _
                                               "dt_atualizacao = getdate() " + _
                                               "where id_art = @id_art and " + _
                                               "id_coa = @id_coa"

  Private Shared ReadOnly C_UPDATE_STATUS As String = "update tbl_comentario_texto " + _
                                                      "set status = @status, " + _
                                                      "motivo_status = @motivo_status, " + _
                                                      "atualizador = @atualizador, " + _
                                                      "dt_atualizacao = getdate() " + _
                                                      "where id_art = @id_art and " + _
                                                      "id_coa = @id_coa"

  'Parametros
  Private _paramIdArt As New SqlParameter("@id_art", SqlDbType.Int)
  Private _paramIdCoa As New SqlParameter("@id_coa", SqlDbType.Int)
  Private _paramAutor As New SqlParameter("@autor", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramTexto As New SqlParameter("@texto", SqlDbType.VarChar)
  Private _paramStatus As New SqlParameter("@status", SqlDbType.Int)
  Private _paramMotivoStatus As New SqlParameter("@motivo_status", SqlDbType.VarChar)

  'Propriedades
  Private _idArt As Integer = 0
  Private _idCoa As Integer = 0
  Private _autor As String = ""
  Private _email As String = ""
  Private _texto As String = ""
  Private _motivoStatus As String = ""
  Private _status As StatusComentario = StatusComentario.Pendente

#End Region

#Region "Consulta / Lista"

  Friend Shared Function Consultar(ByVal idArtigo As Integer, _
                                   ByVal idComentario As Integer) As ComentarioTexto

    'Chama metodo da classe base
    Dim paramArt As New SqlParameter("@id_art", SqlDbType.Int)
    Dim paramCoa As New SqlParameter("@id_coa", SqlDbType.Int)

    paramArt.Value = idArtigo
    paramCoa.Value = idComentario

    Return CType(BaseEntidade.ConsultarEntidade(New ComentarioTexto, _
                                                C_GET_DATA, _
                                                paramArt, _
                                                paramCoa), ComentarioTexto)

  End Function

  Friend Shared Function Listar(ByVal idTexto As Integer, _
                                ByVal ParamArray astatus() As StatusComentario) As IList

    Dim sql As String
    Dim status As StatusComentario

    'Monta clausula de status
    If (Not astatus Is Nothing) Then

      For Each status In astatus
        sql += Convert.ToInt32(status).ToString() + ","
      Next

      If (sql <> "") Then
        sql = " status in (" + sql.Substring(0, sql.Length - 1) + ") and "
      End If

    End If

    'Monta Clasula para Id do texto
    sql += " id_art =" + idTexto.ToString() + " and "

    'Monta consulta
    sql = String.Format(C_GET_LIST, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

#End Region

#Region "Funcoes privadas"

  Private Sub AtualizarParametros()

    'Verifica email
    ValidadorEMail.Validar(_email)

    'Atualiza parametros de usuario
    MyBase.AtualizarParametrosUsuario()

    'Atualiza parametros especificos
    _paramIdArt.Value = _idArt
    _paramIdCoa.Value = _idCoa
    _paramAutor.Value = _autor
    _paramEmail.Value = _email
    _paramTexto.Value = _texto
    _paramStatus.Value = Convert.ToInt32(_status)
    _paramMotivoStatus.Value = _motivoStatus

  End Sub

#End Region

#Region "Metodos publicos"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'Popula propriedades comuns a todas as entidades
    MyBase.PopularDados(reader)

    'Popula propriedades especificas
    Me.Id = reader("id_coa")
    Me.IdTexto = reader("id_art")
    Me.Autor = Convert.ToString(reader("autor"))
    Me.Email = Convert.ToString(reader("email"))
    Me.Texto = Convert.ToString(reader("texto"))
    Me.MotivoStatus = Convert.ToString(reader("motivo_status"))
    Me.Status = CType(Convert.ToInt32(reader("status")), StatusComentario)

  End Sub

  Public Sub Inserir()

    'Prepara parametros
    AtualizarParametros()

    'Executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _
                                                       _paramIdArt, _
                                                       _paramAutor, _
                                                       _paramEmail, _
                                                       _paramTexto, _
                                                       _paramCriador, _
                                                       _paramAtualizador)

    Try

      'Popula dados
      If (ret.Read()) Then
        PopularDados(ret)
      End If

    Finally

      'Fecha reader se necessario
      If (Not ret.IsClosed()) Then
        ret.Close()
      End If

    End Try

  End Sub

  Public Sub AlterarStatus()

    'Chamada para verificacao de perfil
    PermissaoComissao.VerificarPermissao("comentariotexto", "alterarstatus")

    'Atualiza parametros
    AtualizarParametros()

    'Executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_STATUS, _
                              _paramIdArt, _
                              _paramIdCoa, _
                              _paramStatus, _
                              _paramMotivoStatus, _
                              _paramAtualizador)

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, C_GET_DATA, _paramIdArt, _paramIdCoa)

  End Sub

  Public Sub Excluir()

    'Chamada para verificacao de perfil
    PermissaoComissao.VerificarPermissao("comentariotexto", "excluir")

    'Prepara parametros
    _paramIdArt.Value = _idArt
    _paramIdCoa.Value = _idCoa

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramIdArt, _paramIdCoa)

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, C_GET_DATA, _paramIdArt, _paramIdCoa)

  End Sub

#End Region

#Region "Propriedades"

  Public Property Id() As Integer
    Get
      Return _idCoa
    End Get
    Set(ByVal Value As Integer)
      _idCoa = Value
    End Set
  End Property

  Public Property IdTexto() As Integer
    Get
      Return _idArt
    End Get
    Set(ByVal Value As Integer)
      _idArt = Value
    End Set
  End Property

  Public Property Autor() As String
    Get
      Return _autor
    End Get
    Set(ByVal Value As String)
      _autor = Value
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

  Public Property Texto() As String
    Get
      Return _texto
    End Get
    Set(ByVal Value As String)
      _texto = Value
    End Set
  End Property

  Public Property MotivoStatus() As String
    Get
      Return _motivoStatus
    End Get
    Set(ByVal Value As String)
      _motivoStatus = Value
    End Set
  End Property

  Public Property Status() As StatusComentario
    Get
      Return _status
    End Get
    Set(ByVal Value As StatusComentario)
      _status = Value
    End Set
  End Property

#End Region

End Class

'Pesquisa de textos
Public NotInheritable Class PesquisaTexto
  Inherits BasePesquisa

#Region "Variaveis membro"

  Private Shared ReadOnly C_GET_LIST As String = "SELECT art.id_art AS 'Id', art.autor AS 'Autor', art.email AS 'Email', " + _
                                                 "art.titulo AS 'Titulo', art.resumo AS 'Resumo', art.texto AS 'Texto', " + _
                                                 "art.id_com AS 'IdComissao', dt_criacao AS 'DataCriacao', " + _
                                                 "(select count(coa.id_coa) from tbl_comentario_texto coa " + _
                                                 " where coa.id_art = art.id_art and coa.status = 1) AS 'Comentarios', " + _
                                                 "(select count(coa.id_coa) from tbl_comentario_texto coa " + _
                                                 " where coa.id_art = art.id_art and coa.status = 0) AS 'ComentariosPendentes' " + _
                                                 "FROM tbl_texto art " + _
                                                 "where {0} art.excluido = 0 " + _
                                                 "order by art.titulo "


#End Region

#Region "Metodos estaticos"

  Private Shared Function ClausulaPadrao(ByVal idComissao As String) As String

    Dim ret As String

    'Monta clausula do id da comissao
    ret = "(art.id_com = " + idComissao.ToString() + " or " + _
          " exists(select * from tbl_assoc_comissao_texto ca " + _
          " where ca.id_art = art.id_art and ca.status = 1 and " + _
          " ca.id_com = " + idComissao.ToString() + ")) " + _
          IIf(Usuario.UsuarioCorrente.Autenticado, "", " and oculto = 0 ")

    'Retorno
    Return ret

  End Function

  Private Shared Function ListarComissao(ByVal idComissao As Integer) As IList

    Dim sql As String

    'Monta consulta
    sql = ClausulaPadrao(idComissao) + " and art.status = 1 and "
    sql = String.Format(C_GET_LIST, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Private Shared Function ListarStatus(ByVal idComissao As Integer, _
                                         ByVal status As StatusTexto) As IList

    Dim sql As String
    Dim istatus As Integer

    'Monta consulta
    istatus = Convert.ToInt32(status)
    sql = ClausulaPadrao(idComissao) + _
          " and art.status = " + _
          istatus.ToString() + " and "
    sql = String.Format(C_GET_LIST, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

  Public Shared Function ListarComissaoCorrente() As IList

    'Chama overload
    Return ListarComissao(Comissao.ComissaoCorrente.Id)

  End Function

  Public Shared Function ListarStatusComissaoCorrente(ByVal status As StatusTexto) As IList

    'Somente usuarios com perfil de alterar texto podem
    'ver esta lista
    PermissaoComissao.VerificarPermissao("texto", "alterar")

    'Chama overload
    Return ListarStatus(Comissao.ComissaoCorrente.Id, status)

  End Function

#End Region

#Region "Metodos abstratos de BasePesquisa"

  Protected Overrides Function MontaResultado(ByVal record As IDataRecord) As ResultadoPesquisa

    Dim fragmento As String

    fragmento = ExtrairFragmento("RESUMO : " + Convert.ToString(record("Resumo")) + vbCrLf + "CONTEUDO : " + _
                                 Convert.ToString(record("Texto")), _
                                 150)

        Dim item As New ResultadoPesquisa(Convert.ToInt32(record("Id")), _
                                      Convert.ToString(record("Titulo")), _
                                      fragmento)

    Return item

  End Function

  Public Overrides Function Pesquisar() As ColecaoResultadoPesquisa

    'Monta consulta
    Dim sql As String
    Dim reader As SqlDataReader
    Dim params As SqlParameter()

    'Monta array de parametros
    params = MontarParametros()

    'Monta sql
    sql = ClausulaPadrao(Comissao.ComissaoCorrente.Id) + _
          " and art.status in (1,2) and "

    sql += "(" + _
            MontarClausulaWhere("resumo") + " or " + _
            MontarClausulaWhere("texto") + " or " + _
            MontarClausulaWhere("titulo") + ") and"

    sql = String.Format(C_GET_LIST, sql)

    'Executa pesquisa
    Return PesquisarSQL(sql, params)

  End Function

#End Region

End Class