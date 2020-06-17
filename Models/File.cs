using System;

namespace opg_201910_interview.Models
{
    public class FileModel
    {
        public int FileId { get; set; }
        public string FileName {get; set;}
        public string FileExactName { get; set; }
        public DateTime? FileDate { get;set; }
    }
}
