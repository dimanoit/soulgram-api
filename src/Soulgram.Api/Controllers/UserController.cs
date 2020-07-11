using Microsoft.AspNetCore.Mvc;
using Soulgram.UserInfo;
using Soulgram.UserInfo.Models;
using System.Threading.Tasks;

namespace Soulgram.Api.Controllers
{
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        public UserController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpPost]
        public async Task AddUser([FromBody] User user)
        {
            await _userInfoService.AddAsync(user);
        }
    }
}