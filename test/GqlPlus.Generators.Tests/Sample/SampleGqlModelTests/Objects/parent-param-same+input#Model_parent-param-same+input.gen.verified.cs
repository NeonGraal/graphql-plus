//HintName: Model_parent-param-same+input.gen.cs
// Generated from parent-param-same+input.graphql+

/*
*/

namespace GqlTest.Model_parent_param_same_input;

public interface IInpPrntParamSame<Ta>
  : IRefInpPrntParamSame
{
  Ta field { get; }
}
public class InputInpPrntParamSame<Ta>
  : InputRefInpPrntParamSame
  , IInpPrntParamSame<Ta>
{
  public Ta field { get; set; }
}

public interface IRefInpPrntParamSame<Ta>
{
  Ta Asa { get; }
}
public class InputRefInpPrntParamSame<Ta>
  : IRefInpPrntParamSame<Ta>
{
  public Ta Asa { get; set; }
}
