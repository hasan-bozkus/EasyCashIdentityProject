using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {
        public int CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public string Description { get; set; }

        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiveAccountNumber { get; set; }
    }
}
