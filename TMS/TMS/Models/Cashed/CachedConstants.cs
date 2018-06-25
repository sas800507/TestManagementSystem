using System.Collections.Generic;
using TMS.Services.Implements.Repository;

namespace TMS.Models.Cashed
{
    public static class CachedConstants
    {
        private static IEnumerable<ConstantsPlanState> _planStates;
        private static IEnumerable<ConstantsTestCaseState> _testCaseStates;
        private static Repository _repository;
        private static Repository Repository {
            get { return _repository ?? (_repository = new Repository()); }
        }

        public static IEnumerable<ConstantsPlanState> PlanStates
        {
            get
            {
                if (_planStates != null) return _planStates;
                _planStates = new List<ConstantsPlanState>();
                _planStates = Repository.PlanStates();

                return _planStates;
            }
        }

        public static IEnumerable<ConstantsTestCaseState> TestCaseStates
        {
            get
            {
                if (_testCaseStates != null) return _testCaseStates;
                _testCaseStates = new List<ConstantsTestCaseState>();
                _testCaseStates = Repository.TestCaseStates();

                return _testCaseStates;
            }
        }

        public static void Clear()
        {
            _repository = null;
            _testCaseStates = null;
            _planStates = null;
        }
    }
}