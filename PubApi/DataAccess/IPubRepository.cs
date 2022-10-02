using PubApi.Domain;

namespace PubApi.DataAccess
{
    public interface IPubRepository
    {
        Task<IEnumerable<PubInformation>> Get();
    }
}
