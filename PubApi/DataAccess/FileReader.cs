namespace PubApi.DataAccess
{
    public class FileReader : IFileReader
    {
        public Task<string[]> ReadAllLinesAsync(string filePath)
        {
            return File.ReadAllLinesAsync(filePath);
        }
    }
}
