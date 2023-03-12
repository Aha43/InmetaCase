using InmetaCase.Business.ViewControl;
using Microsoft.AspNetCore.Components;

namespace InmetaCase.Application.WebApp.Pages.Application
{
    public partial class NewOrderPage
    {
#nullable disable
        [Inject] private NewOrderViewController ViewControl { get; set; }
#nullable enable

        [Parameter] public int UserId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await ViewControl.Load(UserId);
        }

    }

}