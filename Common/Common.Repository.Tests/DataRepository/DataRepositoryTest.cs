using Common.Model.Entities;
using Common.Repository;
using Common.Repository.DataRepository;
using Dapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace Common.Repository.Tests.Policy
{
    public class DataRepositoryTest
    {
        private IServiceCollection services = new ServiceCollection();
        private Mock<IDataConnection> connectionManager = new Mock<IDataConnection>();

        [Fact]
        public void DataRepository_GetAllActiveEntitySubscriptions_ShouldReturnOne()
        {
            var connection = new Mock<IDbConnection>();
            connectionManager.Setup(x => x.CreateConnection(It.IsAny<string>())).Returns(connection.Object);
            connection.SetupDapper(c => c.Query<Data>(It.IsAny<string>(), null, null, true, null, null))
                      .Returns(new List<Data>() { new Data { Id = 1 } });
            services.AddSingleton(sp => connectionManager.Object);

            TestStartup.ConfigureServices(services);

            var dataRepository = TestStartup.ServiceProvider.GetService<IDataRepository>();

            var result = dataRepository.GetData();

            result?.ToList().Count().Should().Be(1);
        }
    }
}