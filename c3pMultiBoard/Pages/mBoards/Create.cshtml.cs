using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataModels;

namespace c3pMultiBoard.Pages.mBoards
{
    public class CreateModel : PageModel
    {
        private readonly DataModels.dbContext _context;

        public CreateModel(DataModels.dbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public mBoard mBoard { get; set; }
        public FrmType frmType { get; set; } = FrmType.Write;

        public async Task<IActionResult> OnPostAsync(object summernote, string aa)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newBoard = new mBoard();


            //newBoard.Name = "ImsiName";
            //newBoard.WriterID = "ImsiID";

            var bb = summernote;

            if (await TryUpdateModelAsync<mBoard>(
                newBoard, "mboard", b=>b.WriterID, b=>b.Name, b=>b.Password, 
                b=>b.Password, b=>b.Title, b=>b.Content, b=>b.Category, b=>b.Encoing))
            {

                
                newBoard.PosteDate = DateTime.Now;
                newBoard.PostIp = HttpContext.Connection.RemoteIpAddress.ToString();
                newBoard.ReadCount = 0;
                newBoard.ReplySubCount = 0;


                _context.mBoards.Add(newBoard);
                await _context.SaveChangesAsync();

                newBoard.Ref = newBoard.ID;
                newBoard.Step = 0;
                newBoard.RefOrder = 0;
                newBoard.DelFlag = false;

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}