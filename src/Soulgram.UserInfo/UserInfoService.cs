using Soulgram.UserInfo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulgram.UserInfo
{
    public class UserInfoService : IUserInfoService
    {
        public async Task<UserInfoResponse> Get(UserInfoRequest request)
        {
            await Task.Run(() => { });
            var responseList = new List<UserInfoModel> { new UserInfoModel() };
            return new UserInfoResponse
            {
                Data = responseList,
                TotalCount = 0
            };
        }
    }
}
