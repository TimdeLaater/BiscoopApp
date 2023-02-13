namespace DomainServices.Interfaces;

public interface IState<T>
{
    public void PayOrder();
    public bool HasTicketsLeft();
    public void SubmitOrder();
    public void UpdateOrder(T order);
    public void CancelOrder();
    public void ReminderPayOrder();
    public void SendTicketsToCustumer();
    public void SetContext(T context);
}

