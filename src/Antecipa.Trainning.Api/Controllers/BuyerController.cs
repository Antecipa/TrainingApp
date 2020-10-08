using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antecipa.Trainning.Application;
using Antecipa.Trainning.Domain.Buyers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Antecipa.Trainning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerApplicationService _buyerApplicationService;
      

        public BuyerController(IBuyerApplicationService buyerApplicationService)
        {
            _buyerApplicationService = buyerApplicationService ?? throw new ArgumentNullException(nameof(buyerApplicationService));
        }

        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            return _buyerApplicationService.GetAll();
        }
    }
}
