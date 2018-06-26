using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TMS.Models.Cashed;

namespace TMS.Models.DataModels
{
    public class TestPlanModel : FolderedModel
    {
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        [DisplayName("Вывод")]
        public string Result { get; set; }
        [DisplayName("Версия")]
        public string Version { get; set; }
        [DisplayName("Состояние")]
        public ConstantsPlanState State { get; set; }
        [DisplayName("Список тесткейсов")]
        public TestCaseResultModel[] TestCases { get; set; }
    }
}