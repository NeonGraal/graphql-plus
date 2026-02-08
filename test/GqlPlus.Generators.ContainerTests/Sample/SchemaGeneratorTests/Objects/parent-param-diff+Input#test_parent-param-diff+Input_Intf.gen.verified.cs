//HintName: test_parent-param-diff+Input_Intf.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public interface ItestPrntParamDiffInp<Ta>
  : ItestRefPrntParamDiffInp
{
  public ItestPrntParamDiffInpObject AsPrntParamDiffInp { get; set; }
}

public interface ItestPrntParamDiffInpObject<Ta>
  : ItestRefPrntParamDiffInpObject
{
  public Ta Field { get; set; }
}

public interface ItestRefPrntParamDiffInp<Tb>
{
  public Tb Asb { get; set; }
  public ItestRefPrntParamDiffInpObject AsRefPrntParamDiffInp { get; set; }
}

public interface ItestRefPrntParamDiffInpObject<Tb>
{
}
