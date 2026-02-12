//HintName: test_parent-param-same+Input_Intf.gen.cs
// Generated from parent-param-same+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public interface ItestPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
  ItestPrntParamSameInpObject<TA> AsPrntParamSameInp { get; }
}

public interface ItestPrntParamSameInpObject<TA>
  : ItestRefPrntParamSameInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameInp<TA>
{
  TA Asa { get; }
  ItestRefPrntParamSameInpObject<TA> AsRefPrntParamSameInp { get; }
}

public interface ItestRefPrntParamSameInpObject<TA>
{
}
