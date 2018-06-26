using System.Drawing;

namespace TMS.Models.Cashed
{
    public class ConstantsPlanState : BaseModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Color Color { get; set; }
        public string HtmlColor { get { return ColorTranslator.ToHtml(Color); }}
    }
}