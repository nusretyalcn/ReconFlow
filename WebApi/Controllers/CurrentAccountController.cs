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
    public class CurrentAccountController : ControllerBase
    {
        private ICurrentAccountService _currentAccountService;

        public CurrentAccountController(ICurrentAccountService currentAccountService)
        {
            _currentAccountService = currentAccountService;
        }

        [HttpPost("add")]
        public IActionResult Add(CurrentAccount currentAccount)
        {
            var result = _currentAccountService.Add(currentAccount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("update")]
        public IActionResult Update(CurrentAccount currentAccount)
        {
            var result = _currentAccountService.Update(currentAccount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(CurrentAccount currentAccount)
        {
            var result = _currentAccountService.Delete(currentAccount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _currentAccountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _currentAccountService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
