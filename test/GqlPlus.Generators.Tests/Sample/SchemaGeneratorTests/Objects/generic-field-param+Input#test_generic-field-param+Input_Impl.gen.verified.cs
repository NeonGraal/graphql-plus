//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from generic-field-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class InputtestGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; set; }
}

public class InputtestRefGnrcFieldParamInp<Tref>
  : ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public class InputtestAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
