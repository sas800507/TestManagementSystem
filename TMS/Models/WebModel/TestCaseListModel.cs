using System.Collections;
using System.Collections.Generic;
using TMS.Models.DataModels;

namespace TMS.Models.WebModel
{
    public class TestCaseListModel
    {
        public FolderModel CurrentFolder { get; set; }
        public FolderModel ParentFolder { get; set; }
        public IEnumerable<FolderModel> Folders { get; set; }
        public IEnumerable<TestCaseModel> TestCases { get; set; }
    }
}