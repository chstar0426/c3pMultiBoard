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
    public class DeleteModel : PageModel
    {
        private readonly DataModels.dbContext _context;

        public DeleteModel(DataModels.dbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            mBoard = await _context.mBoards.FindAsync(id);

            if (mBoard != null)
            {
                _context.mBoards.Remove(mBoard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
