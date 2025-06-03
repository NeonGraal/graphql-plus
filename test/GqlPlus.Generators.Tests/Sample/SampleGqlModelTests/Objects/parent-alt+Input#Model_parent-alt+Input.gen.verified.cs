//HintName: Model_parent-alt+Input.gen.cs
// Generated from parent-alt+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_Input;

public interface IInpPrntAlt
  : IRefInpPrntAlt
{
  Number AsNumber { get; }
}
public class InputInpPrntAlt
  : InputRefInpPrntAlt
  , IInpPrntAlt
{
  public Number AsNumber { get; set; }
}

public interface IRefInpPrntAlt
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrntAlt
  : IRefInpPrntAlt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
