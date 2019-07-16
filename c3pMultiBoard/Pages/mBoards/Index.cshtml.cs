using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataModels;

namespace c3pMultiBoard.Pages.mBoards
{
    public class IndexModel : PageModel
    {
        private readonly DataModels.dbContext _context;

        public IndexModel(DataModels.dbContext context)
        {
            _context = context;
           
        }

        public IList<mBoard> mBoard { get;set; }
        public SearchingVar searchingVar { get; set; }

        #region 페이징관련 변수
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        #endregion


        public async Task OnGetAsync(int? Id=0)
        {

            int pageIndex = 0;
            int pageSize = 5;


            ////////////////////////////////////////////////////////////////////////////////////

            string searchField = string.Empty;
            string searchQuery = string.Empty;
            bool searchMode = false;

            if (!String.IsNullOrEmpty(Request.Query["SearchField"]) &&
                 !String.IsNullOrEmpty(Request.Query["SearchQuery"]))
            {
                searchMode = true;
                searchField = Request.Query["SearchField"];
                searchQuery = Request.Query["SearchQuery"];

            }

            searchingVar = new SearchingVar();
            searchingVar.SearchMode = searchMode;
            searchingVar.SearchField = searchField;
            searchingVar.SearchQuery = searchQuery;
            searchingVar.DicField = new Dictionary<string, string>()
            {
                { "Title", "제목" },
                { "Content", "내용" },
                { "Name", "작성자" }
            };

            //////////////////////////////////////////////////////////////////////////////
            //var iBoard = (IQueryable<mBoard>)_context.mBoards.Where(m => ((m.Category == Category.공지 && m.Step < 1) || (m.Ref == Id)))
            //var iBoard = (IQueryable<mBoard>)_context.mBoards.Where(m => ((m.Step < 1) || (m.Ref == Id)));

            var iBoard = (IQueryable<mBoard>)_context.mBoards;


            //한 번 더 생각
            if (searchMode == false)
            {
                iBoard = iBoard.Where(m => ((m.Step < 1) || (m.Ref == Id)));

            }
            
            if (searchMode)
            {
                switch (searchField)
                {
                    case "Title":
                        iBoard = iBoard.Where(s => s.Title.Contains(searchQuery));
                        break;

                    case "Content":
                        iBoard = iBoard.Where(s => s.Content.Contains(searchQuery));
                        break;

                    default:
                        iBoard = iBoard.Where(s => s.Content.Contains(searchQuery));
                        break;
                }

            };

            iBoard =iBoard.OrderByDescending(m => m.Ref).ThenBy(m => m.RefOrder);



            //[1] 쿼리스트링에 따른 페이지 보여주기
            if (!string.IsNullOrEmpty(Request.Query["Page"]))
            {
                // Page는 보여지는 쪽은 1, 2, 3, ... 코드단에서는 0, 1, 2, ...
                pageIndex = Convert.ToInt32(Request.Query["Page"]) - 1;
                //Response.Cookies.Append("Page", pageIndex.ToString());
            }

            TotalCount = iBoard.Count();
            PageIndex = pageIndex + 1;

            mBoard = await iBoard
                .Skip((pageIndex) * pageSize).Take(pageSize).ToListAsync();


        }
    }
}
