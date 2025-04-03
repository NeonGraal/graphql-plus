using System.Reflection;
using AutoFixture;
using AutoFixture.Xunit3;
using GqlPlus.AutoFixture;
using Xunit;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class RepeatDataAttribute
  : AutoDataAttribute
{
  public RepeatDataAttribute()
    : this(Repeats)
  { }

  public RepeatDataAttribute(int repeat)
    : base(() => new Fixture().Customize(new TestsCustomizations()))
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    if (bool.TryParse(Environment.GetEnvironmentVariable("CI"), out bool isCi) && isCi) {
      repeat = CiRepeats;
    }

    Repeat = repeat;
  }

  public int Repeat { get; } = 1;

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
