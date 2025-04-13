//HintName: Model_parent-dual+output.gen.cs
// Generated from parent-dual+output.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_output;

public interface IOutpPrntDual
  : IRefOutpPrntDual
{
}
public class OutputOutpPrntDual
  : OutputRefOutpPrntDual
  , IOutpPrntDual
{
}

public interface IRefOutpPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefOutpPrntDual
  : IRefOutpPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
