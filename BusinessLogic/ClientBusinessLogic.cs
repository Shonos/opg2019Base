using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            OrderFiles(files);
            return files;
        }

        protected virtual void OrderFiles(List<FileModel> files)
        {
            
        }

        protected virtual List<FileModel> GetFiles()
        {
            var files = new List<FileModel>();
            var filesInDirectory = Directory.GetFiles(_clientSettings.Value.FileDirectoryPath);
            foreach(var file in filesInDirectory)
            {
                
                string fileName = GetFileNameFromFileNameWithDirectory(file);
                DateTime fileDate = GetFileDateFromFileName(fileName);

            }

            return files;
        }

        protected string GetFileNameFromFileNameWithDirectory(string fileWithDirectory)
        {
            return fileWithDirectory.Replace(_clientSettings.Value.FileDirectoryPath, "");
        }

        protected DateTime GetFileDateFromFileName(string fileWithDirectory)
        {

        }
    }
}
