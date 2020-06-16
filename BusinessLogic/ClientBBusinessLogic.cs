using Microsoft.Extensions.Options;
using opg_201910_interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.BusinessLogic
{
    public class ClientBBusinessLogic : ClientBusinessLogic
    {
        public ClientBBusinessLogic(IOptions<ClientSettingsModel> clientSettings) : base(clientSettings)
        {
        }
    }
}
