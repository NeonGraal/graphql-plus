using System.Diagnostics;
using System.Reflection;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class TracePerTestAttribute
  : BeforeAfterTestAttribute
{
  private Activity? _activity;

  public override void Before(MethodInfo methodUnderTest)
  {
    ArgumentNullException.ThrowIfNull(methodUnderTest);

    ActivityLink[]? links = OpenTelemetryFixture.TestRun is not null
      ? [new(OpenTelemetryFixture.TestRun.Context, new() {
        ["test.run_id"] = OpenTelemetryFixture.TestRunId
      })]
      : null;

    string? testClass = methodUnderTest.ReflectedType?.ExpandTypeName();
    string? testNamespace = methodUnderTest.ReflectedType?.Namespace;
    string testMethod = methodUnderTest.Name;

    Map<object?>? tags = new() {
      ["namespace"] = testNamespace,
      ["class"] = testClass,
      ["method"] = testMethod,
    };

    if (methodUnderTest.DeclaringType != methodUnderTest.ReflectedType) {
      tags["declared-in"] = methodUnderTest.DeclaringType?.FullTypeName(testNamespace);
    }

    _activity = OpenTelemetryFixture.ActivitySource.StartActivity(
      ActivityKind.Internal,
      name: testClass.Suffixed(".") + testMethod,
      links: links,
      tags: tags,
      parentContext: new ActivityContext());

    base.Before(methodUnderTest);
  }

  public override void After(MethodInfo methodUnderTest)
  {
    _activity?.Stop();

    base.After(methodUnderTest);
  }
}
