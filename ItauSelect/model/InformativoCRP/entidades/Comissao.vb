Imports System.Runtime.Remoting.Messaging

'Areas para montar menu da comissao
<Flags()> _
 Public Enum AreasComissao
  Nenhuma = 0
  Agenda = 1
  Noticia = 2
  Relatorio = 4
  Texto = 8
  Forum = 16
  Links = 32
  LegislacaoEspecifica = 64
  FaleConosco = 128
End Enum

'Tipos de Comissao
Public Enum TipoComissao
  Comissao = 0
  GrupoTrabalho = 1
  Subsede = 2
End Enum

'Classe para representar comissoes do sistema
Public Class Comissao
  Inherits BaseEntidade

#Region "Member Variables"

  ' constantes para SQL
  Private Shared ReadOnly C_GET_MEMBERS As New String("select u.* from tbl_usuario_evento u inner join " & _
                                                      "tbl_comissao_usuario uc on u.id_usu = uc.id_usu " & _
                                                      "where uc.id_com = @id_com order by u.nome")

  Private Shared ReadOnly C_GET_LIST As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                  " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                  " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                  " from tbl_comissao" + _
                                                  " where {0} excluido = 0 and tipo <> 2" + _
                                                  " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                    " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                    " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                    " from tbl_comissao" + _
                                                    " where {0} excluido = 0 and tipo = 2" + _
                                                    " order by Nome"
  'Assis
  Private Shared ReadOnly C_GET_LIST_SUB_ASSIS As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                      " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                      " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                      " from tbl_comissao" + _
                                                      " where {0} id_com = 17 and excluido = 0 and tipo = 2" + _
                                                      " order by nome"
  'Bauru
  Private Shared ReadOnly C_GET_LIST_SUB_BAURU As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                      " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                      " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                      " from tbl_comissao" + _
                                                      " where {0} id_com = 18 and excluido = 0 and tipo = 2" + _
                                                      " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB_CAMPINAS As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                      " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                      " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                      " from tbl_comissao" + _
                                                      " where {0} id_com = 19 and excluido = 0 and tipo = 2" + _
                                                      " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB_GRANDEABC As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                        " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                        " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                        " from tbl_comissao" + _
                                                        " where {0} id_com = 20 and excluido = 0 and tipo = 2" + _
                                                        " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB_RIBEIRAOPRETO As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                        " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                        " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                        " from tbl_comissao" + _
                                                        " where {0} id_com = 21 and excluido = 0 and tipo = 2" + _
                                                        " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB_SANTOS As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                        " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                        " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                        " from tbl_comissao" + _
                                                        " where {0} id_com = 22 and excluido = 0 and tipo = 2" + _
                                                        " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB_SJRPRETO As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                        " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                        " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                        " from tbl_comissao" + _
                                                        " where {0} id_com = 23 and excluido = 0 and tipo = 2" + _
                                                        " order by nome"

  Private Shared ReadOnly C_GET_LIST_SUB_TAUBATE As String = "select id_com as 'Id', nome as 'Nome', email as 'Email', sigla as 'Sigla', titulo_apresentacao as 'TituloApresentacao', apresentacao as 'Apresentacao', " + _
                                                       " titulo_coordenador as 'TituloCoordenador', titulo_membros as 'TituloMembros', id_usu as 'IdCoordenador', criador as 'IdCriador', dt_criacao as 'DataCriacao', " + _
                                                       " atualizador as 'IdAtualizador', dt_atualizacao as 'DataAtualizacao', excluido as 'Excluido', oculto as 'Oculto', tipo as 'Tipo'" + _
                                                       " from tbl_comissao" + _
                                                       " where {0} id_com = 24 and excluido = 0 and tipo = 2" + _
                                                       " order by nome"

  Private Shared ReadOnly C_GET_DATA As String = "select * from tbl_comissao where id_com = @id_com"

  Private Shared ReadOnly C_INSERT As String = " insert into tbl_comissao (nome, email, sigla, areas, titulo_apresentacao, apresentacao, " + _
                                                                          "titulo_coordenador, titulo_membros, id_usu, criador, dt_criacao, " + _
                                                                          "atualizador, dt_atualizacao, excluido, oculto, tipo) " + _
                                               " values(@nome, @email, @sigla, @areas, @titulo_apresentacao, @apresentacao, " + _
                                                       "@titulo_coordenador, @titulo_membros, @id_usu, @criador, getdate(), " + _
                                                       "@atualizador, getdate(), 0, @oculto, @tipo); " + _
                                               " select * from tbl_comissao where id_com = @@identity"

  Private Shared ReadOnly C_DELETE As String = " update tbl_comissao set excluido = 1, atualizador = @atualizador, dt_atualizacao = getdate() " + _
                                               " where id_com = @id_com"

  Private Shared ReadOnly C_UPDATE As String = " update tbl_comissao set nome = @nome, email = @email, sigla = @sigla, areas = @areas, titulo_apresentacao = @titulo_apresentacao, apresentacao = @apresentacao, " + _
                                                                          "titulo_coordenador = @titulo_coordenador, titulo_membros = @titulo_membros, id_usu = @id_usu, " + _
                                                                          "atualizador = @atualizador, dt_atualizacao = getdate(), oculto = @oculto, tipo = @tipo " + _
                                               " where id_com = @id_com"
  Private Shared ReadOnly C_UPDATE_APRES As String = " update tbl_comissao set nome = @nome, email = @email, sigla = @sigla, titulo_apresentacao = @titulo_apresentacao, apresentacao = @apresentacao, " + _
                                                                        "titulo_coordenador = @titulo_coordenador, titulo_membros = @titulo_membros, " + _
                                                                        "atualizador = @atualizador, dt_atualizacao = getdate() " + _
                                             " where id_com = @id_com"

  ' parametros
  Private _paramIdCom As New SqlParameter("@id_com", SqlDbType.Int)
  Private _paramNome As New SqlParameter("@nome", SqlDbType.VarChar)
  Private _paramEmail As New SqlParameter("@email", SqlDbType.VarChar)
  Private _paramSigla As New SqlParameter("@sigla", SqlDbType.VarChar)
  Private _paramTituloApresentacao As New SqlParameter("@titulo_apresentacao", SqlDbType.VarChar)
  Private _paramApresentacao As New SqlParameter("@apresentacao", SqlDbType.VarChar)
  Private _paramTituloCoordenador As New SqlParameter("@titulo_coordenador", SqlDbType.VarChar)
  Private _paramTituloMembros As New SqlParameter("@titulo_membros", SqlDbType.VarChar)
  Private _paramIdUsu As New SqlParameter("@id_usu", SqlDbType.Int)
  Private _paramOculto As New SqlParameter("@oculto", SqlDbType.Bit)
  Private _paramAreas As New SqlParameter("@areas", SqlDbType.Int)
  Private _paramTipo As New SqlParameter("@tipo", SqlDbType.Int)

  ' propriedades
  Private _id_com As Integer
  Private _nome As String
  Private _email As String
  Private _sigla As String
  Private _titulo_apresentacao As String
  Private _apresentacao As String
  Private _titulo_coordenador As String
  Private _titulo_membros As String
  Private _id_usu As Integer
  Private _areas As AreasComissao = AreasComissao.Nenhuma
  Private _oculta As Boolean
  Private _membros As ColecaoUsuario
  Private _tipo As TipoComissao = TipoComissao.Comissao

