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

## Coole links

- [Framework benchmark comparison](https://github.com/krausest/js-framework-benchmark)




