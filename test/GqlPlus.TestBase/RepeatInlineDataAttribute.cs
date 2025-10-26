using System.Reflection;
using AutoFixture.Xunit3;
using AutoFixture.Xunit3.Internal;
using GqlPlus.AutoFixture;
using Xunit;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class RepeatInlineDataAttribute
  : InlineAutoDataAttribute
{
  public RepeatInlineDataAttribute(params object[] values)
    : this(Repeats, values)
  { }

  public RepeatInlineDataAttribute(int repeat, params object[] values)
    : base(TestsCustomizations.CreateFixture(), values)
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
    if (testMethod.ThrowIfNull().GetParameters().Length <= Values.Length) {
      return await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
    }

    List<ITheoryDataRow> data = [];

    if (!TestsCustomizations.IsCi) {
      AutoDataSource source = new(TestsCustomizations.CreateFixture(true), new InlineDataSource(Values));

      ITheoryDataRow row = source.GetData(testMethod)
          .Select(x => new TheoryDataRow(x))
          .First();
      data.Add(row);
    }

    for (int i = 0; i < Repeat; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.AddRange(values);
    }

    return data;
  }
}