#End Region

#Region "Funcao consultar"

  Public Shared Function Consultar(ByVal id As Integer) As Comissao

    'Chama metodo da classe base
    Dim param As New SqlParameter("@id_com", SqlDbType.Int)
    param.Value = id

    Dim ret As Comissao

    ret = CType(BaseEntidade.ConsultarEntidade(New Comissao, C_GET_DATA, param), Comissao)

    'Se a comissao for oculta e nao estamos conectados, retorna nova comissao
    If (ret.Oculta And Not Usuario.UsuarioCorrente.Autenticado) Then
      Return New Comissao
    End If

    Return ret

  End Function

#End Region

#Region "Listar Comissão"

  Public Shared Function Listar() As IList

    Dim sql As String

    'Monta consulta
    sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and ")
    sql = String.Format(C_GET_LIST, sql)

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

#End Region

#Region "Listar Subsede"

  Public Shared Function ListarSubsede() As IList

    Dim sql As String
    Dim IdCom As Integer
    IdCom = Comissao.ComissaoCorrente.Id.ToString

    'Monta consulta
    sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and ") 'id_com = IdCom and")
    sql = String.Format(C_GET_LIST_SUB, sql)

    '  sql = IIf(
    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

#End Region

#Region "Listar Subsede Login"

  Public Shared Function ListarSubsedeLogin() As IList

    Dim sql As String

    If Usuario.UsuarioCorrente.Logon = "Assis" Then
      'Monta consulta Assis
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_ASSIS, sql)
    Elseif Usuario.UsuarioCorrente.Logon = "Bauru" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_BAURU, sql)
    Elseif  Usuario.UsuarioCorrente.Logon = "Campinas" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_CAMPINAS, sql)
    Elseif  Usuario.UsuarioCorrente.Logon = "Abc" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_GRANDEABC, sql)
    Elseif  Usuario.UsuarioCorrente.Logon = "Ribeirao" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_RIBEIRAOPRETO, sql)
    Elseif  Usuario.UsuarioCorrente.Logon = "Santos" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_SANTOS, sql)
    Elseif  Usuario.UsuarioCorrente.Logon = "SaoJose" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_SJRPRETO, sql)
    Elseif Usuario.UsuarioCorrente.Logon = "Paraiba" Then
      'Monta consulta bauru
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB_TAUBATE, sql)
    Else
      'Monta consulta geral
      sql = IIf(Usuario.UsuarioCorrente.Autenticado, "", "oculto = 0 and")
      sql = String.Format(C_GET_LIST_SUB, sql)
    End If

    'Retorna lista
    Return ListaHelper.ListarRegistros(sql)

  End Function

