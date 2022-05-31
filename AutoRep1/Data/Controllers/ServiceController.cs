using AutoRep1.Data.DTOs;
using AutoRep1.Data.Models;
using AutoRep1.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoRep1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _context;

        public ServiceController(ServiceService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetService()
        {
            return await _context.GetServices();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.GetService(id);

            if (service == null)
            {
                return NotFound();
            }
            return service;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> PutService(int id, [FromBody] Service service)
        {
            var result = await _context.UpdateService(id, service);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> PostService([FromBody] ServiceDTO service)
        {
            var result = await _context.AddService(service);
            if (result == null)
            {
                BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var service = await _context.DeleteService(id);
            if (service)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("/incomplete")]
        public async Task<ActionResult<IEnumerable<IncompleteServiceDTO>>> GetServiceIncomplete()
        {
            return await _context.GetServicesIncomplete();

        }
    }
}