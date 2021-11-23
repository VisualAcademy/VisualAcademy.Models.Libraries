namespace VisualAcademy.Models.Libraries
{
    /// <summary>
    /// [4] Repository Interface
    /// </summary>
    public interface ILibraryRepository : ILibraryCrudRepository<LibraryModel>
    {
        Task<Tuple<int, int>> GetStatus(int parentId);
        Task<bool> DeleteAllByParentId(int parentId);
        Task<SortedList<int, double>> GetMonthlyCreateCountAsync();
    }
}
