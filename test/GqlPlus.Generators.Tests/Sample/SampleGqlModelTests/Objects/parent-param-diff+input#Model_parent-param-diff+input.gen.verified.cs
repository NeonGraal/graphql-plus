//HintName: Model_parent-param-diff+input.gen.cs
// Generated from parent-param-diff+input.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_input;

public interface IInpPrntParamDiff<Ta>
  : IRefInpPrntParamDiff
{
  Ta field { get; }
}
public class InputInpPrntParamDiff<Ta>
  : InputRefInpPrntParamDiff
  , IInpPrntParamDiff<Ta>
{
  public Ta field { get; set; }
}

public interface IRefInpPrntParamDiff<Tb>
{
  Tb Asb { get; }
}
public class InputRefInpPrntParamDiff<Tb>
  : IRefInpPrntParamDiff<Tb>
{
  public Tb Asb { get; set; }
}
