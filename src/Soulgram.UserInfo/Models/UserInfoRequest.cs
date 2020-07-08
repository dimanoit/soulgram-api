using Soulgram.Model;

namespace Soulgram.UserInfo.Models
{
    public class UserInfoRequest : PageRequestBase
    {
        public string Name { get; set; }
        public int? Id { get; set; }
    }
}
