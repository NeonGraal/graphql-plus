//HintName: test_generic-alt-param+Input_Intf.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
{
  public testRefGnrcAltParamInp<testAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
  public testGnrcAltParamInp GnrcAltParamInp { get; set; }
}

public interface ItestGnrcAltParamInpField
{
}

public interface ItestRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltParamInp RefGnrcAltParamInp { get; set; }
}

public interface ItestRefGnrcAltParamInpField<Tref>
{
}

public interface ItestAltGnrcAltParamInp
{
  public testString AsString { get; set; }
  public testAltGnrcAltParamInp AltGnrcAltParamInp { get; set; }
}

public interface ItestAltGnrcAltParamInpField
{
  public testNumber alt { get; set; }
}
