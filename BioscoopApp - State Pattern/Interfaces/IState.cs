using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopApp___State_Pattern.Interfaces
{
    public interface IState
    {
        public bool HasTicketsLeft();
        public void SubmitOrder();
        public void StoreOrder();
        public void UpdateOrder();
        public void CancelOrder();
        public void ReminderPayOrder();
        public void SendTicketsToCustumer();
        public void CompleteOrder();
    }
}
