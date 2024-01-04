using System.Diagnostics;
using OpenTelemetry;

namespace GqlPlus.Verifier.TestBase;

public class TestRunSpanProcessor(
  string testRunId
) : BaseProcessor<Activity>
{
  public override void OnStart(Activity data)
    => data?.SetTag("test.run_id", testRunId);
}
