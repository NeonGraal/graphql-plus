using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;

namespace GqlPlus;


public sealed class OpenTelemetryFixture : IDisposable, IAsyncLifetime
{
  public static readonly ActivitySource ActivitySource = new(TracerName);
  public static Activity? TestRun { get; private set; }
  public static Guid TestRunId { get; } = Guid.NewGuid();

  private const string TracerName = "Xunit.Tests";
  private readonly TracerProvider? _tracerProvider;
  private readonly List<Activity> _activities = [];
  private readonly TestRunSpanProcessor _spanPrcessor;

  public OpenTelemetryFixture()
  {
    _tracerProvider = Sdk.CreateTracerProviderBuilder()
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(TracerName))
        .AddSource(TracerName)
        .AddProcessor(_spanPrcessor = new TestRunSpanProcessor(TestRunId.ToString()))
        .AddInMemoryExporter(_activities)
        .Build();

    TestRun = ActivitySource.StartActivity(ActivityKind.Internal, name: "Xunit.TestRun");
  }

  public void Dispose()
  {
    _spanPrcessor.Dispose();
    _tracerProvider?.Dispose();
    GC.SuppressFinalize(this);
  }

  public ValueTask InitializeAsync() => ValueTask.CompletedTask;

  public ValueTask DisposeAsync()
  {
    string dir = Environment.CurrentDirectory;
    string? outDir = dir;

    string? parent = Path.GetDirectoryName(dir);
    while (!string.IsNullOrWhiteSpace(parent) && parent != dir) {
      dir = parent!;
      parent = Path.GetDirectoryName(dir);
      if (Path.GetFileName(dir) == "bin") {
        outDir = parent;
      }
    }

    //ISerializer serializer = new SerializerBuilder()
    //  .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitDefaults | DefaultValuesHandling.OmitEmptyCollections)
    //  .DisableAliases()
    //  .Build();

    //using StreamWriter writer = File.CreateText(outDir + "/activities.yml");
    //serializer.Serialize(writer, _activities);

    return ValueTask.CompletedTask;
  }
}
