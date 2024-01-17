using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/paymentMethod")]
    public class PaymentMethodControllers : Controller
    {
        private readonly IPaymentMethodAppService _paymentMethodAppService;
        public PaymentMethodControllers(IPaymentMethodAppService paymentMethodAppService)
        {
            _paymentMethodAppService = paymentMethodAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _paymentMethodAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<PaymentMethodViewModel> Get(Guid id)
        {
            var result = _paymentMethodAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] PaymentMethodViewModel model)
        {
            var result = _paymentMethodAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] PaymentMethodViewModel model)
        {
            var result = _paymentMethodAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _paymentMethodAppService.Remove(id);
            return Ok();
        }
    }
}
