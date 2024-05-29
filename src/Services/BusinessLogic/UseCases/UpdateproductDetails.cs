using Services.Products.Dtos;
using Shared.Communication.Publisher.Domain;
using Services.Products.BusinessLogic.DataAccess;


namespace Services.Products.BusinessLogic.UseCases
{
    public interface IUpdateProductDetails
    {
        Task<bool> Execute(int id, ProductDetails productDetails);
    }


    public class UpdateproductDetails : IUpdateProductDetails
    {
        private readonly IProductsWriteStore _writeStore;
        private readonly IDomainMessagePublisher _domainMessagePublisher;

        public UpdateproductDetails(IProductsWriteStore writeStore, IDomainMessagePublisher domainMessagePublisher)
        {
            _writeStore = writeStore;
            _domainMessagePublisher = domainMessagePublisher;
        }

        public async Task<bool> Execute(int id, ProductDetails productDetails)
        {
            await _writeStore.UpdateProduct(id, productDetails);

            await _domainMessagePublisher.Publish(new ProductUpdated(id, productDetails), routingKey: "internal");

            return true;
        }

    }
}
