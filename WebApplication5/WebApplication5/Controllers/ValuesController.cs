using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    //get id of now
    public class ValuesController : ApiController
    {
        private TESTAPIEntities db = new TESTAPIEntities();
        // GET api/values
        public IEnumerable<Karyawan> Get()
        {
                return db.Karyawans.ToList();
        }

        // GET api/values/5
        public Karyawan Get(int id)
        {
            var data = db.Karyawans.Where(e => e.kd_nama == id).FirstOrDefault();
            return(data);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            //var updatedata = db.Karyawans.Where(e => e.Nama == value).FirstOrDefault();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
