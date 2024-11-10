using Microsoft.AspNetCore.Mvc;
using lab99.Models;

namespace lab99.Components
{
    public class ProductTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ComponentModel> data)
        {
            return View(data);
        }
    }
}
