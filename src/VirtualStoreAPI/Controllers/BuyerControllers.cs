using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/buyer")]
    public class BuyerControllers : Controller
    {
        private readonly IBuyerAppService _buyerAppService;
        public BuyerControllers(IBuyerAppService buyerAppService)
        {
            _buyerAppService = buyerAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _buyerAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<BuyerViewModel> Get(Guid id)
        {
            var result = _buyerAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] BuyerViewModel model)
        {
            var result = _buyerAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] BuyerViewModel model)
        {
            var result = _buyerAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _buyerAppService.Remove(id);
            return Ok();
        }

    }
}
