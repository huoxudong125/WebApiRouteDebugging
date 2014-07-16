using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using WebApiRouteDebugging.Infrastructure;
using WebApiRouteDebugging.Models;
using Bind = System.Web.Mvc.BindAttribute;

namespace WebApiRouteDebugging.Controllers
{
    public class TestParamBindingController : ApiController
    {
        private const string ok = "ok.";

        [HttpGet, HttpPut]
        public string SimpleParams(int id, string name)
        {
            return string.Format("id: {0}; name: {1}", id, name);
        }

        public string ByDefaultMethodSupportsPost()
        {
            return ok;
        }

        [AcceptVerbs(new[] {"get", "post"})]
        public string PassingList(IList<string> list)
        {
            return list.Aggregate((a, b) => string.Format("{0}, {1}", a, b));
        }

        public object ComplexType(Book book, int id = -1, bool anOption = false)
        {
            return new
            {
                id,
                book.Author,
                anOption
            };
        }

        public Author Binding([Bind(Exclude = "Name")] Author author)
        {
            return author;
        }

        public string FromAttr([FromUri] int id, [FromBody] string name)
        {
            return ok;
        }

        [HttpGet]
        [BindJson(typeof(Location), "location")]
        public Location CustomBinder(Location location)
        {
            return location;
        }

        [BindJson(typeof(List<Book>), "authors")]
        public List<Author> CustomBinderWithList(List<Author> authors)
        {
            return authors;
        }

        public object JsonObject(JObject jsonData)
        {
            dynamic jsonObj = jsonData;
            JObject jBook = jsonObj.book;
            JObject jUser = jsonObj.user;
            string token = jsonObj.userToken;

            return new
            {
                book = jBook.ToObject<Book>(),
                user = jUser.ToObject<User>(),
                token
            };
        }

        public HttpResponseMessage ManualParametersParsing(FormDataCollection data)
        {
            Author item = new Author()
            {
                Id = Convert.ToInt32(data.Get("Id")),
                BirthDate = Convert.ToDateTime(data.Get("BirthDate")),
                Name = data.Get("Name"),
            };
            HttpResponseMessage response = Request.CreateResponse<Author>(HttpStatusCode.Created, item);
            //string uri = Url.Link("DefaultApi", new { id = item.Id });
            //response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
