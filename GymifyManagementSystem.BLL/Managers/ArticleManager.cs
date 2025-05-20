using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.ArticleDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public class ArticleManager : IArticleManager
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticleManager(IArticlesRepository articlesRepository) 
        {
            _articlesRepository = articlesRepository;
        }
        public IEnumerable<ArticleReadDto> GetAll()
        {
            var articlesModels = _articlesRepository.GetAll();

            var articlesDtos = articlesModels
                .Select (a => new ArticleReadDto
                {
                    Content = a.Content,
                    Title = a.Title,
                    Id = a.Id,
                    PublishedAt = a.PublishedAt,
                    
            })
                .ToList();
            return articlesDtos;
        }

        public ArticleReadDto GetById(int id)
        {
            var ArticleModel = _articlesRepository.GetById(id);
            var ArticleDto = new ArticleReadDto
            {
                Content = ArticleModel.Content,
                Title = ArticleModel.Title,
                Id = id,
                PublishedAt = ArticleModel.PublishedAt,
            };
            return ArticleDto;
        }

        public void Insert(ArticleAddDto articles)
        {
            var ArticleModel = new articles
            {
                Content = articles.Content,
                Title = articles.Title,
            };
            _articlesRepository.Add(ArticleModel);
        }

        public void Update(ArticleUpdateDto articles)
        {
            var ArticleModel = _articlesRepository.GetById(articles.Id);
            articles.Content = ArticleModel.Content;
            articles.Title = ArticleModel.Title;
        }
        public void Delete(int id)
        {
            var ArticleModel = _articlesRepository.GetById(id);
            _articlesRepository.Delete(ArticleModel);
        }
    }

}
