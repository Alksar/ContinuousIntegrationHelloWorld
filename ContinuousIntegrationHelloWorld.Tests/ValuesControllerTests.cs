using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ContinuousIntegrationHelloWorld.Tests
{
    public class ValuesControllerTests
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _httpClient;

        public ValuesControllerTests()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _httpClient = _testServer.CreateClient();
        }

        [Fact]
        public async Task GetMethodTest()
        {
            var response = await _httpClient.GetAsync("api/values");
            response.EnsureSuccessStatusCode();
            string actual = await response.Content.ReadAsStringAsync();

            Assert.Equal("Hello World", actual);
        }
		
		Fact]
        public async Task GetMethodTest1()
        {
            var response = await _httpClient.GetAsync("api/values");
            response.EnsureSuccessStatusCode();
            string actual = await response.Content.ReadAsStringAsync();

            Assert.Equal("Hello World1", actual);
        }
    }
}
