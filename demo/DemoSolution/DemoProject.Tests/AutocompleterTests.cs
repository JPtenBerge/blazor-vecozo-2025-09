using Bunit;
using DemoProject.Components.Layout;

namespace DemoProject.Tests;

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
}

[TestClass]
public sealed class AutocompleterTests
{
    IRenderedComponent<Autocompleter<Car>> _fixture = null!;
    Autocompleter<Car> _sut = null!;

    [TestInitialize]
    public void Init()
    {
        var ctx = new Bunit.TestContext();

        //ctx.ComponentFactories
        //ctx.Services.addtra

        _fixture = ctx.RenderComponent<Autocompleter<Car>>(parameters =>
        {
            parameters.Add(x => x.Data, new List<Car>
            {
                new Car { Make = "Fiat", Model = "500e" },
                new Car { Make = "Kia", Model = "Niro" },
                new Car { Make = "Opel", Model = "Astra 2010" },
                new Car { Make = "Opel", Model = "Astra 2015" },
            });
            parameters.Add(x => x.ItemTemplate, item => $"{item.Make} {item.Model}");
        });
        _sut = _fixture.Instance;
    }

    [TestMethod]
    public void Autocomplete_BasicQuery_RendersSuggestions()
    {
        // Act
        _fixture.Find("input").Input("e");
        _fixture.Find("input").KeyUp("e");
        _fixture.Render();

        // Assert
        var lis = _fixture.FindAll("li");
        Assert.AreEqual(3, lis.Count);
    }
}
