//HintName: Gqlp_generic-field-param+Output_Impl.gen.cs
// Generated from generic-field-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_param_Output;
public class OutputGnrcFieldParamOutp
  : IGnrcFieldParamOutp
{
  public RefGnrcFieldParamOutp<AltGnrcFieldParamOutp> field { get; set; }
}
public class OutputRefGnrcFieldParamOutp<Tref>
  : IRefGnrcFieldParamOutp<Tref>
{
  public Tref Asref { get; set; }
}
public class OutputAltGnrcFieldParamOutp
  : IAltGnrcFieldParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
