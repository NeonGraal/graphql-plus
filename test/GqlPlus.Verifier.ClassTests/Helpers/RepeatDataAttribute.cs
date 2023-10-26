using System.Reflection;
using AutoFixture;
using AutoFixture.Xunit2;

namespace GqlPlus.Verifier.ClassTests;

public class RepeatDataAttribute : AutoDataAttribute
{
  private readonly int _repeat = 1;

  public RepeatDataAttribute(int repeat)
    : base(() => new Fixture().Customize(new TestsCustomizations()))
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    if (bool.TryParse(Environment.GetEnvironmentVariable("CI"), out var isCi) && isCi) {
      repeat = CiRepeats;
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
