using InmetaCase.Domain.Model;

namespace InmetaCase.Business
{
    public static class ViewModelExtensionsMethods
    {
        public static string Presentation(this Customer customer) => $"{customer.Id} {customer.FirstName} {customer.LastName}";
        public static string PageUri(this Customer customer) => $"customer/{customer.Id}";
        public static string NewOrderUri(this Customer customer) => $"neworder/{customer.Id}";

        public static string Presentation(this Order order)
        {
            return $"{order.Id} {order.OrderDate} {(ServiceType)order.ServiceType}";
        }

        public static string PageUri(this Order order) => $"order/{order.Id}";
    }
}
