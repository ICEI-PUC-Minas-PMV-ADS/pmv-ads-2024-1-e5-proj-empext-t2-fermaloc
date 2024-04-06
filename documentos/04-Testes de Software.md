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
| Requisito Associado | RF-003 – Permitir ao administrador atualizar o banner do site.                                                    |
| Objetivo do Teste   | Verificar se, após efetuar o login no sistema, o administrador realizará a atualização do banner.                 |
| Passos              | 1) Acessar a tela de login; 2) Inserir as informação de "Email" e "Password"; 3) Selecionar a opção "Categorias"; |
| Critério de Êxito   |                                                                                                                   |

# Evidências de Testes de Software

### CT-001
![Imagem do Vídeo](/Imgs/login_sucesso.png)
![Vídeo](/Imgs/login_sucesso.mp4)

### CT-002
![Imagem do Vídeo](/Imgs/login_falha.png)
![Vídeo](/Imgs/llogin_falha.mp4)

### CT-003
![Vídeo](/Imgs/Edição_do_banner.mp4)

### CT-004
![Vídeo](/Imgs/CRUD_Categorias.mp4)