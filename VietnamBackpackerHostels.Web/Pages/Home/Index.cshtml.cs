namespace VietnamBackpackerHostels.Web.Pages.Home
{
	public class IndexModel : TravaloudBasePageModel
    {
        [BindProperty]
        public FullImageCarouselComponent CarouselComponent { get; private set; }

        [BindProperty]
        public FullImageCardsComponent ToursCards { get; private set; }

        [BindProperty]
        public GenericCardsComponent PromotedToursCards { get; private set; }

        [BindProperty]
        public FullImageCardsComponent DestinationsCards { get; private set; }

        [BindProperty]
        public CarouselCardsComponent ToursCarousel { get; private set; }

        [BindProperty]
        public CarouselCardsComponent ServicesCarousel { get; private set; }

        public override List<Guid> PromotedToursIds()
        {
            return new List<Guid>() {
                new Guid("CDA60752-3C10-4E5E-9F89-57DCA5DA9020"),
                new Guid("732A1761-4870-4797-92F0-956E53B744C0"),
                new Guid("106E5F27-19A7-46DE-8A7C-D8B1A7BEF3F6"),
                new Guid("7DFDF106-6F6E-4BBF-8DE7-D4B0F8A9B80D"),
                new Guid("DAB38E23-4CD3-4299-86B4-02B3F7440BE7"),
                new Guid("C0DA1FB6-4620-466F-89B0-7AF6E3ED0FD6"),
                new Guid("E07C4685-AB93-4450-8FE2-AEDCAA221F2C"),
                new Guid("9FF6B3B7-839E-40D2-916A-2F60C5728ABD")
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();

            CarouselComponent = new FullImageCarouselComponent(await GetHomePageCarouselImages(), new BookNowComponent(Properties, null, true), true);
            ToursCards = WebComponentsBuilder.UncutTravel.GetToursWithCategoriesFullImageCards(ToursWithCategories, null, null);
            ToursCarousel = WebComponentsBuilder.VietnamBackpackerHostels.GetToursWithCategoriesCarouselCards(PromotedTours);
            DestinationsCards = WebComponentsBuilder.VietnamBackpackerHostels.GetDestinationsCards(Destinations);
            ServicesCarousel = WebComponentsBuilder.VietnamBackpackerHostels.GetServicesCarouselCards(Services);

            return Page();
        }

        public async Task<List<Image>> GetHomePageCarouselImages()
        {
            var images = new List<Image>();

            await Task.Run(() =>
            {
                images = new List<Image>()
                {
                    new Image("https://ik.imagekit.io/rqlzhe7ko/vbh/home-5.webp?tr=w-2000", new Guid("F28C2D2C-1C90-40A5-B13E-31D323C14E1E"), "Page", null, null, null, null, "<div class=\"text-center text-white\"><h1 class=\"display-1 lh-1 m-0 p-0 fs-1 text-white\">Vietnam</h1><h2 class=\"mb-0 mt-n3 fs-4 text-white\">Backpacker Hostels</h2><small class=\"text-end mt-n2 me-1 mb-4 header-font d-block\">est. 2004</small> <h4 class=\"mb-4 text-white\">#MORETHANJUSTABED</h4></div>"),
                    new Image("https://ik.imagekit.io/rqlzhe7ko/vbh/home-8.webp?tr=w-2000", new Guid("F28C2D2C-1C90-40A5-B13E-31D323C14E1E"), "Page", null, null, null, null, "<div class=\"text-center text-white\"><h1 class=\"display-1 lh-1 m-0 p-0 fs-1 text-white\">Vietnam</h1><h2 class=\"mb-0 mt-n3 fs-4 text-white\">Backpacker Hostels</h2><small class=\"text-end mt-n2 me-1 mb-4 header-font d-block\">est. 2004</small> <h4 class=\"mb-4 text-white\">#MORETHANJUSTABED</h4></div>"),
                    new Image("https://ik.imagekit.io/rqlzhe7ko/vbh/hoi-an-banner-3.webp?tr=w-2000", new Guid("F28C2D2C-1C90-40A5-B13E-31D323C14E1E"), "Page", null, null, null, null, "<div class=\"text-center text-white\"><h1 class=\"display-1 lh-1 m-0 p-0 fs-1 text-white\">Vietnam</h1><h2 class=\"mb-0 mt-n3 fs-4 text-white\">Backpacker Hostels</h2><small class=\"text-end mt-n2 me-1 mb-4 header-font d-block\">est. 2004</small> <h4 class=\"mb-4 text-white\">#MORETHANJUSTABED</h4></div>"),
                    //new Image("https://ik.imagekit.io/rqlzhe7ko/vbh/home-3.webp?tr=w-2000", new Guid("F28C2D2C-1C90-40A5-B13E-31D323C14E1E"), "Page", null, null, null, null, "<div class=\"text-center text-white\"><h1 class=\"display-1 lh-1 m-0 p-0 fs-1 text-white\">Vietnam</h1><h2 class=\"mb-0 mt-n3 fs-4 text-white\">Backpacker Hostels</h2><small class=\"text-end mt-n2 me-1 mb-4 header-font d-block\">est. 2004</small> <h4 class=\"mb-4 text-white\">#MORETHANJUSTABED</h4></div>"),
                    new Image("https://ik.imagekit.io/rqlzhe7ko/vbh/hue-banner-2.webp?tr=w-2000", new Guid("F28C2D2C-1C90-40A5-B13E-31D323C14E1E"), "Page", null, null, null, null, "<div class=\"text-center text-white\"><h1 class=\"display-1 lh-1 m-0 p-0 fs-1 text-white\">Vietnam</h1><h2 class=\"mb-0 mt-n3 fs-4 text-white\">Backpacker Hostels</h2><small class=\"text-end mt-n2 me-1 mb-4 header-font d-block\">est. 2004</small> <h4 class=\"mb-4 text-white\">#MORETHANJUSTABED</h4></div>")
                };
            });

            return images;
        }
    }
}
