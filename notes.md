# Notes

## Paradigmas der webdevelopment

Single Page Application - SPA
- libs/frameworks: React, Blazor, Angular, Vue, Svelte, Solid, Qwik, Lit
- kenmerkt zich geen/heel weinig page refreshes
- server KAN partials renderen, vaak geeft server enkel data terug en doet de browser het renderen
- nadeel: 25 versies voor 1 framework. dependencies 25 versies. security.
- nadeel: traag op mobiel. initieel traag want moet JS opsturen.
- hip

Server-side rendering - SSR
- nadeel van SPA compenseren
- rendert de initiele pagina alvast
- complementair aan de SPA
- na de initiele render is het gewoon weer een SPA
- libs/frameworks: ASP.NET Core  Next.js Nuxt.js @angular/ssr QwikCity SolidStart SvelteKit
- hip
- complexiteit++    `@rendermode`

Static Site Generation - SSG
- productcatalogus   bol.com/product/muis-28483959
- bij de pipeline  .html genereren
- libs/frameworks: Hugo 11ty Astro
- hip

Multi Page Application - MPA
- kenmerkt zich door elk klikje is paginarefresh, elk klikje is de server bij betrokken
  - server moet alle pagina's renderen
  - server slechte dag? dan duurt het even voordat die volgende pagina zichtbaar op scherm is
- libs/frameworks: ASP.NET WebForms/MVC  PHP  Java Spring
- wordt vaak niet als hip ervaren onder junior developers

## Blazor

**De waarom**

- lekker .NET
- developers hoef je niet om te scholen
  - fijn voor de stokoude boomerbackenders
- komt weg bij Microsoft
- nadeel: dingen als Tailwind haakt minder soepel in op het buildproces - pre-build command
- nadeel: HMR/live reload
- namedroppen: Steve Sanderson (maker)    Daniel Roth (programmamanager)

**Edities**

- Blazor Static SSR
  - niet interactief. oldskool MPA
  - vs Razor Pages?
    - Je hebt wel het componentmodel van Blazor (ipv ViewComponents)
    - mocht je ooit wel interactiviteit willen, dan is dat behoorlijk makkelijk geregeld met `@rendermode`
- Blazor WebAssembly  (.wasm)
  - interactief
  - web API: WebAssembly. hoor je niet zelf te schrijven. er zijn een hoop compilers voor.
  - nadeel: WebAssembly is nogal groot  >7MB
    - compressie helpt: gzip .gz / .br Brotli
  - compileert eventjes .NET naar webassembly
  - alle code draait IN DE BROWSER
- Blazor Server
  - interactief
  - alle code draait OP DE SERVER
  - werkt middels SignalR  (wrapper WebSocket)
    - elk klikje is een berichtje over die socket
    - geen server == dode UI
  - Azure SignalR Service  5000 connecties
- met MAUI kun je Blazor Mobile Bindings inzetten

## FluentValidation vs default Data Annotations

- Leest lekker
- Validatie op 1 plek
- testbaarheid
- krachtigere validaties: conditionele validaties, async validatie, items-in-lijst-validatie
  ```cs
  When(x => x.Age > 18, () =>
  {
    RuleFor(x => x...)...;
  });

  RuleForEach(x => x.Products).ChildRules(product =>
  {
    product.RuleFor(x => x.Code).NotEmpty().WithMessage("...");
  });
  ```

## Dependency injection

```cs
.AddSingleton(); // 1 instance to rule them all 
.AddScoped();    // per scope
.AddTransient()  // altijd een nieuwe
```

`AddScoped()` - wat is scoped?

- Blazor Static SSR: per request (HTTP/WebSocket/...)
- Blazor WebAssembly: [singleton](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-9.0#service-lifetime)
- Blazor Server: **per SignalR-circuit**  <== mogelijk veel langer dan normaal.

## Component library integreren

Is meestal deze stappen doorlopen:

0. check license/compatibility (niet alle libraries ondersteunen Static SSR)
1. install package
2. In `App.razor` globale componenten opnemen: `<Theme />`, `<Snackbar />`
3. Dependency injection  `builder.Services.AddRadzenUIControls();` bijv.
4. Styling opnemen in `App.razor`  `<link rel="stylesheet" href="">`
5. `.js`-script opnemen - UI libraries zijn vaak gewoon wrappers om bestaande JS-libs
6. `Imports.razor` uitbreiden met `@using`

Meestal ben je dan good to go!

## Nadelen `HttpClient`

- testbaarheid: geen `Mock<IHttpClient>()`
- GET is dikke prima 👍
- voor POST kun je niet meteen de response typed terugkrijgen:

```cs
var response = await http.PostAsJsonAsync<Burger>("http://...", new Burger());
var responseData = await response.Content.ReadFromJsonAsync<Burger>();
```

Oplossingen/alternatieven:

- Library als [Flurl](https://flurl.dev/) - makkelijker testbaar en wat veelzijdiger
- Wrapper om `HttpClient` schrijven voor makkelijkere operaties: "typed HttpClient"
- Client genereren op basis van OpenAPI
- [Refit](https://github.com/reactiveui/refit)

## CORS

Niet relevant voor ons huidige project, maar wel even benoemen.

- wordt vaak als "gezeur" ervaren
- vaak een een pentestbevinding
- "Cross-origin resource sharing"
- is een security features, volledig afhankelijk van je browser. Een command-line project heeft hier geen last van.

browser van domein A ===> domein B  HTTP-request VANUIT JAVASCRIPT
- POST, PUT, PATCH en DELETE: eerst even een OPTIONS request sturen  ACcess-Control-Allow-Origin header
- GET voert hij WEL meteen uit
  - kijkt in response naar `ACcess-Control-Allow-Origin` header
    - worden die niet meegegeven? dan is de response niet uitleesbaar voor je JS-code

## Minimal API vs controllers?

- Minimal API is minder formele structuur - bedenk je eigen structuur!
- minimal API is performance++ want hij is MINIMAL - er zit minder in
  - geen data annotation-validaties
  - geen controllerfactory
  - geen action filter attributes
- Met typed results haak je nauwer in op OpenAPI-docs
  - Met `[Produces()]` `[Consumes(Result<string>)]` kan een mismatch ontstaan tussen wat je documenteert en wat je echt teruggeeft
- Dependency injection werkt iets anders:
  - controller: bij de constructor declareren. Met 8 methoden in je controller worden er waarschijnlijk dependencies aangemaakt die vervolgens niet gebruikt worden.
  - minimal API: methode zelf, daarmee dan ook veel nauwkeuriger resource-gebruik

## Coole links

- [Framework benchmark comparison](https://github.com/krausest/js-framework-benchmark)
- [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor?tab=readme-ov-file#libraries--extensions), geinig repootje met een hoop handige dingen voor Blazor. Mooi overzichtje component libraries.
- [Rendermodes detecteren in Blazor 8](https://blog.lhotka.net/2024/03/30/Blazor-8-Render-Mode-Detection), Blazor 9+ heeft [`RendererInfo`](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-9.0)





