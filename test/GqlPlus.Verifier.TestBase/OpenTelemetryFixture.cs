using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System.Diagnostics;
using Xunit;
using GqlPlus.Verifier.TestBase;
using YamlDotNet.Serialization;

namespace GqlPlus.Verifier;

public class OpenTelemetryFixture : IDisposable, IAsyncLifetime
{
  public static readonly ActivitySource ActivitySource = new(TracerName);
  public static Activity? TestRun;
  public static Guid TestRunId = Guid.NewGuid();

  private const string TracerName = "Xunit.Tests";
  private readonly TracerProvider? _tracerProvider;
  private readonly List<Activity> _activities = [];

  public OpenTelemetryFixture()
  {
    _tracerProvider = Sdk.CreateTracerProviderBuilder()
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(TracerName))
        .AddSource(TracerName)
        .AddProcessor(new TestRunSpanProcessor(TestRunId.ToString()))
        .AddInMemoryExporter(_activities)
        .Build();

    TestRun = ActivitySource.StartActivity(ActivityKind.Internal, name: "Xunit.TestRun");
  }

  public void Dispose()
    => _tracerProvider?.Dispose();

  public Task InitializeAsync() => Task.CompletedTask;

  public Task DisposeAsync()
  {
    var dir = Environment.CurrentDirectory;
    var outDir = dir;

    var parent = Path.GetDirectoryName(dir);
    while (parent is not null && parent != dir) {
      dir = parent;
      parent = Path.GetDirectoryName(dir);
      if (Path.GetFileName(dir) == "bin") {
        outDir = parent;
      }
    }

    var serializer = new SerializerBuilder()
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitDefaults | DefaultValuesHandling.OmitEmptyCollections)
      .DisableAliases()
      .Build();

    using var writer = File.CreateText(outDir + "/activities.yml");
    serializer.Serialize(writer, _activities);

    return Task.CompletedTask;
  }
}
