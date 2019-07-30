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
        DataContext m_data = new DataContext();

        public IEnumerable<DataItem> Get()
        {
            return m_data.Items;
        }

        [HttpPost]
        public void Post(Newtonsoft.Json.Linq.JArray a_dataItems)
        {

        }
    }
}
