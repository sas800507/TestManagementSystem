using System.Web.Mvc;
using System.Web.Routing;
using TMS.Models;
using TMS.Models.DataModels;
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
                CurrentFolder = currentFolder,
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

        public ActionResult Edit(string tcid = null, string folderId = null)
        {
            var model = string.IsNullOrEmpty(tcid) ? new TestCaseModel(){Folder = new FolderModel(){ID = folderId}} : Repository.GetTestCase(tcid);
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(TestCaseModel model)
        {
            var old = Repository.GetTestCase(model.ID);
            model.Folder = Repository.GetFolder(model.Folder.ID);
            model = Repository.UpdateTestCase(model);
            Repository.UpdateTestCase(model);
            return RedirectToAction("ViewTc", new { testCaseId = model.ID });
        }

        public ActionResult Delete(string tcid)
        {
            var tc = Repository.GetTestCase(tcid);
            if (tc == null)
                return RedirectToAction("Index");
            
            Repository.DeleteTestCase(tc);
            return RedirectToAction("Index", new { parent = tc.Folder.ID });
        }

        public ActionResult Copy(string tcid)
        {
            var tc = Repository.GetTestCase(tcid).Clone() as TestCaseModel;
            tc.ID = string.Empty;
            tc.Name = string.Format("{0} - Copy", tc.Name);
            tc = Repository.UpdateTestCase(tc);
            return RedirectToAction("ViewTc", new { testCaseId = tc.ID });
        }
    }
}