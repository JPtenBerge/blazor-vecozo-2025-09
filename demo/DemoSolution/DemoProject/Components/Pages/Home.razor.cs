using DemoProject.Entities;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Components.Pages;

public partial class Home : ComponentBase
{

    [SupplyParameterFromForm(FormName = "NewBurgerForm")]
    public Burger NewBurger { get; set; } = new();

    public static List<Burger>? Burgers { get; set; } =
    [
        new() { Name = "Quarter Pounder", Price = 6.95M, Rating = 7, PhotoUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.mcdonalds.com.sg%2Fsites%2Fdefault%2Ffiles%2F2023-02%2F1200x1200_MOP_BBPilot_QPC.png&f=1&nofb=1&ipt=bc1adfe0c7808840f3358cc0aa17b29fb942dbb1441d626c763a3c42ce33167b" },
        new() { Name = "Big Mac", Price = 5.50M, Rating = 8, PhotoUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.welt.de%2Fimg%2Fvermischtes%2Fkurioses%2Fmobile146868682%2F0002501437-ci102l-w1024%2FMcDonalds-Big-Mac.jpg&f=1&nofb=1&ipt=e74ef2ce1eedcef5c6267c209999c4aa6163fcdd4ae1520bf60eb2a5f48471d0" },
        new() { Name = "Chili chicken", Price = 3.00M, Rating = 6, PhotoUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmichaeleats.com%2Fwp-content%2Fuploads%2F2024%2F04%2Fscc2.jpg&f=1&nofb=1&ipt=5a21ff8a9ea3c9dd7f28cf9e7d09a6e731e3abacd2ba37e2fd3bc5b5ba199cec" },
        new() { Name = "Filet o fish", Price = 3.00M, Rating = 6, PhotoUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2Foriginals%2F47%2Fda%2F64%2F47da648daed117d814abe05fe622f4a7.jpg&f=1&nofb=1&ipt=f3f2b4fd0f6c7050ccbd413aa07209289d958ce54d3488b6f724c3d7e788987a" },
    ];

    protected override void OnInitialized()
    {
        NewBurger ??= new();

    }

    public void AddBurger()
    {
        Thread.Sleep(3000);
        Burgers!.Add(NewBurger);

        Console.WriteLine($"adding burger! {NewBurger.Name} krijgt een {NewBurger.Rating}");
    }
}
