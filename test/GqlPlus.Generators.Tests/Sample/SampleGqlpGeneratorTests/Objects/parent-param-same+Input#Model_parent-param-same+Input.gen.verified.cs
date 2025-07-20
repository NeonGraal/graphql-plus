//HintName: Model_parent-param-same+Input.gen.cs
// Generated from parent-param-same+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_param_same_Input;

public interface IPrntParamSameInp<Ta>
  : IRefPrntParamSameInp
{
  Ta field { get; }
}
public class InputPrntParamSameInp<Ta>
  : InputRefPrntParamSameInp
  , IPrntParamSameInp<Ta>
{
  public Ta field { get; set; }
}

public interface IRefPrntParamSameInp<Ta>
{
  Ta Asa { get; }
}
public class InputRefPrntParamSameInp<Ta>
  : IRefPrntParamSameInp<Ta>
{
  public Ta Asa { get; set; }
}
