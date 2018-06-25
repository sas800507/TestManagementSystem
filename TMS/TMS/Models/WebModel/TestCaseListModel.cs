using System.Collections;
using System.Collections.Generic;

namespace TMS.Models.WebModel
{
    public class TestCaseListModel
    {
        public FolderModel ParentFolder { get; set; }
        public IEnumerable<FolderModel> Folders { get; set; }
        public IEnumerable<TestCaseModel> TestCases { get; set; }
    }
}