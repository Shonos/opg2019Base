using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using opg_201910_interview.Models;

namespace opg_201910_interview.BusinessLogic
{
    public class ClientBusinessLogic
    {
        private readonly IOptions<ClientSettingsModel> _clientSettings;
        public ClientBusinessLogic(IOptions<ClientSettingsModel> clientSettings)
        {
            _clientSettings = clientSettings;
        }

        public List<FileModel> EnumerateFiles()
        {
            var files = GetFiles();
            files = OrderFiles(files);
            return files;
        }

        protected virtual List<FileModel> OrderFiles(List<FileModel> files)
        {
            // no implementation on base class
            return files;
        }

        protected List<FileModel> GetFiles()
        {
            var files = new List<FileModel>();
            var filesInDirectory = Directory.GetFiles(_clientSettings.Value.FileDirectoryPath);
            foreach(var file in filesInDirectory)
            {
                
                string fileName = GetFileNameFromFileNameWithDirectory(file);
                string exactFileName = GetExactFileName(fileName);
                DateTime? fileDate = GetFileDateFromFileName(fileName);

                if (!string.IsNullOrEmpty(exactFileName) && fileDate.HasValue) // main way of checking file name validity
                {
                    files.Add(new FileModel
                    {
                        FileName = fileName,
                        FileDate = fileDate,
                        FileExactName = exactFileName
                    });
                }
            }

            return files;
        }

        protected string GetFileNameFromFileNameWithDirectory(string fileWithDirectory)
        {
            return fileWithDirectory.Replace(_clientSettings.Value.FileDirectoryPath +"\\", "");
        }

        protected virtual DateTime? GetFileDateFromFileName(string fileName)
        {
            // base class same logic with client a
            var m = Regex.Match(fileName, @"\b[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])\b");
            if (m.Success)
            {
                DateTime.TryParseExact(m.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parseResult);
                return parseResult != null ? (DateTime?)parseResult : null;
            }
            else
            {
                return null; ;
            }
        }

        protected virtual string GetExactFileName(string fileName)
        {
            // no implementation on base class
            return fileName;
        }
    }
}
