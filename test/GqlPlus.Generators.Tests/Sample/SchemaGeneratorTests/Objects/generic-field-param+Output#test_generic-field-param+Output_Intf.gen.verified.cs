//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from generic-field-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
{
  public testGnrcFieldParamOutp GnrcFieldParamOutp { get; set; }
}

public interface ItestGnrcFieldParamOutpField
{
  public testRefGnrcFieldParamOutp<testAltGnrcFieldParamOutp> field { get; set; }
}

public interface ItestRefGnrcFieldParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldParamOutp RefGnrcFieldParamOutp { get; set; }
}

public interface ItestRefGnrcFieldParamOutpField<Tref>
{
}

public interface ItestAltGnrcFieldParamOutp
{
  public testString AsString { get; set; }
  public testAltGnrcFieldParamOutp AltGnrcFieldParamOutp { get; set; }
}

public interface ItestAltGnrcFieldParamOutpField
{
  public testNumber alt { get; set; }
}
