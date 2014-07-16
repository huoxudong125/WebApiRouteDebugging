using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRouteDebugging.Models
{
    public class Book
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}