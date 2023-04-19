using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamBackpackerHostels.Web.Pages.Explore
{
	public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, explore Vietnam, backpacker travel, Vietnam tours, adventure travel, backpacker-friendly, Vietnam destinations";
        }

        public override string MetaDescription()
        {
            return "Embark on an adventure of a lifetime with Vietnam Backpacker Hostels. Explore Vietnam's vibrant cities and stunning landscapes with our exciting tours and travel options.";
        }

        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();
            Cards = WebComponentsBuilder.GetToursWithCategoriesPageCategoryComponent(TenantId, ToursWithCategories);

            ViewData["Title"] = "Explore";

            return Page();
        }
    }
}
