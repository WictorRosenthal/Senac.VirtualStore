using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/prder")]
    public class OrderControllers : Controller
    {
        private readonly IOrderAppService _orderAppService;
        public OrderControllers(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _orderAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<OrderViewModel> Get(Guid id)
        {
            var result = _orderAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] OrderViewModel model)
        {
            var result = _orderAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] OrderViewModel model)
        {
            var result = _orderAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _orderAppService.Remove(id);
            return Ok();
        }
    }
}
