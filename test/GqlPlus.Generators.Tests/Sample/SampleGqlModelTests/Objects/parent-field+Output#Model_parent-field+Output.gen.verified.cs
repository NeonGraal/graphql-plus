﻿//HintName: Model_parent-field+Output.gen.cs
// Generated from parent-field+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_field_Output;

public interface IOutpPrntField
  : IRefOutpPrntField
{
  Number field { get; }
}
public class OutputOutpPrntField
  : OutputRefOutpPrntField
  , IOutpPrntField
{
  public Number field { get; set; }
}

public interface IRefOutpPrntField
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefOutpPrntField
  : IRefOutpPrntField
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
