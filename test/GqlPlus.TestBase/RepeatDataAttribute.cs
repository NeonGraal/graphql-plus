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
      ParameterInfo[] stringParams = [.. testMethod.ThrowIfNull().GetParameters()
        .Where(p => !p.GetCustomAttributes<RegularExpressionAttribute>(true).Any())
        .Where(p => p.ParameterType == typeof(string) || p.ParameterType == typeof(string[]))];

      if (stringParams.Length == 1) {
        data.Add(RepeatDataAttribute.GetFixedDataRow(testMethod));
      } else if (stringParams.Length > 2) {
        data.AddRange(await GetStringDataRows(stringParams, testMethod, disposalTracker));
      }

      ParameterInfo[] boolParams = [.. testMethod.ThrowIfNull().GetParameters()
        .Where(p => p.ParameterType == typeof(bool))];

      if (boolParams.Length > 1) {
        data.AddRange(await GetBoolDataRows(boolParams, testMethod, disposalTracker));
      }
    }

    int repeats = Repeat * testMethod?.GetParameters()?.Length ?? 0;
    for (int i = 1; i <= repeats; ++i) {
      IReadOnlyCollection<ITheoryDataRow> values = await base.GetData(testMethod, disposalTracker).ConfigureAwait(false);
      data.AddRange(values);
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

  private async Task<IEnumerable<ITheoryDataRow>> GetBoolDataRows(ParameterInfo[] boolParams, MethodInfo testMethod, DisposalTracker disposalTracker)
  {
    object?[] row = (await base.GetData(testMethod, disposalTracker)).First().GetData();

    List<ITheoryDataRow> dataRows = [];
    for (int i = 0; i < boolParams.Length; i++) {
      SetRowFixed(i);
    }

    dataRows.Add(new TheoryDataRow([.. row]));
    for (int i = 0; i < boolParams.Length; i++) {
      SetRowFixed(i, true);
      dataRows.Add(new TheoryDataRow([.. row]));

      for (int j = 0; j < i; j++) {
        SetRowFixed(j, true);
        dataRows.Add(new TheoryDataRow([.. row]));
      }

      for (int j = 0; j <= i; j++) {
        SetRowFixed(j);
      }
    }

    return dataRows;

    void SetRowFixed(int index, bool value = false)
    {
      ParameterInfo param = boolParams[index];
      row[param.Position] = value;
    }
  }

  private static TheoryDataRow GetFixedDataRow(MethodInfo testMethod)
  {
    AutoDataSource source = new(TestsCustomizations.CreateFixture(true));

    return source.GetData(testMethod)
        .Select(x => new TheoryDataRow(x))
        .First();
  }
}
