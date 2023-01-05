using ArticleApp.Models.Articles;
using Dul.Domain.Common;
using Dul.Web;
using Microsoft.AspNetCore.Components;
using System;

namespace ArticleApp.Pages.Articles
{
	public partial class Index
	{
		[Inject]
		NavigationManager NavigationManager { get; set; }
		[Inject]
		public IArticleRepository ArticleRepository { get; set; }
		private void btnTitle_Click(int id)
		{
			NavigationManager.NavigateTo($"/Articles/Details/{id}");
		}
		// 페이저 기본값 설정
		PagerBase pagerBase = new PagerBase()
		{
			PageNumber = 1,
			PageIndex = 0,
			PageSize = 2,
			PageCount = 5,
			PagerButtonCount = 3,
		};

		private List<Article> articles;

		protected override async Task OnInitializedAsync()
		{
			//[1] 전체 데이터 모두 출력
			//articles = await ArticleRepository.GetArticlesAsync();

			//[2] 페이징 처리된 데이터만 출력
			PagingResult<Article> pagingData = await ArticleRepository.GetAllAsync(pagerBase.PageIndex, pagerBase.PageSize);
			pagerBase.RecordCount = pagingData.TotalRecords;    // 총 레코드 수
			articles = pagingData.Records.ToList(); // 페이징 처리된 레코드
		}

		// Pager 버튼 클릭 콜백 메서드
		private async void PageIndexChanged(int PageIndex)
		{
			pagerBase.PageIndex = PageIndex;
			pagerBase.PageNumber = PageIndex + 1;

			var pagingData = await ArticleRepository.GetAllAsync(pagerBase.PageIndex, pagerBase.PageSize);
			pagerBase.RecordCount = pagingData.TotalRecords;    // 총 레코드 수
			articles = pagingData.Records.ToList(); // 페이징 처리된 레코드
			StateHasChanged();  // 현재 컴포넌트 재로드
		}
	}
}
