using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/product")]


    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
            
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _productAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> Get(Guid id)
        {
            var result = _productAppService.GetById(id);
            return result;
        }
        [HttpPost]
        //Insere produto no banco de dados
        public ActionResult Post([FromBody] ProductViewModel model)
        {
            var result = _productAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] ProductViewModel model)
        {
            var result = _productAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _productAppService.Remove(id);
            return Ok();
        }

    }
}
