![Daifuku](https://raw.githubusercontent.com/goto10hq/Daifuku/master/daifuku-icon.png)

# Daifuku

[![Software License](https://img.shields.io/badge/license-MIT-brightgreen.svg?style=flat-square)](LICENSE.md)
[![Latest Version on NuGet](https://img.shields.io/nuget/v/Daifuku.svg?style=flat-square)](https://www.nuget.org/packages/Daifuku/)
[![NuGet](https://img.shields.io/nuget/dt/Daifuku.svg?style=flat-square)](https://www.nuget.org/packages/Daifuku/)
[![Visual Studio Team services](https://img.shields.io/vso/build/frohikey/c3964e53-4bf3-417a-a96e-661031ef862f/124.svg?style=flat-square)](https://github.com/goto10hq/Daifuku)

## What Daifuku can do?

### Configure the HTTP request pipeline

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
  // set Server (HTTP hader)
  app.UseServerHeader("Daifuku server");
  // or just remove it completely
  app.UseServerHeader();
  
  // configure domain redirects
  app.UseDomainEnforcement(new System.Collections.Generic.Dictionary<string, string>
  {
      { "daifu.ku", "www.daifu.ku" },
      { "test.azurewebsites.net", "www.daifu.ku" },
  });
}
```

## License

MIT © [frohikey](http://frohikey.com) / [Goto10 s.r.o.](http://www.goto10.cz)
