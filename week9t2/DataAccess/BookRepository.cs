using DBCon;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class BookRepository : IBookRepository
    {
        public BookRepository()
        {
            con = ConnectionManager.GetConnection();
            reader = null;
            cmd = null;
            AllBooks = new List<Book>();

        }

        private SqlConnection con;
        private SqlDataReader reader;
        private SqlCommand cmd;
        private List<Book> AllBooks;

        public List<Book> GetAllBooks()
        {



            using (con)
            {

                var q = "select BookId, Title, PublisherId, Year, Price from Book";

                cmd = new SqlCommand(q, con);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookId = (int)reader["BookId"];
                    book.Title = reader["Title"] as string;
                    book.PublisherId = reader["PublisherId"] as int? ?? default(int);
                    book.Year = reader["Year"] as int? ?? default(int);
                    book.Price = reader["Price"] as decimal? ?? default(decimal);
                    AllBooks.Add(book);
                }

            }


            return AllBooks;
        }

        public void cacat()
        {
            using (con)
            {
                var q = "select * from Publisher";

                cmd = new SqlCommand(q, con);

                reader = cmd.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["PublisherId"]} {reader["Name"]}");
                }

            }
        }
    }
}
