using Grpc.Core;

namespace ItemApi.Services
{
    public class ItemService : ItemGrpc.ItemGrpcBase
    {
        public override Task<GetItemRes> GetItem(GetItemReq request, ServerCallContext context)
        {
            return Task.FromResult(new GetItemRes
            {
                Id = 1,
                Name = "Demo",
                Description = "Demo",
                Price = 10000
            });
        }
    }
}
