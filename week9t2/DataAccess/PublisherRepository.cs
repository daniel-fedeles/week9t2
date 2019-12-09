using DBCon;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DataAccess
{
    public class PublisherRepository : IPublisherRepository
    {
        private SqlConnection con = ConnectionManager.GetConnection.SqlConnetionFactory;
        private List<Publisher> allPublishers;
        private List<NumberOfBooksPerPublisher> numberOfBooksPerPublishers;
        private SqlDataReader reader;
        private SqlCommand cmd;
        private List<PriceForAllBooksForEachPublisher> totalPrice;

        public PublisherRepository()
        {

            allPublishers = new List<Publisher>();
            numberOfBooksPerPublishers = new List<NumberOfBooksPerPublisher>();
            totalPrice = new List<PriceForAllBooksForEachPublisher>();
        }

        public List<Publisher> GetTop10Publishers()
        {

            using (con)
            {
                con.Open();

                var q = "select top(10) PublisherId, Name from Publisher";

                cmd = new SqlCommand(q, con);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Publisher pub = new Publisher();
                    pub.PublisherId = (int)reader["PublisherId"];
                    pub.Name = reader["Name"] as string;
                    allPublishers.Add(pub);
                }
            }
            return allPublishers;
        }

        public int NrOfRowsFromPublisher()
        {
            using (con)
            {
                con.Open();

                var q = "select Count(PublisherId), Name from Publisher";


                object z = null;
                using (cmd)
                {
                    cmd = new SqlCommand(q, con);
                    z = cmd.ExecuteScalar();
                }

                return (int)z;
            }
        }

        public List<NumberOfBooksPerPublisher> AllBooksForEachPublisher()
        {
            using (con)
            {
                con.Open();

                var q = "SELECT Name, COUNT(BookId) AS NrOfBooks FROM Publisher join Book on Book.PublisherId=Publisher.PublisherId group by (Name)"; ;


                using (cmd)
                {
                    cmd = new SqlCommand(q, con);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NumberOfBooksPerPublisher pub = new NumberOfBooksPerPublisher();
                        pub.NoOfBooks = (int)reader["NrOfBooks"];
                        pub.PublisherName = reader["Name"] as string;

                        numberOfBooksPerPublishers.Add(pub);
                    }
                }

                con.Close();
            }

            return numberOfBooksPerPublishers;
        }

        public List<PriceForAllBooksForEachPublisher> TotalPriceForAllBooksForEachPublisher()
        {
            using (con)
            {
                var q = "SELECT Name, SUM(Price) AS TotalPrice FROM Publisher join Book on Book.PublisherId=Publisher.PublisherId group by (Name)";

                using (cmd)
                {
                    cmd = new SqlCommand(q, con);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PriceForAllBooksForEachPublisher pub = new PriceForAllBooksForEachPublisher();
                        pub.TotalPrice = (int)reader["TotalPrice"];
                        pub.PublisherName = reader["Name"] as string;

                        totalPrice.Add(pub);
                    }
                }

            }

            return totalPrice;
        }
    }
}