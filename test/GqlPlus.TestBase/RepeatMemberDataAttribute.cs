using System.Reflection;
using AutoFixture.Xunit3;
using AutoFixture.Xunit3.Internal;
using GqlPlus.AutoFixture;
using Xunit;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class RepeatMemberDataAttribute
  : MemberAutoDataAttribute
{
  public RepeatMemberDataAttribute(string memberName, params object[] parameters)
    : this(Repeats, memberName, parameters)
  { }

  public RepeatMemberDataAttribute(int repeat, string memberName, params object[] parameters)
    : base(TestsCustomizations.CreateFixture(), null, memberName, parameters)
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
      Type sourceType = testMethod?.DeclaringType ?? throw new InvalidOperationException("Source type cannot be null.");

      MemberDataSource memberSource = new(sourceType, MemberName, Parameters);
      AutoDataSource source = new(TestsCustomizations.CreateFixture(true), memberSource);

      IEnumerable<ITheoryDataRow> row = source.GetData(testMethod)
          .Select(x => new TheoryDataRow(x));
      data.AddRange(row);
    }

    for (int i = 0; i < Repeat; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.AddRange(values);
    }

    return data;
  }
}
