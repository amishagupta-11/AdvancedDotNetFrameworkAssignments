using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Models;
using AdvanceDataAccessAssignment.Repositories;

namespace AdvanceDataAccessAssignment.Services
{
    public class ElectronicsService: IElectronicsService
    {
        private readonly ElectronicsRepository _repository;

        public ElectronicsService(ElectronicsRepository repository)
        {
            _repository = repository;
        }

        public List<Electronics> GetAllElectronics()
        {
            return _repository.GetAll();
        }

        public bool AddElectronic(Electronics electronic)
        {
            return _repository.Add(electronic) > 0;
        }

        public bool DeleteElectronic(int id)
        {
            return _repository.Delete(id) > 0;
        }

        public bool UpdateElectronic(int id, Electronics electronic)
        {
            return _repository.Update(id, electronic) > 0;
        }

        public List<Electronics> FilterElectronicsBasedOnPrice(decimal range)
        {
            var allElectronics = _repository.GetAll();
            return allElectronics.FindAll(e => e.Price < range);
        }

        public List<Electronics> GetElectronicsByName(string electronicName)
        {
            var searchByName = _repository.GetElectronicsByName(electronicName);
            return searchByName;
        }
    }
}

