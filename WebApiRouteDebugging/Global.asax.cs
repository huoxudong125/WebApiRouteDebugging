using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;

namespace WebApiRouteDebugging
{
    public class WebApiRouteDebuggingApplication : System.Web.HttpApplication
    {
        private void SerializationConfig()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        protected void Application_Start()
        {
            SerializationConfig();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
