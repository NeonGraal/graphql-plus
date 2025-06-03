//HintName: Model_parent-dual+Output.gen.cs
// Generated from parent-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_Output;

public interface IPrntDualOutp
  : IRefPrntDualOutp
{
}
public class OutputPrntDualOutp
  : OutputRefPrntDualOutp
  , IPrntDualOutp
{
}

public interface IRefPrntDualOutp
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntDualOutp
  : IRefPrntDualOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