#End Region

#Region "Funções Privadas"

  Private Sub AtualizarParametros()

    'testa areas
    If (_areas = AreasComissao.Nenhuma) Then
      Throw New InvalidOperationException("Favor informar uma ou mais áreas")
    End If

    'atualiza paramatros especificos
    _paramIdCom.Value = _id_com
    _paramNome.Value = _nome
    _paramEmail.Value = _email
    _paramSigla.Value = _sigla
    _paramTituloApresentacao.Value = _titulo_apresentacao
    _paramApresentacao.Value = _apresentacao
    _paramTituloCoordenador.Value = _titulo_coordenador
    _paramTituloMembros.Value = _titulo_membros
    _paramIdUsu.Value = _id_usu
    _paramAreas.Value = Convert.ToInt32(_areas)
    _paramOculto.Value = Convert.ToInt32(_oculta)
    _paramTipo.Value = Convert.ToInt32(_tipo)

    'parametros de log
    MyBase.AtualizarParametrosUsuario()

  End Sub

  Private Sub AtualizarParametrosApres()

    'testa areas
    'If (_areas = AreasComissao.Nenhuma) Then
    'Throw New InvalidOperationException("Favor informar uma ou mais áreas")
    'End If

    'atualiza paramatros especificos
    _paramIdCom.Value = _id_com
    _paramNome.Value = _nome
    _paramEmail.Value = _email
    _paramSigla.Value = _sigla
    _paramTituloApresentacao.Value = _titulo_apresentacao
    _paramApresentacao.Value = _apresentacao
    _paramTituloCoordenador.Value = _titulo_coordenador
    _paramTituloMembros.Value = _titulo_membros
    _paramIdUsu.Value = _id_usu
    _paramAreas.Value = Convert.ToInt32(_areas)
    _paramOculto.Value = Convert.ToInt32(_oculta)
    _paramTipo.Value = Convert.ToInt32(_tipo)

    'parametros de log
    MyBase.AtualizarParametrosUsuario()

  End Sub


#End Region

#Region "Popular Dados"

  'Popula membros para uma comissao
  Private Shared Function PopularMembros(ByVal idComissao As Integer) As ColecaoUsuario

    'Prepara parametros
    Dim param As SqlParameter = New SqlParameter("@id_com", SqlDbType.Int)
    param.Value = idComissao

    Return ColecaoHelper.PopularColecaoEntidade(C_GET_MEMBERS, New ColecaoUsuario, True, param)

  End Function

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula as propriedades da tabela Comissao
    MyBase.PopularDados(reader)

    'popular proiedades
    Me._id_com = reader("id_com")
    Me._nome = reader("nome")
    Me._email = reader("email")
    Me._sigla = reader("sigla")
    Me._titulo_apresentacao = reader("titulo_apresentacao")
    Me._apresentacao = reader("apresentacao")
    Me._titulo_coordenador = reader("titulo_coordenador")
    Me._titulo_membros = reader("titulo_membros")
    Me._id_usu = reader("id_usu")
    Me._areas = CType(reader("areas"), AreasComissao)
    Me._oculta = CType(reader("oculto"), Boolean)
    Me._tipo = CType(reader("tipo"), TipoComissao)

  End Sub

