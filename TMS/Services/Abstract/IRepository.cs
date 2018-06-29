using TMS.Models;
using System.Collections.Generic;
using TMS.Models.Cashed;
using TMS.Models.DataModels;

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
        void DeleteFolder(FolderModel folder);

        TestCaseModel GetTestCase(string id);
        IEnumerable<TestCaseModel> GetTestCases(FolderModel folder = null);
        TestCaseModel UpdateTestCase(TestCaseModel testCase);
        void DeleteTestCase(TestCaseModel testCase);

        TestPlanModel GetTestPlan(string id);
        IEnumerable<TestPlanModel> GetTestPlans(FolderModel folder = null);
        TestPlanModel UpdaTestPlan(TestPlanModel testPlan);
        void DeleteTestPlan(TestPlanModel testPlan); 

        TestCaseResultModel GetTestCaseResult(string id);
        TestCaseResultModel UpdateTestCaseResult(TestCaseResultModel tcResult);
        void DeleteTestResult(TestCaseResultModel tcResult);
    }
}
