using Soulgram.UserInfoDB.Entities;
using Soulgram.UserInfo.Models;

namespace Soulgram.UserInfo.Mapping
{
    public static class UserInfoMapper
    {
        public static UserInfoModel ToUserInfo(this User user)
        {
            return new UserInfoModel
            {
                Email = user.email,
                Id = user.user_id,
                UserPhone = user.user_phone,
                FullName = null,
                Hobbies = null
            };
        }
    }
}
