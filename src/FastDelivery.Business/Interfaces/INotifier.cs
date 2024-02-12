namespace FastDelivery.Business
{
    public interface INotifier
    {
        bool HasNotification();
        IEnumerable<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
