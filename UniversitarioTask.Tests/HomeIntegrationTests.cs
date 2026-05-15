using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

using UniversitarioTask.Site.Models;

namespace UniversitarioTask.Tests
{
    
    public class HomeIntegrationTests : IClassFixture<WebApplicationFactory<UniversitarioTask.Site.Controllers.HomeController>>
    {
        private readonly WebApplicationFactory<UniversitarioTask.Site.Controllers.HomeController> _factory;

        public HomeIntegrationTests(WebApplicationFactory<UniversitarioTask.Site.Controllers.HomeController> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Index_RetornaSucesso_E_ContemAtividades()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var html = await response.Content.ReadAsStringAsync();

            // Verificação flexível para evitar erros de acento
            Assert.Contains("Atividades", html);
        }

        [Fact]
        public async Task Post_Adicionar_DeveRedirecionarParaIndex_AposSalvar()
        {
            // Arrange
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var dadosFormulario = new Dictionary<string, string>
            {
                { "Materia", "Teste de Integracao" },
                { "NomeAtividade", "Laboratorio" },
                { "Data", "2026-05-20" },
                { "Dificuldade", "1" },
                { "Tipo", "1" }
            };

            var conteudo = new FormUrlEncodedContent(dadosFormulario);

            // Act
            var response = await client.PostAsync("/Home/Adicionar", conteudo);

            // Assert
            // Esperamos um redirecionamento (302) após salvar com sucesso
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }

        [Fact]
        public async Task Get_Adicionar_DeveCarregarTelaDeCadastro()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Home/Adicionar");

            // Assert
            response.EnsureSuccessStatusCode();
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Nova Atividade", html);
        }
    }
}
