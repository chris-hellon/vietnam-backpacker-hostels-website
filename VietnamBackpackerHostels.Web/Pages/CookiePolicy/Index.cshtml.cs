namespace VietnamBackpackerHostels.Web.Pages.CookiePolicy
{
	public class IndexModel : TravaloudBasePageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();

            ViewData["Title"] = "Cookie Policy";

            return Page();
        }
    }
}
