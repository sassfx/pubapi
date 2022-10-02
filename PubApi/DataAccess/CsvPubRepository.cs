using Microsoft.Extensions.Options;
using PubApi.Domain;

namespace PubApi.DataAccess
{

    public class CsvPubRepository : IPubRepository
    {
        private readonly string _filePath;
        private readonly IFileReader _fileReader;
        private bool _isInitialised = false;
        private List<PubInformation> _pubs = new List<PubInformation>();

        public CsvPubRepository(IOptions<DataSettings> dataSettings, IFileReader fileReader)
        {
            _filePath = dataSettings.Value.FileName;
            _fileReader = fileReader;
        }

        private async Task Initialise()
        {
            if (!_isInitialised)
            {
                var lines = await _fileReader.ReadAllLinesAsync(_filePath);
                var pubs = lines.Skip(1).Select(ConvertLine);
                _pubs.AddRange(pubs);
                _isInitialised = true;
            }
        }

        private PubInformation ConvertLine(string line)
        {
            var parts = line.Substring(1, line.Length - 2).Split("\",\"");
            return new PubInformation(parts[0],
                parts[1],
                parts[2],
                DateTime.Parse(parts[3]),
                parts[4],
                parts[5],
                double.Parse(parts[6]),
                double.Parse(parts[7]),
                parts[8],
                parts[9],
                parts[10],
                decimal.Parse(parts[11]),
                decimal.Parse(parts[12]),
                decimal.Parse(parts[13]),
                decimal.Parse(parts[14]),
                parts[15]
                );
        }

        private string CleanPart(string input) => input.Substring(1, input.Length - 2);

        public async Task<IEnumerable<PubInformation>> Get()
        {
            await Initialise();
            return _pubs;
        }
    }
}
