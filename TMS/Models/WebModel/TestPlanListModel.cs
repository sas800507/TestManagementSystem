using System.Collections.Generic;
using TMS.Models.DataModels;

namespace TMS.Models.WebModel
{
    public class TestPlanListModel
    {
        public FolderModel CurrentFolder { get; set; }
        public FolderModel ParentFolder { get; set; }
        public IEnumerable<FolderModel> Folders { get; set; }
        public IEnumerable<TestPlanModel> TestPlans { get; set; }
    }
}