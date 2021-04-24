using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using WebApplication2.Entities;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository repository;

        public ArticlesController(IArticleRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<Article> Get(Guid id)
        {
            Article article = this.repository.Get(id);
            if (article == null)
            {
                var content = Content("Item not found", "application/json");
                content.StatusCode = StatusCode(404).StatusCode;
                return NotFound(content);
            }
            return Ok(article);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Article article)
        {
            Guid id = repository.Create(article);
            this.HttpContext.Response.Headers["Location"] = "api/articles/" + id;
            return Content("created");
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] Article article)
        {
            try
            {
                bool result = this.repository.Update(id, article);

            }
            catch (ArgumentException ex)
            {
                var content = Content("Not found", "application/json");
                return NotFound(content);
            }
            this.HttpContext.Response.Headers["Location"] = "api/articles/" + id;
           return Content("created");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                repository.Delete(id);
                
            }
            catch (ArgumentException ex)
            {
                var content = Content("Not found", "application/json");
                return NotFound(content);
            }
            return Ok("Deleted");
        }
    }
}
