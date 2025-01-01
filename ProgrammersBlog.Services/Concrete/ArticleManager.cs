using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using ProgrammersBlog.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class ArticleManager : ManagerBase, IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} Başlıklı makale başarıyla eklenmiştir.");

        }

        public Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                article.IsDeleted = true;

                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} Başlıklı makale başarıyla silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı.");
        }

        public Task<IResult> DeleteAsync(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ArticleListDto>> GelAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });

                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı.", null);

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategeori bulunamadı.", null);
        }


        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success

                });

            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı.", null);
        }

        public Task<IDataResult<ArticleListDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllAsyncV2(int? categoryId, int? userId, bool? isActive, bool? isDeleted, int currentPage, int pageSize, OrderByGeneral orderBy, bool isAscending, bool includeCategory, bool includeComments, bool includeUser)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, ar => ar.User, ar => ar.Category);
            if (articles.Count() > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User, articles => articles.Category);
            if (articles.Count() > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı.", null);
        }

        public Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy, OrderBy orderBy, bool isAscending, int takeSize, int categoryId, DateTime startAt, DateTime endAt, int minViewCount, int maxViewCount, int minCommentCount, int maxCommentCount)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleDto>> GetAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleDto>> GetByIdAsync(int articleId, bool includeCategory, bool includeComments, bool includeUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale bvaşarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı.");

        }

        public Task<IResult> HardDeleteAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> IncreaseViewCountAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UndoDeleteAsync(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(ArticleAddDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} başlıklı makale başarıyla güncellenmiştir.");
        }

        public Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
