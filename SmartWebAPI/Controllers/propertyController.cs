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
    public class propertyController : ControllerBase
    {
        private ISearchManager _searchManager;

        public propertyController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        // GET <propertyController>/5
        [HttpGet("{PropertyID}")]
        public GetPropertyResponse Get(int PropertyID)
        {
            return _searchManager.GetProperty(PropertyID);
        }

    }
}
