using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
    }
}