using DataAccess;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SerializeBooksAndPublishers
{
    public class SerializeBandP
    {

        private IBookRepository BookRepo = new BookRepository();
        private IPublisherRepository PublisherRepo = new PublisherRepository();
        private List<Book> Books;
        private List<Publisher> Publishers;

        public SerializeBandP()
        {
            Books = BookRepo.GetAllBooks();
            Publishers = PublisherRepo.AllPublishers();
        }

        public string SerializeJsonBook()
        {
            return JsonConvert.SerializeObject(Books, Formatting.Indented);
        }
        public string SerializeJsonPublisher()
        {
            return JsonConvert.SerializeObject(Publishers, Formatting.Indented);
        }
    }
}
