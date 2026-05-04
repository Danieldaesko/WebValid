 WebValid — Aplicação Web de Autenticação





 Descrição

Aplicação Web dinâmica desenvolvida em *ASP.NET Web Forms (C#)* com base de dados *SQL Server (LocalDB)*, que implementa um sistema completo de autenticação de utilizadores com registo, login, recuperação de palavra-passe e gestão de utilizadores.



Tecnologias Utilizadas

- ASP.NET Web Forms (.NET Framework 4.8)
- C#
- SQL Server LocalDB
- Bootstrap 5.3
- RSS Feed (XML)



 Estrutura do Projeto


WebValid/
├── Site.Master                   # MasterPage com layout Bootstrap
├── registo_utilizador.aspx       # Página de registo de utilizadores
├── login.aspx                    # Página de login
├── app.aspx                      # Página principal com notícias RSS
├── gestao_utilizadores.aspx      # Gestão de utilizadores (GridView)
├── recuperar.aspx                # Recuperação de palavra-passe por email
├── Web.config                    # Configurações e connection string
└── README.md




# Base de Dados

- *Nome:* `dbWebValid`
- *Servidor:* `(localdb)\MSSQLLocalDB`

 Tabela: Utilizadores

| Campo        | Tipo          | Descrição                  |
|--------------|---------------|----------------------------|
| Id           | INT (PK)      | Identificador automático   |
| Utilizador   | NVARCHAR(50)  | Nome único do utilizador   |
| PalavraPasse | NVARCHAR(256) | Password encriptada (MD5)  |
| Email        | NVARCHAR(100) | Email único                |
| DataRegisto  | DATETIME      | Data de registo automática |



Páginas

# `registo_utilizador.aspx`
- Campos: Utilizador, Palavra-Passe, Confirmar Palavra-Passe, Email
- Validações: campos obrigatórios, confirmação de password, formato de email
- Grava na BD apenas se utilizador e email não existirem

# `login.aspx`
- Campos: Utilizador, Palavra-Passe
- Redireciona para `app.aspx` se credenciais corretas
- Link para recuperação de palavra-passe

# `app.aspx`
- Protegida por sessão
- Link para gestão de utilizadores
- Tabela de notícias de tecnologia via RSS com Imagem, Título e Data

# `gestao_utilizadores.aspx`
- Protegida por sessão
- GridView com editar ✏️ e eliminar 🗑️
- Edita todos os campos exceto a palavra-passe

# `recuperar.aspx`
- Campo: Email
- Gera nova password aleatória e envia por email
- Atualiza a password encriptada na BD
- Mensagem clara se o email não existir

---

# Configuração

# Connection String (Web.config)
```xml
<connectionStrings>
  <add name="dbConn"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbWebValid;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

# Email SMTP (Web.config)
```xml
<system.net>
  <mailSettings>
    <smtp from="email@gmail.com">
      <network host="smtp.gmail.com" port="587"
               userName="email@gmail.com"
               password="APP_PASSWORD"
               enableSsl="true"/>
    </smtp>
  </mailSettings>
</system.net>
```



# Como Executar

1. Abre o projeto no *Visual Studio *
2. Garante que o *SQL Server LocalDB* está instalado
3. Corre o script `dbWebValid_script.sql` no SQL Server para criar a base de dados
4. Configura o email no `Web.config`
5. Define `login.aspx` como página inicial (clica direito → Set As Start Page)
6. Prime *F5* para executar


 Autor

Daniel Estêvão Kololo
 Junior Full Stack Developer

