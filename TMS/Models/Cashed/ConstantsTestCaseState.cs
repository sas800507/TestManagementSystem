using System.Drawing;
using TMS.Models.DataModels;

namespace TMS.Models.Cashed
{
    public class ConstantsTestCaseState : BaseModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Color Color { get; set; }
        public string HtmlColor { get { return ColorTranslator.ToHtml(Color); }}
    }
}