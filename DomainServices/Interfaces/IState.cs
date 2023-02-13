namespace DomainServices.Interfaces;

public interface IState<T>
{
    public void PayOrder();
    public bool HasTicketsLeft();
    public void SubmitOrder();
    public void UpdateOrder(T order);
    public void CancelOrder();
    public void ReminderPayOrder();
    public void SendTicketsToCostumer();
    public void SetContext(T context);
}

