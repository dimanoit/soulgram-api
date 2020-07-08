using System.Collections.Generic;

namespace Soulgram.UserInfo.Models
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserPhone { get; set; }
        public FullName FullName { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
    }
}
