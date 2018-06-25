using System.Web.Mvc;
using TMS.Models.WebModel;

namespace TMS.Controllers
{
    public class TestPlansController : BaseController
    {
        public ActionResult Index(string parent = "")
        {
            var currentFolder = Repository.GetFolder(parent);
            var model = new TestPlanListModel
            {
                ParentFolder = currentFolder != null ? currentFolder.Parent : null, 
                Folders = Repository.GetFolderList(parent),
                TestPlans = Repository.GetTestPlans(currentFolder)
            };

            return View(model);
        }

        public ActionResult ViewTp(string testplanid)
        {
            var model = Repository.GetTestPlan(testplanid);
            return View(model);
        }
    }
}