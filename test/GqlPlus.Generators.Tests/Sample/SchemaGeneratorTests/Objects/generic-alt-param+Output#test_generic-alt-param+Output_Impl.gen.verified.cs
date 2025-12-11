//HintName: test_generic-alt-param+Output_Impl.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public class testGnrcAltParamOutp
  : ItestGnrcAltParamOutp
{
  public testRefGnrcAltParamOutp<testAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
  public testGnrcAltParamOutp GnrcAltParamOutp { get; set; }
}

public class testRefGnrcAltParamOutp<Tref>
  : ItestRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltParamOutp RefGnrcAltParamOutp { get; set; }
}

public class testAltGnrcAltParamOutp
  : ItestAltGnrcAltParamOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcAltParamOutp AltGnrcAltParamOutp { get; set; }
}
