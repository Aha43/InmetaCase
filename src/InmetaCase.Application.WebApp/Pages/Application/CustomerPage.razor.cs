using InmetaCase.Business.ViewControl;
using Microsoft.AspNetCore.Components;

namespace InmetaCase.Application.WebApp.Pages.Application
{
    public partial class CustomerPage
    {
#nullable disable
        [Inject] private CustomerViewControl ViewControl { get; set; }
#nullable enable

        [Parameter] public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await ViewControl.LoadAsync(Id);
        }

    }

}