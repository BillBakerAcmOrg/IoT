using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IoTRestAPI.Controllers
{
    public class IoTController : ApiController
    {
        ILog _logger = null;

        public IoTController(ILog logger)
        {
            _logger = logger;
        }

        public async Task<HttpResponseMessage> Post(HttpRequestMessage requestMessage)
        {
            _logger.Debug("what's going on here?");

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
    }
}
