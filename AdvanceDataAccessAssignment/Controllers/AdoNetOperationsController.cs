using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Models;
using Microsoft.AspNetCore.Mvc;


namespace AdvanceDataAccessAssignment.Controllers
{
    public class AdoNetOperationsController : Controller
    {
        private readonly IElectronicsService Service;

        public AdoNetOperationsController(IElectronicsService service)
        {
            Service = service;
        }

        [HttpGet("GetAllElectronics")]
        public IActionResult GetAllElectronics()
        {
            try
            {
                var electronics = Service.GetAllElectronics();
                return Ok(electronics);
            }
            catch (Exception ex)
            {
                return BadRequest($"Please try again later.{ex.Message}");
            }
        }

        [HttpPost("InsertElectronicsData")]
        public IActionResult AddElectronicsData([Bind("Name","Price","description","Category")] Electronics newElectronic)
        {
            if (newElectronic == null)
                return BadRequest("Invalid data.");
            try
            {
                var rowsAffected = Service.AddElectronic(newElectronic);
                return Ok("Electronics data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add electronics data{ex.Message}.");
            }

        }

        [HttpDelete("DeleteElectronic")]
        public IActionResult DeleteElectronic(int id)
        {
            if (id==0)
            {
                return BadRequest("Id Does not exist.");
            }
            try
            {
                var rowsAffected = Service.DeleteElectronic(id);
                return Ok("Record deleted successfully.");

            }
            catch (Exception ex)
            {
                return NotFound($"Please try again later {ex.Message}");
            }
        }

        [HttpPut("UpdateDetails")]
        public IActionResult UpdateElectronicDetails(int id, [FromBody] Electronics updatedElectronic)
        {
            if (id == 0|| updatedElectronic==null)
                return BadRequest("Data not found");
            try
            {
                var rowsAffected = Service.UpdateElectronic(id, updatedElectronic);
                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound($"Updation failed. Please try later{ex.Message}");
            }

        }

        [HttpGet("GetFilteredElectronics")]
        public IActionResult GetFilteredElectronics(decimal minPrice)
        {
            try
            {
                var filteredElectronics = Service.FilterElectronicsBasedOnPrice(minPrice);
                return Ok(filteredElectronics);
            }catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error{ex.Message}");
            }
        }

        [HttpGet("Search")]
        public IActionResult GetElectronicsByName(string electronicName)
        {
            if (string.IsNullOrEmpty(electronicName))
            {
                return BadRequest("Name parameter cannot be empty.");
            }
            try
            {
                var searchedElectronics = Service.GetElectronicsByName(electronicName);
                if (searchedElectronics.Count>0 || searchedElectronics ==null)
                {
                    return Ok(searchedElectronics);
                }
                return NotFound("No electronics found matching the specified name.");
            }
            catch(Exception ex)
            {
                return BadRequest("No data found!");
            }
        }
    }
}
