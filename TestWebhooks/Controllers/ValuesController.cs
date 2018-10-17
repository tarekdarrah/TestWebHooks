using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace TestWebhooks.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IMemoryCache _cache;
        
        public ValuesController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            string body = "";
            return _cache.Get<string>("IDGKey");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpHead]
        public void Head()
        {
            Ok("Great");
        }
        // POST api/values
        [HttpPost]
        public void Post()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                _cache.Set("IDGKey", body);
            }
            Ok("Great");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
