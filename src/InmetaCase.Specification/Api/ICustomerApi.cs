using InmetaCase.Domain.Model;

namespace InmetaCase.Specification.Api;

public interface ICustomerApi : ICrudApi<Customer, Customer, int?, Customer, int>
{
}
