using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceDataAccessAssignment.Controllers
{
    /// <summary>
    /// Handles the CRUD operations for electronics data.
    /// </summary>
    public class AdoNetOperationsController : Controller
    {
        private readonly IElectronicsService _service;

        public AdoNetOperationsController(IElectronicsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets a list of all electronics.
        /// </summary>
        
        [HttpGet("GetAllElectronics")]
        public IActionResult GetAllElectronics()
        {
            try
            {
                var electronics = _service.GetAllElectronics();
                return Ok(electronics);
            }
            catch (Exception ex)
            {
                return BadRequest($"Please try again later. {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new electronics record.
        /// </summary>
        [HttpPost("InsertElectronicsData")]
        public IActionResult AddElectronicsData([Bind("Name", "Price", "Description", "Category")] Electronics newElectronic)
        {
            if (newElectronic == null)
                return BadRequest("Invalid data.");

            try
            {
                _service.AddElectronic(newElectronic);
                return Ok("Electronics data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add electronics data. {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an electronics record by ID.
        /// </summary>
        [HttpDelete("DeleteElectronic")]
        public IActionResult DeleteElectronic(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id does not exist.");
            }

            try
            {
                _service.DeleteElectronic(id);
                return Ok("Record deleted successfully.");
            }
            catch (Exception ex)
            {
                return NotFound($"Please try again later. {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing electronics record by ID.
        /// </summary>
        [HttpPut("UpdateDetails")]
        public IActionResult UpdateElectronicDetails(int id, [FromBody] Electronics updatedElectronic)
        {
            if (id == 0 || updatedElectronic == null)
                return BadRequest("Data not found.");

            try
            {
                _service.UpdateElectronic(id, updatedElectronic);
                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound($"Update failed. Please try later. {ex.Message}");
            }
        }

        /// <summary>
        /// Filters electronics based on minimum price.
        /// </summary>
        [HttpGet("GetFilteredElectronics")]
        public IActionResult GetFilteredElectronics(decimal minPrice)
        {
            try
            {
                var filteredElectronics = _service.FilterElectronicsBasedOnPrice(minPrice);
                return Ok(filteredElectronics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error. {ex.Message}");
            }
        }

        /// <summary>
        /// Searches electronics by name.
        /// </summary>
        [HttpGet("Search")]
        public IActionResult GetElectronicsByName(string electronicName)
        {
            if (string.IsNullOrEmpty(electronicName))
            {
                return BadRequest("Name parameter cannot be empty.");
            }

            try
            {
                var searchedElectronics = _service.GetElectronicsByName(electronicName);
                if (searchedElectronics != null && searchedElectronics.Count > 0)
                {
                    return Ok(searchedElectronics);
                }
                return NotFound("No electronics found matching the specified name.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Search failed: {ex.Message}");
            }
        }
    }
}
