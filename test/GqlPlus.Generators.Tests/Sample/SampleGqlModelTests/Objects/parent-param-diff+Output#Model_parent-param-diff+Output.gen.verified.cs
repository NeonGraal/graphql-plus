//HintName: Model_parent-param-diff+Output.gen.cs
// Generated from parent-param-diff+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_Output;

public interface IPrntParamDiffOutp<Ta>
  : IRefPrntParamDiffOutp
{
  Ta field { get; }
}
public class OutputPrntParamDiffOutp<Ta>
  : OutputRefPrntParamDiffOutp
  , IPrntParamDiffOutp<Ta>
{
  public Ta field { get; set; }
}

public interface IRefPrntParamDiffOutp<Tb>
{
  Tb Asb { get; }
}
public class OutputRefPrntParamDiffOutp<Tb>
  : IRefPrntParamDiffOutp<Tb>
{
  public Tb Asb { get; set; }
}
