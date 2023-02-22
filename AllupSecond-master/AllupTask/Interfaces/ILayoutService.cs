using AllupTask.Models;

namespace AllupTask.Interfaces
{
    public interface ILayoutService
    {
        Task<IDictionary<string,string>> GetSettings();
        Task<IEnumerable<Category>> GetCategories();
    }
}
