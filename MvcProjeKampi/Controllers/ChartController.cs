using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MvcProjeKampi.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryPieChart()
        {
            return View();
        }
        public ActionResult HeadingPieChart()
        {
            return View();
        }
        public ActionResult WriterColumnChart()
        {
            return View();
        }
        public ActionResult TalentLineChart()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }
        public List<HeadingChart> HeadingList()
        {
            List<HeadingChart> headingCharts = new List<HeadingChart>();
            using (var context = new Context())
            {
                headingCharts = context.Headings.Select(c => new HeadingChart
                {
                    HeadingName = c.HeadingName,
                    ContentCount = c.Contents.Count()
                }).ToList();
            }

            return headingCharts;
        }
        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }

    }
}