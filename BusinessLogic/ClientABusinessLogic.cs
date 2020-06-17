using Microsoft.Extensions.Options;
using opg_201910_interview.Models;
using opg_201910_interview.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace opg_201910_interview.BusinessLogic
{
    public class ClientABusinessLogic : ClientBusinessLogic
    {
        

        public ClientABusinessLogic(IOptions<ClientSettingsModel> clientSettings) : base(clientSettings)
        {

        }

        protected override string GetExactFileName(string fileName)
        {
            var r = Regex.Match(fileName, @"(shovel|waghor|blaze|discus)");
            if (r.Success)
            {
                return r.Value;
            }
            return string.Empty;
        }

        protected override List<FileModel> OrderFiles(List<FileModel> files)
        {
            return files.OrderBy(f => f.FileExactName, new ClientAFileNameComparer()).ThenBy(f => f.FileDate).ToList();
        }

        protected override DateTime? GetFileDateFromFileName(string fileName)
        {
            var m = Regex.Match(fileName, @"\b[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])\b");
            if (m.Success)
            {
                DateTime.TryParseExact(m.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parseResult);
                return parseResult != null ? (DateTime?)parseResult : null;
            }
            else
            {
                return null;
            }
        }
    }
}
