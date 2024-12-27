using AdvanceDataAccessAssignment.Models;

namespace AdvanceDataAccessAssignment.Interface
{
    public interface ILinqDataService
    {
        public List<Electronics> FilterDataByCategory(string category);
        public List<Electronics> FilterDataByCategoryAndPrice(string category,int price);
    }
}
