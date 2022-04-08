Public Class Poster
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_LIST As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where Excluido = 0 order by titulo"
  Private Shared ReadOnly C_GET_LIST_EM_AVALIACAO As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where Excluido = 0 and status = 'Em avaliação' order by titulo"
  Private Shared ReadOnly C_GET_LIST_USUARIO As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where id_usu = {0} and Excluido = 0 order by titulo"
  Private Shared ReadOnly C_GET_LIST_USUARIO_PARECERISTA As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo', resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where id_parecerista = {0} and Excluido = 0  and status = 'EM AVALIAÇÃO' order by titulo"
  Private Shared ReadOnly C_GET_LIST_EIXO As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo',  resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where eixo = {0} and Excluido = 0"
  Private Shared ReadOnly C_GET_LIST_RESUMO As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo',  resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where id = {0} and Excluido = 0"
  Private Shared ReadOnly C_GET_LIST_EIXO_STATUS As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo',  resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where eixo = {0} and id_parecerista = {0} and Excluido = 0 and status = 'EM AVALIAÇÃO'"
  Private Shared ReadOnly C_GET_LIST_PARECERISTA_STATUS As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo',  resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where id_parecerista = {0} and Excluido = 0 and status = 'EM AVALIAÇÃO'"
  Private Shared ReadOnly C_GET_LIST_EIXOSTATUS As String = "select id as 'id', id_usu as 'id_usu', id_parecerista as 'Id_parecerista', autor as 'Autor', titulo as 'Titulo',  resumo as 'Resumo', outros_autores as 'Outros_autores', palavra as 'Palavra', status as 'Status' from tbl_poster_medicalizacao where id_parecerista = @id_parecerista and Excluido = 0 and status = 'EM AVALIAÇÃO'"

  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_poster_medicalizacao where id = @id"
  Private Shared ReadOnly C_GET_DATA_EIXO As String = "select * from tbl_poster_medicalizacao where eixo = @eixo"
  Private Shared ReadOnly C_GET_DATA_AUTOR As String = "select * from tbl_poster_medicalizacao where id_usu = @id_usu"
  Private Shared ReadOnly C_INSERT As String = "insert into tbl_poster_medicalizacao (id_usu, id_parecerista, autor, titulo, resumo, outros_autores, palavra, status, excluido, criador, dt_criacao, atualizador, dt_atualizacao) " + _
                                               "values(@id_usu, @id_parecerista, @autor, @titulo, @resumo, @outros_autores, @palavra, @status,0,1,getdate(),1,getdate());" + _
                                               "select * from tbl_poster_medicalizacao where id = @@identity"
  Private Shared ReadOnly C_DELETE As String = "update tbl_poster_medicalizacao set excluido = 1 where id = @id"
  Private Shared ReadOnly C_UPDATE As String = "update tbl_poster_medicalizacao set id_usu = @id_usu, id_parecerista = @id_parecerista, autor = @autor, titulo = @titulo, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = @status where id = @id"
  Private Shared ReadOnly C_UPDATE_TRABALHO As String = "update tbl_poster_medicalizacao set autor = @autor, titulo = @titulo, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = @status where id = @id"
  Private Shared ReadOnly C_UPDATE_STATUS As String = "update tbl_poster_medicalizacao set status = @status, dt_atualizacao = getdate() where id = @id"
  Private Shared ReadOnly C_UPDATE_APROVADO As String = "update tbl_poster_medicalizacao set id_usu = @id_usu, id_parecerista = @id_parecerista, autor = @autor, titulo = @titulo, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = 'Aprovado' where id = @id"
  Private Shared ReadOnly C_UPDATE_REPROVADO As String = "update tbl_poster_medicalizacao set id_usu = @id_usu, id_parecerista = @id_parecerista, autor = @autor, titulo = @titulo, resumo = @resumo, outros_autores = @outros_autores, palavra = @palavra, status = 'Reprovado' where id = @id"

  ' parametros
  Private _paramId As New SqlParameter("@id", SqlDbType.Int)
  Private _paramid_usu As New SqlParameter("@id_usu", SqlDbType.Int)
  Private _paramId_parecerista As New SqlParameter("@id_parecerista", SqlDbType.Int)
  Private _paramautor As New SqlParameter("@autor", SqlDbType.VarChar)
  Private _paramtitulo As New SqlParameter("@titulo", SqlDbType.VarChar)
  Private _paramresumo As New SqlParameter("@resumo", SqlDbType.VarChar)
  Private _paramoutros_autores As New SqlParameter("@outros_autores", SqlDbType.VarChar)
  Private _parampalavra As New SqlParameter("@palavra", SqlDbType.VarChar)
  Private _paramstatus As New SqlParameter("@status", SqlDbType.VarChar)

  ' propriedades
  Private _id As Integer
  Private _id_usu As Integer
  Private _id_parecerista As Integer
  Private _autor As String
  Private _titulo As String
  Private _resumo As String
  Private _outros_autores As String
  Private _palavra As String
  Private _status As String

#End Region

