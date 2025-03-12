using System.Reflection;
using AutoFixture;
using AutoFixture.Xunit3;
using Xunit;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class RepeatInlineDataAttribute
  : InlineAutoDataAttribute
{
  public RepeatInlineDataAttribute(int repeat, params object[] values)
    : this(repeat, () => new Fixture().Customize(new TestsCustomizations()), values)
  {
  }

  public RepeatInlineDataAttribute(params object[] values)
    : this(Repeats, values)
  {
  }

  public RepeatInlineDataAttribute(Func<IFixture> fixtureFactory, params object[] values)
    : this(Repeats, () => fixtureFactory().Customize(new TestsCustomizations()), values)
  {
  }

  public RepeatInlineDataAttribute(int repeat, Func<IFixture> fixtureFactory, params object[] values)
    : base(() => fixtureFactory().Customize(new TestsCustomizations()), values)
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    if (bool.TryParse(Environment.GetEnvironmentVariable("CI"), out bool isCi) && isCi) {
      repeat = CiRepeats;
    }

    Repeat = repeat;
  }

  public int Repeat { get; }

  public override async ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
  {
    List<ITheoryDataRow> data = [];
    for (int i = 0; i < Repeat; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.Add(values.First());
    }

    return data;
  }
}
