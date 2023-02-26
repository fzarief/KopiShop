using KopiShop.Model;
using System.Threading.Tasks;

namespace KopiShop.Repository
{
    public interface IKopiRepository
    {
        Task<List<KopiMenu>> GetAllCoffeShopMenu();
        Task<KopiMenu> GetCoffeShopMenu(int menuId);
        Task<string> CreateMenu(KopiMenu menu);
        Task<string> UpdateMenu(KopiMenu menu);
        Task<int> DeleteMenu(int menuId);
    }
}
