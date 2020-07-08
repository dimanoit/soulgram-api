using Soulgram.UserInfo.Models;
using Soulgram.UserInfoDB.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulgram.UserInfo
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserRepository _userRepository;

        public UserInfoService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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
