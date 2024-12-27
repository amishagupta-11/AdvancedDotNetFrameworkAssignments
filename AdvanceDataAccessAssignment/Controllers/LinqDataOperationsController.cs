using AdvanceDataAccessAssignment.Interface;
using Microsoft.AspNetCore.Mvc;


namespace AdvanceDataAccessAssignment.Controllers
{
    public class LinqDataOperationsController : Controller
    {
        public ILinqDataService LinqDataService;
        public LinqDataOperationsController(ILinqDataService linqDataService)
        {
            LinqDataService = linqDataService;


        }
        [HttpGet("CategoryBasedSearch")]
        public IActionResult FilterDataByCategory(string category)
        {
            try
            {
                var CategorizedElectronics = LinqDataService.FilterDataByCategory(category);
                if (CategorizedElectronics!=null && CategorizedElectronics.Any())
                    return Ok(CategorizedElectronics);
                else
                    return BadRequest($" No matches found for the {category} ");
            }
            catch (Exception ex)
            {
                return BadRequest($"Please try again later.{ex.Message}");
            }
        }

        [HttpGet("CategorizedPricedBasedSearch")]
        public IActionResult FilterDataByCategoryAndPrice(string category, int price)
        {
            try
            {
                var CategorizedPricedElectronics = LinqDataService.FilterDataByCategoryAndPrice(category, price);
                if (CategorizedPricedElectronics!=null && CategorizedPricedElectronics.Any())
                    return Ok(CategorizedPricedElectronics);
                else
                    return BadRequest($"No match found for the {category} with the price of {price} or below");
            }
            catch (Exception ex)
            {
                return BadRequest($"Please try again later.{ex.Message}");
            }
        }


    }
}
