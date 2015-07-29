using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IoTRest.Controllers
{
    public interface IFOO
    {
        void foo(string fooed);
    }

    public class FOO : IFOO
    {
        public void foo(string fooed)
        {
            System.Diagnostics.Debug.WriteLine(fooed);
        }
    }

    public class ValuesController : ApiController
    {
        ILog _logger = null;
        IFOO _foo = null;


        //public ValuesController(IFOO foo)
        //{
        //    _foo = foo;
        //}

        //public ValuesController(ILog logger)
        //{
        //    _logger = logger;
        //}

        public async Task<HttpResponseMessage> Post(HttpRequestMessage requestMessage)
        {
            var json = string.Empty;
            JArray events = null;

            try
            {
                json = await requestMessage.Content.ReadAsStringAsync();
                dynamic request = JObject.Parse(json);
                events = (JArray)request.events;

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw;
            }           
        }

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
