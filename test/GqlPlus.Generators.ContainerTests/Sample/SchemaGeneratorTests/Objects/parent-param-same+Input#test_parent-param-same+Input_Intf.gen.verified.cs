//HintName: test_parent-param-same+Input_Intf.gen.cs
// Generated from parent-param-same+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public interface ItestPrntParamSameInp<Ta>
  : ItestRefPrntParamSameInp
{
}

public interface ItestPrntParamSameInpObject<Ta>
  : ItestRefPrntParamSameInpObject
{
  public Ta Field { get; set; }
}

public interface ItestRefPrntParamSameInp<Ta>
{
  public Ta Asa { get; set; }
}

public interface ItestRefPrntParamSameInpObject<Ta>
{
}
