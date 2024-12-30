using AdvanceDataAccessAssignment.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdvanceDataAccessAssignment.Repositories
{
    /// <summary>
    /// Repository class for interacting with the Electronics data using LINQ queries on the dataset.
    /// Contains methods for retrieving electronics filtered by category and price.
    /// </summary>
    public class LinqDataRepository
    {
        private readonly string ConnectionString;

        /// <summary>
        /// Initializes a new instance of the LinqDataRepository class with the given connection string.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        public LinqDataRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves electronics filtered by category using LINQ on a DataSet.
        /// </summary>
        /// <param name="category">The category of electronics to filter by.</param>
        /// <returns>A list of electronics that match the specified category.</returns>
        public List<Electronics> GetDataByCategory(string category)
        {
            var electronics = new List<Electronics>();

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                // Fetch all data into a DataTable.
                using (var cmd = new SqlCommand("SELECT * FROM Electronics", con))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet, "Electronics");

                        // Perform LINQ query against the DataSet's DataTable.
                        var filteredData = dataSet.Tables["Electronics"].AsEnumerable()
                            .Where(row => string.Equals(row.Field<string>("Category"), category, StringComparison.OrdinalIgnoreCase))
                            .Select(row => new Electronics
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                Name = row.Field<string>("Name"),
                                Description = row.Field<string>("Description"),
                                Price = Convert.ToDecimal(row["Price"]),
                                Category = row.Field<string>("Category")
                            })
                            .ToList();

                        electronics.AddRange(filteredData);
                    }
                }
            }
            return electronics;
        }

        /// <summary>
        /// Retrieves electronics filtered by both category and price using LINQ.
        /// </summary>
        /// <param name="category">The category of electronics to filter by.</param>
        /// <param name="price">The price range to filter the electronics by.</param>
        /// <returns>A list of electronics that match the specified category and price range.</returns>
        public List<Electronics> GeteDataByCategoryAndPrice(string category, int price)
        {
            var electronics = new List<Electronics>();
            var categorizedData = GetDataByCategory(category);

            // Filter the electronics by price
            var categorizedPricedData = categorizedData
                  .Where(electronic => electronic.Price <= price)
                  .ToList();

            return categorizedPricedData;
        }
    }
}
