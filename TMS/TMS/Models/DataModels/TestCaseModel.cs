using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Models
{
    public class TestCaseModel : FolderedModel
    {
        public string UnicID { get; set; }
        public string Name { get; set;}
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string StepBefore { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string Description { get; set; }
        [UIHint("MultyLineText")]
        [AllowHtml]
        public string Expected { get; set; }
    }
}