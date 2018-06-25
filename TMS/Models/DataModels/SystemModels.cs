using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class FolderModel : BaseModel
    {
        public string Name { get; set; }
        public FolderModel Parent { get; set; }
    }
}