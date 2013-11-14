using System.Web.Mvc;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class GridDemoController : Controller
    {
        public ActionResult Index()
        {
            var o = new GridDemoCfgInput { Groupable = true, Sortable = true, Height = 350, MinHeight = 0, PageSize = 15, ShowGroupedColumn = true };
            return View(o);
        }

        public ActionResult IndexContent(GridDemoCfgInput input)
        {
            return View(input);
        }

        public ActionResult Selection()
        {
            return View();
        }

        public ActionResult RTLSupport()
        {
            return View();
        }

        public ActionResult CustomFormat()
        {
            return View();
        }

        public ActionResult CustomQuerying()
        {
            return View();
        }

        public ActionResult ClientSideApi()
        {
            return View();
        }

        public ActionResult ClientSideApiContent()
        {
            return View();
        }

        public ActionResult Sorting()
        {
            var o = new GridDemoSortingCfgInput {Sortable = true,  PageSize = 15,
                        PersonSortable = true, PersonSort = Sort.Asc, PersonRank = 1,
                        FoodSortable = true, FoodSort = Sort.None, FoodRank = 2,
                    };
            return View(o);
        }

        public ActionResult SortingContent(GridDemoSortingCfgInput input)
        {
            return View(input);
        }

        public ActionResult Grouping()
        {
            var o = new GridDemoGroupingCfgInput { Groupable = true, ShowGroupedColumn = false, ShowGroupBar = true,
                PersonGrouped = true, PersonRem = true, PersonGroupable = true, PersonRank = 1,
                FoodGrouped = false, FoodRem = true, FoodGroupable = true,
                PageSize = 15
                };
            return View(o);
        }

        public ActionResult GroupingContent(GridDemoGroupingCfgInput input)
        {
            return View(input);
        }
    }

    public class GridDemoSortingCfgInput
    {
        public int PageSize { get; set; }

        public bool SingleColumnSort { get; set; }

        public bool FoodSortable { get; set; }

        public bool PersonSortable { get; set; }

        public int PersonRank { get; set; }

        public Sort PersonSort { get; set; }

        public int FoodRank { get; set; }

        public Sort FoodSort { get; set; }

        public bool Sortable { get; set; }
    }

    public class GridDemoGroupingCfgInput
    {
        public bool Groupable { get; set; }

        public bool ShowGroupedColumn { get; set; }

        public bool ShowGroupBar { get; set; }

        public int PageSize { get; set; }

        public bool PersonGrouped { get; set; }

        public bool PersonRem { get; set; }

        public bool PersonGroupable { get; set; }

        public int PersonRank { get; set; }

        public bool FoodGrouped { get; set; }

        public bool FoodRem { get; set; }

        public bool FoodGroupable { get; set; }

        public int FoodRank { get; set; }

        public bool Collapsed { get; set; }
    }

    public class GridDemoCfgInput
    {
        public bool Sortable { get; set; }

        public bool Groupable { get; set; }

        public int Height { get; set; }

        public int PageSize { get; set; }

        public int MinHeight { get; set; }

        public bool SingleColumnSorting { get; set; }

        public bool ShowGroupedColumn { get; set; }
    }

    public class GridDemoSelectionInput
    {
        public int SelectionType { get; set; }
    }
}