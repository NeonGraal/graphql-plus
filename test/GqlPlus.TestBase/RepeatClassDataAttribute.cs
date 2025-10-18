﻿using System.Reflection;
using AutoFixture.Xunit3;
using AutoFixture.Xunit3.Internal;
using GqlPlus.AutoFixture;
using Xunit;
using Xunit.Sdk;

namespace GqlPlus;

public sealed class RepeatClassDataAttribute
  : ClassAutoDataAttribute
{
  public RepeatClassDataAttribute(Type sourceType, params object[] parameters)
    : this(Repeats, sourceType, parameters)
  { }

  public RepeatClassDataAttribute(int repeat, Type sourceType, params object[] parameters)
    : base(TestsCustomizations.CreateFixture(), sourceType, parameters)
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

  public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
  {
    List<ITheoryDataRow> data = [];

    TheoryClassDataSource memberSource = new(SourceType, Parameters);
    if (!TestsCustomizations.IsCi) {
      AutoDataSource source = new(TestsCustomizations.CreateFixture(true), memberSource);

      IEnumerable<ITheoryDataRow> row = source.GetData(testMethod)
          .Select(x => new TheoryDataRow(x));
      data.AddRange(row);
    }

    for (int i = 0; i < Repeat; ++i) {
      AutoDataSource source = new(FixtureFactory, memberSource);

      IEnumerable<ITheoryDataRow> values = source.GetData(testMethod)
          .Select(row => new TheoryDataRow(row));
      data.AddRange(values);
    }

    return new ValueTask<IReadOnlyCollection<ITheoryDataRow>>(data.AsReadOnly());
  }
}
