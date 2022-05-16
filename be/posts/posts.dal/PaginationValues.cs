namespace posts.dal
{
    public class PaginationValues
    {
        const int maxSize = 10;
        public int Number { get; set; } = 1;

        public string Filter { get; set; }

        private int _size = 5;

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = (value > maxSize) ? maxSize : value;
            }
        }
    }
}
