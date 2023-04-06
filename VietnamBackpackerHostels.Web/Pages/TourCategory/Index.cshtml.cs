using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamBackpackerHostels.Web.Pages.TourCategory
{
    public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            if (TourCategory == null && !string.IsNullOrEmpty(TourCategory.MetaKeywords))
                return "budget hostels, cheap hostels, backpackers hostels, Vietnam travel";

            return TourCategory.MetaKeywords;
        }

        public override string MetaDescription()
        {
            if (TourCategory == null && !string.IsNullOrEmpty(TourCategory.MetaDescription))
                return "Our budget hostels in Vietnam offer comfortable and affordable accommodation for backpackers and budget travelers. Book now and start your Vietnam adventure!";

            return TourCategory.MetaDescription;
        }

        public override string MetaImageUrl()
        {
            if (TourCategory == null && !string.IsNullOrEmpty(TourCategory.ImagePath))
                return base.MetaImageUrl();

            return TourCategory.ImagePath;
        }

        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        [BindProperty]
        public TourWithCategory TourCategory { get; private set; }

        public async Task<IActionResult> OnGetAsync(string tourCategoryName = null)
        {
            await OnGetDataAsync();

            TourCategory = tourCategoryName != null ? ToursWithCategories.FirstOrDefault(x => x.FriendlyUrl == tourCategoryName && !x.CategoryId.HasValue) : null;
            var toursWithCategories = ToursWithCategories.ToList();

            var pageSortings = PageSortings.Where(x => x.ParentTourCategoryId == TourCategory.Id);

            if (pageSortings.Any())
            {
                toursWithCategories = toursWithCategories.Select(x =>
                {
                    if (pageSortings.Any(ps => ps.TourCategoryId == x.Id))
                    {
                        x.SortOrder = pageSortings.First(ps => ps.TourCategoryId == x.Id).SortOrder;
                    }
                    else if (pageSortings.Any(ps => ps.TourId == x.Id))
                    {
                        x.SortOrder = pageSortings.First(ps => ps.TourId == x.Id).SortOrder;
                    }

                    return x;
                }).OrderBy(x => x.SortOrder).ToList();
            }

            Cards = WebComponentsBuilder.VietnamBackpackerHostels.GetToursWithCategoriesPageCategoryComponent(toursWithCategories, TourCategory);

            if (TourCategory != null)
            {
                ViewData["Title"] = TourCategory.Name;
                ViewData["TourInfo"] = TourCategory.Description;
                ViewData["SubTitle"] = "Explore";
            }
            else
                ViewData["Title"] = "Explore";

            return Page();
        }
    }
}
