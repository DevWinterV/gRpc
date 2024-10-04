namespace BasketApi.Services
{
    public interface IItemService
    {
        Task<object?> GetItemAsync(int productId);
    }
}
