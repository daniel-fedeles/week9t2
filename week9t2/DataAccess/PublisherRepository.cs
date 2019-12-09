using DBCon;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DataAccess
{
    public class PublisherRepository : IPublisherRepository
    {
        SqlConnection con = ConnectionManager.GetConnection();
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

            try
            {
                var q = "select top(10) PublisherId, Name from Publisher";
                using (cmd = new SqlCommand(q, con))
                {
                    using (reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Publisher pub = new Publisher();
                            pub.PublisherId = (int)reader["PublisherId"];
                            pub.Name = reader["Name"] as string;
                            allPublishers.Add(pub);
                        }
                    }
                }

                return allPublishers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                //                con.Close();
            }


        }

        public int NrOfRowsFromPublisher()
        {
            SqlConnection con = ConnectionManager.GetConnection();
            try
            {

                var q = "select Count(PublisherId) from Publisher";


                object z = null;
                using (cmd)
                {
                    cmd = new SqlCommand(q, con);
                    z = cmd.ExecuteScalar();
                }

                return (int)z;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                //                con.Close();
            }

        }

        public List<NumberOfBooksPerPublisher> AllBooksForEachPublisher()
        {
            SqlConnection con = ConnectionManager.GetConnection();
            try
            {


                var q =
                    "SELECT Name, COUNT(BookId) AS NrOfBooks FROM Publisher join Book on Book.PublisherId=Publisher.PublisherId group by (Name)";
                ;


                using (cmd)
                {
                    cmd = new SqlCommand(q, con);
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NumberOfBooksPerPublisher pub = new NumberOfBooksPerPublisher();
                            pub.NoOfBooks = (int)reader["NrOfBooks"];
                            pub.PublisherName = reader["Name"] as string;

                            numberOfBooksPerPublishers.Add(pub);
                        }
                    }
                    return numberOfBooksPerPublishers;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                //                con.Close();
            }

        }




        public List<PriceForAllBooksForEachPublisher> TotalPriceForAllBooksForEachPublisher()
        {
            SqlConnection con = ConnectionManager.GetConnection();
            try
            {

                var q =
                    "SELECT Name, SUM(Price) AS TotalPrice FROM Publisher join Book on Book.PublisherId=Publisher.PublisherId group by (Name)";

                using (cmd)
                {
                    using (cmd = new SqlCommand(q, con))
                    {
                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PriceForAllBooksForEachPublisher pub = new PriceForAllBooksForEachPublisher();
                                pub.TotalPrice = (decimal)reader["TotalPrice"];
                                pub.PublisherName = reader["Name"] as string;

                                totalPrice.Add(pub);
                            }
                        }
                    }
                }

                return totalPrice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                //                con.Close();
            }
        }
    }
}