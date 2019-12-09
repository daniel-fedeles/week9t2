using DataAccess;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class SummaryBook
    {
        public SummaryBook()
        {
            books = new BookRepository();
            Books = books.GetAllBooks();
        }

        private IBookRepository books;
        private List<Book> Books;

        public List<Book> BoocksPublishedIn2010()
        {
            return (Books.Where(x => x.Year == 2010)).ToList();
        }

        public Book BookPublishedInMaxYear()
        {
            Book book = new Book();
            var year = (Books.Select(x => x.Year)).Max();
            var b = (Books.Where(x => x.Year.Equals(year)));
            foreach (var z in b)
            {
                book = z;

            }

            return book;
        }

        public List<Book> Top10Books()
        {
            return (Books.Take(10)).ToList();
        }
    }
}
