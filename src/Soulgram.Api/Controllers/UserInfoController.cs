using Microsoft.AspNetCore.Mvc;
using Soulgram.UserInfo;
using Soulgram.UserInfo.Models;
using System.Threading.Tasks;

namespace Soulgram.Api.Controllers
{
    [Route("/user/info")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public async Task<UserInfoResponse> Get(UserInfoRequest request)
        {
            return await _userInfoService.Get(request);
        }
    }
}