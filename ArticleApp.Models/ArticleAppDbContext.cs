using ArticleApp.Models.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Models
{
    public class ArticleAppDbContext : DbContext
	{
		protected ArticleAppDbContext()
		{
		}

		public ArticleAppDbContext(DbContextOptions<ArticleAppDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// App.config 또는 Web.config의 연결 문자열 사용
			if (!optionsBuilder.IsConfigured)
			{
				string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
				optionsBuilder.UseSqlServer(connectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Articles 테이블의 Created 열은 자동으로 GetDate() 제약 조건을 부여하기
			modelBuilder.Entity<Article>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
		}

		// ArticleApp 관련 모든 테이블 참조
		public DbSet<Article> Articles { get; set; }
	}
}
