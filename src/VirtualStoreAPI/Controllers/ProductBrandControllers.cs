using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/productbrand")]
    public class ProductBrandControllers : Controller
    {
        private readonly IProductBrandAppService _productBrandAppService;
        public ProductBrandControllers(IProductBrandAppService productBrandAppService)
        {
            _productBrandAppService = productBrandAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _productBrandAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<ProductBrandViewModel> Get(Guid id)
        {
            var result = _productBrandAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] ProductBrandViewModel model)
        {
            var result = _productBrandAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] ProductBrandViewModel model)
        {
            var result = _productBrandAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _productBrandAppService.Remove(id);
            return Ok();
        }
    }
}
