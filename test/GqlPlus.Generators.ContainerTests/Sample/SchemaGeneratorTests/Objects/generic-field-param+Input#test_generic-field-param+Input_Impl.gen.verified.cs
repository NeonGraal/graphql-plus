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

public class testRefGnrcFieldParamInp<TRef>
  : ItestRefGnrcFieldParamInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldParamInpObject<TRef> AsRefGnrcFieldParamInp { get; set; }
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldParamInpObject AsAltGnrcFieldParamInp { get; set; }
}
