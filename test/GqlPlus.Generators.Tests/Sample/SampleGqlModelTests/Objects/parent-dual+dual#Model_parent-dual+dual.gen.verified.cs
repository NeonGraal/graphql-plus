﻿//HintName: Model_parent-dual+dual.gen.cs
// Generated from parent-dual+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_dual;

public interface IDualPrntDual
  : IRefDualPrntDual
{
}
public class DualDualPrntDual
  : DualRefDualPrntDual
  , IDualPrntDual
{
}

public interface IRefDualPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntDual
  : IRefDualPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
