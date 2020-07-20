using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Soulgram.TestApi.Controllers
{
    public class SecretController : ControllerBase
    {

        [Authorize]
        [Route("/secret")]
        public string  Index()
        {
            return "Secret message form Api1";
        }
    }
}
