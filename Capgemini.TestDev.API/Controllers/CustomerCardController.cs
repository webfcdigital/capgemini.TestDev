using Capgemini.TestDev.Business.Interfaces;
using Capgemini.TestDev.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capgemini.TestDev.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class CustomerCardController : Controller
    {


        private readonly ICustomerCardService _customerCardService;

        public CustomerCardController(ICustomerCardService customerCardService)
        {
            _customerCardService = customerCardService;
        }

        [HttpPost]
        public IActionResult SaveCard(RequestSaveCardNumber req)
        {
            try
            {
                var saveCard = _customerCardService.SaveCard(req);
                return Ok(saveCard); 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public IActionResult validateToken(ValidateToken validate)
        {
            try
            {
                var validateTk = _customerCardService.ValidateToken(validate);
                return Ok(validateTk);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
