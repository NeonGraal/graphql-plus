﻿//HintName: Model_generic-dual+Output.gen.cs
// Generated from generic-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_Output;

public interface IOutpGnrcDual
{
  OutpGnrcDualRef<OutpGnrcDualAlt> field { get; }
}
public class OutputOutpGnrcDual
  : IOutpGnrcDual
{
  public OutpGnrcDualRef<OutpGnrcDualAlt> field { get; set; }
}

public interface IOutpGnrcDualRef<Tref>
{
  Tref Asref { get; }
}
public class OutputOutpGnrcDualRef<Tref>
  : IOutpGnrcDualRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IOutpGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualOutpGnrcDualAlt
  : IOutpGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
