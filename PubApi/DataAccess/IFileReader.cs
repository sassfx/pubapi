namespace PubApi.DataAccess
{
    public interface IFileReader
    {
        Task<string[]> ReadAllLinesAsync(string filePath);
    }
}
