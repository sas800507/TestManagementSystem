using System.Collections.Generic;
using TMS.Models.DataModels;

namespace TMS.Models.WebModel
{
    public class TestPlanEditTestListModel
    {
        public string TestPlanId { get; set; }
        public TestCaseListModel TestCasesAll { get; set; }
        public IEnumerable<TestCaseModel> TestCases { get; set; }
    }
}