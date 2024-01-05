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

    var testClass = methodUnderTest.ReflectedType?.ExpandTypeName();
    var testNamespace = methodUnderTest.ReflectedType?.Namespace;
    var testMethod = methodUnderTest.Name;

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
