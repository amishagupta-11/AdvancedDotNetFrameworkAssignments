using AdvanceDataAccessAssignment.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdvanceDataAccessAssignment.Repositories
{
    public class ElectronicsRepository
    {
        private readonly string ConnectionString;

        public ElectronicsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

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
                    Category=row["Category"].ToString()
                });
            }

            return electronics;
        }


        public int Add(Electronics electronic)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO Electronics (Name, Description, Price,Category) VALUES (@Name, @Description, @Price,@Category)", con))
                {
                    cmd.Parameters.AddWithValue("@Name", electronic.Name);
                    cmd.Parameters.AddWithValue("@Description", electronic.Description);
                    cmd.Parameters.AddWithValue("@Price", electronic.Price);
                    cmd.Parameters.AddWithValue("@Category", electronic.Category);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

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
