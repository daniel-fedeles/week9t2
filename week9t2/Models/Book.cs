namespace Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }

}
