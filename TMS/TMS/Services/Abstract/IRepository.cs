using TMS.Models;
using System.Collections.Generic;
using TMS.Models.Cashed;

namespace TMS.Services.Abstract
{
    public interface IRepository
    {
        IEnumerable<ConstantsPlanState> PlanStates();
        IEnumerable<ConstantsTestCaseState> TestCaseStates();

        UserModel GetUser(string id);
        UserModel GetUser(string login, string password);

        FolderModel GetFolder(string id);
        IEnumerable<FolderModel> GetFolderList(string parent);

        TestCaseModel GetTestCase(string id);
        IEnumerable<TestCaseModel> GetTestCases(FolderModel folder = null);
        TestCaseModel UpdateTestCase(TestCaseModel testCase);

        TestPlanModel GetTestPlan(string id);
        IEnumerable<TestPlanModel> GetTestPlans(FolderModel folder = null);
        TestPlanModel UpdaTestPlan(TestPlanModel testPlan);
    }
}
