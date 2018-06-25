using TMS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using TMS.Models;

namespace TMS.Services.Implements.Repository
{
    public class Repository : IRepository
    {
        private List<UserModel> _userList = new List<UserModel>();
        private List<FolderModel> _folderList = new List<FolderModel>();
        private List<TestCaseModel> _testCases = new List<TestCaseModel>();

        public Repository()
        {
            #region Тестовые пользователи
            _userList.Add(new UserModel() { 
                ID = "1", 
                Email = "admin@site.ru", 
                FirstName = "Admin",
                MiddleName = "Admin",
                LastName = "Admin",
                Login = "admin",
                Password = "admin",
                UserType = Constants.Constants.UserType.Admin
            });
            _userList.Add(new UserModel()
            {
                ID = "2",
                Email = "manager@site.ru",
                FirstName = "manager",
                MiddleName = "manager",
                LastName = "manager",
                Login = "manager",
                Password = "manager",
                UserType = Constants.Constants.UserType.Manager
            });
            _userList.Add(new UserModel()
            {
                ID = "3",
                Email = "user@site.ru",
                FirstName = "user",
                MiddleName = "user",
                LastName = "user",
                Login = "user",
                Password = "user",
                UserType = Constants.Constants.UserType.User
            });
            _userList.Add(new UserModel()
            {
                ID = "4",
                Email = "staff@site.ru",
                FirstName = "staff",
                MiddleName = "staff",
                LastName = "staff",
                Login = "staff",
                Password = "staff",
                UserType = Constants.Constants.UserType.Staff
            });
            #endregion
            #region Тестовые папки
            _folderList.Add(new FolderModel() {
                ID = 1.ToString(),
                Name = "Папка 1",
                Parent = null
            });
            _folderList.Add(new FolderModel()
            {
                ID = 2.ToString(),
                Name = "Папка 2",
                Parent = null
            });
            _folderList.Add(new FolderModel()
            {
                ID = 3.ToString(),
                Name = "Папка 1 - 1",
                Parent = new FolderModel()
                {
                    ID = 1.ToString(),
                    Name = "Папка 1",
                    Parent = null
                }
            });
            _folderList.Add(new FolderModel()
            {
                ID = 4.ToString(),
                Name = "Папка 4",
                Parent = null
            });
            _folderList.Add(new FolderModel()
            {
                ID = 5.ToString(),
                Name = "Папка 5",
                Parent = null
            });
            #endregion

            #region Тест кейсы
            _testCases.Add(new TestCaseModel()
            {
                ID = 1.ToString(),
                Name = "Test case 1",
                UnicID = "TC1",
                Description = "Bla bla bla",
                Expected = "Work",
                StepBefore = "None",
                Folder = _folderList.FirstOrDefault(x => x.Name.Equals("Папка 1"))
            });
            _testCases.Add(new TestCaseModel()
            {
                ID = 2.ToString(),
                Name = "Test case 2",
                UnicID = "TC2",
                Description = "Bla bla bla",
                Expected = "Work",
                StepBefore = "Шаг 1",
                Folder = _folderList.FirstOrDefault(x => x.Name.Equals("Папка 1"))
            });
            #endregion
        }

        public UserModel GetUser(string id)
        {
            return _userList.FirstOrDefault(x => x.ID == id);
        }

        public UserModel GetUser(string login, string password)
        {
            return _userList.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public FolderModel GetFolder(string id)
        {
            return _folderList.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<FolderModel> GetFolderList(string parent)
        {
            if (string.IsNullOrEmpty(parent)) return _folderList.Where(x => x.Parent == null);
            return _folderList.Where(x => x.Parent != null && x.Parent.ID == parent);
        }

        public TestCaseModel GetTestCase(string id)
        {
            return _testCases.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<TestCaseModel> GetTestCases(FolderModel folder = null)
        {
            return _testCases.Where(x => x.Folder == folder);
        }

        public TestCaseModel UpdateTestCase(TestCaseModel testCase)
        {
            var index = _testCases.FindIndex(x => x.ID.Equals(testCase.ID));
            if (index == -1)
            {
                _testCases.Add(testCase);
            }
            else
            {
                _testCases[index] = testCase;
            }

            return testCase;
        }
    }
}