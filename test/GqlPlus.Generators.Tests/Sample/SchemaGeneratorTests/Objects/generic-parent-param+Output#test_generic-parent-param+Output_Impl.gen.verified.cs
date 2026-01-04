//HintName: test_generic-parent-param+Output_Impl.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp
  , ItestGnrcPrntParamOutp
{
  public testGnrcPrntParamOutp GnrcPrntParamOutp { get; set; }
}

public class testRefGnrcPrntParamOutp<Tref>
  : ItestRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntParamOutp RefGnrcPrntParamOutp { get; set; }
}

public class testAltGnrcPrntParamOutp
  : ItestAltGnrcPrntParamOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntParamOutp AltGnrcPrntParamOutp { get; set; }
}
