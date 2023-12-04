using Microsoft.AspNetCore.Mvc;
using MostafaProject.Application.Interfaces;
using MostafaProject.Domain.Entities;
using Shared.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MostafaProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : BaseController
    {
        private readonly IBookService _demoService;

        public DemoController(IBookService demoService)
        {
            this._demoService = demoService;
        }
        // GET: api/<DemoController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return BaseResponseHandler(await _demoService.GetAll());
        }

        // GET api/<DemoController>/5
        [HttpGet("GetById{id}")]
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<DemoController>
        [HttpPost("AddNewDemo")]
        public async Task<IActionResult> Creat([FromBody] Book add)
        {
            return BaseResponseHandler(await _demoService.CreateNewDemo(add));
        }

        // PUT api/<DemoController>/5
        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<DemoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return BaseResponseHandler(await _demoService.Remove(id));
        }
    }
}
