using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Models;
using AdvanceDataAccessAssignment.Repositories;

namespace AdvanceDataAccessAssignment.Services
{
    public class LinqDataService: ILinqDataService
    {
        private readonly LinqDataRepository Repository;
        public LinqDataService(LinqDataRepository repository)
        {
            Repository=repository;
        }
    
        public List<Electronics> FilterDataByCategory(string category)
        {
            return Repository.GetDataByCategory(category);
        }

        public List<Electronics> FilterDataByCategoryAndPrice(string category, int price)
        {
            return Repository.GeteDataByCategoryAndPrice(category, price);
        }
    }
}
