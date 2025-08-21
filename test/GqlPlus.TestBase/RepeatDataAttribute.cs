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
      ParameterInfo[] stringParams = [.. testMethod.ThrowIfNull().GetParameters()
        .Where(p => !p.GetCustomAttributes<RegularExpressionAttribute>(true).Any())
        .Where(p => p.ParameterType == typeof(string) || p.ParameterType == typeof(string[]))];

      if (stringParams.Length == 1) {
        data.Add(RepeatDataAttribute.GetFixedDataRow(testMethod));
      } else if (stringParams.Length > 2) {
        data.AddRange(await GetStringDataRows(stringParams, testMethod, disposalTracker));
      }
    }

    int repeats = Repeat * testMethod?.GetParameters()?.Length ?? 0;
    for (int i = 0; i < repeats; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.Add(values.First());
    }

    return data.AsReadOnly();
  }

  private async Task<IEnumerable<ITheoryDataRow>> GetStringDataRows(ParameterInfo[] stringParams, MethodInfo testMethod, DisposalTracker disposalTracker)
  {
    object?[] row = [];

    List<ITheoryDataRow> dataRows = [];
    for (int i = 0; i < stringParams.Length - 1; i++) {
      for (int j = i + 1; j < stringParams.Length; j++) {
        row = (await base.GetData(testMethod, disposalTracker)).First().GetData();
        SetRowFixed(i);
        SetRowFixed(j);
        dataRows.Add(new TheoryDataRow(row));
      }
    }

    return dataRows;

    void SetRowFixed(int index)
    {
      ParameterInfo param = stringParams[index];
      if (param.ParameterType == typeof(string[])) {
        row[param.Position] = new[] { "AbcdeFghij" };
      } else {
        row[param.Position] = "AbcdeFghij";
      }
    }
  }

  private static TheoryDataRow GetFixedDataRow(MethodInfo testMethod)
  {
    AutoDataSource source = new(() => {
      IFixture fixture = new Fixture().Customize(new TestsCustomizations());
      fixture.Customizations.Insert(0, new FixedStringSpecimenBuilder());
      return fixture;
    });

    return source.GetData(testMethod)
        .Select(x => new TheoryDataRow(x))
        .First();
  }
}
