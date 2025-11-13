//HintName: test_generic-parent-param+Dual_Impl.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public class testGnrcPrntParamDual
  : testRefGnrcPrntParamDual
  , ItestGnrcPrntParamDual
{
  public testGnrcPrntParamDual GnrcPrntParamDual { get; set; }
}

public class testRefGnrcPrntParamDual<Tref>
  : ItestRefGnrcPrntParamDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntParamDual RefGnrcPrntParamDual { get; set; }
}

public class testAltGnrcPrntParamDual
  : ItestAltGnrcPrntParamDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntParamDual AltGnrcPrntParamDual { get; set; }
}
