//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class InputtestGnrcPrntParamPrntInp
  : InputtestRefGnrcPrntParamPrntInp
  , ItestGnrcPrntParamPrntInp
{
}

public class InputtestRefGnrcPrntParamPrntInp<Tref>
  : Inputtestref
  , ItestRefGnrcPrntParamPrntInp<Tref>
{
}

public class InputtestAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
