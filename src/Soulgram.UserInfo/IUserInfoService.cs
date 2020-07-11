using System.Threading.Tasks;
using Soulgram.UserInfo.Models;

namespace Soulgram.UserInfo
{
    public interface IUserInfoService
    {
        public Task AddAsync(User user);
    }
}
