using Soenneker.Persona.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Persona.HttpClients.Tests;

[Collection("Collection")]
public sealed class PersonaOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IPersonaOpenApiHttpClient _httpclient;

    public PersonaOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IPersonaOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
