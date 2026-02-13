//HintName: test_parent-param-diff+Input_Intf.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public interface ItestPrntParamDiffInp<TA>
  : ItestRefPrntParamDiffInp<TA>
{
  ItestPrntParamDiffInpObject<TA> AsPrntParamDiffInp { get; }
}

public interface ItestPrntParamDiffInpObject<TA>
  : ItestRefPrntParamDiffInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffInp<TB>
{
  TB Asb { get; }
  ItestRefPrntParamDiffInpObject<TB> AsRefPrntParamDiffInp { get; }
}

public interface ItestRefPrntParamDiffInpObject<TB>
{
}
