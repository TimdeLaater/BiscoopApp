using BioscoopApp___State_Pattern.Interfaces;
namespace BioscoopApp___State_Pattern.Domain.States;
public class NoTicketsLeftState : IState
{
    public NoTicketsLeftState(BioscoopApp.Domain.Order order) { }
    public void CancelOrder()
    {
        Console.WriteLine("No order was placed. Canceling is not possible.");
    }

    public void CompleteOrder()
    {
        Console.WriteLine("No order was placed.");
    }

    public bool HasTicketsLeft()
    {
        Console.WriteLine("No tickets left.");
        return false;
    }

    public void ReminderPayOrder()
    {
        throw new NotImplementedException();
    }

    public void SendTicketsToCustumer()
    {
        throw new NotImplementedException();
    }

    public void StoreOrder()
    {
        throw new NotImplementedException();
    }

    public void SubmitOrder()
    {
        throw new NotImplementedException();
    }

    public void UpdateOrder()
    {
        throw new NotImplementedException();
    }
}

