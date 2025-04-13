//HintName: Model_parent-dual+input.gen.cs
// Generated from parent-dual+input.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_input;

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
