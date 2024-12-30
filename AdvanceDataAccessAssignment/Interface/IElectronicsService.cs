using AdvanceDataAccessAssignment.Models;

namespace AdvanceDataAccessAssignment.Interface
{
    /// <summary>
    /// Interface for defining the operations related to electronics management.
    /// Provides methods to retrieve, add, update, delete, and filter electronics data.
    /// </summary>
    public interface IElectronicsService
    {
        /// <summary>
        /// Retrieves a list of all electronics.
        /// </summary>
        /// <returns>A list of  objects.</returns>
        public List<Electronics> GetAllElectronics();

        /// <summary>
        /// Adds a new electronic item to the database.
        /// </summary>
        /// <param name="electronic">The  object to be added.</param>
        /// <returns>True if the electronic item was successfully added; otherwise, false.</returns>
        public bool AddElectronic(Electronics electronic);

        /// <summary>
        /// Deletes an electronic item based on its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the electronic item to be deleted.</param>
        /// <returns>True if the electronic item was successfully deleted; otherwise, false.</returns>
        public bool DeleteElectronic(int id);

        /// <summary>
        /// Updates the details of an existing electronic item.
        /// </summary>
        /// <param name="id">The unique identifier of the electronic item to be updated.</param>
        /// <param name="electronic">The updated  object.</param>
        /// <returns>True if the electronic item was successfully updated; otherwise, false.</returns>
        public bool UpdateElectronic(int id, Electronics electronic);

        /// <summary>
        /// Filters the list of electronics based on a specified price range.
        /// </summary>
        /// <param name="range">The price range for filtering electronics.</param>
        /// <returns>A list of  objects that fall within the specified price range.</returns>
        public List<Electronics> FilterElectronicsBasedOnPrice(decimal range);

        /// <summary>
        /// Retrieves a list of electronics based on their name.
        /// </summary>
        /// <param name="electronicName">The name of the electronic item to search for.</param>
        /// <returns>A list of  objects that match the specified name.</returns>
        public List<Electronics> GetElectronicsByName(string electronicName);
    }
}
