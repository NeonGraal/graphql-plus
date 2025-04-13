//HintName: Model_parent-alt+input.gen.cs
// Generated from parent-alt+input.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_input;

public interface IInpPrntAlt
{
  Number AsNumber { get; }
}
public class InputInpPrntAlt
{
  public Number AsNumber { get; set; }
}

public interface IRefInpPrntAlt
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrntAlt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
