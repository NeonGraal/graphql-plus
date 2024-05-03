namespace GqlPlus.Result;

[TracePerTest]
public class BaseResultTests
{
  protected const string Sample = "Sample";

  [SuppressMessage("Performance", "CA1819:Properties should not return arrays")]
  protected string[] SampleArray { get; } = [Sample];
}
