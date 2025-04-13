//HintName: Model_parent-param-diff+output.gen.cs
// Generated from parent-param-diff+output.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_output;

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
