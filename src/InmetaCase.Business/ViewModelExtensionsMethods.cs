using InmetaCase.Domain.Model;

namespace InmetaCase.Business
{
    public static class ViewModelExtensionsMethods
    {
        public static string PageUri(this Customer customer) => $"customer/{customer.Id}"; 
    }
}
