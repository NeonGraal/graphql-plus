//HintName: Gqlp_generic-parent-param+Output_Impl.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_Output;
public class OutputGnrcPrntParamOutp
  : OutputRefGnrcPrntParamOutp
  , IGnrcPrntParamOutp
{
}
public class OutputRefGnrcPrntParamOutp<Tref>
  : IRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
}
public class OutputAltGnrcPrntParamOutp
  : IAltGnrcPrntParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
