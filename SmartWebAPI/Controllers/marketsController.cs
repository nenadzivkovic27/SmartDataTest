using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smart.DataTypes;
using Smart.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class marketsController : ControllerBase
    {
        private ISearchManager _searchManager;

        public marketsController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        // GET: <marketsController>
        [HttpGet]
        public GetMarketsResponse Get()
        {
            return _searchManager.GetAllMarkets();
        }
    }
}
