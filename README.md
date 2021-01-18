# IMDb WebAPI

Implementado uma API que o site [IMDb](https://www.imdb.com/) irá consultar para exibir seu conteúdo, com as seguintes funcionalidades:

- Administrador
  - Cadastro
  - Edição
  - Exclusão lógica (desativação)
  - Listagem de usuários não administradores ativos
    - Opção de trazer registros paginados
    - Retornar usuários por ordem alfabética
- Usuário
  - Cadastro
  - Edição
  - Exclusão lógica (desativação)
- Filmes
  - Cadastro (somente um usuário administrador poderá realizar esse cadastro)
  - Voto (a contagem de votos será feita por usuário de 0-4 que indica quanto o usuário gostou do filme)
  - Listagem
    - Opção de filtros por diretor, nome, gênero e/ou atores
    - Opção de trazer registros paginados
    - Retornar a lista ordenada por filmes mais votados e por ordem alfabética
  - Detalhes do filme trazendo todas as informações sobre o filme, inclusive a média dos votos

**Obs.:**

**Apenas os usuários poderão votar nos filmes e a API deverá validar quem é o usuário que está acessando, ou seja, se é um usuário administrador ou não.**
