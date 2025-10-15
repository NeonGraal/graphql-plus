//HintName: test_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class OutputtestGnrcPrntParamPrntOutp
  : OutputtestRefGnrcPrntParamPrntOutp
  , ItestGnrcPrntParamPrntOutp
{
}

public class OutputtestRefGnrcPrntParamPrntOutp<Tref>
  : Outputtestref
  , ItestRefGnrcPrntParamPrntOutp<Tref>
{
}

public class OutputtestAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
