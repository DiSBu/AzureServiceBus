using Common.AzureServiceBus;
using Common.Model.Entities;
using Common.Model.MessageModels;
using Common.Repository.DataRepository;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Common.Services.Tests
{
    public class PublisherServiceTest
    {
        private IServiceCollection services = new ServiceCollection();
        private Mock<IDataRepository> dataRepository = new Mock<IDataRepository>();
        private Mock<IMessagePublisher> messagePublisher = new Mock<IMessagePublisher>();

        private int sentMessageCount = 0;
        public static readonly object[][] expiredTestData=
        {
            new object[] { 1},
            new object[] { 1 },
        };

        public PublisherServiceTest()
        {
            dataRepository.Setup(x => x.GetData()).Returns(new List<Data> { new Data { Id = 1 } });
            services.AddSingleton(sp => dataRepository.Object);

            messagePublisher.Setup(x => x.SendAsync(It.IsAny<AzureMessage>())).Callback(() => sentMessageCount++);
            services.AddSingleton(sp => messagePublisher.Object);
        }

        [Fact]
        public async void Start_Stop_Dispose()
        {
            TestStartup.ConfigureServices(services);

            var svc = TestStartup.ServiceProvider.GetService<IPublisherService>();
            await svc.StartAsync(new System.Threading.CancellationToken());
            await svc.StopAsync(new System.Threading.CancellationToken());

            TestStartup.DisposeServices();
        }

        [Theory, MemberData(nameof(expiredTestData))]
        public void Process_GetData_ShouldSendMessageToAzure(int msgCount)
        {
            dataRepository.Setup(x => x.GetData()).Returns(new List<Data> { new Data { Id = 1 } });
            services.AddSingleton(sp => dataRepository.Object);

            TestStartup.ConfigureServices(services);

            var svc = TestStartup.ServiceProvider.GetService<IPublisherService>();

            svc.Process(null);

            sentMessageCount.Should().Be(msgCount);
        }
    }
}