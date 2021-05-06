using Microsoft.AspNetCore.Mvc;
using Smart.DataTypes;
using Smart.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class mgmtController : ControllerBase
    {
        private ISearchManager _searchManager;

        public mgmtController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }


        // GET api/<mgmtController>/5
        [HttpGet("{mgmtID}")]
        public GetMgmtResponse Get(int mgmtID)
        {
            return _searchManager.GetMgmt(mgmtID);
        }
    }
}
