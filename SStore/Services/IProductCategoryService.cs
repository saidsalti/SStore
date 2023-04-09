using SStore.Data;
using SStore.Model.Data.Entities;

namespace SStore.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetByProductId(int? productId);
        

        bool Insert(List<ProductCategory> productCategories);
        void DeleteAll(int? productId);

    }

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ApplicationDbContext _db;

        public ProductCategoryService(ApplicationDbContext db)
        {
            this._db = db;
        }

       

        public void DeleteAll(int? productId)
        {
            _db.Remove(GetByProductId(productId));
            _db.SaveChanges();
        }

        public List<ProductCategory> GetByProductId(int? productId)
        {
            return _db.ProductCategories.Where(m=>m.ProductId== productId).ToList();
        }

        public bool Insert(List<ProductCategory> productCategories)
        {
            _db.ProductCategories.AddRange(productCategories);
            return _db.SaveChanges()>0;
        }
    }
}
