using KopiShop.Model;
using KopiShop.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KopiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KopiShopController : ControllerBase
    {
        private readonly IKopiService _kopiService;

        public KopiShopController(IKopiService kopiService)
        {
            _kopiService = kopiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _kopiService.GetAll();
            return Ok(result);
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> Details(int menuId)
        {
            var result = await _kopiService.GetById(menuId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KopiMenu menu)
        {
            var createdMenu = await _kopiService.Insert(menu);
            return CreatedAtAction(nameof(Details), new { menuId = createdMenu.Id }, createdMenu);
        }

        [HttpPut("{menuId}")]
        public async Task<IActionResult> Edit(int menuId, [FromBody] KopiMenu menu)
        {
            menu.Id = menuId;
            var updatedMenu = await _kopiService.Update(menu);
            if (updatedMenu == null)
            {
                return NotFound();
            }

            return Ok(updatedMenu);
        }

        [HttpDelete("{menuId}")]
        public async Task<IActionResult> Delete(int menuId)
        {
            var deletedMenu = await _kopiService.Delete(menuId);
            if (deletedMenu == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
