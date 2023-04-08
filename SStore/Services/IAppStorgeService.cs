using SStore.Data;
using SStore.Model.Data.Entities;

namespace SStore.Services
{
    public interface IAppStorgeService
    {
        (bool isSave, AppStorge? appStorge, string? errors) CreateAppStorge(AppStorge appStorge);
        AppStorge? FindOne(int? Id);
    }
    public class AppStorgeService : IAppStorgeService
    {
        private readonly ApplicationDbContext _db;

        public AppStorgeService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public (bool isSave, AppStorge? appStorge, string? errors) CreateAppStorge(AppStorge appStorge)
        {
            _db.Add(appStorge);
            var result = _db.SaveChanges();
            if(result > 0)
            {
                return (true, appStorge, null);
            }
            return (false,null, "عذرا لم يتم رفه الملف");
        }

        public AppStorge? FindOne(int? Id)
        {
            return _db.AppStorges.FirstOrDefault(m => m.Id == Id);
        }
    }
}