#Region "Static Methods"

  Public Shared Function Consultar(ByVal id As Integer) As Object

    Dim ret As New Poster
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
    Throw New Exception("Poster não encotrado.")

  End Function
  Public Shared Function ConsultarTrabalho(ByVal id As Integer) As Object

    Dim ret As New Poster
    Dim param As New SqlParameter("@id", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      '      ret.PopularDados(reader)
      '     Return ret

      Throw New Exception("Poster nao encotrado.")

    Else

      ' retorna novo objeto
      'Throw New Exception("CPF não encotrado.")

    End If

  End Function
  Public Shared Function ConsultarTrabalhoCadastrado(ByVal id_usu As Integer) As Object

    Dim ret As New Poster
    Dim param As New SqlParameter("@id_usu", SqlDbType.Int)

    ' prepara parametro
    param.Value = id_usu

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_AUTOR, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      '      ret.PopularDados(reader)
      '     Return ret

      Throw New Exception("Poster nao encotrado.")

    Else

      ' retorna novo objeto
      'Throw New Exception("CPF não encotrado.")

    End If

  End Function
  Public Shared Function Listar() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

  Public Shared Function ListarEmAvaliacao() As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(C_GET_LIST_EM_AVALIACAO)

  End Function


  Public Shared Function ListarPosterUsuario(ByVal id_usu As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_USUARIO, id_usu))

  End Function
  Public Shared Function ListarPosterUsuarioParecerista(ByVal id_parecerista As Integer) As IList

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_USUARIO_PARECERISTA, id_parecerista))

  End Function

  Public Shared Function ListarPosterEixo(ByVal xeixo As String) As IList

    xeixo = "'" + xeixo + "'"

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_EIXO, xeixo))

  End Function

  Public Shared Function ListarPosterResumo(ByVal id As Integer) As IList

    id = id

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_RESUMO, id))

  End Function

  Public Shared Function ListarPosterEixoEmAvaliacao(ByVal xeixo As String, ByVal xid As Integer) As IList

    xeixo = "'" + xeixo + "'"
    xid = xid

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_EIXO_STATUS, xeixo, xid))

  End Function

  Public Shared Function ListarPosterEmAvaliacaoParecerista(ByVal xid As Integer) As IList

    xid = xid

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_PARECERISTA_STATUS, xid))

  End Function
  Public Shared Function ListarPosterEixoEmAvaliacaoparecerista(ByVal id As Integer) As IList

    Dim ret As New Poster
    Dim paramid_parecerista As New SqlParameter("@id_parecerista", SqlDbType.Int)
    Dim parameixo As New SqlParameter("@eixo", SqlDbType.VarChar)

    ' prepara parametro
    paramid_parecerista.Value = id
    'parameixo.Value = eixo

    'retorna lista
    Return ListaHelper.ListarRegistros(String.Format(C_GET_LIST_EIXOSTATUS, paramid_parecerista))

    '' executa comando no db
    'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA, param)

    '' verifica se encontrou o registro
    'If (reader.Read()) Then

    '  ret.PopularDados(reader)
    '  Return ret

    'End If

    '' retorna novo objeto
    'Throw New Exception("Poster não encotrado.")

  End Function

#End Region

#Region "Private Functions"

  Private Sub AtualizarParametros()

    _paramid_usu.Value = _id_usu
    _paramId_parecerista.Value = _id_parecerista
    _paramautor.Value = _autor
    _paramtitulo.Value = _titulo
    _paramresumo.Value = _resumo
    _paramoutros_autores.Value = _outros_autores
    _parampalavra.Value = _palavra
    _paramstatus.Value = _status

  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popular proiedades
    Me.Id = reader("id")
    Me.id_usu = reader("id_usu")
    Me.id_parecerista = reader("id_parecerista")
    Me.autor = reader("autor")
    Me.titulo = reader("titulo")
    Me.resumo = reader("resumo")
    Me.outros_autores = reader("outros_autores")
    Me.palavra = reader("palavra")
    Me.status = reader("status")

  End Sub

  Public Sub Inserir()

    'Chamada para verificacao de perfil
    '  PermissaoGlobal.VerificarPermissao("link", "inserir")

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _paramid_usu, _paramId_parecerista, _paramautor, _paramtitulo, _paramresumo, _paramoutros_autores, _parampalavra, _paramstatus)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Sub Alterar()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _paramId, _paramid_usu, _paramId_parecerista, _paramautor, _paramtitulo, _paramresumo, _paramoutros_autores, _parampalavra, _paramstatus)

  End Sub

  Public Sub AlterarTrabalho()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_TRABALHO, _paramId, _paramautor, _paramtitulo, _paramresumo, _paramoutros_autores, _parampalavra, _paramstatus)

  End Sub
  Public Sub AlterarStatus()

    'Chamada para verificacao de perfil
    'PermissaoGlobal.VerificarPermissao("link", "alterar")

    ' prepara parametros
    _paramId.Value = Me._id
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE_STATUS, _paramId, _paramstatus)

  End Sub
  Public Sub Excluir()

    'Chamada para verificacao de perfil
    '    PermissaoGlobal.VerificarPermissao("link", "excluir")

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

  Public Property id_usu() As Integer
    Get
      Return _id_usu
    End Get
    Set(ByVal Value As Integer)
      _id_usu = Value
    End Set
  End Property
  Public Property id_parecerista() As Integer
    Get
      Return _id_parecerista
    End Get
    Set(ByVal Value As Integer)
      _id_parecerista = Value
    End Set
  End Property

  Public Property autor() As String
    Get
      Return _autor
    End Get
    Set(ByVal Value As String)
      _autor = Value
    End Set
  End Property

  Public Property titulo() As String
    Get
      Return _titulo
    End Get
    Set(ByVal Value As String)
      _titulo = Value
    End Set
  End Property
  Public Property resumo() As String
    Get
      Return _resumo
    End Get
    Set(ByVal Value As String)
      _resumo = Value
    End Set
  End Property

  Public Property outros_autores() As String
    Get
      Return _outros_autores
    End Get
    Set(ByVal Value As String)
      _outros_autores = Value
    End Set
  End Property
  Public Property palavra() As String
    Get
      Return _palavra
    End Get
    Set(ByVal Value As String)
      _palavra = Value
    End Set
  End Property

  Public Property status() As String
    Get
      Return _status
    End Get
    Set(ByVal Value As String)
      _status = Value
    End Set
  End Property

#End Region

End Class
