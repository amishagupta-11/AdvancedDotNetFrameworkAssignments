using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Models;
using AdvanceDataAccessAssignment.Repositories;

namespace AdvanceDataAccessAssignment.Services
{
    /// <summary>
    /// Service class for managing electronics data. Implements the IElectronicsService interface
    /// to provide business logic for retrieving, adding, updating, deleting, and filtering electronics.
    /// </summary>
    public class ElectronicsService : IElectronicsService
    {
        private readonly ElectronicsRepository _repository;

        /// <summary>
        /// Initializes a new instance of the ElectronicsService class with the provided repository.
        /// </summary>
        /// <param name="repository">The repository to access electronics data.</param>
        public ElectronicsService(ElectronicsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all electronics from the repository.
        /// </summary>
        /// <returns>A list of all electronics.</returns>
        public List<Electronics> GetAllElectronics()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Adds a new electronic item to the repository.
        /// </summary>
        /// <param name="electronic">The electronics item to add.</param>
        /// <returns>A boolean indicating whether the addition was successful.</returns>
        public bool AddElectronic(Electronics electronic)
        {
            return _repository.Add(electronic) > 0;
        }

        /// <summary>
        /// Deletes an electronic item from the repository based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the electronic item to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public bool DeleteElectronic(int id)
        {
            return _repository.Delete(id) > 0;
        }

        /// <summary>
        /// Updates an existing electronic item in the repository.
        /// </summary>
        /// <param name="id">The ID of the electronic item to update.</param>
        /// <param name="electronic">The updated electronics item.</param>
        /// <returns>A boolean indicating whether the update was successful.</returns>
        public bool UpdateElectronic(int id, Electronics electronic)
        {
            return _repository.Update(id, electronic) > 0;
        }

        /// <summary>
        /// Filters electronics based on a specified price range.
        /// </summary>
        /// <param name="range">The maximum price to filter by.</param>
        /// <returns>A list of electronics with a price lower than the specified range.</returns>
        public List<Electronics> FilterElectronicsBasedOnPrice(decimal range)
        {
            var allElectronics = _repository.GetAll();
            return allElectronics.FindAll(e => e.Price < range);
        }

        /// <summary>
        /// Retrieves a list of electronics that match a specified name.
        /// </summary>
        /// <param name="electronicName">The name of the electronic item to search for.</param>
        /// <returns>A list of electronics that match the specified name.</returns>
        public List<Electronics> GetElectronicsByName(string electronicName)
        {
            return _repository.GetElectronicsByName(electronicName);
        }
    }
}
