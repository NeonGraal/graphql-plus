//HintName: Model_parent-param-diff+Output.gen.cs
// Generated from parent-param-diff+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_Output;

public interface IOutpPrntParamDiff<Ta>
  : IRefOutpPrntParamDiff
{
  Ta field { get; }
}
public class OutputOutpPrntParamDiff<Ta>
  : OutputRefOutpPrntParamDiff
  , IOutpPrntParamDiff<Ta>
{
  public Ta field { get; set; }
}

public interface IRefOutpPrntParamDiff<Tb>
{
  Tb Asb { get; }
}
public class OutputRefOutpPrntParamDiff<Tb>
  : IRefOutpPrntParamDiff<Tb>
{
  public Tb Asb { get; set; }
}
