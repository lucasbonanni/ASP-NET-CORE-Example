using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Entities;

namespace WebApplication2.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        IList<Article> articles = new List<Article>()
        {
            new Article()
            {
                Id = Guid.Parse("0831478d-6755-41e0-8352-650ea6930265"),
                Text = "text 1",
                Title = "Title 1"
            },
            new Article()
            {
                Id = Guid.Parse("1131478d-6755-41e0-8352-650ea6930265"),
                Text = "text 1",
                Title = "Title 1"
            },
            new Article()
            {
                Id = Guid.Parse("1231478d-6755-41e0-8352-650ea6930265"),
                Text = "text 1",
                Title = "Title 1"
            },
        };

        public Guid Create(Article article)
        {
            Guid guid = Guid.NewGuid();
            article.Id = guid;
            this.articles.Add(article);
            return guid;
        }

        public bool Delete(Guid id)
        {
            var storedArticle = articles.FirstOrDefault(x => x.Id == id);
            if (storedArticle == null)
                throw new ArgumentException("Not found");
            return articles.Remove(storedArticle);
        }

        public Article Get(Guid id)
        {
            var storedArticle = articles.FirstOrDefault(x => x.Id == id);
            return storedArticle;
        }

        public bool Update(Guid id, Article article)
        {
            var storedArticle = articles.FirstOrDefault(x => x.Id == id);
            if (storedArticle == null)
                throw new ArgumentException("Not found");
            storedArticle.Text = article.Text;
            storedArticle.Title = article.Title;
            return true;
        }
    }
}
