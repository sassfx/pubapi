using Microsoft.Extensions.Logging;
using PubApi.Controllers;
using PubApi.DataAccess;
using PubApi.Domain;
using System.ComponentModel;

namespace PubApi.Test
{
    public class PubsControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllFromRepository()
        {
            var logger = new Mock<ILogger<PubsController>>();
            var repository = new Mock<IPubRepository>();
            var controller = new PubsController(logger.Object, repository.Object);
            var fixure = new Fixture();

            var expectedPubs = new PubInformation[]
            {
                fixure.Create<PubInformation>(),
                fixure.Create<PubInformation>()
            };

            repository.Setup(x => x.Get()).ReturnsAsync(expectedPubs);

            var pubs = await controller.GetAll();

            pubs.Should().BeEquivalentTo(expectedPubs);
        }
    }
}