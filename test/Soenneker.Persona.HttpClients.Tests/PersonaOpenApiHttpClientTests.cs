using Soenneker.Persona.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Persona.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PersonaOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IPersonaOpenApiHttpClient _httpclient;

    public PersonaOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IPersonaOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
