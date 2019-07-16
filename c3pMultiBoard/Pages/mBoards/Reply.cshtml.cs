using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataModels;
using Microsoft.EntityFrameworkCore;

namespace c3pMultiBoard.Pages.mBoards
{
    public class ReplyModel : PageModel
    {
        private readonly DataModels.dbContext _context;

        public ReplyModel(DataModels.dbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? Id)
        {

            return Page();

        }

        [BindProperty]
        public mBoard mBoard { get; set; }
        public FrmType frmType { get; set; } = FrmType.Reply;

        public async Task<IActionResult> OnPostAsync(int? Id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ParentBoard = _context.mBoards.AsNoTracking().FirstOrDefault(m => m.ID == Id);

            var newBoard = new mBoard();


            //newBoard.Name = "ImsiName";
            //newBoard.WriterID = "ImsiID";
            


            if (await TryUpdateModelAsync<mBoard>(
                newBoard, "mboard", b=>b.WriterID, b=>b.Name, b=>b.Password, 
                b=>b.Password, b=>b.Title, b=>b.Content, b=>b.Category, b=>b.Encoing))
            {

                
                newBoard.PosteDate = DateTime.Now;
                newBoard.PostIp = HttpContext.Connection.RemoteIpAddress.ToString();
                newBoard.ReadCount = 0;
                newBoard.ReplySubCount = 0;
                
                newBoard.Ref = ParentBoard.Ref;
                newBoard.Step = ParentBoard.Step + 1;
                newBoard.RefOrder = ParentBoard.RefOrder + 1;
                newBoard.DelFlag = false;

                _context.mBoards.Add(newBoard);

                var mBoardsToUpdate = _context.mBoards.Where(m => m.Ref == ParentBoard.Ref && m.RefOrder >= newBoard.RefOrder);
                await mBoardsToUpdate.ForEachAsync(m => m.RefOrder = m.RefOrder + 1);


                _context.Attach(ParentBoard).State = EntityState.Modified;

                ParentBoard.ReplySubCount++;

                await _context.SaveChangesAsync();

                var aa = Request.Query["Path"].ToString();
                //return RedirectToPage("./Index");
                return Redirect("../mBoards" + Request.Query["Path"].ToString());

            }

            return Page();
        }
    }
}