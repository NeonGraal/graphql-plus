//HintName: Model_parent-dual+Output.gen.cs
// Generated from parent-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_Output;

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
