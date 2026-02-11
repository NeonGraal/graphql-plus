//HintName: test_parent-param-diff+Dual_Intf.gen.cs
// Generated from parent-param-diff+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public interface ItestPrntParamDiffDual<TA>
  : ItestRefPrntParamDiffDual<TA>
{
  ItestPrntParamDiffDualObject AsPrntParamDiffDual { get; }
}

public interface ItestPrntParamDiffDualObject<TA>
  : ItestRefPrntParamDiffDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffDual<TB>
{
  TB Asb { get; }
  ItestRefPrntParamDiffDualObject AsRefPrntParamDiffDual { get; }
}

public interface ItestRefPrntParamDiffDualObject<TB>
{
}
