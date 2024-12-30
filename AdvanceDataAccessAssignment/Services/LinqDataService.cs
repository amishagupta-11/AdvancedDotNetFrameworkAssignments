using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Models;
using AdvanceDataAccessAssignment.Repositories;

namespace AdvanceDataAccessAssignment.Services
{
    /// <summary>
    /// Service class for managing LINQ-based data filtering. Implements the ILinqDataService interface
    /// to provide business logic for filtering electronics by category and category-price combination.
    /// </summary>
    public class LinqDataService : ILinqDataService
    {
        private readonly LinqDataRepository _repository;

        /// <summary>
        /// Initializes a new instance of the LinqDataService class with the provided repository.
        /// </summary>
        /// <param name="repository">The repository to access electronics data with LINQ operations.</param>
        public LinqDataService(LinqDataRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Filters electronics by the specified category.
        /// </summary>
        /// <param name="category">The category to filter the electronics by.</param>
        /// <returns>A list of electronics in the specified category.</returns>
        public List<Electronics> FilterDataByCategory(string category)
        {
            return _repository.GetDataByCategory(category);
        }

        /// <summary>
        /// Filters electronics by the specified category and price.
        /// </summary>
        /// <param name="category">The category to filter the electronics by.</param>
        /// <param name="price">The price to filter the electronics by (electronic items that cost less than this price).</param>
        /// <returns>A list of electronics that match the specified category and are below the specified price.</returns>
        public List<Electronics> FilterDataByCategoryAndPrice(string category, int price)
        {
            return _repository.GeteDataByCategoryAndPrice(category, price);
        }
    }
}
