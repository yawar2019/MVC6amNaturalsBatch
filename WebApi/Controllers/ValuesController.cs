using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
  
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("MyValues")]
        public IEnumerable<string> AllValues()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
///web api

//web api interface through which any type of application either web or mobile application consume data

//web api in mvc provide the information the of restful services

//web api is a restful services

//web api follow MVC Architecture

//Web api follow Rest Principle and Rest full architecture

//Web api

//1)Each an every resource should have unique resource
//2)Each an every service should work on http action verbs
//3)Each and every service should provide data in the the form html, xml and json
//4)No session data should be stored in api

