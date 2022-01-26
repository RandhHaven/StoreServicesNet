using System;
using System.Collections.Generic;
using System.Text;

namespace StoreServicesNet.Email.Messaging.SendGridLibrary.Models
{
    class SendGridData
    {
        public String SendGridApiKey { get; set; }
        public String DestinyEmail { get; set; }
        public String DestinyName { get; set; }
        public String Tittle { get; set; }
        public String Content { get; set; }
    }
}
