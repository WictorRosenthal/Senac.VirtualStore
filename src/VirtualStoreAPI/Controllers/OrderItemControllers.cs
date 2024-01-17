using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/orderItem")]

    public class OrderItemControllers : Controller
    {
        private readonly IOrderItemAppService _orderItemAppService;
        public OrderItemControllers(IOrderItemAppService orderItemAppService)
        {
            _orderItemAppService = orderItemAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _orderItemAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<OrderItemViewModel> Get(Guid id)
        {
            var result = _orderItemAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] OrderItemViewModel model)
        {
            var result = _orderItemAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] OrderItemViewModel model)
        {
            var result = _orderItemAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _orderItemAppService.Remove(id);
            return Ok();
        }
    }
}
