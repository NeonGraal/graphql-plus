﻿//HintName: Model_parent-alt+Dual.gen.cs
// Generated from parent-alt+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_Dual;

public interface IDualPrntAlt
  : IRefDualPrntAlt
{
  Number AsNumber { get; }
}
public class DualDualPrntAlt
  : DualRefDualPrntAlt
  , IDualPrntAlt
{
  public Number AsNumber { get; set; }
}

public interface IRefDualPrntAlt
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntAlt
  : IRefDualPrntAlt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
