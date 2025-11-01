//HintName: test_parent-param-same+Dual_Intf.gen.cs
// Generated from parent-param-same+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public interface ItestPrntParamSameDual<Ta>
  : ItestRefPrntParamSameDual
{
  public testPrntParamSameDual PrntParamSameDual { get; set; }
}

public interface ItestPrntParamSameDualField<Ta>
  : ItestRefPrntParamSameDualField
{
  public Ta field { get; set; }
}

public interface ItestRefPrntParamSameDual<Ta>
{
  public Ta Asa { get; set; }
  public testRefPrntParamSameDual RefPrntParamSameDual { get; set; }
}

public interface ItestRefPrntParamSameDualField<Ta>
{
}
