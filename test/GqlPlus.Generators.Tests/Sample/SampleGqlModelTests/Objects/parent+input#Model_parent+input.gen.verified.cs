﻿//HintName: Model_parent+input.gen.cs
// Generated from parent+input.graphql+

/*
*/

namespace GqlTest.Model_parent_input;

public interface IInpPrnt
  : IRefInpPrnt
{
}
public class InputInpPrnt
  : InputRefInpPrnt
  , IInpPrnt
{
}

public interface IRefInpPrnt
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrnt
  : IRefInpPrnt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
