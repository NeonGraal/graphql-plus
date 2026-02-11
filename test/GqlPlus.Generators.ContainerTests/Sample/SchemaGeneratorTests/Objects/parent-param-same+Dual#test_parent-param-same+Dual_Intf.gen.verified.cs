//HintName: test_parent-param-same+Dual_Intf.gen.cs
// Generated from parent-param-same+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public interface ItestPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
  ItestPrntParamSameDualObject AsPrntParamSameDual { get; }
}

public interface ItestPrntParamSameDualObject<TA>
  : ItestRefPrntParamSameDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameDual<TA>
{
  TA Asa { get; }
  ItestRefPrntParamSameDualObject AsRefPrntParamSameDual { get; }
}

public interface ItestRefPrntParamSameDualObject<TA>
{
}
