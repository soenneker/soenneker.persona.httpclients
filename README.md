[![](https://img.shields.io/nuget/v/soenneker.persona.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.persona.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.persona.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.persona.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.persona.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.persona.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.persona.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.persona.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Persona.HttpClients

Provides a cached `HttpClient` configured for Persona's identity API, including bearer authentication and API-version pinning.

## Installation

```bash
dotnet add package Soenneker.Persona.HttpClients
```

## Configuration

```json
{
  "Persona": {
    "ApiKey": "your-api-key"
  }
}
```

The provider sends `Persona-Version: 2025-12-08`, matching the newest version in the packaged schema. `Persona:ApiVersion`, `Persona:ClientBaseUrl`, `Persona:AuthHeaderName`, and `Persona:AuthHeaderValueTemplate` can override their defaults.

## Usage

```csharp
using Soenneker.Persona.HttpClients.Abstract;
using Soenneker.Persona.HttpClients.Registrars;

services.AddPersonaOpenApiHttpClientAsSingleton();

IPersonaOpenApiHttpClient provider = serviceProvider
    .GetRequiredService<IPersonaOpenApiHttpClient>();

HttpClient client = await provider.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync("accounts", cancellationToken);
response.EnsureSuccessStatusCode();
```

The provider owns its cached client. Disposing the provider removes and disposes that client. Scoped registration gives each provider instance its own cached client.
