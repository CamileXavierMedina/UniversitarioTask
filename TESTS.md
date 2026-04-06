# Plano de Testes - UniversitarioTask

Este documento descreve os cenários de teste automatizados para validar as regras de negócio do sistema utilizando **xUnit**.

## 1. Validação de Regras de Estudo
O sistema deve calcular a frequência semanal de estudo com base na dificuldade da disciplina:

| Entrada (Dificuldade) | Saída Esperada (Sessões) | Status |
| :--- | :--- | :--- |
| Fácil | 1 Sessão semanal | Planejado |
| Médio | 2 Sessões semanais | Planejado |
| Difícil | 3 Sessões semanais | Planejado |

## 2. Validação de Ordenação
* **Cenário:** Inserir múltiplas tarefas com prazos diferentes.
* **Expectativa:** A listagem deve ser exibida em ordem crescente de data (mais próxima primeiro).

## 3. Validação de Integridade
* **Cenário:** Tentar cadastrar tarefa com nome vazio.
* **Expectativa:** O sistema deve impedir o cadastro e retornar um erro amigável.
* **Cenário:** Cadastrar tarefa com data no passado.
* **Expectativa:** O sistema deve emitir um alerta de prazo vencido.

---
*Estes testes serão executados automaticamente pelo GitHub Actions a cada commit.*
