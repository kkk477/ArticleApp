using Dul.Domain.Common;

namespace ArticleApp.Models
{
	/// <summary>
	/// Repository Class
	/// </summary>
	public class ArticleRepository : IArticleRepository
	{
		public Task<Article> AddArticleAsync(Article article)
		{
			throw new NotImplementedException();
		}

		public Task<Article> DeleteArticleAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Article> EditArticleAsync(Article article)
		{
			throw new NotImplementedException();
		}

		public Task<PagingResult<Article>> GetAllAsync(int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task<Article> GetArticleByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Article>> GetArticlesAsync()
		{
			throw new NotImplementedException();
		}
	}
}
