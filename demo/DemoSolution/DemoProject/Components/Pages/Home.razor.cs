using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Components.Pages;

public partial class Home : ComponentBase
{
    [Inject] public IBurgerRepository BurgerRepository { get; set; } = null!;

    [SupplyParameterFromForm(FormName = "NewBurgerForm")]
    public Burger NewBurger { get; set; } = new();

    public static List<Burger>? Burgers { get; set; }

    protected override async Task OnInitializedAsync()
    {
        NewBurger ??= new();
        Burgers = (await BurgerRepository.GetAllAsync()).ToList();
    }
    public void AddBurger()
    {
        Thread.Sleep(3000);
        Burgers!.Add(NewBurger);

        Console.WriteLine($"adding burger! {NewBurger.Name} krijgt een {NewBurger.Rating}");
    }
}
