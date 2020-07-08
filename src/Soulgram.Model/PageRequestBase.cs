namespace Soulgram.Model
{
    public abstract class PageRequestBase
    {
        public int Skip { get; set; } = 0;

        public int Take { get; set; } = 20;
    }
}
