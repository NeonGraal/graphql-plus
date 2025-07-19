//HintName: Model_parent-param-diff+Input.gen.cs
// Generated from parent-param-diff+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_Input;

public interface IPrntParamDiffInp<Ta>
  : IRefPrntParamDiffInp
{
  Ta field { get; }
}
public class InputPrntParamDiffInp<Ta>
  : InputRefPrntParamDiffInp
  , IPrntParamDiffInp<Ta>
{
  public Ta field { get; set; }
}

public interface IRefPrntParamDiffInp<Tb>
{
  Tb Asb { get; }
}
public class InputRefPrntParamDiffInp<Tb>
  : IRefPrntParamDiffInp<Tb>
{
  public Tb Asb { get; set; }
}
