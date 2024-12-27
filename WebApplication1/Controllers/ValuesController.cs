using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public ValuesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("GetAllElectronics")]
        [HttpGet]
        public IActionResult GetAllElectronics()
        {
            var electronics = new List<Electronics>();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            using (var con = new SqlConnection(connectionString))
            {
                con.Open(); // Synchronous connection open

                using (var cmd = new SqlCommand("SELECT * FROM Electronics", con))
                {
                    using (var reader = cmd.ExecuteReader()) // Synchronous data reader
                    {
                        while (reader.Read()) // Synchronous row reading
                        {
                            electronics.Add(new Electronics
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetFloat(reader.GetOrdinal("Price"))
                            });
                        }
                    }
                }
            }

            return Ok(electronics);
        }

    }
}
