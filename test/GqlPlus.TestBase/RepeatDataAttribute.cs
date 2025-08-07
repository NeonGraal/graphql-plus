using System.Reflection;
using AutoFixture.Xunit3;
using AutoFixture.Xunit3.Internal;
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
    : base(TestsCustomizations.CreateFixture())
  {
    if (repeat < 1) {
      throw new ArgumentException("Repeat must be greater than 0.");
    }

    if (TestsCustomizations.IsCi) {
      repeat = CiRepeats;
    }

    Repeat = repeat;
  }

  public int Repeat { get; }

  public override async ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
  {
    List<ITheoryDataRow> data = [];

    if (!TestsCustomizations.IsCi) {
      AutoDataSource source = new(TestsCustomizations.CreateFixture(true));

      ITheoryDataRow row = source.GetData(testMethod)
          .Select(r => new TheoryDataRow(r)).First();
      data.Add(row);
    }

    int repeats = Repeat * testMethod?.GetParameters()?.Length ?? 0;
    for (int i = 1; i <= repeats; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.AddRange(values);
    }

    return data;
  }
}
