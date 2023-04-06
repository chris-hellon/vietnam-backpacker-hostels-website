namespace VietnamBackpackerHostels.Web.Pages.TermsAndConditions
{
	public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, terms and conditions, policies, guidelines, hostel rules, backpacker accommodation";
        }

        public override string MetaDescription()
        {
            return "Find out more about Vietnam Backpacker Hostels' terms and conditions. Read our policies and guidelines to ensure a smooth and enjoyable stay at our hostels.";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();

            ViewData["Title"] = "Terms & Conditions";

            return Page();
        }
    }
}
