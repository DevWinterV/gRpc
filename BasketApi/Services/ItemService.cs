
using Grpc.Core;
using ItemApi;

namespace BasketApi.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemGrpc.ItemGrpcClient _client;

        public ItemService(ItemGrpc.ItemGrpcClient client)
        {
            _client = client;
        }

        public async Task<object?> GetItemAsync(int productId)
        {

            try
            {
                GetItemReq request = new() { Id = productId };
                var response = await _client.GetItemAsync(request);

                return new
                {
                    Id = response.Id,
                    Name = response.Name,
                    Description = response.Description,
                    Price = response.Price
                };
            }
            catch (RpcException e)
            {

                return null;
            }

        }
    }
}
