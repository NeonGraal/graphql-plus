//HintName: test_generic-alt-param+Output_Impl.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public class OutputtestGnrcAltParamOutp
  : ItestGnrcAltParamOutp
{
  public RefGnrcAltParamOutp<AltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
}

public class OutputtestRefGnrcAltParamOutp<Tref>
  : ItestRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class OutputtestAltGnrcAltParamOutp
  : ItestAltGnrcAltParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
