using SStore.Model.Data.Models;

//using Microsoft.AspNetCore.Http;
namespace SStore.Services
{
    public interface IGlobalDataService
    {
         void Add( GlobalDataModel globalDataModel);
         void Remove();
         GlobalDataModel? GetData();
    }

    public class GlobalDataService : IGlobalDataService
    {
        const string _key = "globaldata";
      
        private readonly HttpContextAccessor _httpContextAccessor;

        public GlobalDataService(ISession session,HttpContextAccessor httpContextAccessor)
        {
           
            this._httpContextAccessor = httpContextAccessor;
        }
        public void Add(GlobalDataModel globalDataModel)
        {
            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(globalDataModel);
            //_httpContextAccessor!.HttpContext!.Session.SetString(_key, json);
        }

        public GlobalDataModel? GetData()
        {
            //GlobalDataModel? data = null;
            //var val = _httpContextAccessor!.HttpContext!.Session.GetString(_key);
            //Newtonsoft.Json.JsonConvert.PopulateObject(val!, data!);
            //return data;
            throw new NotImplementedException();
        }

        public void Remove()
        {
            //_httpContextAccessor!.HttpContext!.Session.Remove(_key );
            //_httpContextAccessor!.HttpContext!.Session.Clear();
            throw new NotImplementedException();

        }
    }
}
