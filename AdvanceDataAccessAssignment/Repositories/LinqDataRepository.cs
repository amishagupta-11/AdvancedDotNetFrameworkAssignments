using AdvanceDataAccessAssignment.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdvanceDataAccessAssignment.Repositories
{
    public class LinqDataRepository
    {
        private readonly string ConnectionString;
        public LinqDataRepository(string connectionString)
        {
            ConnectionString=connectionString;
        }

        public List<Electronics> GetDataByCategory(string category)
        {
            var electronics = new List<Electronics>();

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                // Fetch all data into a DataTable
                using (var cmd = new SqlCommand("SELECT * FROM Electronics", con))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet, "Electronics");

                        // Perform LINQ query against the DataSet's DataTable
                        var filteredData = dataSet.Tables["Electronics"].AsEnumerable()
                            .Where(row => string.Equals(row.Field<string>("Category"), category, StringComparison.OrdinalIgnoreCase))
                            .Select(row => new Electronics
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                Name = row.Field<string>("Name"),
                                Description = row.Field<string>("Description"),
                                Price = Convert.ToDecimal(row["Price"]),
                                Category=row.Field<string>("Category")
                            })
                            .ToList();

                        electronics.AddRange(filteredData);
                    }
                }
            }
            return electronics;
        }

        public List<Electronics> GeteDataByCategoryAndPrice(string category, int price)
        {
            var electronics = new List<Electronics>();
            var categorizedData = GetDataByCategory(category);
            var categorizedPricedData = categorizedData
                  .Where(electronic => electronic.Price <= price)
                  .ToList();
            return categorizedPricedData;
        }
    }


}
