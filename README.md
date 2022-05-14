
## Documentação da API

#### Request (find all)

```http
  GET /api/Produto

  curl -X 'GET' \
  'https://localhost:7096/api/Produto' \
  -H 'accept: */*'
```
#### Response body
```http
[
  {
    "id": 3,
    "nome": "Celular",
    "marca": "Xaiomi"
  },
  {
    "id": 4,
    "nome": "Celular",
    "marca": "Motorola"
  }
]
```
#### Request (find by ID) 

```http
  GET /api/Produto/GetById/${id}
  
  curl -X 'GET' \
  'https://localhost:7096/api/Produto/GetById?id=1' \
  -H 'accept: */*'
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do item que você quer |

#### Reponse body

```http
{
  "id": 4,
  "nome": "Celular",
  "marca": "Motorola"
}
```

#### Request (create new product) 
```http
  POST /api/Produto

  curl -X 'POST' \
  'https://localhost:7096/api/Produto' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0,
  "nome": "Celular",
  "marca": "Iphone"
}'
```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nome`      | `string` | **Obrigatório**. Informar o nome do produto que deseja cadastrar |
| `marca`      | `string` | **Obrigatório**. Informar o marca do produto que deseja cadastrar |

#### Response body

```http
{
  "id": 5,
  "nome": "Celular",
  "marca": "Iphone"
}
```
#### Change one exists product
```http
  PUT /api/Produto

curl -X 'PUT' \
  'https://localhost:7096/api/Produto' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 4,
  "nome": "Celular",
  "marca": "Motorola"
}'
```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que deseja alterar |
| `nome`      | `string` | **Obrigatório**. Informar o nome do produto que deseja cadastrar |
| `marca`      | `string` | **Obrigatório**. Informar o marca do produto que deseja cadastrar |

#### Response body 
```http
{
  "id": 4,
  "nome": "Celular",
  "marca": "Motorola"
}
```
#### Delete one exists product
```http
  DELETE /api/Produto

curl -X 'DELETE' \
  'https://localhost:7096/api/Produto?id=4' \
  -H 'accept: */*'
```
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que deseja deletar |

#### Response body 
```http
Produto 4 excluido com sucesso!
```

