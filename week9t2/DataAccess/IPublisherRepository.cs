using Models;
using System.Collections.Generic;


namespace DataAccess
{
    public interface IPublisherRepository
    {
        List<Publisher> GetTop10Publishers();
        int NrOfRowsFromPublisher();
        List<NumberOfBooksPerPublisher> AllBooksForEachPublisher();
        List<PriceForAllBooksForEachPublisher> TotalPriceForAllBooksForEachPublisher();
    }
}