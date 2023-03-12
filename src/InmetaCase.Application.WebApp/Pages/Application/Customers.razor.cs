using InmetaCase.Business.ViewControl;
using Microsoft.AspNetCore.Components;

namespace InmetaCase.Application.WebApp.Pages.Application;

public partial class Customers
{
#nullable disable
    [Inject] private CustomersViewControl ViewControl { get; set; }
#nullable enable

    protected override async Task OnInitializedAsync()
    {
        await ViewControl.Load();
    }
}