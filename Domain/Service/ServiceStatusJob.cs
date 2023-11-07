using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ServiceStatusJob
    {
        public bool isSuccess { get; private set; }
        public string messageText { get; private set; }
        public string messageTitle { get; private set; }

        public ServiceStatusJob(bool isSuccess, string messageTitle, string messageText)
        {
            this.isSuccess = isSuccess;
            this.messageTitle = messageTitle;
            this.messageText = messageText;
        }

        public ServiceStatusJob(bool isSuccess)
        {
            this.isSuccess = isSuccess;
        }
    }
}
