using Microsoft.Extensions.Options;
using PubApi.DataAccess;

namespace PubApi.Test
{
    public class CsvPubRepositoryTests
    {
        [Fact]
        public async Task Get_ReadsPubsFromFile()
        {
            var options = new Mock<IOptions<DataSettings>>();
            var fileReader = new Mock<IFileReader>();

            var data = new string[]
            {
                "csv, titles",
                "\"...escobar\",\"Closed venues\",\"http://leedsbeer.info/?p=765\",\"2012-11-30T21:58:52+00:00\",\"...It's really dark in here!\",\"http://leedsbeer.info/wp-content/uploads/2012/11/20121129_185815.jpg\",\"53.8007317\",\"-1.5481764\",\"23-25 Great George Street, Leeds LS1 3BB\",\"0113 220 4389\",\"EscobarLeeds\",\"2\",\"3\",\"3\",\"3\",\"food,live music,sofas",
                "\"\"Golf\"\" Cafe Bar\",\"Bar reviews\",\"http://leedsbeer.info/?p=1382\",\"2013-04-27T14:44:22+00:00\",\"FORE! You can play \"\"golf\"\" here and enjoy a nice bottled ale. \",\"http://leedsbeer.info/wp-content/uploads/2013/04/20130422_204442.jpg\",\"53.7934952\",\"-1.5478653\",\"1 Little Neville Street, Granary Wharf, Leeds LS1 4ED\",\"0113 244 4428\",\"GolfCafeBar\",\"2.5\",\"2.5\",\"3.5\",\"2.5\",\"beer garden,coffee,food,free wifi,sports"
            };

            var fileName = "fileName";
            options.Setup(x => x.Value).Returns(new DataSettings { FileName = fileName });
            fileReader.Setup(x => x.ReadAllLinesAsync(fileName)).ReturnsAsync(data);

            var repository = new CsvPubRepository(options.Object, fileReader.Object);

            var pubs = await repository.Get();

            pubs.Count().Should().Be(2);
            var pub = pubs.First();
            pub.Name.Should().Be("...escobar");
            pub.IsClosed.Should().Be(true);
        }
    }
}