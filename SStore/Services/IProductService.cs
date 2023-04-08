using SStore.Data;
using SStore.Model.Data;
using SStore.Model.Data.Dtos;
using SStore.Model.Data.Entities;

namespace SStore.Services
{
    public interface IProductService {
        IQueryable<ProductDto?> ReadAll();
        Product? FindOne(int? Id);

        (bool isSave, ProductDto productDto) CreateUpdateProduct(Product product);


        bool DeleteOne(int? Id);
        ProductDto? FindOneProductDto(int? Id);
    }
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IQueryable<ProductDto?> ReadAll()
        {
            return _db.Products.OrderByDescending(m => m.Created).Select(s => new ProductDto
            {
                Id = s.Id,
                IsActive = s.IsActive,
                //ProductImagePath = _db.AppStorges.Where(m => m.Id == s.ProductImageId)!.FirstOrDefault()!.FileName,
                ProductName = s.ProductName,
                ProductPrice = s.ProductPrice,
                Quantity = s.Quantity,
                Created = s.Created,
                ProductImageId = s.ProductImageId
            }) ;
        }
        public ProductDto? FindOneProductDto(int? Id)
        {
            var data= ReadAll().FirstOrDefault(m => m!.Id == Id);
            if (data != null)
            {
                if (data.ProductImageId != null)
                {
                    data.ProductImagePath = _db.AppStorges.FirstOrDefault(m=>m.Id == data.ProductImageId )!.FileName;
                   
                }
            }
            return data;
        }
        public Product? FindOne(int? Id)
        {
            return _db.Products.FirstOrDefault(m => m.Id == Id)!;
        }
        public ( bool isSave,ProductDto productDto) CreateUpdateProduct(Product product)
        {
            bool isEdit = false;
            if (product.Id > 0)
            {
                isEdit= true;
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
          var isSave  =_db.SaveChanges();
            if (!isEdit)
            {
                return (isSave > 0, new());

            }
            return (isSave > 0, ProductDto.toDto(product));

        }

        public bool DeleteOne(int? Id)
        {
            var product = FindOne(Id);
            _db.Products.Remove(product!);
            return _db.SaveChanges() > 0;
        }
    }
}

