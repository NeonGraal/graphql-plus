//HintName: Model_parent-field+input.gen.cs
// Generated from parent-field+input.graphql+

/*
*/

namespace GqlTest.Model_parent_field_input;

public interface IInpPrntField
{
  Number field { get; }
}
public class InputInpPrntField
{
  public Number field { get; set; }
}

public interface IRefInpPrntField
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrntField
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
