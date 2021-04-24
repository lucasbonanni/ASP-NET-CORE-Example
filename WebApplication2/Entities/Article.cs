using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
