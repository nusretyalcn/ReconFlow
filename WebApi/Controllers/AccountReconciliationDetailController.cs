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
    public class AccountReconciliationDetailController : ControllerBase
    {
        private readonly IAccountReconciliationDetailService _accountReconciliationDetailService;

        public AccountReconciliationDetailController(IAccountReconciliationDetailService accountReconciliationDetailService)
        {
            _accountReconciliationDetailService = accountReconciliationDetailService;
        }
        
               [HttpPost("add")]
        public IActionResult Add(AccountReconciliationDetail accountReconciliationDetail)
        {
            var result= _accountReconciliationDetailService.Add(accountReconciliationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
                
        [HttpPost("update")]
        public IActionResult Update(AccountReconciliationDetail accountReconciliationDetail)
        {
            var result = _accountReconciliationDetailService.Update(accountReconciliationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(AccountReconciliationDetail accountReconciliationDetail)
        {
            var result = _accountReconciliationDetailService.Delete(accountReconciliationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _accountReconciliationDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _accountReconciliationDetailService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyaccountreconciliationid")]
        public IActionResult GetByAccountReconciliationId(int accountReconciliationId)
        {
            var result = _accountReconciliationDetailService.GetByAccountReconciliationId(accountReconciliationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
