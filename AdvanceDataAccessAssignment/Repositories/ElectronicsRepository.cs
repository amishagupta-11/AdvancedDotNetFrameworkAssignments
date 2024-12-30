using AdvanceDataAccessAssignment.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdvanceDataAccessAssignment.Repositories
{
    /// <summary>
    /// Repository class for interacting with the Electronics data in the database.
    /// Contains methods for retrieving, adding, updating, and deleting electronics.
    /// </summary>
    public class ElectronicsRepository
    {
        private readonly string ConnectionString;

        /// <summary>
        /// Initializes a new instance of the ElectronicsRepository class with the given connection string.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        public ElectronicsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all electronics from the database.
        /// </summary>
        /// <returns>A list of electronics.</returns>
        public List<Electronics> GetAll()
        {
            var electronics = new List<Electronics>();
            var dataTable = new DataTable();

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Electronics", con))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        // Fill the DataTable with the result set
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Convert DataTable rows to List<Electronics>
            foreach (DataRow row in dataTable.Rows)
            {
                electronics.Add(new Electronics
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Category = row["Category"].ToString()
                });
            }

            return electronics;
        }

        /// <summary>
        /// Adds a new electronic item to the database.
        /// </summary>
        /// <param name="electronic">The electronic item to be added.</param>
        /// <returns>The number of rows affected.</returns>
        public int Add(Electronics electronic)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO Electronics (Name, Description, Price, Category) VALUES (@Name, @Description, @Price, @Category)", con))
                {
                    cmd.Parameters.AddWithValue("@Name", electronic.Name);
                    cmd.Parameters.AddWithValue("@Description", electronic.Description);
                    cmd.Parameters.AddWithValue("@Price", electronic.Price);
                    cmd.Parameters.AddWithValue("@Category", electronic.Category);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes an electronic item from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the electronic item to be deleted.</param>
        /// <returns>The number of rows affected.</returns>
        public int Delete(int id)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("DELETE FROM Electronics WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates an existing electronic item in the database.
        /// </summary>
        /// <param name="id">The ID of the electronic item to be updated.</param>
        /// <param name="electronic">The updated electronic item data.</param>
        /// <returns>The number of rows affected.</returns>
        public int Update(int id, Electronics electronic)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("UPDATE Electronics SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", electronic.Name);
                    cmd.Parameters.AddWithValue("@Description", electronic.Description);
                    cmd.Parameters.AddWithValue("@Price", electronic.Price);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves a list of electronics by their name, with partial matching.
        /// </summary>
        /// <param name="electronicName">The name or partial name of the electronic items to search for.</param>
        /// <returns>A list of electronics that match the search criteria.</returns>
        public List<Electronics> GetElectronicsByName(string electronicName)
        {
            var electronics = new List<Electronics>();

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Electronics WHERE Name LIKE @Name", con))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + electronicName + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var electronic = new Electronics
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Category = reader.GetString(reader.GetOrdinal("Category")),
                            };

                            electronics.Add(electronic);
                        }
                    }
                }
            }

            return electronics;
        }
    }
}
