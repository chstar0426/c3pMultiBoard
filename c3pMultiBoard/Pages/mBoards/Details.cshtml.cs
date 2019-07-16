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
    public class DetailsModel : PageModel
    {
        private readonly DataModels.dbContext _context;

        public DetailsModel(DataModels.dbContext context)
        {
            _context = context;
        }

        public mBoard mBoard { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            mBoard = await _context.mBoards.FirstOrDefaultAsync(m => m.ID == id);

            if (mBoard == null)
            {
                return NotFound();
            }

            mBoard.ReadCount++;
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
