using GymifyManagementSystem.BLL.Dtos.ArticleDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface IArticleManager
    {
        IEnumerable<ArticleReadDto> GetAll();
        ArticleReadDto GetById(int id);
        void Update(ArticleUpdateDto articles);
        void Delete(int id);
        void Insert (ArticleAddDto articles);
    }
}
