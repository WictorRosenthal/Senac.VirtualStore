using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/basket")]

    public class BasketControllers : Controller
    {

        private readonly IBasketAppService _basketAppService;
        public BasketControllers(IBasketAppService basketAppService)
        {
            _basketAppService = basketAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _basketAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<BasketViewModel> Get(Guid id)
        {
            var result = _basketAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] BasketViewModel model)
        {
            var result = _basketAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] BasketViewModel model)
        {
            var result = _basketAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _basketAppService.Remove(id);
            return Ok();
        }
    }
}
