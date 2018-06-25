using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TMS.Models.DataModels
{
    public class TestCaseResultModel : BaseModel
    {
        public TestCaseModel TestCase { get; set; }
        public string ResultId { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string Comment { get; set; }
    }
}