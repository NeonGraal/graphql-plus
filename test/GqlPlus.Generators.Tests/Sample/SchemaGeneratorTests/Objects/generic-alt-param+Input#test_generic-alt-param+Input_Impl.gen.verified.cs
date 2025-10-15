//HintName: test_generic-alt-param+Input_Impl.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class InputtestGnrcAltParamInp
  : ItestGnrcAltParamInp
{
  public RefGnrcAltParamInp<AltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
}

public class InputtestRefGnrcAltParamInp<Tref>
  : ItestRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public class InputtestAltGnrcAltParamInp
  : ItestAltGnrcAltParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
