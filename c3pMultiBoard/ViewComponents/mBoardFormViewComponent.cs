using DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c3pMultiBoard.ViewComponents
{
    public class mBoardFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(mBoardFrm frm)
        {
            return View(frm);

        }
    }
}
