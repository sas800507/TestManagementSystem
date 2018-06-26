using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TMS.Models.Cashed;

namespace TMS.Models.DataModels
{
    public class TestCaseResultModel : BaseModel
    {
        public TestCaseModel TestCase { get; set; }
        public ConstantsTestCaseState TcResult { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string Comment { get; set; }
    }
}