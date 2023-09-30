using System.Reflection;
using AutoFixture.Xunit2;

namespace GqlPlus.Verifier.ClassTests;

public class RepeatInlineDataAttribute : InlineAutoDataAttribute
{
  private readonly int _repeat = 1;

  public RepeatInlineDataAttribute(int repeat, params object[] values) : base(values)
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    _repeat = repeat;
  }

  public override IEnumerable<object[]> GetData(MethodInfo testMethod)
  {
    for (var i = 0; i < _repeat; ++i) {
      yield return base.GetData(testMethod).First();
    }
  }
}
