using TMS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Web;
using TMS.Models;
using TMS.Models.Cashed;
using TMS.Models.DataModels;

namespace TMS.Services.Implements.Repository
{
    public class Repository : IRepository
    {
        private List<UserModel> _userList = new List<UserModel>();
        private List<FolderModel> _folderList = new List<FolderModel>();
        private List<TestCaseModel> _testCases = new List<TestCaseModel>();
        private List<TestPlanModel> _testPlans = new List<TestPlanModel>();
        private List<TestCaseResultModel> _testCaseResult = new List<TestCaseResultModel>();

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

            #region TestCaseResult
            _testCaseResult.Add(new TestCaseResultModel()
            {
                ID = 1.ToString(),
                TcResult = CachedConstants.TestCaseStates.FirstOrDefault(x => x.ID.Equals("2")),
                TestCase = _testCases.FirstOrDefault(x => x.ID.Equals("1"))
            });
            _testCaseResult.Add(new TestCaseResultModel()
            {
                ID = 2.ToString(),
                TcResult = CachedConstants.TestCaseStates.FirstOrDefault(x => x.ID.Equals("4")),
                TestCase = _testCases.FirstOrDefault(x => x.ID.Equals("2"))
            });
            _testCaseResult.Add(new TestCaseResultModel()
            {
                ID = 3.ToString(),
                TcResult = CachedConstants.TestCaseStates.FirstOrDefault(x => x.ID.Equals("1")),
                TestCase = _testCases.FirstOrDefault(x => x.ID.Equals("1"))
            });
            _testCaseResult.Add(new TestCaseResultModel()
            {
                ID = 4.ToString(),
                TcResult = CachedConstants.TestCaseStates.FirstOrDefault(x => x.ID.Equals("3")),
                TestCase = _testCases.FirstOrDefault(x => x.ID.Equals("2"))
            });
            #endregion

            #region TestPlans
            _testPlans.Add(new TestPlanModel()
            {
                ID = 1.ToString(),
                Description = "First test plan",
                Folder = _folderList.FirstOrDefault(x => x.Name.Equals("Папка 1")),
                Name = "First plan",
                Result = "Not run yet",
                Version = "release_7",
                State = CachedConstants.PlanStates.FirstOrDefault(x => x.ID.Equals("2")),
                TestCases = new []
                { 
                    _testCaseResult.FirstOrDefault(x => x.ID.Equals("1")),
                    _testCaseResult.FirstOrDefault(x => x.ID.Equals("2")),
                }
            });
            _testPlans.Add(new TestPlanModel()
            {
                ID = 2.ToString(),
                Description = "Second test plan",
                Folder = _folderList.FirstOrDefault(x => x.Name.Equals("Папка 2")),
                Name = "Second plan",
                Result = "Not run yet",
                Version = "release_7",
                State = CachedConstants.PlanStates.FirstOrDefault(x => x.ID.Equals("1")),
                TestCases = new []
                { 
                    _testCaseResult.FirstOrDefault(x => x.ID.Equals("3")),
                    _testCaseResult.FirstOrDefault(x => x.ID.Equals("4")),
                }
            });

            #endregion
        }

        public IEnumerable<ConstantsPlanState> PlanStates()
        {
            return new[]
            {
                new ConstantsPlanState(){ ID = 1.ToString(), Name = "Новый", Color = Color.Red, Icon = "fa fa-plus-circle"},
                new ConstantsPlanState(){ ID = 2.ToString(), Name = "В работе", Color = Color.Green, Icon = "fa fa-gear"},
                new ConstantsPlanState(){ ID = 3.ToString(), Name = "Завершён", Color = Color.DarkGray, Icon = "fa fa-check"},
            };
        }

        public IEnumerable<ConstantsTestCaseState> TestCaseStates()
        {
            return new[]
            {
                new ConstantsTestCaseState() { ID = 1.ToString(), Name = "Не выполнялся", Color = Color.DarkGray, Icon = "fa fa-gear"}, 
                new ConstantsTestCaseState() { ID = 2.ToString(), Name = "Успешно", Color = Color.Green, Icon = "fa fa-check"}, 
                new ConstantsTestCaseState() { ID = 3.ToString(), Name = "Провален", Color = Color.Red, Icon = "fa fa-close"}, 
                new ConstantsTestCaseState() { ID = 4.ToString(), Name = "Игнорирован", Color = Color.Orange, Icon = "fa fa-eye-slash"}, 
            };
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

        public TestPlanModel GetTestPlan(string id)
        {
            var result = _testPlans.FirstOrDefault(x => x.ID == id);
            var updResults = result.TestCases.Select(x => GetTestCaseResult(x.ID));
            result.TestCases = updResults.ToArray();
            return result;
        }

        public IEnumerable<TestPlanModel> GetTestPlans(FolderModel folder = null)
        {
            return _testPlans.Where(x => x.Folder == folder);
        }

        public TestPlanModel UpdaTestPlan(TestPlanModel testPlan)
        {
            var index = _testPlans.FindIndex(x => x.ID.Equals(testPlan.ID));
            if (index == -1)
            {
                _testPlans.Add(testPlan);
            }
            else
            {
                _testPlans[index] = testPlan;
            }

            return testPlan;
        }

        public TestCaseResultModel GetTestCaseResult(string id)
        {
            var result = _testCaseResult.FirstOrDefault(x => x.ID.Equals(id));
            result.TestCase = _testCases.FirstOrDefault(x => x.ID.Equals(result.TestCase.ID));
            return result;
        }

        public TestCaseResultModel UpdateTestCaseResult(TestCaseResultModel tcResult)
        {
            var index = _testCaseResult.FindIndex(x => x.ID.Equals(tcResult.ID));
            if (index == -1)
            {
                _testCaseResult.Add(tcResult);
            }
            else
            {
                _testCaseResult[index] = tcResult;
            }

            return tcResult;
        }
    }
}