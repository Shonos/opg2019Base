using System;
using System.Collections.Generic;

namespace opg_201910_interview.Models
{
    public class HomeViewModel
    {
        public List<FileModel> FilesForEnumeration { get; set; }
        public string FilesForEnumerationAsJson
        { 
            get
            {
                if (FilesForEnumeration != null)
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(FilesForEnumeration);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
