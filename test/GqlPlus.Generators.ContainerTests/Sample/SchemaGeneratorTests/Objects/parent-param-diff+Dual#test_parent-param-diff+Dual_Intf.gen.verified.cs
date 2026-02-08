//HintName: test_parent-param-diff+Dual_Intf.gen.cs
// Generated from parent-param-diff+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public interface ItestPrntParamDiffDual<Ta>
  : ItestRefPrntParamDiffDual
{
  public ItestPrntParamDiffDualObject AsPrntParamDiffDual { get; set; }
}

public interface ItestPrntParamDiffDualObject<Ta>
  : ItestRefPrntParamDiffDualObject
{
  public Ta Field { get; set; }
}

public interface ItestRefPrntParamDiffDual<Tb>
{
  public Tb Asb { get; set; }
  public ItestRefPrntParamDiffDualObject AsRefPrntParamDiffDual { get; set; }
}

public interface ItestRefPrntParamDiffDualObject<Tb>
{
}
