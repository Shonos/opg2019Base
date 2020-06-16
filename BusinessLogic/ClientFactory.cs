using Microsoft.Extensions.Options;
using opg_201910_interview.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.BusinessLogic
{
    public static class ClientFactory
    {
        public static ClientBusinessLogic GetClientBusinessLogic(IOptions<ClientSettingsModel> clientSettings)
        {
            if (clientSettings.Value == null)
            {
                throw new ArgumentNullException("ClientBusinessLogic", "Settings where not properly configured");
            }

            if (!Directory.Exists(clientSettings.Value.FileDirectoryPath))
            {
                throw new ArgumentNullException("ClientBusinessLogic", string.Format("{0} is not a valid file directory", clientSettings.Value.FileDirectoryPath));
            }

            if (clientSettings.Value.FileDirectoryPath.Contains("ClientA", StringComparison.OrdinalIgnoreCase))
            {
                // Client A Instance
                return new ClientABusinessLogic(clientSettings);
            }
            else if (clientSettings.Value.FileDirectoryPath.Contains("ClientA", StringComparison.OrdinalIgnoreCase))
            {
                // Client B Instance
                return new ClientBBusinessLogic(clientSettings);
            }
            else
            {
                // default, not actually required by interview test
                return new ClientBusinessLogic(clientSettings);
            }
        }
    }
}
