using DataAccess;
using System;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPublisherRepository pub = new PublisherRepository();

            Console.WriteLine($"Number of rows from the Publisher table {pub.NrOfRowsFromPublisher()}");

            Console.WriteLine();
            Console.WriteLine("Top 10 publishers");
            foreach (var top10Publisher in pub.GetTop10Publishers())
            {
                Console.WriteLine($"{top10Publisher.PublisherId} {top10Publisher.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Number of books for each publisher (Publiher Name, Number of Books)");
            foreach (var x in pub.AllBooksForEachPublisher())
            {
                Console.WriteLine($"{x.PublisherName} {x.NoOfBooks}");
            }

            Console.WriteLine();
            Console.WriteLine($"The total price for books for a publisher");
            Console.WriteLine($"Number of books and publisher name ( Create a class NumberOfBooksPerPublisher , load the information into a List<NumberOfBooksPerPublisher > )");
            foreach (var z in pub.TotalPriceForAllBooksForEachPublisher())
            {
                Console.WriteLine($"{z.PublisherName} {z.TotalPrice}");
            }

        }
    }
}
