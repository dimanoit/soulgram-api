using System.ComponentModel.DataAnnotations.Schema;

namespace Soulgram.UserInfoDB.Entities
{
    [Table("tbl_hobby")]
    public class Hobby
    {
        public int hobby_id { get; set; }
        public bool is_active { get; set; }
        public string name { get; set; }
    }
}
