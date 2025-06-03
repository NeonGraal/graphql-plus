//HintName: Model_parent-field+Input.gen.cs
// Generated from parent-field+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_field_Input;

public interface IInpPrntField
  : IRefInpPrntField
{
  Number field { get; }
}
public class InputInpPrntField
  : InputRefInpPrntField
  , IInpPrntField
{
  public Number field { get; set; }
}

public interface IRefInpPrntField
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrntField
  : IRefInpPrntField
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
