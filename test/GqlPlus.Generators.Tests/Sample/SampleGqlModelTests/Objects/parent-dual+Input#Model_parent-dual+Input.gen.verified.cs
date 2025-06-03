//HintName: Model_parent-dual+Input.gen.cs
// Generated from parent-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_Input;

public interface IInpPrntDual
  : IRefInpPrntDual
{
}
public class InputInpPrntDual
  : InputRefInpPrntDual
  , IInpPrntDual
{
}

public interface IRefInpPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefInpPrntDual
  : IRefInpPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
