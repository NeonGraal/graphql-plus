//HintName: test_parent-param-same+Dual_Intf.gen.cs
// Generated from parent-param-same+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public interface ItestPrntParamSameDual<Ta>
  : ItestRefPrntParamSameDual
{
  ItestPrntParamSameDualObject AsPrntParamSameDual { get; }
}

public interface ItestPrntParamSameDualObject<Ta>
  : ItestRefPrntParamSameDualObject
{
  Ta Field { get; }
}

public interface ItestRefPrntParamSameDual<Ta>
{
  Ta Asa { get; }
  ItestRefPrntParamSameDualObject AsRefPrntParamSameDual { get; }
}

public interface ItestRefPrntParamSameDualObject<Ta>
{
}
