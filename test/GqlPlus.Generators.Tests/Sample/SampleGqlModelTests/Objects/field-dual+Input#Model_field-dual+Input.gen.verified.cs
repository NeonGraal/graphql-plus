﻿//HintName: Model_field-dual+Input.gen.cs
// Generated from field-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_field_dual_Input;

public interface IInpFieldDual
{
  FldInpFieldDual field { get; }
}
public class InputInpFieldDual
  : IInpFieldDual
{
  public FldInpFieldDual field { get; set; }
}

public interface IFldInpFieldDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldInpFieldDual
  : IFldInpFieldDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
