using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using KopiShop.Model;
using Microsoft.AspNetCore.Mvc;

namespace KopiShop.Repository
{
    public class KopiRepository : IKopiRepository
    {
        private readonly IConfiguration _config;

        public KopiRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<KopiMenu>> GetAllCoffeShopMenu()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var menus = await connection.QueryAsync<KopiMenu>("Select * from CoffeShopMenu");
            return menus.ToList();
        }

        public async Task<KopiMenu> GetCoffeShopMenu(int menuId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var menu = await connection.QueryFirstAsync<KopiMenu>("Select * from CoffeShopMenu where Id = @Id",
                new { Id = menuId });
            return menu;
        }

        public async Task<string> CreateMenu(KopiMenu menu)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("insert into CoffeShopMenu(menuname, price, stock) values (@MenuName, @Price, @Stock)", menu);
            return "Ok";
        }

        public async Task<string> UpdateMenu(KopiMenu menu)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update CoffeShopMenu set menuname=@MenuName, price=@Price, stock=@Stock where id=@Id", menu);
            return "Ok";
        }

        public async Task<int> DeleteMenu(int menuId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var result = await connection.ExecuteAsync("delete from CoffeShopMenu where id=@Id", new { Id = menuId });
            return result;
        }

    }
}
