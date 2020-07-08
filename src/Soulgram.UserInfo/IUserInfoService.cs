using Soulgram.UserInfo.Models;
using System.Threading.Tasks;

namespace Soulgram.UserInfo
{
    public interface IUserInfoService
    {
        public Task<UserInfoResponse> Get(UserInfoRequest request);
    }
}
