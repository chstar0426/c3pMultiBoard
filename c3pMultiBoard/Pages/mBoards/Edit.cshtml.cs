using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModels;

namespace c3pMultiBoard.Pages.mBoards
{
    public class EditModel : PageModel
    {
        private readonly DataModels.dbContext _context;

        public EditModel(DataModels.dbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public mBoard mBoard { get; set; }
        public FrmType frmType { get; set; } = FrmType.Modify;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            mBoard = await _context.mBoards.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (mBoard == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mBoardToUpdate = await _context.mBoards.FindAsync(id);

            if (await TryUpdateModelAsync<mBoard>(
                mBoardToUpdate, "mboard", b => b.WriterID, b => b.Name, b => b.Password,
                b => b.Password, b => b.Title, b => b.Content, b => b.Category, b => b.Encoing))
            {

                mBoardToUpdate.ModifyDate = DateTime.Now;
                mBoardToUpdate.PostIp = HttpContext.Connection.RemoteIpAddress.ToString();

                await _context.SaveChangesAsync();
                //return RedirectToPage("./Index");
                return Redirect("../mBoards" + Request.Query["Path"].ToString());

            }

            return Page();
        }

        private bool mBoardExists(int id)
        {
            return _context.mBoards.Any(e => e.ID == id);
        }
    }
}