#End Region

#Region "Metodos Internos"

  Friend Sub Inserir(ByVal contexto As SqlTransaction)

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("comissao", "inserir")

    'Prepara parametros
    AtualizarParametros()

    'Executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(contexto, _
                                                      CommandType.Text, _
                                                      C_INSERT, _
                                                      _paramNome, _
                                                      _paramEmail, _
                                                      _paramSigla, _
                                                      _paramTituloApresentacao, _
                                                      _paramApresentacao, _
                                                      _paramTituloCoordenador, _
                                                      _paramTituloMembros, _
                                                      _paramIdUsu, _
                                                      _paramCriador, _
                                                      _paramAtualizador, _
                                                      _paramAreas, _
                                                      _paramOculto, _
                                                      _paramTipo)

    'Consulta dados
    If ret.Read() Then
      PopularDados(ret)
    End If

    ret.Close()

    'Atualiza membros
    AtualizarMembros(contexto)

  End Sub

  Friend Sub Alterar(ByVal contexto As SqlTransaction)

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("comissao", "alterar")

    'Prepara parametros
    AtualizarParametros()

    'Executa comando no db
    SqlHelper.ExecuteNonQuery(contexto, _
                              CommandType.Text, _
                              C_UPDATE, _
                              _paramIdCom, _
                              _paramNome, _
                              _paramEmail, _
                              _paramSigla, _
                              _paramTituloApresentacao, _
                              _paramApresentacao, _
                              _paramTituloCoordenador, _
                              _paramTituloMembros, _
                              _paramIdUsu, _
                              _paramAtualizador, _
                              _paramOculto, _
                              _paramAreas, _
                              _paramTipo)

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, contexto, C_GET_DATA, _paramIdCom)

    'Atualiza membros
    AtualizarMembros(contexto)

  End Sub

  Friend Sub AlterarApres(ByVal contexto As SqlTransaction)

    'Chamada para verificacao de perfil
    'comentar a permissão, por que devemos, criar um perfil para este tipo de alteração.
    'PermissaoGlobal.VerificarPermissao("comissao", "alterar")

    'Prepara parametros
    AtualizarParametrosApres()

    'Executa comando no db
    SqlHelper.ExecuteNonQuery(contexto, _
                              CommandType.Text, _
                              C_UPDATE_APRES, _
                              _paramIdCom, _
                              _paramNome, _
                              _paramEmail, _
                              _paramSigla, _
                              _paramTituloApresentacao, _
                              _paramApresentacao, _
                              _paramTituloCoordenador, _
                              _paramTituloMembros, _
                              _paramAtualizador _
                              )

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, contexto, C_GET_DATA, _paramIdCom)

    'Atualiza membros
    AtualizarMembros(contexto)

  End Sub

  Friend Sub Excluir(ByVal contexto As SqlTransaction)

    'Chamada para verificacao de perfil
    PermissaoGlobal.VerificarPermissao("comissao", "excluir")

    'Prepara parametro
    AtualizarParametros()

    'Deleta membros
    SqlHelper.ExecuteNonQuery(contexto, _
                              CommandType.Text, _
                              "delete from tbl_comissao_usuario " + _
                              "where id_com = " + Me.Id.ToString())

    'Delete comissao
    SqlHelper.ExecuteNonQuery(contexto, _
                              CommandType.Text, _
                              C_DELETE, _
                              _paramIdCom, _
                              _paramAtualizador)

    'Consulta dados
    BaseEntidade.ConsultarEntidade(Me, contexto, C_GET_DATA, _paramIdCom)

  End Sub

  Friend Sub AtualizarMembros(ByVal contexto As SqlTransaction)

    'Variaveis locais
    Dim sql As String
    Dim list As String
    Dim delClause As String
    Dim insClause As String
    Dim usu As Usuario

    'Testa se temos algum item na colecao
    If (Me.Membros.Count > 0) Then

      'Monta clausula in
      For Each usu In Me.Membros
        list += usu.Id.ToString() + ","
      Next
      list = list.Substring(0, list.Length - 1)

      delClause = "id_usu not in(" + list + ")"
      insClause = "id_usu in(" + list + ")"

    Else

      delClause = "1=1"
      insClause = "1=2"

    End If

    'Deleta perfis de membros excluidos
    sql = "delete from tbl_comissao_perfil where id_com = " + _
          Me.Id.ToString() + " and " + delClause

    SqlHelper.ExecuteNonQuery(contexto, CommandType.Text, sql)

    'Deleta membros excluidos
    sql = "delete from tbl_comissao_usuario where id_com = " + _
          Me.Id.ToString() + " and " + delClause

    SqlHelper.ExecuteNonQuery(contexto, CommandType.Text, sql)

    'Insere membros novos
    sql = "insert into tbl_comissao_usuario (id_com,id_usu) " + _
          "select " + Me.Id.ToString() + ",id_usu " + _
          "from tbl_usuario_evento u where " + insClause + " " + _
          "and not exists(select * from tbl_comissao_usuario uc " + _
          "where uc.id_usu = u.id_usu and uc.id_com = " + Me.Id.ToString() + ")"

    SqlHelper.ExecuteNonQuery(contexto, CommandType.Text, sql)


  End Sub

