using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebService.Models;

namespace WebService.Controllers
{
    public class DataController : ApiController
    {
        DataItem[] m_items = new DataItem[] {
            new DataItem { Code = 1, Value = "111" },
            new DataItem { Code = 2, Value = "222" },
            new DataItem { Code = 3, Value = "333" }
        };

        public IEnumerable<DataItem> Get()
        {
            return m_items;
        }

        [HttpPost]
        public void Post(Newtonsoft.Json.Linq.JArray a_dataItems)
        {

        }
    }
}
