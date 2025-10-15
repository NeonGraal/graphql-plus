//HintName: test_generic-field-param+Output_Impl.gen.cs
// Generated from generic-field-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public class OutputtestGnrcFieldParamOutp
  : ItestGnrcFieldParamOutp
{
  public RefGnrcFieldParamOutp<AltGnrcFieldParamOutp> field { get; set; }
}

public class OutputtestRefGnrcFieldParamOutp<Tref>
  : ItestRefGnrcFieldParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class OutputtestAltGnrcFieldParamOutp
  : ItestAltGnrcFieldParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
