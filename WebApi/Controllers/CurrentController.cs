using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentController : ControllerBase
    {
        private readonly ICurrentService _currentService;

        public CurrentController(ICurrentService currentService)
        {
            _currentService = currentService;
        }
        
        [HttpPost("add")]
        public IActionResult Add(Current current)
        {
            var result = _currentService.Add(current);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("update")]
        public IActionResult Update(Current current)
        {
            var result = _currentService.Update(current);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(Current current)
        {
            var result = _currentService.Delete(current);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _currentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getallbycompanyid")]
        public IActionResult GetAllByCompanyId(int companyId)
        {
            var result = _currentService.GetCurrentByCompanyId(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _currentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getcurrentdetails")]
        public IActionResult GetCurrentDetails()
        {
            var result = _currentService.GetCurrentDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
