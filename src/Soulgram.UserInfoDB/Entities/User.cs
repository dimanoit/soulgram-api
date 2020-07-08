using System.ComponentModel.DataAnnotations.Schema;

namespace Soulgram.UserInfoDB.Entities
{
    [Table("tbl_user", Schema = "soulgram_user")]
    public class User
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string user_phone { get; set; }
    }
}
