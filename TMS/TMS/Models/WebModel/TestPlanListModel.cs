using System.Collections.Generic;

namespace TMS.Models.WebModel
{
    public class TestPlanListModel
    {
        public FolderModel ParentFolder { get; set; }
        public IEnumerable<FolderModel> Folders { get; set; }
        public IEnumerable<TestPlanModel> TestPlans { get; set; }
    }
}