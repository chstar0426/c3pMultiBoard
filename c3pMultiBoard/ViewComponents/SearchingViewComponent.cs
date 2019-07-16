using DataModels;
using Microsoft.AspNetCore.Mvc;

namespace c3pMultiBoard.ViewComponents
{
    public class SearchingViewComponent : ViewComponent
    {
       
        public  IViewComponentResult Invoke(SearchingVar searchingVar)
        {
            return View(searchingVar);
        }

    }
}
