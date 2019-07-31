using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
using System.Web.Http.Description;
using System.Security.Principal;

using WebService.Models;

namespace WebService.Controllers
{
    public class DataController : ApiController
    {
        DataContext m_data = new DataContext();

        [HttpGet]
        public JArray Get()
        {
            return JArray.FromObject(m_data.Items);
        }

        [HttpGet]
        public JArray Get(String a_filter)
        {
            if(String.IsNullOrEmpty(a_filter))
            {
                return Get();
            }

            return JArray.FromObject(m_data.Items.SqlQuery(String.Format("Select * from DataItems where {0}", a_filter)));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] JArray a_dataItems)
        {
            using (var transaction = m_data.Database.BeginTransaction())
            {
                m_data.Database.ExecuteSqlCommand("TRUNCATE TABLE DataItems");

                foreach (var o in a_dataItems.OrderBy(o => o.Value<int>("Code")))
                {
                    m_data.Items.Add(new DataItem() { Code = o.Value<int>("Code"), Value = o.Value<string>("Value") });
                }

                m_data.SaveChanges();

                transaction.Commit();
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
