using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class BaseModel
    {
        public string ID { get; set; }
    }

    public class FolderedModel : BaseModel
    {
        public FolderModel Folder { get; set; }
    }
}