//HintName: test_parent-param-diff+Input_Intf.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public interface ItestPrntParamDiffInp<Ta>
  : ItestRefPrntParamDiffInp
{
  public testPrntParamDiffInp PrntParamDiffInp { get; set; }
}

public interface ItestPrntParamDiffInpField<Ta>
  : ItestRefPrntParamDiffInpField
{
  public Ta field { get; set; }
}

public interface ItestRefPrntParamDiffInp<Tb>
{
  public Tb Asb { get; set; }
  public testRefPrntParamDiffInp RefPrntParamDiffInp { get; set; }
}

public interface ItestRefPrntParamDiffInpField<Tb>
{
}
