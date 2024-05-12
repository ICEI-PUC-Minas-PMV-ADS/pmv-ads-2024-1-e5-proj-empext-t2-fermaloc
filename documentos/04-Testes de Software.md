# Planos de Testes de Software

Diante dos cenários apresentados e analisando os requisitos do projeto, foi realizado o plano de teste de software da aplicação.

| Caso de Teste       | CT-001 – Acesso de administrados do sistema                                                                  |
| ------------------- | ------------------------------------------------------------------------------------------------------------ |
| Requisito Associado | RF-001 – Garantir que o cliente tenha um acesso administrador por meio de login.                             |
| Objetivo do Teste   | Verificar autenticação do login do usuário administrador.                                                    |
| Passos              | 1) Acessar a tela de login; 2) Inserir as informação de "Email" e "Password"; 3) Selecionar o botão "Login". |
| Critério de Êxito   | Será realizado o login com sucesso.                                                                          |

| Caso de Teste         | CT-002 – Acesso de administrador do sistema                                                                                         |
| --------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado   | RF-001 – Garantir que o cliente tenha um acesso administrador por meio de login.                                                    |
| Objetivo do Teste     | Verificar autenticação do login do usuário administrador.                                                                           |
| Passos                | 1) Acessar a tela de login; 2) Inserir as informação de "Email" e "Password"; 3) Selecionar o botão "Login".                        |
| Critério de Não Êxito | Ao informar senha incorreta, o sistema deverá retornar essa informação e não permitirá o acesso ao menu administrador da aplicação. |

| Caso de Teste       | CT-003 – Atualização do banner pelo administrador do sistema                                                                                                                                            |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-002 – Permitir ao administrador atualizar o banner do site.                                                                                                                                          |
| Objetivo do Teste   | Verificar se, após efetuar o login no sistema, o administrador realizará a atualização do banner.                                                                                                       |
| Passos              | 1) Acessar a tela de login; 2) Inserir as informação de "Email" e "Password"; 3) Selecionar o botão "Login"; 4)Selecionar a opção Banner, 5)Selecionar a opção para escolha da imagem, Salvar a imagem. |
| Critério de Êxito   | Após salvar a imagem, o banner será atualizado.                                                                                                                                                         |

| Caso de Teste       | CT-004 – Permitir ao administrador adicionar, editar e excluir categorias de classificação dos produtos           |
| ------------------- | ----------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-004 – Permitir ao administrador adicionar, editar e excluir categorias de classificação dos produtos.                                                    |
| Objetivo do Teste   | Verificar se, após efetuar o login no sistema, o administrador adicionará, editará e excluirá categorias de classificação dos produtos.                 |
| Passos              | 1) Acessar a tela de login; 2) Inserir as informação de "Email" e "Password"; 3) Selecionar a opção "Categorias"; |
| Critério de Êxito   |  Após preencher o formulário, as categorias dos produtos serão atualizados.                                                                                                                 |

| Caso de Teste       | CT-005 – Permitir ao administrador adicionar, editar e excluir os produtos do catálogo                                                                  |
| ------------------- | ------------------------------------------------------------------------------------------------------------ |
| Requisito Associado | RF-003 – Permitir ao administrador adicionar, editar e excluir os produtos do catálogo.                             |
| Objetivo do Teste   | Verificar se, após efetuar o login no sistema, o administrador adicionará, editará e excluirá os produtos do catálogo.                                                    |
| Passos              | 1) Acessar a tela de login; 2) Inserir as informação de "Email" e "Password"; 3) Selecionar a opção "Produtos". |
| Critério de Êxito   | Após preencher o formulário, os produtos serão atualizados.  

| Caso de Teste       | CT-006 – Disponibilizar a visualização do catálogo de produtos a todos os usuários                                                                 |
| ------------------- | ------------------------------------------------------------------------------------------------------------ |
| Requisito Associado | RF-005 – Disponibilizar a visualização do catálogo de produtos a todos os usuários.                            |
| Objetivo do Teste   | Verificar se a visualização dos produtos cadastrados está disponível para todos os usuários.                                                    |
| Passos              | 1) Acessar a tela inicial da aplicação; 2) Clicar em "Ver mais". |
| Critério de Êxito   | O usuário consegue visualizar os produtos cadastrados.

| Caso de Teste       | CT-007 – Disponibilizar a visualização dos produtos de acordo com a categoria a todos os usuários                                                                 |
| ------------------- | ------------------------------------------------------------------------------------------------------------ |
| Requisito Associado | RF-006 – Disponibilizar a visualização dos produtos de acordo com a categoria a todos os usuários.                            |
| Objetivo do Teste   | Verificar se a visualização dos produtos de acordo com a categoria está disponível para todos os usuários.                                                    |
| Passos              | 1) Acessar a tela inicial da aplicação; 2) Clicar em "Ver mais"; 3) Clicar na categoria desejada.|
| Critério de Êxito   | O usuário consegue visualizar os produtos cadastrados de acordo com a categoria.


# Evidências de Testes de Software

### CT-001
![Imagem do Vídeo](/Imgs/login_sucesso.png)
<a href="https://www.youtube.com/watch?v=-2Pfg8ujfiM" title="Login sucesso">Video de sucesso no login</a>

### CT-002
![Imagem do Vídeo](/Imgs/login_falha.png)
<a href="https://www.youtube.com/watch?v=-FxS9iOVSFA" title="Edição do banner">Video de falha no login</a>

### CT-003
<a href="https://www.youtube.com/watch?v=5M55_UF-Nfw" title="Edição do banner">Video edidando o banner</a>

### CT-004
<a href="https://www.youtube.com/watch?v=7i8PA2yUyEM" title="CRUD categoria">Video fazendo o CRUD de uma categoria</a>

### CT-005

### CT-006 e CT-007
<a href="https://youtu.be/lta58_TIcMU" title="Visualização dos Produtos">Vídeo visualizando todos os produtos e a divisão de acordo com a categoria</a>
