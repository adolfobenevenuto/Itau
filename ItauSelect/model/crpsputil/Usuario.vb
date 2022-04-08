'//////////////////////////////////////////////////////////////////////////////
'// Este arquivo contem classes relacionadas aos usuarios do sistema.
'//////////////////////////////////////////////////////////////////////////////

Imports System.Threading
Imports System.Runtime.Remoting.Messaging

'Classe que representa usuarios do sistema.
Public Class Usuario
  Inherits BaseEntidade

#Region "Variaveis membro"

  ' constantes para SQL
  Protected Shared ReadOnly C_GET_LIST As String = " select id_usu 'Id',crp as 'Crp', cpf 'CPF',nome 'Nome',logon 'Logon'," & _
                                                 " email as Email, senha 'Senha', cidade as 'Cidade', telefone 'Telefone', comercial as 'Comercial', " & _
                                                 " celular as 'Celular',instituicao as 'Instituicao', " & _
                                                 " possui_neces as 'Possui_neces', baixa_visao as 'Baixa_visao', cegueira as 'Cegueira', " & _
                                                 " surdez as 'Surdez', defic_fisica as 'Defic_fisica', defic_intelectual as 'Defic_intelectual', outra as 'Outra',  " & _
                                                 " outral_qual as 'Outral_qual', neces_atend as 'Neces_atend', braille as 'braille', guia as 'guia', libras as 'libras', guia_inter as 'guia_inter', " & _
                                                 " outro_meces as 'outro_meces', qual_atend as 'Qual_atend',  congresso as 'Congresso', " & _
                                                 " criador 'IdCriador', dt_criacao 'DataCriacao', " & _
                                                 " atualizador 'IdAtualizador', dt_atualizacao 'DataAtualizacao'," & _
                                                 " excluido 'Excluido' from tbl_user_eventos_usuario where excluido = 0 " & _
                                                 " order by nome"

  Protected Shared ReadOnly C_GET_LIST_NOME As String = "select id_usu as 'Id_usu',cpf as 'CPF',nome as 'Nome',logon as 'Logon', senha 'Senha',  " & _
                                                  " telefone 'Telefone', email 'EMail', eixo 'Eixo', cargo as 'Cargo', congresso as 'Congresso',  excluido as 'Excluido',  " & _
                                                  " criador as 'Criador', dt_criacao as 'Dt_criacao', atualizador as 'Atualizador',  " & _
                                                  " dt_atualizacao as 'Dt_atualizacao' from tbl_user_eventos_usuario  " & _
                                                  " where nome = {0} and excluido = 0 order by nome"

  Private Shared ReadOnly C_GET_DATA_AUTOR As String = "select * from tbl_user_eventos_usuario where id_usu = @id_usu and Excluido = 0"


  Protected Shared ReadOnly C_INSERT As String = " insert into tbl_user_eventos_usuario(crp, cpf, nome, logon, email, senha, cidade,  " & _
                                                 " telefone, comercial, celular, instituicao, possui_neces, baixa_visao,  " & _
                                                 "  cegueira, surdez, defic_fisica, defic_intelectual, outra, outral_qual, neces_atend, braille, guia, libras, guia_inter, outro_meces, qual_atend, congresso, " & _
                                                 "  excluido, criador, dt_criacao, atualizador, dt_atualizacao)" & _
                                                 " values (@crp, @cpf, @nome, @logon, @email, @senha, @cidade, @telefone, @comercial, @celular,  " & _
                                                 " @instituicao, @possui_neces, @baixa_visao, @cegueira, @surdez,  " & _
                                                 " @defic_fisica, @defic_intelectual, @outra, @outral_qual, @neces_atend, @braille, @guia, @libras, @guia_inter, @outro_meces, @qual_atend, @congresso, 0,  @criador, " & _
                                                 " getdate(), @atualizador, getdate());" & _
                                                 " select id_usu, cpf, nome, logon, senha, telefone, email, criador," & _
                                                 " dt_criacao, atualizador, dt_atualizacao, excluido from tbl_user_eventos_usuario" & _
                                                 " where (id_usu = @@identity)"

  Protected Shared ReadOnly C_INSERT_PARTICIPANTE As String = " insert into tbl_user_eventos_usuario(crp, cpf, nome, logon, email, senha, cidade,  " & _
                                                 " telefone, comercial, celular, instituicao, possui_neces, baixa_visao,  " & _
                                                 "  cegueira, surdez, defic_fisica, defic_intelectual, outra, outral_qual, neces_atend, braille, guia, libras, guia_inter, outro_meces, qual_atend, congresso,  " & _
                                                 "  excluido, criador, dt_criacao, atualizador, dt_atualizacao)" & _
                                                 " values (@crp, @cpf, @nome, @logon, @email, @senha, @cidade, @telefone, @comercial, @celular,  " & _
                                                 " @instituicao, @possui_neces, @baixa_visao, @cegueira, @surdez,  " & _
                                                 " @defic_fisica, @defic_intelectual, @outra, @outral_qual, @neces_atend, @braille, @guia, @libras, @guia_inter, @outro_meces, @qual_atend, @congresso, 0,  1, " & _
                                                 " getdate(), 1, getdate());" & _
                                                 " select id_usu, crp, cpf, nome, logon, email, senha, cidade, telefone, comercial, celular, instituicao, possui_neces, baixa_visao, cegueira, surdez, defic_fisica, defic_intelectual, outra, outral_qual, neces_atend, braille, guia, libras, guia_inter, outro_meces, qual_atend, congresso, criador," & _
                                                 " dt_criacao, atualizador, dt_atualizacao, excluido from tbl_user_eventos_usuario" & _
                                                 " where (id_usu = @@identity)"



  Protected Shared ReadOnly C_DELETE As String = " update tbl_user_eventos_usuario set excluido = 1, " & _
                                                 " atualizador = @atualizador, dt_atualizacao = getdate() " & _
                                                 " where id_usu = @id_usu"

  Protected Shared ReadOnly C_UPDATE As String = " update tbl_user_eventos_usuario set crp = @crp, nome = @nome, " & _
                                                " logon = @logon, email = @email, cidade = @cidade, " & _
                                                " telefone = @telefone, comercial = @comercial, celular = @celular, " & _
                                                " titulacao = @titulacao, instituicao = @instituicao, " & _
                                                " possui_neces = @possui_neces, baixa_visao = @baixa_visao, " & _
                                                " cegueira = @cegueira, " & _
                                                " surdez = @surdez, defic_fisica = @defic_fisica, defic_intelectual = @defic_intelectual, outra = @outra, " & _
                                                " outral_qual = @outral_qual, neces_atend = @neces_atend, braille = @braille, guia = @guia, libras = @libras, guia_inter = @guia_inter, outro_meces = @outro_meces,  qual_atend = @qual_atend " & _
                                               " atualizador = @atualizador, dt_atualizacao = getdate()" & _
                                               " where id_usu = @id_usu"

  Protected Shared ReadOnly C_UPDATE_COMPLETE As String = " update tbl_user_eventos_usuario set crp = @crp, cpf = @cpf, nome = @nome, " & _
                                                " logon = @logon, email = @email, senha = @senha, cidade = @cidade, " & _
                                                " telefone = @telefone, comercial = @comercial, celular = @celular, " & _
                                                " instituicao = @instituicao, " & _
                                                " possui_neces = @possui_neces, baixa_visao = @baixa_visao, " & _
                                                " cegueira = @cegueira, " & _
                                                " surdez = @surdez, defic_fisica = @defic_fisica, defic_intelectual = @defic_intelectual, outra = @outra, " & _
                                                " outral_qual = @outral_qual, neces_atend = @neces_atend, braille = @braille, guia = @guia, libras = @libras, guia_inter = @guia_inter, outro_meces = @outro_meces, qual_atend = @qual_atend, congresso = @congresso, " & _
                                               " atualizador = @atualizador, dt_atualizacao = getdate()" & _
                                               " where id_usu = @id_usu"

  Protected Shared ReadOnly C_SET_PASSWORD As String = "update tbl_user_eventos_usuario set senha = @senha where id_usu = @id_usu"

  Protected Shared ReadOnly C_GET_BY_ID As String = "select * from tbl_user_eventos_usuario where id_usu = @id_usu"

  Private Shared ReadOnly C_GET_DATA_LIMITE As String = "select count(*) as 'Totalinscritos' from tbl_user_eventos_usuario where congresso = '24/04/2019 - A Psicologia na Saúde Suplementar: construindo práticas de qualidade na diversidade das psicologias'"

  Protected Shared ReadOnly C_GET_BY_NOME As String = "select * from tbl_user_eventos_usuario where nome = {0}"

  Protected Shared ReadOnly C_GET_BY_LOGON As String = "select * from tbl_user_eventos_usuario where logon = @logon"
  Private Shared ReadOnly C_NUMERO As String = "select * from tbl_user_eventos_usuario order by id desc"
  Private Shared ReadOnly C_GET_DATA_CPF As String = "select * from tbl_user_eventos_usuario where cpf = @cpf order by id_usu desc"
  Private Shared ReadOnly C_GET_DATA_CPF_LOGON As String = "select * from tbl_user_eventos_usuario where cpf = @cpf or logon = @logon order by id_usu desc"


  Private Shared ReadOnly C_GET_DATA_CONGRESSO As String = "select count(*) as 'Totalinscritos' from tbl_user_eventos_usuario where congresso = '24/04/2019 - A Psicologia na Saúde Suplementar: construindo práticas de qualidade na diversidade das psicologias'"

  'essa é a query que conta o total de inscritos
  Private Shared ReadOnly C_GET_DATA_CONGRESSO_RODOLFO As String = "select count(*) as 'Totalinscritos' from tbl_user_eventos_usuario where congresso = @congresso"



  Private Shared ReadOnly C_GET_DATA_CONGRESSO_TOTAL As String = "select count(*) as 'Totalinscritos' from tbl_user_eventos_usuario where congresso = '24/04/2019 - A Psicologia na Saúde Suplementar: construindo práticas de qualidade na diversidade das psicologias'"



  'Parametros
  Protected ReadOnly _paramId As New SqlParameter("@id_usu", System.Data.SqlDbType.Int)
  Protected ReadOnly _paramCrp As New SqlParameter("@crp", System.Data.SqlDbType.VarChar, 15)
  Protected ReadOnly _paramCPF As New SqlParameter("@cpf", System.Data.SqlDbType.VarChar, 15)
  Protected ReadOnly _paramNome As New SqlParameter("@nome", System.Data.SqlDbType.VarChar, 175)
  Protected ReadOnly _paramLogon As New SqlParameter("@logon", System.Data.SqlDbType.VarChar, 175)
  Protected ReadOnly _paramEmail As New SqlParameter("@email", System.Data.SqlDbType.VarChar, 175)
  Protected ReadOnly _paramSenha As New SqlParameter("@senha", System.Data.SqlDbType.VarChar, 15)
  Protected ReadOnly _paramCidade As New SqlParameter("@cidade", System.Data.SqlDbType.VarChar, 75)
  Protected ReadOnly _paramTelefone As New SqlParameter("@telefone", System.Data.SqlDbType.VarChar, 15)
  Protected ReadOnly _paramComercial As New SqlParameter("@comercial", System.Data.SqlDbType.VarChar, 15)
  Protected ReadOnly _paramCelular As New SqlParameter("@celular", System.Data.SqlDbType.VarChar, 15)
  Protected ReadOnly _paramInstituicao As New SqlParameter("@instituicao", System.Data.SqlDbType.VarChar, 150)
  Protected ReadOnly _paramPossui_neces As New SqlParameter("@possui_neces", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramBaixa_visao As New SqlParameter("@baixa_visao", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramCegueira As New SqlParameter("@cegueira", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramSurdez As New SqlParameter("@surdez", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramDefic_fisica As New SqlParameter("@defic_fisica", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramDefic_intelectual As New SqlParameter("@defic_intelectual", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramOutra As New SqlParameter("@outra", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramOutral_qual As New SqlParameter("@outral_qual", System.Data.SqlDbType.VarChar, 150)
  Protected ReadOnly _paramNeces_atend As New SqlParameter("@neces_atend", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramBraille As New SqlParameter("@braille", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramGuia As New SqlParameter("@guia", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramLibras As New SqlParameter("@libras", System.Data.SqlDbType.VarChar, 150)
  Protected ReadOnly _paramGuia_inter As New SqlParameter("@guia_inter", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramOutro_meces As New SqlParameter("@outro_meces", System.Data.SqlDbType.VarChar, 5)
  Protected ReadOnly _paramQual_atend As New SqlParameter("@qual_atend", System.Data.SqlDbType.VarChar, 150)
  Protected ReadOnly _paramCongresso As New SqlParameter("@congresso", System.Data.SqlDbType.VarChar, 250)
  Protected ReadOnly _paramTotalinscritos As New SqlParameter("@Totalinscritos", System.Data.SqlDbType.Int)

  'Propriedades
  Private _id As Integer = 0
  Private _crp As New String("")
  Private _cpf As New String("")
  Private _nome As New String("")
  Private _logon As New String("")
  Private _email As New String("")
  Private _senha As New String("")
  Private _cidade As New String("")
  Private _telefone As New String("")
  Private _comercial As New String("")
  Private _celular As New String("")
  Private _instituicao As New String("")
  Private _possui_neces As New String("")
  Private _baixa_visao As New String("")
  Private _cegueira As New String("")
  Private _surdez As New String("")
  Private _defic_fisica As New String("")
  Private _defic_intelectual As New String("")
  Private _outra As New String("")
  Private _outral_qual As New String("")
  Private _neces_atend As New String("")
  Private _braille As New String("")
  Private _guia As New String("")
  Private _libras As New String("")
  Private _guia_inter As New String("")
  Private _outro_meces As New String("")
  Private _qual_atend As New String("")
  Private _congresso As New String("")
  Private _Totalinscritos As New Integer
  Private _autenticado As Boolean = False

#End Region

#Region "Metodos estaticos"

  Public Shared Function Consultar(ByVal id As Integer) As Usuario

    'prepara parametro
    Dim p As SqlParameter = New SqlParameter("@id_usu", SqlDbType.Int)
    p.Value = id

    'retorno
    Return BaseEntidade.ConsultarEntidade(New Usuario, C_GET_BY_ID, p)

  End Function

  'Public Shared Function Limite() As Usuario

  '  'retorno
  '  Return BaseEntidade.ConsultarEntidade(New Usuario, C_GET_DATA_LIMITE)

  '  'Dim ret As New Usuario
  '  'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_LIMITE)

  '  'If (reader.Read()) Then

  '  '  ret.PopularDadosLimite(reader)
  '  '  Return ret

  '  'End If

  'End Function

  Public Shared Function Limite() As Object

    Dim ret As New Usuario
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_LIMITE)

    If (reader.Read()) Then

      ret.PopularDadosLimite(reader)
      Return ret

    End If

  End Function

  Public Sub PopularDadosLimite(ByVal reader As IDataReader)

    'popula propriedades da tabela links (criador, atualizador etc.)
    '  MyBase.PopularDados(reader)

    'popular proiedades
    Me.Totalinscritos = reader("Totalinscritos")


  End Sub
 
  Public Shared Function ConsultarNome(ByVal nome As Integer) As Usuario

    'prepara parametro
    Dim p As SqlParameter = New SqlParameter("@nome", SqlDbType.VarChar)
    p.Value = nome

    'retorno
    Return BaseEntidade.ConsultarEntidade(New Usuario, C_GET_BY_NOME, p)

  End Function

  'Public Shared Function ConsultarEixo(ByVal eixo As String) As Usuario

  '  'prepara parametro
  '  Dim p As SqlParameter = New SqlParameter("@eixo", SqlDbType.VarChar)
  '  p.Value = "'" + eixo + "'"

  '  'retorno
  '  Return BaseEntidade.ConsultarEntidade(New Usuario, C_GET_BY_EIXO, p)

  'End Function

  'Public Shared Function ConsultarPareceristaEixo(ByVal eixo As String) As Object

  '  Dim ret As New Usuario
  '  Dim param As New SqlParameter("@eixo", SqlDbType.VarChar)

  '  ' prepara parametro
  '  param.Value = eixo

  '  ' executa comando no db
  '  Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_EIXO, param)

  '  ' verifica se encontrou o registro
  '  If (reader.Read()) Then

  '    ret.PopularDados(reader)
  '    Return ret

  '    'Throw New Exception("Parecerista/Eixo não encotrado.")

  '  Else
  '    ' retorna novo objeto
  '    Throw New Exception("Parecerista/Eixo não encotrado.")

  '  End If

  'End Function

  Public Shared Function ConsultarAutor(ByVal id As Integer) As Object

    Dim ret As New Usuario
    Dim param As New SqlParameter("@id_usu", SqlDbType.Int)

    ' prepara parametro
    param.Value = id

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_AUTOR, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

      'Throw New Exception("Parecerista/Eixo não encotrado.")

    Else
      ' retorna novo objeto
      Throw New Exception("Parecerista/Eixo não encotrado.")

    End If

  End Function

  Public Shared Function ConsultarNomeErro(ByVal xnome As String) As Usuario

    'prepara parametro
    Dim p As SqlParameter = New SqlParameter("@nome", SqlDbType.VarChar)
    p.Value = xnome

    'retorno
    Return BaseEntidade.ConsultarEntidade(New Usuario, C_GET_LIST_NOME, p)

  End Function


  Public Shared Function Consultar(ByVal logon As String) As Usuario

    'prepara parametro
    Dim p As SqlParameter = New SqlParameter("@logon", SqlDbType.VarChar)
    p.Value = logon

    'retorno
    Return BaseEntidade.ConsultarEntidade(New Usuario, C_GET_BY_LOGON, p)

  End Function
  Public Shared Function ConsultarID() As Object

    Dim ret As New Usuario

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_NUMERO)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDados(reader)
      Return ret

    End If

    ' retorna novo objeto
    Throw New Exception("Inscrição não encontrada.")

  End Function

  Public Shared Function ConsultarCPFCadastrado(ByVal cpf As String, ByVal logon As String) As Object

    Dim ret As New Usuario
    Dim paramCpf As New SqlParameter("@cpf", SqlDbType.VarChar)
    Dim paramLogon As New SqlParameter("@logon", SqlDbType.VarChar)

    paramCpf.Value = cpf
    paramLogon.Value = logon


    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF_LOGON, paramCpf, paramLogon)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      Throw New Exception("CPF encotrado.")
      'ret.PopularDados(reader)
      'Return ret

    End If

    ' retorna novo objeto
    ' Throw New Exception("Inscrição não encontrada.")

    'Dim ret As New Congresso
    'Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    '' prepara parametro
    'param.Value = cpf

    '' executa comando no db
    'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, param)

    '' verifica se encontrou o registro
    'If (reader.Read()) Then

    '  '  ret.PopularDados(reader)
    '  '  Return ret
    '  Throw New Exception("CPF encotrado.")

    '  'Else
    '  'retorna novo objeto
    '  '           Throw New Exception("CPF não encotrado.")

    'End If


  End Function

  Public Shared Function ConsultarCPF(ByVal cpf As String) As Object

    Dim ret As New Usuario
    Dim paramCpf As New SqlParameter("@cpf", SqlDbType.VarChar)



    paramCpf.Value = cpf
  

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, paramCpf)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      Throw New Exception("CPF encotrado.")
      'ret.PopularDados(reader)
      'Return ret

    End If

    ' retorna novo objeto
    ' Throw New Exception("Inscrição não encontrada.")

    'Dim ret As New Congresso
    'Dim param As New SqlParameter("@cpf", SqlDbType.VarChar)

    '' prepara parametro
    'param.Value = cpf

    '' executa comando no db
    'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CPF, param)

    '' verifica se encontrou o registro
    'If (reader.Read()) Then

    '  '  ret.PopularDados(reader)
    '  '  Return ret
    '  Throw New Exception("CPF encotrado.")

    '  'Else
    '  'retorna novo objeto
    '  '           Throw New Exception("CPF não encotrado.")

    'End If


  End Function

  Public Shared Function ConsultarCongresso() As Object

    Dim ret As New Usuario

    '' executa comando no db
    'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CONGRESSO)

    '' verifica se encontrou o registro
    'If (reader.Read()) Then

    '  Throw New Exception("Congresso não encotrado.")
    '  'ret.PopularDados(reader)
    '  'Return ret

    'End If

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CONGRESSO)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    Else
      'retorna novo objeto
      Throw New Exception("CPF não encotrado.")

    End If


  End Function

  Public Shared Function ConsultarCongressoRodolfo(ByVal xcongresso As String) As Object

    Dim ret As New Usuario

    'Dim ret As New Congresso
    Dim param As New SqlParameter("@congresso", SqlDbType.VarChar)

    ' prepara parametro
    param.Value = xcongresso


    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CONGRESSO_RODOLFO, param)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    Else
      'retorna novo objeto
      Throw New Exception("CPF não encotrado.")

    End If


  End Function

  Public Shared Function ConsultarCongressoTotal() As Object

    Dim ret As New Usuario

    '' executa comando no db
    'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CONGRESSO)

    '' verifica se encontrou o registro
    'If (reader.Read()) Then

    '  Throw New Exception("Congresso não encotrado.")
    '  'ret.PopularDados(reader)
    '  'Return ret

    'End If

    ' executa comando no db
    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(C_GET_DATA_CONGRESSO_TOTAL)

    ' verifica se encontrou o registro
    If (reader.Read()) Then

      ret.PopularDadosTotal(reader)
      Return ret

    Else
      'retorna novo objeto
      Throw New Exception("CPF não encotrado.")

    End If


  End Function

  Public Shared Function Autenticar(ByVal logon As String, _
                                    ByVal senha As String) As Usuario

    'declara usuario
    Dim ret As Usuario

    'consulta por logon
    ret = Consultar(logon)

    'verifica senha (sem criptografia por enquento, 
    'mas deve ser alterado posteriormente)
    ret._autenticado = (ret._senha.ToLower() = senha.ToLower())

    Return ret

  End Function

  Public Shared Function Listar() As IList

    'retorno
    Return ListaHelper.ListarRegistros(C_GET_LIST)

  End Function

  'Public Shared Function ListarParecerista() As IList

  '  'retorno
  '  Return ListaHelper.ListarRegistros(C_GET_LIST_PARECERISTA)

  'End Function

  'Public Shared Function ListarConselheiro() As IList

  '  'retorno
  '  Return ListaHelper.ListarRegistros(C_GET_LIST_CONSELHEIRO)

  'End Function

  'Public Shared Function ListarGestor() As IList

  '  'retorno
  '  Return ListaHelper.ListarRegistros(C_GET_LIST_GESTOR)

  'End Function

  'Public Shared Function ListarConvidado() As IList

  '  'retorno
  '  Return ListaHelper.ListarRegistros(C_GET_LIST_CONVIDADO)

  'End Function

#End Region

#Region "Metodos privados"

  Private Sub AtualizarParametros()

    'atualiza valor de propriedades especificas
    _paramId.Value = _id
    _paramCrp.Value = _crp
    _paramCPF.Value = _cpf
    _paramNome.Value = _nome
    _paramLogon.Value = _logon
    _paramEmail.Value = _email
    _paramSenha.Value = _senha
    _paramCidade.Value = _cidade
    _paramTelefone.Value = _telefone
    _paramComercial.Value = _comercial
    _paramCelular.Value = _celular
    _paramInstituicao.Value = _instituicao
    _paramPossui_neces.Value = _possui_neces
    _paramBaixa_visao.Value = _baixa_visao
    _paramCegueira.Value = _cegueira
    _paramSurdez.Value = _surdez
    _paramDefic_fisica.Value = _defic_fisica
    _paramDefic_intelectual.Value = _defic_intelectual
    _paramOutra.Value = _outra
    _paramOutral_qual.Value = _outral_qual
    _paramBraille.Value = _braille
    _paramGuia.Value = _guia
    _paramLibras.Value = _libras
    _paramGuia_inter.Value = _guia_inter
    _paramOutro_meces.Value = _outro_meces
    _paramNeces_atend.Value = _neces_atend
    _paramQual_atend.Value = _qual_atend
    _paramCongresso.Value = _congresso
    _paramTotalinscritos.Value = _Totalinscritos

    'atualiza parametros da entidade
    MyBase.AtualizarParametrosUsuario()

  End Sub

#End Region

#Region "Implementacao da interface IEntidade"

  Public Overrides Sub PopularDados(ByVal reader As IDataReader)

    'popula propriedades de log (criador, atualizador etc.)
    MyBase.PopularDados(reader)

    'popula propriedades
    _id = reader("id_usu")
    _crp = reader("crp")
    _cpf = reader("cpf")
    _nome = reader("nome")
    _logon = reader("logon")
    _email = reader("email")
    _senha = reader("senha")
    _cidade = reader("cidade")
    _telefone = reader("telefone")
    _comercial = reader("comercial")
    _celular = reader("celular")
    _instituicao = reader("instituicao")
    _possui_neces = reader("possui_neces")
    _baixa_visao = reader("baixa_visao")
    _cegueira = reader("cegueira")
    _surdez = reader("surdez")
    _defic_fisica = reader("defic_fisica")
    _defic_intelectual = reader("defic_intelectual")
    _outra = reader("outra")
    _outral_qual = reader("outral_qual")
    _neces_atend = reader("neces_atend")

    _braille = reader("braille")
    _guia = reader("guia")
    _libras = reader("libras")
    _guia_inter = reader("guia_inter")
    _outro_meces = reader("outro_meces")

    _qual_atend = reader("qual_atend")
    _congresso = reader("congresso")
    '_Totalinscritos = reader("Totalinscritos")

  End Sub

  Public Sub PopularDadosTotal(ByVal reader As IDataReader)

    ''popula propriedades de log (criador, atualizador etc.)
    'MyBase.PopularDados(reader)

    ''popula propriedades
    '_id = reader("id_usu")
    '_crp = reader("crp")
    '_cpf = reader("cpf")
    '_nome = reader("nome")
    '_logon = reader("logon")
    '_email = reader("email")
    '_senha = reader("senha")
    '_cidade = reader("cidade")
    '_telefone = reader("telefone")
    '_comercial = reader("comercial")
    '_celular = reader("celular")
    '_titulacao = reader("titulacao")
    '_instituicao = reader("instituicao")
    '_possui_neces = reader("possui_neces")
    '_baixa_visao = reader("baixa_visao")
    '_cegueira = reader("cegueira")
    '_surdez = reader("surdez")
    '_defic_fisica = reader("defic_fisica")
    '_defic_intelectual = reader("defic_intelectual")
    '_outra = reader("outra")
    '_outral_qual = reader("outral_qual")
    '_neces_atend = reader("neces_atend")

    '_braille = reader("braille")
    '_guia = reader("guia")
    '_libras = reader("libras")
    '_guia_inter = reader("guia_inter")
    '_outro_meces = reader("outro_meces")

    '_qual_atend = reader("qual_atend")
    _Totalinscritos = reader("Totalinscritos")


  End Sub

#End Region

#Region "Metodos de Cadastro"

  Public Overridable Sub Inserir()

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT, _
      _paramCrp, _
      _paramCPF, _
      _paramNome, _
      _paramLogon, _
      _paramEmail, _
      _paramSenha, _
      _paramCidade, _
      _paramTelefone, _
      _paramComercial, _
      _paramCelular, _
      _paramInstituicao, _
      _paramPossui_neces, _
      _paramBaixa_visao, _
      _paramCegueira, _
      _paramSurdez, _
      _paramDefic_fisica, _
      _paramDefic_intelectual, _
      _paramOutra, _
      _paramOutral_qual, _
      _paramBraille, _
      _paramGuia, _
      _paramLibras, _
      _paramGuia_inter, _
      _paramOutro_meces, _
      _paramNeces_atend, _
      _paramQual_atend, _
      _paramCongresso, _
      _paramCriador, _
      _paramAtualizador)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub
  Public Overridable Sub InserirParticipante()

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    Dim ret As SqlDataReader = SqlHelper.ExecuteReader(C_INSERT_PARTICIPANTE, _
      _paramCrp, _
      _paramCPF, _
      _paramNome, _
      _paramLogon, _
      _paramEmail, _
      _paramSenha, _
      _paramCidade, _
      _paramTelefone, _
      _paramComercial, _
      _paramCelular, _
      _paramInstituicao, _
      _paramPossui_neces, _
      _paramBaixa_visao, _
      _paramCegueira, _
      _paramSurdez, _
      _paramDefic_fisica, _
      _paramDefic_intelectual, _
      _paramOutra, _
      _paramOutral_qual, _
      _paramBraille, _
      _paramGuia, _
      _paramLibras, _
      _paramGuia_inter, _
      _paramOutro_meces, _
      _paramNeces_atend, _
      _paramQual_atend, _
      _paramCongresso, _
      _paramCriador, _
      _paramAtualizador)

    If (ret.Read()) Then
      PopularDados(ret)
    End If

    'fecha reader
    ret.Close()

  End Sub

  Public Overridable Sub Alterar()

    'verifica permissao
    If (Not PermissaoGlobal.Permitido("usuario", "alterar") And _
        UsuarioCorrente.Id <> Me.Id) Then
      Throw New Security.SecurityException("Você não pode alterar os dados deste usuário.")
    End If

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_UPDATE, _
      _paramId, _
      _paramCrp, _
      _paramCPF, _
      _paramNome, _
      _paramLogon, _
      _paramEmail, _
      _paramSenha, _
      _paramCidade, _
      _paramTelefone, _
      _paramComercial, _
      _paramCelular, _
      _paramInstituicao, _
      _paramPossui_neces, _
      _paramBaixa_visao, _
      _paramCegueira, _
      _paramSurdez, _
      _paramDefic_fisica, _
      _paramDefic_intelectual, _
      _paramOutra, _
      _paramOutral_qual, _
      _paramBraille, _
      _paramGuia, _
      _paramLibras, _
      _paramGuia_inter, _
      _paramOutro_meces, _
      _paramNeces_atend, _
      _paramQual_atend, _
      _paramCongresso, _
      _paramAtualizador)

  End Sub

  Public Overridable Sub Excluir()

    ' prepara parametros
    AtualizarParametros()

    ' executa comando no db
    SqlHelper.ExecuteNonQuery(C_DELETE, _paramId, _paramAtualizador)

  End Sub

  Public Sub AlterarSenha(ByVal senhaAtual As String, _
                          ByVal senhaNova As String, _
                          ByVal confirmacaoSenhaNova As String)

    'verifica se o usuario corrente eh o usuario sendo
    'alterado
    If (UsuarioCorrente.Id <> Me.Id) Then
      Throw New Security.SecurityException("Você não pode alterar a senha de " + _
        "outros usuários.")
    End If

    'verifica senha atual
    If (senhaAtual.ToLower() <> _senha.ToLower()) Then
      Throw New Security.SecurityException("Senha inválida")
    End If

    'verifica se o formato da senha nova e valido
    If (senhaNova.Length < 6) Then
      Throw New Security.SecurityException("A senha deve conter pelo menos 6 dígitos")
    End If

    'verifica se a senha nova e a confirmacao sao iguais
    If (senhaNova.ToLower() <> confirmacaoSenhaNova.ToLower()) Then
      Throw New Security.SecurityException("Confirmação de senha inválida")
    End If

    'altera senha
    _paramId.Value = _id
    _paramSenha.Value = senhaNova

    SqlHelper.ExecuteNonQuery(C_SET_PASSWORD, _paramId, _paramSenha)

  End Sub

#End Region

#Region "Propriedades estaticas"

  Public Shared Property UsuarioCorrente() As Usuario
    Get
      If (CallContext.GetData("_UsuarioCorrente") Is Nothing) Then
        CallContext.SetData("_UsuarioCorrente", New Usuario)
      End If
      Return CType(CallContext.GetData("_UsuarioCorrente"), Usuario)
    End Get
    Set(ByVal Value As Usuario)
      CallContext.SetData("_UsuarioCorrente", Value)
    End Set
  End Property

#End Region

#Region "Propriedades"

  'Public ReadOnly Property Id() As Integer
  '  Get
  '    Return _id
  '  End Get
  'End Property

  Public Property Id() As Integer
    Get
      Return _id
    End Get
    Set(ByVal Value As Integer)
      _id = Value
    End Set
  End Property
  Public Property Crp() As String
    Get
      Return _crp
    End Get
    Set(ByVal value As String)
      _crp = value
    End Set
  End Property

  Public Property Cpf() As String
    Get
      Return _cpf
    End Get
    Set(ByVal value As String)
      _cpf = value
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

  Public Property Logon() As String
    Get
      Return _logon
    End Get
    Set(ByVal Value As String)
      _logon = Value
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

  Public Property Senha() As String
    Get
      Return _senha
    End Get
    Set(ByVal Value As String)
      _senha = Value
    End Set
  End Property
  Public Property Cidade() As String
    Get
      Return _cidade
    End Get
    Set(ByVal Value As String)
      _cidade = Value
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

  Public Property Comercial() As String
    Get
      Return _comercial
    End Get
    Set(ByVal Value As String)
      _comercial = Value
    End Set
  End Property

  Public Property Celular() As String
    Get
      Return _celular
    End Get
    Set(ByVal Value As String)
      _celular = Value
    End Set
  End Property

  Public Property Instituicao() As String
    Get
      Return _instituicao
    End Get
    Set(ByVal Value As String)
      _instituicao = Value
    End Set
  End Property

  Public Property Possui_neces() As String
    Get
      Return _possui_neces
    End Get
    Set(ByVal Value As String)
      _possui_neces = Value
    End Set
  End Property

  Public Property Baixa_visao() As String
    Get
      Return _baixa_visao
    End Get
    Set(ByVal Value As String)
      _baixa_visao = Value
    End Set
  End Property

  Public Property Cegueira() As String
    Get
      Return _cegueira
    End Get
    Set(ByVal Value As String)
      _cegueira = Value
    End Set
  End Property

  Public Property Surdez() As String
    Get
      Return _surdez
    End Get
    Set(ByVal Value As String)
      _surdez = Value
    End Set
  End Property

  Public Property Defic_fisica() As String
    Get
      Return _defic_fisica
    End Get
    Set(ByVal Value As String)
      _defic_fisica = Value
    End Set
  End Property

  Public Property Defic_intelectual() As String
    Get
      Return _defic_intelectual
    End Get
    Set(ByVal Value As String)
      _defic_intelectual = Value
    End Set
  End Property

  Public Property Outra() As String
    Get
      Return _outra
    End Get
    Set(ByVal Value As String)
      _outra = Value
    End Set
  End Property

  Public Property Outral_qual() As String
    Get
      Return _outral_qual
    End Get
    Set(ByVal Value As String)
      _outral_qual = Value
    End Set
  End Property

  Public Property Neces_atend() As String
    Get
      Return _neces_atend
    End Get
    Set(ByVal Value As String)
      _neces_atend = Value
    End Set
  End Property

  Public Property Braille() As String
    Get
      Return _braille
    End Get
    Set(ByVal value As String)
      _braille = value
    End Set
  End Property
  Public Property Guia() As String
    Get
      Return _guia
    End Get
    Set(ByVal value As String)
      _guia = value
    End Set
  End Property
  Public Property Libras() As String
    Get
      Return _libras
    End Get
    Set(ByVal value As String)
      _libras = value
    End Set
  End Property

  Public Property Guia_inter() As String
    Get
      Return _guia_inter
    End Get
    Set(ByVal value As String)
      _guia_inter = value
    End Set
  End Property

  Public Property Outro_meces() As String
    Get
      Return _outro_meces
    End Get
    Set(ByVal value As String)
      _outro_meces = value
    End Set
  End Property

  Public Property Qual_atend() As String
    Get
      Return _qual_atend
    End Get
    Set(ByVal Value As String)
      _qual_atend = Value
    End Set
  End Property
  Public Property Congresso() As String
    Get
      Return _congresso
    End Get
    Set(ByVal Value As String)
      _congresso = Value
    End Set
  End Property
  Public Property Totalinscritos() As Integer
    Get
      Return _Totalinscritos
    End Get
    Set(ByVal value As Integer)
      _Totalinscritos = value
    End Set
  End Property

  Public Property Autenticado() As Boolean
    Get
      Return _autenticado
    End Get
    Set(ByVal Value As Boolean)
      _autenticado = Value
    End Set
  End Property


#End Region

End Class

'Classe de colecao de usuarios
Public Class ColecaoUsuario
  Inherits BaseColecaoEntidade

#Region "Metodos"

  Public Overloads Sub Add(ByVal usuario As Usuario)
    InnerList.Add(usuario)
  End Sub

  Public Function ContemUsuario(ByVal idUsuario As Integer) As Boolean

    Dim usu As Usuario

    For Each usu In Me

      If (usu.Id = idUsuario) Then
        Return True
      End If

    Next

    Return False

  End Function

#End Region

#Region "Criar Entidade"

  Public Overrides Function CriarEntidade() As IEntidade

    Return New Usuario

  End Function

#End Region

#Region "Propriedades"

  Public Property Item(ByVal index As Integer) As Usuario
    Get

      Return CType(InnerList(index), Usuario)

    End Get

    Set(ByVal Value As Usuario)

      InnerList(index) = Value

    End Set
  End Property

#End Region

End Class

