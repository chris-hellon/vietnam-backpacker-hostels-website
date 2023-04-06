using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamBackpackerHostels.Web.Pages.AboutUs
{
    public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, about us, backpacker-friendly, Vietnam travel, budget-friendly accommodation, backpacker accommodation";
        }

        public override string MetaDescription()
        {
            return "Learn more about Vietnam Backpacker Hostels and our commitment to providing backpacker-friendly accommodation and travel options in Vietnam.";
        }

        [BindProperty]
        public FullImageCardsComponent DestinationsCards { get; private set; }

        public async Task<IActionResult> OnGet(string serviceName)
        {
            await base.OnGetDataAsync();

            ViewData["Title"] = "About Us";
            DestinationsCards = WebComponentsBuilder.VietnamBackpackerHostels.GetDestinationsCards(Destinations, null);

            return Page();
        }
    }
}
