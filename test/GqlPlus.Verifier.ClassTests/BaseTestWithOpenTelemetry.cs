using Xunit.Extensions.AssemblyFixture;

[assembly: TestFramework(AssemblyFixtureFramework.TypeName, AssemblyFixtureFramework.AssemblyName)]

namespace GqlPlus.Verifier;

public class BaseTestWithOpenTelemetry : IAssemblyFixture<OpenTelemetryFixture>
{
}
