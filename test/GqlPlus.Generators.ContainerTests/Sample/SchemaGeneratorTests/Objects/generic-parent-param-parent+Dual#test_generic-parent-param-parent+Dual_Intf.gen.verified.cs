//HintName: test_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual
{
  public testGnrcPrntParamPrntDual GnrcPrntParamPrntDual { get; set; }
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject
{
}

public interface ItestRefGnrcPrntParamPrntDual<Tref>
  : Itestref
{
  public testRefGnrcPrntParamPrntDual RefGnrcPrntParamPrntDual { get; set; }
}

public interface ItestRefGnrcPrntParamPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntParamPrntDual
{
  public testString AsString { get; set; }
  public testAltGnrcPrntParamPrntDual AltGnrcPrntParamPrntDual { get; set; }
}

public interface ItestAltGnrcPrntParamPrntDualObject
{
  public testNumber alt { get; set; }
}
