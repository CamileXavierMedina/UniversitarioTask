# UniversitarioTask

## 1. Definição do Programa
O ambiente acadêmico exige a gestão simultânea de múltiplas disciplinas, prazos de entrega de trabalhos e cronogramas de avaliações. A framentação destes dados, juntamente com a ausência de uma priorização, resulta em perda de prazos, falta de preparação e sobrecarga cognitiva para o estudante universitário.

## 2. Proposta de Solução 
A aplicação de interface CLI(Linha de Comando) desenvolvida em C# para centralização de tarefas e compromissos acadêmicos. 

A solução diferencia-se ao oferecer um sistema de planejamento de carga horaria: ao registrar uma disciplina, o utilizador define seu nivel de dificuldade, e o sistema recomenda automaticamente a frequencia semanal de estudos necessária. Adicionalmente, a ferramenta organiza todas as atividades registradas com foco na criticidade cronológica, apresentando prioritariamente as entregas com prazos mais curtos.

## 3. Funcionalidades Principais
* **Gestão de Disciplinas por Complexidade:**
  * **Nível Fácil:** Recomendação de 1 sessão de estudo semanal.
  * **Nível Médio:** Recomendação de 2 sessões de estudos semanais.
  * **Nível Dificil:** Recomendação de 3 sessões de estudos semanais.
* **Registro de Atividades e Avaliações:** Cadastro detalhado de tarefas e datas de provas associadas a cada disciplina.
* **Ordenação Inteligente de Prazos:** Listagem de compromissos organizada automaticamente da data mais próxima para a mais distante.
* **Interface CLI:** Interação simplificada via terminal para garantir agilidade de fluxo de trabalho do estudante.

## 4. Tecnologias e Boas Práticas
* **Linguagem:** C#(.NET 8.0)
* **Framework de Testes:** xUnit (Validação da Lógica de prazos e cálculo de frequencia de estudos).
* **Análise Estática:** .NET Format / Analyzers (Garantia de padronização e qualidade do código).
* **CI/CD:** GitHub Actions (Pipeline para a execução automática de testes em liting em cada commit).
* **Versionamento:** Semântico (v10.0).

## 5. Guia de Execução 
### Pré-requisitos
* .NET SDK 8.0 ou superior.
* Git instalado.

###Instruções 
1. Efetuar o clone do repositório:
   ```bash
   git clone [https://github.com/CamileXavierMedina/UniversitarioTask]
   ````
2. Aceder ao diretório do projeto:
  	```bash
   cd UniversitarioTask
   ```
3. Executar a aplicação:
   ```bash
   dotnet run --project UniversitarioTask.Console/UniversitarioTask.Console.csproj
   ```

## 6. Validação de Qualidade
Para assegurar a integridade do sistema, utilize os seguintes comandos:
* **Executar testes:** `dotnet test`
* **Verificar Formatação:** `dotnet format --verify-no-changes`

----
### **Autor:** Camile Medina
###**Versão:** 1.0.0
