using SStore.Data;
using SStore.Model.Data.Dtos;
using SStore.Model.Data.Entities;

namespace SStore.Services
{
    public interface ICategoryService
    {
        List<CategoryDropDown> GetCategoryDropDownlist();

        void Insert(Category category);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public List<CategoryDropDown> GetCategoryDropDownlist()
        {
            return _db.Categories.Select(s => new CategoryDropDown
            {
                Id = s.Id,
                Text = s.CategoryName
            }).ToList();
        }

        public void Insert(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }
    }
}
