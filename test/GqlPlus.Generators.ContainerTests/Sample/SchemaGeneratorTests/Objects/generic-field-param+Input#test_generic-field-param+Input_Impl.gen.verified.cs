//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from generic-field-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
}

public class testRefGnrcFieldParamInp<TRef>
  : ItestRefGnrcFieldParamInp<TRef>
{
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public decimal Alt { get; set; }
}
