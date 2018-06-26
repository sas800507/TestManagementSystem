using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TMS.Models.DataModels
{
    public class TestCaseModel : FolderedModel
    {
        public string UnicID { get; set; }
        [DisplayName("Наименование")]
        public string Name { get; set;}
        [UIHint("MultyLineText")]
        [AllowHtml]
        [DisplayName("Шаги")]
        public string StepBefore { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        [DisplayName("Ожидается")]
        public string Expected { get; set; }
    }
}