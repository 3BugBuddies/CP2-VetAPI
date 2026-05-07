# CP2 VetAPI

API REST desenvolvida em ASP.NET Core para gerenciamento de uma clínica veterinária, permitindo o cadastro e consulta de pets e seus tutores.

## Descrição do Projeto

A VetAPI oferece um CRUD completo para duas entidades principais:

- **Pet** — animais cadastrados na clínica (nome, raça, espécie e idade)
- **Tutor** — responsáveis pelos animais (nome, e-mail e telefone)

O telefone do tutor é normalizado automaticamente na entrada (remove parênteses, hífens e espaços), e a busca por telefone aceita qualquer formatação.

## Componentes Utilizados

| Componente | Versão | Finalidade |
|---|---|---|
| .NET | 8.0 | Plataforma de execução |
| ASP.NET Core | 8.0 | Framework web |
| Entity Framework Core | 8.0.26 | ORM para acesso ao banco |
| Oracle.EntityFrameworkCore | 8.23.26200 | Driver Oracle para EF Core |
| Swashbuckle.AspNetCore | 6.6.2 | Geração do Swagger/OpenAPI |
| Swashbuckle.AspNetCore.Annotations | 6.6.2 | Anotações descritivas nos endpoints |

## Estrutura de Pastas

```
CP2-VetAPI/
├── CP2-VetAPI.slnx
├── README.md
└── CP2-VetAPI/
    ├── Controllers/       # Endpoints da API (Pet, Tutor)
    ├── Data/
    │   └── Migrations/    # Histórico de migrations do EF Core
    ├── Entities/          # Modelos de domínio
    ├── Properties/
    ├── Program.cs
    └── appsettings.json
```

## Como Rodar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- Acesso ao banco Oracle (FIAP ou próprio)

### Configuração do Banco de Dados

Edite o arquivo `CP2-VetAPI/appsettings.Development.json` com suas credenciais Oracle:

```json
{
  "ConnectionStrings": {
    "Oracle": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=SEU_RM;Password=SUA_SENHA"
  }
}
```

### Rodando a API

```bash
# Restaurar dependências
dotnet restore

# Instalar ferramenta dotnet-ef (caso não tenha)
dotnet tool install --global dotnet-ef

# Aplicar migrations (criar tabelas no banco)
dotnet ef database update --project CP2-VetAPI

# Iniciar a aplicação
dotnet run --project CP2-VetAPI
```

A API estará disponível em `http://localhost:5000` e a documentação Swagger em `http://localhost:5000/swagger`.

## Endpoints Disponíveis

### Pet — `/api/pet`

| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/pet` | Lista todos os pets |
| GET | `/api/pet/{id}` | Busca um pet pelo ID |
| GET | `/api/pet/buscar/{especie}` | Lista pets por espécie |
| POST | `/api/pet` | Cadastra um novo pet |
| PUT | `/api/pet/{id}` | Atualiza um pet existente |
| DELETE | `/api/pet/{id}` | Remove um pet |

### Tutor — `/api/tutor`

| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/tutor` | Lista todos os tutores |
| GET | `/api/tutor/{id}` | Busca um tutor pelo ID |
| GET | `/api/tutor/buscar/{telefone}` | Busca tutor pelo telefone |
| POST | `/api/tutor` | Cadastra um novo tutor |
| PUT | `/api/tutor/{id}` | Atualiza um tutor existente |
| DELETE | `/api/tutor/{id}` | Remove um tutor |

## Exemplos de Requisição (JSON)

### Criar Pet — `POST /api/pet`

```json
{
  "nome": "Rex",
  "raca": "Labrador",
  "especie": "Cachorro",
  "idade": 3
}
```

**Resposta 200:**
```json
{
  "id": 1,
  "nome": "Rex",
  "raca": "Labrador",
  "especie": "Cachorro",
  "idade": 3
}
```

---

### Atualizar Pet — `PUT /api/pet/1`

```json
{
  "nome": "Rex",
  "raca": "Labrador Retriever",
  "especie": "Cachorro",
  "idade": 4
}
```

---

### Criar Tutor — `POST /api/tutor`

```json
{
  "nome": "Maria Silva",
  "email": "maria.silva@email.com",
  "telefone": "(11) 91234-5678"
}
```

**Resposta 200:**
```json
{
  "id": 1,
  "nome": "Maria Silva",
  "email": "maria.silva@email.com",
  "telefone": "11912345678"
}
```

> O telefone é normalizado automaticamente (remove formatação).

---

### Buscar Tutor por Telefone — `GET /api/tutor/buscar/11912345678`

**Resposta 200:**
```json
{
  "id": 1,
  "nome": "Maria Silva",
  "email": "maria.silva@email.com",
  "telefone": "11912345678"
}
```

**Resposta 404:**
```json
"Nenhum tutor possui o número informado"
```

---

### Buscar Pets por Espécie — `GET /api/pet/buscar/Cachorro`

**Resposta 200:**
```json
[
  {
    "id": 1,
    "nome": "Rex",
    "raca": "Labrador",
    "especie": "Cachorro",
    "idade": 3
  }
]
```
