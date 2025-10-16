//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from generic-field-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; set; }
}

public class testRefGnrcFieldParamInp<Tref>
  : ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
