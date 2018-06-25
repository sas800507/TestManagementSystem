using TMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Services.Abstract
{
    public interface IRepository
    {
        UserModel GetUser(string id);
        UserModel GetUser(string login, string password);

        FolderModel GetFolder(string id);
        IEnumerable<FolderModel> GetFolderList(string parent);

        TestCaseModel GetTestCase(string id);
        IEnumerable<TestCaseModel> GetTestCases(FolderModel folder = null);
        TestCaseModel UpdateTestCase(TestCaseModel testCase);
    }
}
