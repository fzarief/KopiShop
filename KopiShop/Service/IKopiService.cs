using KopiShop.Model;

namespace KopiShop.Service
{
    public interface IKopiService
    {
        Task<List<KopiMenu>> GetAll();
        Task<KopiMenu> GetById(int menuId);
        Task<KopiMenu> Insert(KopiMenu menu);
        Task<KopiMenu> Update(KopiMenu menu);
        Task<KopiMenu> Delete(int menuId);
    }
}
