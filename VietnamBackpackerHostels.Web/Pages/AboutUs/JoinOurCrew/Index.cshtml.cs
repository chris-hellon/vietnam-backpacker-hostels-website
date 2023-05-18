namespace VietnamBackpackerHostels.Web.Pages.AboutUs.JoinOurCrew
{
    public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, job opportunities, hospitality industry, travel industry, Vietnam jobs, backpacker jobs";
        }

        public override string MetaDescription()
        {
            return "Join the Vietnam Backpacker Hostels crew and become a part of our team. We offer exciting job opportunities in the hospitality and travel industry in Vietnam.";
        }

        [BindProperty]
        public IEnumerable<JobVacancy> JobVacancies { get; set; }

        private readonly IDapperRepository<JobVacancy> _jobVacanciesRepository;

        public IndexModel(IDapperRepository<JobVacancy> jobVacanciesRepository)
        {
            _jobVacanciesRepository = jobVacanciesRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();

            ViewData["Title"] = "Join Our Crew";

            JobVacancies = await _jobVacanciesRepository.GetListAsync("GetJobVacancies", new
            {
                TenantId
            });

            return Page();
        }
    }
}
