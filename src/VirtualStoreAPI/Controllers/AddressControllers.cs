using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.ViewModel;

namespace VirtualStoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/address")]



    public class AddressController : Controller
    {
        private readonly IAddressAppService _addressAppService;
        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _addressAppService.Search(p => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<AddressViewModel> Get(Guid id)
        {
            var result = _addressAppService.GetById(id);
            return result;
        }
        [HttpPost]
        public ActionResult Post([FromBody] AddressViewModel model)
        {
            var result = _addressAppService.Add(model);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put([FromBody] AddressViewModel model)
        {
            var result = _addressAppService.Update(model);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _addressAppService.Remove(id);
            return Ok();
        }
    }
}
