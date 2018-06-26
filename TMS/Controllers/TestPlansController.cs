using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Models;
using TMS.Models.Cashed;
using TMS.Models.DataModels;
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

        public ActionResult EditTcList(string testplanid, string folderId = null)
        {
            var testPlan = Repository.GetTestPlan(testplanid);
            var folder = testPlan.Folder;
            if (!string.IsNullOrEmpty(folderId))
                folder = Repository.GetFolder(folderId);
            var model = new TestPlanEditTestListModel
            {
                TestCasesAll = new TestCaseListModel()
                {
                    Folders = Repository.GetFolderList(folder.ID),
                    ParentFolder = folder,
                    TestCases = Repository.GetTestCases(folder)
                },
                TestCases = testPlan.TestCases.Select(x => x.TestCase),
                TestPlanId = testplanid
            };
            return View(model);
        }

        public ActionResult EditTp(string testplanid)
        {
            var model = Repository.GetTestPlan(testplanid);
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(TestPlanModel model)
        {
            var old = Repository.GetTestPlan(model.ID);
            old.Description = model.Description;
            old.Name = model.Name;
            old.Result = model.Result;
            old.State = CachedConstants.PlanStates.FirstOrDefault(x => x.ID.Equals(model.State.ID));
            Repository.UpdaTestPlan(old);
            return RedirectToAction("ViewTp", new {testplanid = model.ID});
        }

        public ActionResult Play(string testplanid)
        {
            var model = Repository.GetTestPlan(testplanid);
            return View(model);
        }

        public ActionResult ChangeResult(string tpid, string tcresultid, string reultid)
        {
            var tcResult = Repository.GetTestCaseResult(tcresultid);
            tcResult.TcResult = CachedConstants.TestCaseStates.FirstOrDefault(x => x.ID.Equals(reultid));
            Repository.UpdateTestCaseResult(tcResult);
            return RedirectToAction("Play", new { testplanid = tpid });
        }
    }
}