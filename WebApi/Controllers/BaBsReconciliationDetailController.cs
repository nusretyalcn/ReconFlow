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
    public class BaBsReconciliationDetailController : ControllerBase
    {
        private IBaBsReconciliationDetailService _bsReconciliationDetailService;

        public BaBsReconciliationDetailController(IBaBsReconciliationDetailService bsReconciliationDetailService)
        {
            _bsReconciliationDetailService = bsReconciliationDetailService;
        }
        
        [HttpPost("add")]
        public IActionResult Add(BaBsReconciliationDetail bsReconciliationDetail)
        {
            var result= _bsReconciliationDetailService.Add(bsReconciliationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
                
        [HttpPost("update")]
        public IActionResult Update(BaBsReconciliationDetail bsReconciliationDetail)
        {
            var result = _bsReconciliationDetailService.Update(bsReconciliationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(BaBsReconciliationDetail bsReconciliationDetail)
        {
            var result = _bsReconciliationDetailService.Delete(bsReconciliationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bsReconciliationDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bsReconciliationDetailService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbycurrentaccountid")]
        public IActionResult GetByCurrentAccountId(int bsReconciliationId)
        {
            var result = _bsReconciliationDetailService.GetByBaBsReconciliationId(bsReconciliationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
