//HintName: Gqlp_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_parent_Output;

public class OutputGnrcPrntParamPrntOutp
  : OutputRefGnrcPrntParamPrntOutp
  , IGnrcPrntParamPrntOutp
{
}

public class OutputRefGnrcPrntParamPrntOutp<Tref>
  : Outputref
  , IRefGnrcPrntParamPrntOutp<Tref>
{
}

public class OutputAltGnrcPrntParamPrntOutp
  : IAltGnrcPrntParamPrntOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
