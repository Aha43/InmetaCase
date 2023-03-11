using InMetaCase.Domain.Model;

namespace InMetaCase.Specification.Api
{
    public interface ICustomerApi : ICrudApi<Customer, Customer, int?, Customer, int>
    {
    }
}
