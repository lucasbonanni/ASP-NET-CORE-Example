using System;
using WebApplication2.Entities;

namespace WebApplication2.Repositories
{
    public interface IArticleRepository
    {
        Guid Create(Article article);

        bool Delete(Guid id);

        bool Update(Guid id, Article article);

        Article Get(Guid id); 
    }
}
