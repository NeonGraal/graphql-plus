//HintName: Gqlp_generic-alt-param+Output_Impl.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_param_Output;

public class OutputGnrcAltParamOutp
  : IGnrcAltParamOutp
{
  public RefGnrcAltParamOutp<AltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
}

public class OutputRefGnrcAltParamOutp<Tref>
  : IRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class OutputAltGnrcAltParamOutp
  : IAltGnrcAltParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
