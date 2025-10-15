//HintName: test_generic-parent-param+Input_Impl.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public class InputtestGnrcPrntParamInp
  : InputtestRefGnrcPrntParamInp
  , ItestGnrcPrntParamInp
{
}

public class InputtestRefGnrcPrntParamInp<Tref>
  : ItestRefGnrcPrntParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public class InputtestAltGnrcPrntParamInp
  : ItestAltGnrcPrntParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
