using InmetaCase.Business.ViewControl;
using Microsoft.AspNetCore.Components;

namespace InmetaCase.Application.WebApp.Pages.Application
{
    public partial class OrderPage
    {
#nullable disable
        [Inject] private OrderViewController ViewController { get; set; }
#nullable enable

        [Parameter] public int Id { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            await ViewController.Load(Id);
        }

    }

}
