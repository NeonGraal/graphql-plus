using System.Reflection;
using AutoFixture;
using AutoFixture.Xunit2;

namespace GqlPlus;

public sealed class RepeatDataAttribute
  : AutoDataAttribute
{
  public RepeatDataAttribute(int repeat)
    : base(() => new Fixture().Customize(new TestsCustomizations()))
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    if (bool.TryParse(Environment.GetEnvironmentVariable("CI"), out var isCi) && isCi) {
      repeat = CiRepeats;
    }

    Repeat = repeat;
  }

  public override IEnumerable<object[]> GetData(MethodInfo testMethod)
  {
    for (var i = 0; i < Repeat; ++i) {
      yield return base.GetData(testMethod).First();
    }
  }

  public int Repeat { get; } = 1;
}
