//HintName: test_generic-parent-param+Dual_Intf.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual
{
  public testGnrcPrntParamDual GnrcPrntParamDual { get; set; }
}

public interface ItestGnrcPrntParamDualObject
  : ItestRefGnrcPrntParamDualObject
{
}

public interface ItestRefGnrcPrntParamDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntParamDual RefGnrcPrntParamDual { get; set; }
}

public interface ItestRefGnrcPrntParamDualObject<Tref>
{
}

public interface ItestAltGnrcPrntParamDual
{
  public testString AsString { get; set; }
  public testAltGnrcPrntParamDual AltGnrcPrntParamDual { get; set; }
}

public interface ItestAltGnrcPrntParamDualObject
{
  public testNumber alt { get; set; }
}
