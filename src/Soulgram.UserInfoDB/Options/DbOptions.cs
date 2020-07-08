namespace Soulgram.UserInfoDB.Options
{
    public class DbOptions
    {
        public string ConnectionString { get; set; }
        public int? Timeout { get; set; }
        public int? CommandTimeout { get; set; }
        public int? RetryCount { get; set; }
        public bool Pooling { get; set; } = true;
    }
}
