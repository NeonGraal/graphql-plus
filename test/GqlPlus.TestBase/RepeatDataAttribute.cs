using System.Reflection;
using AutoFixture;
using AutoFixture.Xunit3;
using AutoFixture.Xunit3.Internal;
using GqlPlus.AutoFixture;
using Xunit;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class RepeatDataAttribute
  : AutoDataAttribute
{
  private static bool IsCi => bool.TryParse(Environment.GetEnvironmentVariable("CI"), out bool isCi) && isCi;

  public RepeatDataAttribute()
    : this(Repeats)
  { }

  public RepeatDataAttribute(int repeat)
    : base(() => new Fixture().Customize(new TestsCustomizations()))
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    if (IsCi) {
      repeat = CiRepeats;
    }

    Repeat = repeat;
  }

  public int Repeat { get; } = 1;

  public override async ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
  {
    List<ITheoryDataRow> data = [];

    if (!IsCi) {
      AutoDataSource source = new(() => {
        IFixture fixture = new Fixture().Customize(new TestsCustomizations());
        fixture.Customizations.Insert(0, new FixedStringSpecimenBuilder());
        return fixture;
      });

      ITheoryDataRow row = source.GetData(testMethod)
          .Select(x => new TheoryDataRow(x))
          .First();
      data.Add(row);
    }

    int repeats = Repeat * testMethod?.GetParameters()?.Length ?? 0;
    for (int i = 0; i < repeats; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.Add(values.First());
    }

    return data;
  }
}
