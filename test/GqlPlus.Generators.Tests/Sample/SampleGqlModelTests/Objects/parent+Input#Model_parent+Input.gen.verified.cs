﻿//HintName: Model_parent+Input.gen.cs
// Generated from parent+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_Input;

public interface IPrntInp
  : IRefPrntInp
{
}
public class InputPrntInp
  : InputRefPrntInp
  , IPrntInp
{
}

public interface IRefPrntInp
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefPrntInp
  : IRefPrntInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
