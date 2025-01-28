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
    public class BaBsReconciliationController : ControllerBase
    {
        private readonly IBaBsReconciliationService _baBsReconciliationService;

        public BaBsReconciliationController(IBaBsReconciliationService baBsReconciliationService)
        {
            _baBsReconciliationService = baBsReconciliationService;
        }
        
        [HttpPost("add")]
        public IActionResult Add(BaBsReconciliation baBsReconciliation)
        {
            var result= _baBsReconciliationService.Add(baBsReconciliation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
                
        [HttpPost("update")]
        public IActionResult Update(BaBsReconciliation baBsReconciliation)
        {
            var result = _baBsReconciliationService.Update(baBsReconciliation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(BaBsReconciliation baBsReconciliation)
        {
            var result = _baBsReconciliationService.Delete(baBsReconciliation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _baBsReconciliationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _baBsReconciliationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbycurrentaccountid")]
        public IActionResult GetByCurrentAccountId(int currentAccountId)
        {
            var result = _baBsReconciliationService.GetByCurrentAccountId(currentAccountId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbabsreconciliationbycompanyid")]
        public IActionResult GetBaBsReconciliationByCompanyId(int companyId)
        {
            var result = _baBsReconciliationService.GetBaBsReconciliationByCompanyId(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
