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
    public class searchController : ControllerBase
    {
        private ISearchManager _searchManager;

        public searchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        [HttpPost]
        public SmartSearchResponse Get(SmartSearchRequest searchRequest)
        {
            return _searchManager.Search(searchRequest);
        }

    }
}
