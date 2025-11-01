//HintName: test_parent-param-diff+Dual_Intf.gen.cs
// Generated from parent-param-diff+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public interface ItestPrntParamDiffDual<Ta>
  : ItestRefPrntParamDiffDual
{
  public testPrntParamDiffDual PrntParamDiffDual { get; set; }
}

public interface ItestPrntParamDiffDualField<Ta>
  : ItestRefPrntParamDiffDualField
{
  public Ta field { get; set; }
}

public interface ItestRefPrntParamDiffDual<Tb>
{
  public Tb Asb { get; set; }
  public testRefPrntParamDiffDual RefPrntParamDiffDual { get; set; }
}

public interface ItestRefPrntParamDiffDualField<Tb>
{
}
