using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/basketItem")]

    public class BasketItemControllers : Controller
    {
        private readonly IBasketItemAppService _basketItemAppService;
        public BasketItemControllers(IBasketItemAppService basketItemAppService)
        {
            _basketItemAppService = basketItemAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _basketItemAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<BasketItemViewModel> Get(Guid id)
        {
            var result = _basketItemAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] BasketItemViewModel model)
        {
            var result = _basketItemAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] BasketItemViewModel model)
        {
            var result = _basketItemAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _basketItemAppService.Remove(id);
            return Ok();
        }
    }
}
