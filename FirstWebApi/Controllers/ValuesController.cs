using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> myList = new List<string>()
        {
            "Bilgem",
            "Gülsevinim",
        };

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Degerler()
        {
            return myList;
        }

        // GET api/values/5
        [HttpGet]
        public string DegerGetir(int id)
        {
            return myList[id];
        }

        // POST api/values
        [HttpPost]
        public void DegerEkle([FromBody]string value)
        {
            myList.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public void DegerGuncelle(int id, [FromBody]string value)
        {
            myList[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete]
        public void DegerSil(int id)
        {
            myList.RemoveAt(id);
        }
    }
}
