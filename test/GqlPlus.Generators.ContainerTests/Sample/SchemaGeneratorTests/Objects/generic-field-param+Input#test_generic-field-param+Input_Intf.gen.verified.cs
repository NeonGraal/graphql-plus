//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from generic-field-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
{
  public testGnrcFieldParamInp GnrcFieldParamInp { get; set; }
}

public interface ItestGnrcFieldParamInpObject
{
  public testRefGnrcFieldParamInp<testAltGnrcFieldParamInp> field { get; set; }
}

public interface ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldParamInp RefGnrcFieldParamInp { get; set; }
}

public interface ItestRefGnrcFieldParamInpObject<Tref>
{
}

public interface ItestAltGnrcFieldParamInp
{
  public testString AsString { get; set; }
  public testAltGnrcFieldParamInp AltGnrcFieldParamInp { get; set; }
}

public interface ItestAltGnrcFieldParamInpObject
{
  public testNumber alt { get; set; }
}
