using System;

namespace TMS.Models.DataModels
{
    public class BaseModel : ICloneable
    {
        public string ID { get; set; }
        
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class FolderedModel : BaseModel
    {
        public FolderModel Folder { get; set; }
    }
}