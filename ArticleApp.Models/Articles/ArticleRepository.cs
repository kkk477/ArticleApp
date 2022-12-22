﻿using Dul.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Models.Articles
{
    /// <summary>
    /// Repository Class
    /// </summary>
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleAppDbContext _context;
        public ArticleRepository(ArticleAppDbContext context)
        {
            this._context= context;
        }

        // 입력
        public async Task<Article> AddArticleAsync(Article model)
        {
            _context.Articles.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

		public async Task<Article> GetArticleByIdAsync(int id)
		{
            //return await _context.Articles.Where(m => m.Id == id).SingleOrDefaultAsync();
            return await _context.Articles.FindAsync(id);
		}

		public async Task DeleteArticleAsync(int id)
		{
            var model = await _context.Articles.FindAsync(id);
            if (model != null)
            {
                _context.Articles.Remove(model);
                await _context.SaveChangesAsync();
            }
		}

		public async Task<Article> EditArticleAsync(Article model)
		{
			_context.Entry(model).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
		}

		public async Task<List<Article>> GetArticlesAsync()
		{
			return await _context.Articles.OrderByDescending(m => m.Id).ToListAsync();
		}

		// 페이징
		public async Task<PagingResult<Article>> GetAllAsync(int pageIndex, int pageSize)
        {
            var totalRecords = await _context.Articles.CountAsync();
            var articles = await _context.Articles.OrderByDescending(m => m.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            return new PagingResult<Article>(articles, totalRecords);
        }


    }
}
