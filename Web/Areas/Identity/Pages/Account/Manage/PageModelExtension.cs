using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.Pages.Account.Manage
{
    public static class PageModelExtension
    {
        public static void SetMainNav(this PageModel page, string area = "identity")
        {
            if (page == null) return;
            page.ViewData[nameof(area)] = area;
        }
    }
}
