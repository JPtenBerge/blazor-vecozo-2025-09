using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DemoProject.Components.Layout;

public partial class Autocompleter<T> where T : class
{
    public string Query { get; set; }

    [Parameter] public List<T> Data { get; set; }
    [Parameter] public EventCallback<T> OnSelect { get; set; }

    public List<T> Suggestions { get; set; }
    public int? ActiveSuggestionIndex { get; set; }


    public void Autocomplete()
    {
        Suggestions = [];

        foreach (var item in Data)
        {
            // reflection: dynamisch alle props opvragen
            var props = item.GetType().GetProperties().Where(x => x.PropertyType == typeof(string));

            foreach (var prop in props)
            {
                var value = prop.GetValue(item) as string;
                if (value.Contains(Query))
                {
                    Suggestions.Add(item);
                    break;
                }
            }
        }
    }

    public async Task HandleKeyDown(KeyboardEventArgs args)
    {
        if (args.Key == "ArrowDown")
        {
            Next();
        }
        else if (args.Key == "Enter")
        {
            await Select();
        }
    }

    public void Next()
    {
        ActiveSuggestionIndex ??= -1;
        ActiveSuggestionIndex = (ActiveSuggestionIndex + 1) % Suggestions.Count;
    }

    public async Task Select()
    {
        if (ActiveSuggestionIndex is null)
        {
            return;
        }
        var activeSuggestion = Suggestions[ActiveSuggestionIndex.Value];
        await OnSelect.InvokeAsync(activeSuggestion);
    }
}
