using AdvanceDataAccessAssignment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceDataAccessAssignment.Controllers
{
    /// <summary>
    /// Controller for handling LINQ data operations.
    /// </summary>
    public class LinqDataOperationsController : Controller
    {
        private readonly ILinqDataService _linqDataService;

        public LinqDataOperationsController(ILinqDataService linqDataService)
        {
            _linqDataService = linqDataService;
        }

        /// <summary>
        /// Filters electronics data based on the specified category.
        /// </summary>
        [HttpGet("CategoryBasedSearch")]
        public IActionResult FilterDataByCategory(string category)
        {
            try
            {
                var categorizedElectronics = _linqDataService.FilterDataByCategory(category);
                if (categorizedElectronics != null && categorizedElectronics.Any())
                    return Ok(categorizedElectronics);
                else
                    return NotFound($"No matches found for the category '{category}'.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the request. {ex.Message}");
            }
        }

        /// <summary>
        /// Filters electronics data based on the specified category and maximum price.
        /// </summary>
        [HttpGet("CategorizedPricedBasedSearch")]
        public IActionResult FilterDataByCategoryAndPrice(string category, int price)
        {
            try
            {
                var categorizedPricedElectronics = _linqDataService.FilterDataByCategoryAndPrice(category, price);
                if (categorizedPricedElectronics != null && categorizedPricedElectronics.Any())
                    return Ok(categorizedPricedElectronics);
                else
                    return NotFound($"No matches found for the category '{category}' with a price of {price} or below.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the request. {ex.Message}");
            }
        }
    }
}
