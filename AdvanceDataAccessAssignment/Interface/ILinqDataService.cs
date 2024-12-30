using AdvanceDataAccessAssignment.Models;

namespace AdvanceDataAccessAssignment.Interface
{
    /// <summary>
    /// Interface for defining LINQ-based data operations related to electronics filtering.
    /// Provides methods to filter electronics based on category and price.
    /// </summary>
    public interface ILinqDataService
    {
        /// <summary>
        /// Filters electronics based on the specified category.
        /// </summary>
        /// <param name="category">The category of electronics to filter.</param>
        /// <returns>A list of objects that match the specified category.</returns>
        public List<Electronics> FilterDataByCategory(string category);

        /// <summary>
        /// Filters electronics based on the specified category and price range.
        /// </summary>
        /// <param name="category">The category of electronics to filter.</param>
        /// <param name="price">The maximum price to filter electronics by.</param>
        /// <returns>A list of  objects that match the specified category and price range.</returns>
        public List<Electronics> FilterDataByCategoryAndPrice(string category, int price);
    }
}
