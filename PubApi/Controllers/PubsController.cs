using Microsoft.AspNetCore.Mvc;
using PubApi.DataAccess;
using PubApi.Domain;

namespace PubApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubsController : ControllerBase
    {
        private readonly ILogger<PubsController> _logger;
        private readonly IPubRepository _pubRepository;

        public PubsController(ILogger<PubsController> logger, IPubRepository pubRepository)
        {
            _logger = logger;
            _pubRepository = pubRepository;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<PubInformation>> GetAll()
        {
            // Ideally here we'd have some query options available to the client:
            //     1. To sort the pubs by distance from a point
            //     2. To filter out closed pubs.
            //     3. Enabling paging
            // This data set is fairly small so this can be done in the UI, but given more time this is what I would do.
            return await _pubRepository.Get();
        }
    }
}