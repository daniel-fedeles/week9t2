using Business;
using System;

namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("-_-");
            Console.WriteLine();
            Console.WriteLine("BoocksPublishedIn2010");
            SummaryBook sb = new SummaryBook();
            foreach (var x in sb.BoocksPublishedIn2010())
            {
                Console.WriteLine($"{x.BookId} {x.Title} {x.PublisherId} {x.Price} {x.Year}");
            }

            Console.WriteLine();
            Console.WriteLine("-_-");
            Console.WriteLine();
            Console.WriteLine("BookPublishedInMaxYear");
            Console.WriteLine($"{sb.BookPublishedInMaxYear().Title} {sb.BookPublishedInMaxYear().Year} {sb.BookPublishedInMaxYear().Price}");


            Console.WriteLine();
            Console.WriteLine("-_-");
            Console.WriteLine();
            Console.WriteLine("Top10Books");

            foreach (var book in sb.Top10Books())
            {
                Console.WriteLine($"{book.Title} {book.Year} {book.Price}");
            }

        }
    }
}
