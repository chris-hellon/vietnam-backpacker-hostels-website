namespace VietnamBackpackerHostels.Web.Pages.AboutUs.Community
{
	public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, community, travel community, backpacker community, Vietnam travel, connect with travelers";
        }

        public override string MetaDescription()
        {
            return "Join the Vietnam Backpacker Hostels community and connect with like-minded travelers from around the world. Share your travel experiences, tips, and stories with our friendly community.";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();

            ViewData["Title"] = "Community";

            return Page();
        }
    }
}