#End Region

#Region "Metodos Publicos"

  Public Sub Inserir()

    'SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf Inserir))

  End Sub

  Public Sub Alterar()

    'SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf Alterar))

  End Sub
  Public Sub AlterarApres()

    SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf AlterarApres))

  End Sub
  Public Sub Excluir()

    'SqlHelper.ProcessTransactionOperation(New TransactionProcessor(AddressOf Excluir))

  End Sub

  Public Function SouMembro() As Boolean

    Return (Me.Membros.ContemUsuario(Usuario.UsuarioCorrente.Id) _
            Or Me.IdCoordenador = Usuario.UsuarioCorrente.Id)

  End Function

#End Region

#Region "Propriedades"

  'Propriedades
  Public Property Id() As Integer

    Get

      Return _id_com

    End Get

    Set(ByVal Value As Integer)

      _id_com = Value

    End Set

  End Property

  Public Property Nome() As String

    Get

      Return _nome

    End Get

    Set(ByVal Value As String)

      _nome = Value

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

  Public Property Sigla() As String

    Get

      Return _sigla

    End Get

    Set(ByVal Value As String)

      _sigla = Value

    End Set

  End Property

  Public Property TituloApresentacao() As String

    Get

      Return _titulo_apresentacao

    End Get

    Set(ByVal Value As String)

      _titulo_apresentacao = Value

    End Set

  End Property

  Public Property Apresentacao() As String

    Get

      Return _apresentacao

    End Get

    Set(ByVal Value As String)

      _apresentacao = Value

    End Set

  End Property

  Public Property TituloCoordenador() As String

    Get

      Return _titulo_coordenador

    End Get

    Set(ByVal Value As String)

      _titulo_coordenador = Value

    End Set

  End Property

  Public Property TituloMembros() As String

    Get

      Return _titulo_membros

    End Get

    Set(ByVal Value As String)

      _titulo_membros = Value

    End Set

  End Property

  Public Property IdCoordenador() As Integer

    Get

      Return _id_usu

    End Get

    Set(ByVal Value As Integer)

      _id_usu = Value

    End Set

  End Property

  Public Property Areas() As AreasComissao

    Get

      Return _areas

    End Get

    Set(ByVal Value As AreasComissao)

      _areas = Value

    End Set

  End Property

  Public Property Oculta() As Boolean

    Get

      Return _oculta

    End Get

    Set(ByVal Value As Boolean)

      _oculta = Value

    End Set

  End Property

  Public ReadOnly Property Membros() As ColecaoUsuario

    Get

      If (_membros Is Nothing) Then

        _membros = PopularMembros(Me.Id)

      End If

      Return _membros

    End Get

  End Property

  Public Property Tipo() As TipoComissao
    Get
      Return _tipo
    End Get
    Set(ByVal Value As TipoComissao)
      _tipo = Value
    End Set
  End Property

#End Region

#Region "Propriedades estaticas"

  Public Shared Property ComissaoCorrente() As Comissao
    Get
      If (CallContext.GetData("_ComissaoCorrente") Is Nothing) Then
        CallContext.SetData("_ComissaoCorrente", New Comissao)
      End If
      Return CType(CallContext.GetData("_ComissaoCorrente"), Comissao)
    End Get
    Set(ByVal Value As Comissao)
      CallContext.SetData("_ComissaoCorrente", Value)
    End Set
  End Property

#End Region

End Class

