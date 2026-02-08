//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from generic-field-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
  public ItestGnrcFieldParamInpObject AsGnrcFieldParamInp { get; set; }
}

public class testRefGnrcFieldParamInp<Tref>
  : ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldParamInpObject AsRefGnrcFieldParamInp { get; set; }
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldParamInpObject AsAltGnrcFieldParamInp { get; set; }
}
