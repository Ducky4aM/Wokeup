using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{

    //this is simple class retrurn cases where we only need to indicate success or failure with a message,

    public class ServiceStatusResult
    {
        public bool isSuccess { get; private set; }
        public string? messageText { get; private set; }
        public string? messageTitle { get; private set; }

        private ServiceStatusResult(bool isSuccess, string messageTitle, string messageText)
        {
            this.isSuccess = isSuccess;
            this.messageTitle = messageTitle;
            this.messageText = messageText;
        }

        public static ServiceStatusResult Failure(string messageTile,string message)
        {
            return new ServiceStatusResult(false, messageTile, message);
        }

        public static ServiceStatusResult Failure()
        {
            return new ServiceStatusResult(false, string.Empty, string.Empty);
        }

        public static ServiceStatusResult Success()
        {
            return new ServiceStatusResult(true, string.Empty, string.Empty);
        }

        public static ServiceStatusResult Success(string messageTile, string message)
        {
            return new ServiceStatusResult(true, messageTile, message);
        }
    }
}
