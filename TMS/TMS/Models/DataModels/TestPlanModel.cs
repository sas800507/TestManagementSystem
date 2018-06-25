using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TMS.Models.DataModels;

namespace TMS.Models
{
    public class TestPlanModel : FolderedModel
    {
        public string Name { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string Description { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string Result { get; set; }
        public string Version { get; set; }
        public string State { get; set; }
        public TestCaseResultModel[] TestCases { get; set; }
    }
}