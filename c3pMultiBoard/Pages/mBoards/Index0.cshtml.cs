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
    public class Index0Model : PageModel
    {
        private readonly DataModels.dbContext _context;

        public Index0Model(DataModels.dbContext context)
        {
            _context = context;
           
        }

        public IList<mBoard> mBoard { get;set; }

        public async Task OnGetAsync()
        {
            var iBoard = (IQueryable<mBoard>)_context.mBoards.Where(m => m.Category == Category.공지)
                .OrderBy(m => m.Ref).ThenBy(m => m.RefOrder);

            mBoard = await iBoard.ToListAsync();
        }
    }
}
