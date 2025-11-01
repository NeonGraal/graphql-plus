//HintName: test_generic-parent-param+Input_Intf.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp
{
  public testGnrcPrntParamInp GnrcPrntParamInp { get; set; }
}

public interface ItestGnrcPrntParamInpField
  : ItestRefGnrcPrntParamInpField
{
}

public interface ItestRefGnrcPrntParamInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntParamInp RefGnrcPrntParamInp { get; set; }
}

public interface ItestRefGnrcPrntParamInpField<Tref>
{
}

public interface ItestAltGnrcPrntParamInp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntParamInp AltGnrcPrntParamInp { get; set; }
}

public interface ItestAltGnrcPrntParamInpField
{
  public testNumber alt { get; set; }
}
