//HintName: Model_parent-alt+input.gen.cs
// Generated from parent-alt+input.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_input;

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
