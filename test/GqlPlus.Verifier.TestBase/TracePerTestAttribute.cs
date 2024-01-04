using System.Diagnostics;
using System.Reflection;
using Xunit.Sdk;

namespace GqlPlus.Verifier;

public class TracePerTestAttribute : BeforeAfterTestAttribute
{
  private Activity? _activity;

  public override void Before(MethodInfo methodUnderTest)
  {
    ActivityLink[]? links = OpenTelemetryFixture.TestRun is not null
      ? [new(OpenTelemetryFixture.TestRun.Context, new() {
          ["test.run_id"] = OpenTelemetryFixture.TestRunId
        })]
      : null;
    Map<object?>? tags = new() { ["namespace"] = methodUnderTest.DeclaringType?.Namespace };
    var name = methodUnderTest.DeclaringType?.ExpandTypeName().Suffixed(".") + methodUnderTest.Name;
    _activity = OpenTelemetryFixture.ActivitySource.StartActivity(ActivityKind.Internal, name: name, links: links, tags: tags, parentContext: new ActivityContext());

    base.Before(methodUnderTest);
  }

  public override void After(MethodInfo methodUnderTest)
  {
    _activity?.Stop();

    base.After(methodUnderTest);
  }
}
