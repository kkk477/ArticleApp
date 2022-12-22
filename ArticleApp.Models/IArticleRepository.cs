using Dul.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Models
{
	/// <summary>
	/// Repository Interface
	/// </summary>
	public interface IArticleRepository
	{
		Task<Article> AddArticleAsync(Article article);	// 입력
		Task<List<Article>> GetArticlesAsync();         // 출력
		Task<Article> GetArticleByIdAsync(int id);		// 상세
		Task<Article> EditArticleAsync(Article article);// 수정
		Task<Article> DeleteArticleAsync(int id);		// 삭제

		Task<PagingResult<Article>> GetAllAsync(int pageIndex, int pageSize);	// 페이징
	}
}
