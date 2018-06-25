using System.Web.Mvc;
using System.Web.Routing;
using TMS.Models;
using TMS.Models.WebModel;
using TMS.Services;

namespace TMS.Controllers
{
    [Authorize]
    [Auth(SdRole = Constants.Constants.UserType.User)]
    public class TestCasesController : BaseController
    {
        public ActionResult Index(string parent = "")
        {
            var currentFolder = Repository.GetFolder(parent);
            var model = new TestCaseListModel
            {
                ParentFolder = currentFolder != null ? currentFolder.Parent : null, 
                Folders = Repository.GetFolderList(parent),
                TestCases = Repository.GetTestCases(currentFolder)
            };

            return View(model);
        }

        public ActionResult ViewTc(string testCaseId)
        {
            var tc = Repository.GetTestCase(testCaseId);
            return View(tc);
        }

        public ActionResult Edit(string tcid = null)
        {
            var model = string.IsNullOrEmpty(tcid) ? new TestCaseModel() : Repository.GetTestCase(tcid);
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(TestCaseModel model)
        {
            model = Repository.UpdateTestCase(model);
            return RedirectToAction("ViewTc", new { testCaseId = model.ID });
        }
    }
}