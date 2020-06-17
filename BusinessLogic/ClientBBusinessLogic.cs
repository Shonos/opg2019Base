using Microsoft.Extensions.Options;
using opg_201910_interview.Models;
using opg_201910_interview.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace opg_201910_interview.BusinessLogic
{
    public class ClientBBusinessLogic : ClientBusinessLogic
    {
        public ClientBBusinessLogic(IOptions<ClientSettingsModel> clientSettings) : base(clientSettings)
        {
        }

        protected override string GetExactFileName(string fileName)
        {
            var r = Regex.Match(fileName, @"(orca|widget|eclair|talon)");
            if (r.Success)
            {
                return r.Value;
            }
            return string.Empty; ;
        }

        protected override List<FileModel> OrderFiles(List<FileModel> files)
        {
            return files.OrderBy(f => f.FileExactName, new ClientBFileNameComparer()).ThenBy(f => f.FileDate).ToList();
        }

        protected override DateTime? GetFileDateFromFileName(string fileName)
        {
            var m = Regex.Match(fileName, @"\d+");
            if (m.Success)
            {
                DateTime.TryParseExact(m.Value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parseResult);
                return parseResult != null ? (DateTime?)parseResult : null;
            }
            else
            {
                return null;
            }
        }
    }
}
