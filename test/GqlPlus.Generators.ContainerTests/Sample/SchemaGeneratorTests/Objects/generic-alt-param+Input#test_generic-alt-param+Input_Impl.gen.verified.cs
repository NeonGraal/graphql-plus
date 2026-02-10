//HintName: test_generic-alt-param+Input_Impl.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class testGnrcAltParamInp
  : ItestGnrcAltParamInp
{
  public ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
  public ItestGnrcAltParamInpObject AsGnrcAltParamInp { get; set; }
}

public class testRefGnrcAltParamInp<Tref>
  : ItestRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltParamInpObject AsRefGnrcAltParamInp { get; set; }
}

public class testAltGnrcAltParamInp
  : ItestAltGnrcAltParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltParamInpObject AsAltGnrcAltParamInp { get; set; }
}
