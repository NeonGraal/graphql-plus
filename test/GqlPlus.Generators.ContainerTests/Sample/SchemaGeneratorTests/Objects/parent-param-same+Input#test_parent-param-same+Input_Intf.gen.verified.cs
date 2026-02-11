//HintName: test_parent-param-same+Input_Intf.gen.cs
// Generated from parent-param-same+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public interface ItestPrntParamSameInp<Ta>
  : ItestRefPrntParamSameInp
{
  ItestPrntParamSameInpObject AsPrntParamSameInp { get; }
}

public interface ItestPrntParamSameInpObject<Ta>
  : ItestRefPrntParamSameInpObject
{
  Ta Field { get; }
}

public interface ItestRefPrntParamSameInp<Ta>
{
  Ta Asa { get; }
  ItestRefPrntParamSameInpObject AsRefPrntParamSameInp { get; }
}

public interface ItestRefPrntParamSameInpObject<Ta>
{
}
