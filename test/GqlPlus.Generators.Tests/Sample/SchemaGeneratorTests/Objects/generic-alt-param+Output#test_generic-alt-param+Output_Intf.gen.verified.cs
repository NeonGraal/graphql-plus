//HintName: test_generic-alt-param+Output_Intf.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
{
  public testRefGnrcAltParamOutp<testAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
  public testGnrcAltParamOutp GnrcAltParamOutp { get; set; }
}

public interface ItestGnrcAltParamOutpField
{
}

public interface ItestRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltParamOutp RefGnrcAltParamOutp { get; set; }
}

public interface ItestRefGnrcAltParamOutpField<Tref>
{
}

public interface ItestAltGnrcAltParamOutp
{
  public testString AsString { get; set; }
  public testAltGnrcAltParamOutp AltGnrcAltParamOutp { get; set; }
}

public interface ItestAltGnrcAltParamOutpField
{
  public testNumber alt { get; set; }
}
