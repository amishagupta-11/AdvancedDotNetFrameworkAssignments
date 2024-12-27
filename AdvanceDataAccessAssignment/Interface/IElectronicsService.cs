using AdvanceDataAccessAssignment.Models;

namespace AdvanceDataAccessAssignment.Interface
{
    public interface IElectronicsService
    {
        public List<Electronics> GetAllElectronics();
        public bool AddElectronic(Electronics electronic);
        public bool DeleteElectronic(int id);
        public bool UpdateElectronic(int id, Electronics electronic);
        public List<Electronics> FilterElectronicsBasedOnPrice(decimal range);
        public List<Electronics> GetElectronicsByName(string electronicName);
    }
}
