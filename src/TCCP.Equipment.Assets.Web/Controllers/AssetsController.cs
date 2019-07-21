using TCCP.Equipment.Assets.Business.Services;
using TCCP.Equipment.Assets.Web.Mappings;
using TCCP.Equipment.Assets.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace TCCP.Equipment.Assets.Web.Controllers
{
    [Route("assets")]
    public class AssetsController : Controller
    {
        private readonly IAssetsService _assetsService;

        public AssetsController(IAssetsService assetsService)
        {
            _assetsService = assetsService;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(_assetsService.GetAll().ToViewModel());
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var asset = _assetsService.GetById(id);

            if (asset == null)
            {
                return NotFound();
            }

            return View(asset.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, AssetViewModel model)
        {
            var asset = _assetsService.Update(model.ToServiceModel());

            if (asset == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReally(AssetViewModel model)
        {
            _assetsService.Add(model.ToServiceModel());

            return RedirectToAction("Index");
        }
    }
}