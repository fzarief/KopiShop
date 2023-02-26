

using KopiShop.Model;
using KopiShop.Repository;
using Dapper;

namespace KopiShop.Service
{
    public class KopiService : IKopiService
    {
        private readonly IKopiRepository _kopiRepository;

    public KopiService(IKopiRepository kopiRepository)
    {
        _kopiRepository = kopiRepository;
    }

    public async Task<List<KopiMenu>> GetAll()
    {
        return await _kopiRepository.GetAllCoffeShopMenu();
    }

    public async Task<KopiMenu> GetById(int menuId)
    {
        return await _kopiRepository.GetCoffeShopMenu(menuId);
    }

    public async Task<KopiMenu> Insert(KopiMenu menu)
    {
        await _kopiRepository.CreateMenu(menu);
        return menu;
    }

    public async Task<KopiMenu> Update(KopiMenu menu)
    {
        await _kopiRepository.UpdateMenu(menu);
        return menu;
    }

    public async Task<KopiMenu> Delete(int menuId)
    {
        await _kopiRepository.DeleteMenu(menuId);
        return new KopiMenu { Id = menuId };
    }

    }
}
